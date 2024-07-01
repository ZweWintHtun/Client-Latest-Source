//----------------------------------------------------------------------
// <copyright file="TLMSVE00006.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Su Su Wai</CreatedUser>
// <CreatedDate>01/08/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Admin.DataModel;
using System.Linq;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Tel.Sve
{
    /// <summary>
    /// Entry -> Clearing -> Delivered Entry & Entry -> Clearing -> Receipt Entry Service
    /// </summary>
    public class TLMSVE00006 : BaseService, ITLMSVE00006
    {
        #region DAO Properties
        public ICXSVE00002 CodeGenerator { get; set; }
        public ICXSVE00006 CodeChecker { get; set; }
        public IPFMDAO00054 TLFDAO { get; set; }
        public IPFMDAO00028 CledgerDAO { get; set; }
        public IPFMDAO00056 Sys001DAO { get; set; }
        public IPFMDAO00020 UCheckDAO { get; set; }
        #endregion

        #region DTO Properties
        private string ACode { get; set; }
        private DateTime SettlementDate { get; set; }
        private decimal Rate { get; set; }
        private string Channel { get; set; }
        private TLMDTO00005 TransactionTypeDTO { get; set; }
        #endregion

        #region Main Method

        [Transaction(TransactionPropagation.Required)]
        public string Save(TLMDTO00053 entity)
        {
            string paymentSlipNo = string.Empty;
            if (entity.IsDomesticAccountType)
                this.ACode = entity.AccountNo;
            else
            {
                if (entity.AccountSign.StartsWith("C"))
                {
                    this.ACode = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurControl), entity.CurrencyCode, entity.SourceBranchCode, true });
                }
                else if (entity.AccountSign.StartsWith("S") /*&& (entity.TransactionStatus == "Clearing.Receipt")*/)
                {
                    this.ACode = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavControl), entity.CurrencyCode, entity.SourceBranchCode, true });
                }
                if (string.IsNullOrEmpty(this.ACode))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; // Client Data Not Found.
                    return null;
                }
            }
            this.SettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), entity.SourceBranchCode,true });
            if (this.SettlementDate == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME00021; // Client Data Not Found.
                return null;
            }
            this.Rate = CXCOM00010.Instance.GetExchangeRate(entity.CurrencyCode, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType));
            if (this.Rate == 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MI00013; //No Rate For this Currency.
                return null;
            }
            this.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);

            if (entity.TransactionStatus == "Clearing.Receipt")
            {
                this.TransactionTypeDTO = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ClearingDebitReceipt) });
                if (TransactionTypeDTO == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not Found.
                    return null;
                }
               
                paymentSlipNo = this.SaveReceipt(this.GetReceiptTLF(entity),this.GetUCheckEntity(entity), entity.IsLinkTransaction, entity.IsDomesticAccountType);
                if (String.IsNullOrEmpty(paymentSlipNo))
                    return null;
            }
            else if (entity.TransactionStatus == "Clearing.Delivered")
            {
                this.TransactionTypeDTO = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ClearingCreditDeliver) });
                if (TransactionTypeDTO == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not Found.
                    return null;
                }              
                paymentSlipNo = this.SaveDelivered(this.GetDeliveredTLF(entity));
            }
            this.ServiceResult.ErrorOccurred = false;
            return paymentSlipNo;

        }
        
        public PFMDTO00001 GetCustomerByAccountNumber(string accountNo, string transactionStatus)
        {
            // Check saving & current account no is already closed or not.
            if (this.CodeChecker.IsClosedAccountForCLedger(accountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return null;
            }
            // Check Freeze Account No
            else if (this.CodeChecker.IsFreezeAccount(accountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return null;
            }
            else
            {
                PFMDTO00001 customerInformation = new PFMDTO00001();
                IList<PFMDTO00017> currentAccountList = this.CodeChecker.GetCAOFsByAccountNumber(accountNo);
                if (currentAccountList.Count > 0)
                {
                    var customerId = (from value in currentAccountList
                                      where value.CustomerID != null
                                      select value.CustomerID).ToList();

                    customerInformation = this.CodeChecker.GetCustomerByCustomerId(customerId[0]);
                    customerInformation.AccountSign = currentAccountList[0].AccountSign;
                    customerInformation.CurrencyCode = currentAccountList[0].CurrencyCode;
                }
                else if (transactionStatus == "Clearing.Delivered")
                {
                    IList<PFMDTO00016> savingAccountList = this.CodeChecker.GetSAOFsByAccountNumber(accountNo);
                    if (savingAccountList.Count > 0)
                    {
                        var customerId = (from value in savingAccountList
                                          where value.Customer_Id != null
                                          select value.Customer_Id).ToList();

                        customerInformation = this.CodeChecker.GetCustomerByCustomerId(customerId[0]);
                        customerInformation.AccountSign = savingAccountList[0].AccountSign;
                        customerInformation.CurrencyCode = savingAccountList[0].CurrencyCode;
                    }
                }
                else
                {
                    this.ServiceResult.ErrorOccurred = true; //MV00197 - Invalid Current, Saving and Chart of Account. MV00198 - Invalid Current and Chart of Account.
                    this.ServiceResult.MessageCode = (transactionStatus == "Clearing.Delivered") ? CXMessage.MV00197 : CXMessage.MV00198;
                    return null;
                }
                return customerInformation;
            }
        }
        #endregion

        #region Helper Methods
    
        /// <summary>
        /// To check Account has link account or not.
        /// </summary>
        /// <param name="receiptEntity"></param>
        /// <returns>Return CheckAmount return value DTO</returns>
        public CXDTO00009 DebitInformationChecking(TLMDTO00053 receiptEntity)
        {
            string messageNo = string.Empty;
            bool isLink = false ;

            //Check Amount
            if (!this.CodeChecker.CheckAmount(receiptEntity.AccountNo, receiptEntity.Amount, true, receiptEntity.IsVIP, true, ref isLink, ref messageNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = messageNo;
                return new CXDTO00009(messageNo,isLink);
            }
            return new CXDTO00009(messageNo, isLink);
        }

        [Transaction(TransactionPropagation.Required)]
        private string SaveDelivered(PFMORM00054 tlf)
        {
            //string payInSlipNo = this.CodeGenerator.GetGenerateCode("DeliverPayInSlip", string.Empty, tlf.CreatedUserId, CurrentUserEntity.BranchCode, new object[] { this.SettlementDate.Day.ToString().PadLeft(2, '0'), this.SettlementDate.Month.ToString().PadLeft(2, '0'), this.SettlementDate.Year.ToString().Substring(2) });
            string payInSlipNo = this.CodeGenerator.GetGenerateCode("DeliverPayInSlip", string.Empty, tlf.CreatedUserId, tlf.SourceBranchCode, new object[] { this.SettlementDate.Day.ToString().PadLeft(2, '0'), this.SettlementDate.Month.ToString().PadLeft(2, '0'), this.SettlementDate.Year.ToString().Substring(2) });
            tlf.Eno = payInSlipNo;
            this.TLFDAO.Save(tlf);
            return payInSlipNo;
        }

         [Transaction(TransactionPropagation.Required)]
        private string SaveReceipt(PFMORM00054 tlf, PFMORM00020 ucheck, bool isAutoLinkProcessing, bool isDemesticAccountType)
        {
            //string payInSlipNo = this.CodeGenerator.GetGenerateCode("PO.Receipt.Code", string.Empty, tlf.CreatedUserId, CurrentUserEntity.BranchCode, new object[] { this.SettlementDate.Day.ToString().PadLeft(2, '0'), this.SettlementDate.Month.ToString().PadLeft(2, '0'), this.SettlementDate.Year.ToString().Substring(2) });
            string payInSlipNo = this.CodeGenerator.GetGenerateCode("PO.Receipt.Code", string.Empty, tlf.CreatedUserId, tlf.SourceBranchCode, new object[] { this.SettlementDate.Day.ToString().PadLeft(2, '0'), this.SettlementDate.Month.ToString().PadLeft(2, '0'), this.SettlementDate.Year.ToString().Substring(2) });
            tlf.Id = this.TLFDAO.SelectMaxId() + 1;
            tlf.Eno = payInSlipNo;
            if (isAutoLinkProcessing)
            {
                CXServiceWrapper.Instance.Invoke<ICXSVE00010, bool>(x => x.AllUpdateForClearing(tlf, true));
                if (CXServiceWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXServiceWrapper.Instance.ServiceResult.MessageCode;
                    throw new Exception(this.ServiceResult.MessageCode);
                    //return string.Empty;
                }
            }
            else
            {               
                if (!isDemesticAccountType)
                {
                    PFMDTO00028 cledger = CXServiceWrapper.Instance.Invoke<ICXSVE00006, PFMDTO00028>(x => x.GetAccountInfoOfCledgerByAccountNo(tlf.AccountNo));
                    if (cledger.OverdraftLimit > 0 || cledger.TemporaryOverdraftLimit > 0)
                    {
                        if (Sys001DAO.UpdateStatusByName(tlf.CreatedUserId, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.OverdrafIntrestCal), "N", tlf.CreatedDate) == false)
                        {
                            // Update Error
                            throw new Exception(CXMessage.ME90001);
                        }

                    }
                    else if (cledger.LoansCount > 0)
                    {
                        if (Sys001DAO.UpdateStatusByName(tlf.CreatedUserId, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ServiceChargesCal), "N", tlf.CreatedDate) == false)
                        {
                            // Update Error
                            throw new Exception(CXMessage.ME90001);
                        }
                    }
                    decimal currentBalance = cledger.CurrentBal - tlf.Amount;
                    if (this.CledgerDAO.UpdateCurrentBalance(tlf.AccountNo, currentBalance, ++cledger.TransactionCount, tlf.CreatedUserId,tlf.CreatedUserId.ToString()) == false)
                    {
                        // Update Error
                        throw new Exception(CXMessage.ME90001);
                    }
                    this.UCheckDAO.Save(ucheck);
                }
                this.TLFDAO.Save(tlf);
            }
            return payInSlipNo;
        }
        #endregion

        #region Convert DTO to ORM
        private PFMORM00054 GetDeliveredTLF(TLMDTO00053 entity)
        {
            PFMORM00054 tlf = new PFMORM00054();
            tlf.Id= this.TLFDAO.SelectMaxId() + 1;
            tlf.AccountNo = entity.AccountNo;
            tlf.Description = entity.AccountName;
            tlf.Amount = entity.Amount;
            tlf.Acode = this.ACode;
            tlf.HomeAmount = entity.Amount * this.Rate;
            tlf.HomeAmt = entity.Amount * this.Rate;
            tlf.HomeOAmt = 0;
            tlf.LocalAmount = entity.Amount;
            tlf.LocalAmt = entity.Amount;
            tlf.LocalOAmt = 0;
            tlf.OtherBankChq = entity.ChequeNo;
            tlf.DateTime = DateTime.Now;
            tlf.TransactionCode = this.TransactionTypeDTO.TransactionCode;
            tlf.Status = this.TransactionTypeDTO.Status;
            if (entity.IsDomesticAccountType)
            {
                tlf.CLRPostStatus = "Y";//Wrong
                tlf.Narration = "Clearing Deliver with " + entity.AccountNo;
            }
            else
            {
                tlf.AccountSign = entity.AccountSign;
                tlf.Narration = "Clearing Deliver " + entity.ChequeNo;
            }

            tlf.UserNo = entity.CreatedUserId.ToString();
            tlf.OtherBank = entity.OtherBank;
            tlf.DeliverReturn = false;
            tlf.SourceCurrency = entity.CurrencyCode;
            tlf.CurrencyCode = entity.CurrencyCode;
            tlf.SourceBranchCode = entity.SourceBranchCode;
            tlf.SettlementDate = this.SettlementDate;
            tlf.Channel = this.Channel;
            tlf.Rate = this.Rate;
            tlf.Active = true;
            tlf.CreatedUserId = entity.CreatedUserId;
            tlf.CreatedDate = DateTime.Now;
            return tlf;
        }

        private PFMORM00054 GetReceiptTLF(TLMDTO00053 entity)
        {
            PFMORM00054 tlf = new PFMORM00054();
            tlf.Id = this.TLFDAO.SelectMaxId() + 1;
            tlf.AccountNo = entity.AccountNo;
            tlf.Amount = entity.Amount;
            tlf.Cheque = entity.ChequeNo;
            tlf.OtherBank = entity.OtherBank;
            tlf.UserNo = entity.CreatedUserId.ToString();           
            tlf.SourceBranchCode = entity.SourceBranchCode;
            tlf.Rate = this.Rate;
            tlf.SettlementDate = this.SettlementDate;
            tlf.Channel = this.Channel;          
            tlf.CreatedUserId = entity.CreatedUserId;
            tlf.CreatedDate = entity.CreatedDate;
            if (entity.IsLinkTransaction)
            {
                tlf.LocalOAmt = 0;
                CurrencyDTO curdto = CXCOM00011.Instance.GetScalarObject<CurrencyDTO>("Cur.HomeCur.Select", new object[] { true });
                tlf.SourceCurrency = curdto.Cur;
                tlf.CurrencyCode = entity.CurrencyCode;

            }
            else
            {
                tlf.Description = entity.AccountName;
                tlf.Acode = this.ACode;
                tlf.HomeAmount = entity.Amount * this.Rate;
                tlf.HomeAmt = entity.LocalAmt * this.Rate;
                tlf.HomeOAmt = entity.LocalOamt * this.Rate;
                tlf.LocalAmount = entity.Amount;
                tlf.LocalAmt = entity.LocalAmt;
                tlf.LocalOAmt = entity.LocalOamt;
                tlf.Narration = "Clearing Paid " + entity.ChequeNo;
                tlf.DateTime = DateTime.Now;
                tlf.Status = this.TransactionTypeDTO.Status;
                tlf.TransactionCode = this.TransactionTypeDTO.TransactionCode;
                tlf.AccountSign = entity.AccountSign;
                tlf.CLRPostStatus = "Y";
                tlf.DeliverReturn = false;
                tlf.OtherBankAcctNo = entity.ReceiptAccountNo;
                tlf.SourceCurrency = entity.CurrencyCode;
                tlf.CurrencyCode = entity.CurrencyCode;
            }
            return tlf;
        }

        private PFMORM00020 GetUCheckEntity(TLMDTO00053 entity)
        {
            PFMORM00020 tlf = new PFMORM00020();
            tlf.AccountNo = entity.AccountNo;
            tlf.ChequeNo = entity.ChequeNo;
            tlf.DATE_TIME = DateTime.Now;
            tlf.USERNO = entity.CreatedUserId.ToString();
            tlf.SourceBranchCode = entity.SourceBranchCode;            
            tlf.Channel = this.Channel;          
            tlf.Active = true;
            tlf.CreatedUserId = entity.CreatedUserId;
            tlf.CreatedDate = DateTime.Now;
            tlf.AccountSignature = entity.AccountSign;
            return tlf;
        }

        #endregion
    }
}
