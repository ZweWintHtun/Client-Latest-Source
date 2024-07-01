//----------------------------------------------------------------------
// <copyright file="MNMSVE00008.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KTRHMS</CreatedUser>
// <CreatedDate>11/04/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
//using Ace.Cbs.Cx.Ser.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Mnm.Sve
{
    /// <summary>
    /// PO Editting for Encashment Service
    /// </summary>
    public class MNMSVE00019 : BaseService, IMNMSVE00019
    {
        #region DAO Properties

        public IPFMDAO00075 RateInfoDAO { get; set; }
        public ITLMDAO00016 PODAO { get; set; }
        public ICXSVE00002 CodeGenerator { get; set; }
        public ITLMDAO00005 TranTypeDAO { get; set; }
        public IPFMDAO00054 TLFDAO { get; set; }
        public ITLMDAO00001 ReDAO { get; set; }
        public decimal balance { get; set; }
        public string encashNo = string.Empty;
        
        #endregion

        #region DTO Properties

        public string PONo { get; set; }
        public string PaymentOrderNo { get; set; }
        public string VoucherNo { get; set; }
        private ChargeOfAccountDTO CoaDTO { get; set; }
        private DateTime SettlementDate { get; set; }
        private decimal Rate { get; set; }
        private string Channel { get; set; }
        private string TransactionCodeDebit { get; set; }
        private string TransactionCodeCredit { get; set; }
        private string TransactionTypeDebitStatus { get; set; }
        private string TransactionTypeCreditStatus { get; set; }
        private decimal TotalAmount { get; set; }
        public string CoaSetupAccountNo { get; set; }
        public string CoaSetupAccount { get; set; }
        public string CoaSetupIncomeAccountNo { get; set; }
        public string Description { get; set; }
        public string IncomeDescription { get; set; }
        public string Income { get; set; }
        #endregion

        #region "Main Methods"

        [Transaction(TransactionPropagation.Required)]
        public IList<TLMDTO00001> SelectReInformationByRegisterNo(string registerno, string sourcebr)
        {
            IList<TLMDTO00001> relist = this.ReDAO.SelectReListByRegisterNo(registerno, sourcebr);
            if (relist.Count > 0)
            {
                foreach (TLMDTO00001 reDto in relist)
                {
                    if (!string.IsNullOrEmpty(reDto.IssueDate.ToString()))  // checking registerNo is already issued or not 
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "MV00217";    //This Register No. {0} is already received.(need)
                        return null;
                    }
                    else if (!string.IsNullOrEmpty(reDto.ToAccountNo))      // checking registerno is encash or transfer 
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "MV00147";        //Cash -> Remittance Only
                    }
                }

                return relist;
            }
            else
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV00168";  //Invalid Register No
            }
            return null;
        }
              
        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00054> Save(TLMDTO00043 poIssueEncashmentDTO)
        {
            try
            {
                IList<PFMDTO00054> TLFList = new List<PFMDTO00054>();

                this.CoaDTO = CXCOM00012.Instance.SelectCOAByCoaSetupAccountName("Income", poIssueEncashmentDTO.Currency, poIssueEncashmentDTO.SourceBranch);
                if (this.CoaDTO == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; // Client Data Not Found.
                    return null;
                }

                this.SettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), poIssueEncashmentDTO.SourceBranch ,true});
                if (this.SettlementDate == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; // Client Data Not Found.
                    return null;
                }

                this.Rate = CXCOM00010.Instance.GetExchangeRate(poIssueEncashmentDTO.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType));  // TT
               
                if (this.Rate == 0)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; // Client Data Not Found.
                    return null;
                }

                this.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
                this.TransactionCodeDebit = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.POIssueForEncashmentDebit); //POICRTR
                TLMDTO00005 tranTypeDebitDTO = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { this.TransactionCodeDebit }); //TCV
                if (tranTypeDebitDTO == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not Found.
                    return null;
                }

                this.TransactionCodeCredit = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.POIssueForEncashmentCredit); //EREMITDRTR
                TLMDTO00005 tranTypeCreditDTO = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { this.TransactionCodeCredit }); //TDV
                if (tranTypeCreditDTO == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not Found.
                    return null;
                }

                this.TransactionTypeDebitStatus = tranTypeDebitDTO.Status;
                this.TransactionTypeCreditStatus = tranTypeCreditDTO.Status;
               
                this.CoaSetupAccountNo = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { "IBSIR", poIssueEncashmentDTO.Currency, poIssueEncashmentDTO.SourceBranch, true });
                this.CoaSetupAccount = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { "POR", poIssueEncashmentDTO.Currency, poIssueEncashmentDTO.SourceBranch, true });

                //PONo = this.CodeGenerator.GetGenerateCode("PONO.Code", string.Empty, poIssueEncashmentDTO.CreatedUserId, CurrentUserEntity.BranchCode, new object[] { this.SettlementDate.Day.ToString().PadLeft(2, '0'), this.SettlementDate.Month.ToString().PadLeft(2, '0'), this.SettlementDate.Year.ToString().Substring(2) });
                PONo = this.CodeGenerator.GetGenerateCode("PONO.Code", string.Empty, poIssueEncashmentDTO.CreatedUserId, poIssueEncashmentDTO.SourceBranch, new object[] { this.SettlementDate.Day.ToString().PadLeft(2, '0'), this.SettlementDate.Month.ToString().PadLeft(2, '0'), this.SettlementDate.Year.ToString().Substring(2) });
                
                PaymentOrderNo = "IR" + poIssueEncashmentDTO.SourceBranch + "/" + this.PONo;

                poIssueEncashmentDTO.PONo = PONo;
                //VoucherNo = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, poIssueEncashmentDTO.CreatedUserId, CurrentUserEntity.BranchCode, new object[] { this.SettlementDate.Day.ToString().PadLeft(2, '0'), this.SettlementDate.Month.ToString().PadLeft(2, '0'), this.SettlementDate.Year.ToString().Substring(2) });
                VoucherNo = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, poIssueEncashmentDTO.CreatedUserId, poIssueEncashmentDTO.SourceBranch, new object[] { this.SettlementDate.Day.ToString().PadLeft(2, '0'), this.SettlementDate.Month.ToString().PadLeft(2, '0'), this.SettlementDate.Year.ToString().Substring(2) });

                PFMORM00054 tlfEntity = this.GetTLF(poIssueEncashmentDTO);
             
               
                tlfEntity.ReferenceVoucherNo = poIssueEncashmentDTO.RegisterNo;
                tlfEntity.Id = TLFDAO.SelectMaxId() + 1;

                tlfEntity.Eno = VoucherNo;
                this.TLFDAO.Save(tlfEntity);
                tlfEntity.PaymentOrderNo = this.PaymentOrderNo;
                TLFList.Add(new PFMDTO00054(tlfEntity.Eno, tlfEntity.AccountNo,tlfEntity.Amount,tlfEntity.Status, tlfEntity.TransactionCode,tlfEntity.Narration, tlfEntity.DateTime,tlfEntity.Acode, tlfEntity.Cheque,tlfEntity.CurrencyCode,tlfEntity.Rate.Value,tlfEntity.SettlementDate.Value,tlfEntity.TS,tlfEntity.AccountSign,tlfEntity.HomeAmount.Value, tlfEntity.HomeAmt.Value, tlfEntity.HomeOAmt.Value, tlfEntity.LocalAmount.Value, tlfEntity.LocalAmt.Value, tlfEntity.LocalOAmt.Value, tlfEntity.Description,tlfEntity.PaymentOrderNo));

                #region Next Tlf

                tlfEntity = this.GetTLF(poIssueEncashmentDTO);
                tlfEntity.Eno = this.VoucherNo;
                tlfEntity.AccountNo = this.CoaSetupAccount;
                tlfEntity.Acode = this.CoaSetupAccount;
                tlfEntity.TransactionCode = TransactionCodeCredit;
                tlfEntity.Status = TransactionTypeCreditStatus;
                tlfEntity.ReferenceVoucherNo = poIssueEncashmentDTO.RegisterNo;
                tlfEntity.Id = TLFDAO.SelectMaxId() + 1;
                this.TLFDAO.Save(tlfEntity);

                TLFList.Add(new PFMDTO00054(tlfEntity.Eno, tlfEntity.AccountNo, tlfEntity.Amount, tlfEntity.Status, tlfEntity.TransactionCode, tlfEntity.Narration, tlfEntity.DateTime, tlfEntity.Acode, tlfEntity.Cheque, tlfEntity.CurrencyCode, tlfEntity.Rate.Value, tlfEntity.SettlementDate.Value, tlfEntity.TS, tlfEntity.AccountSign, tlfEntity.HomeAmount.Value, tlfEntity.HomeAmt.Value, tlfEntity.HomeOAmt.Value, tlfEntity.LocalAmount.Value, tlfEntity.LocalAmt.Value, tlfEntity.LocalOAmt.Value, tlfEntity.Description,tlfEntity.PaymentOrderNo));
             
                #endregion

                #region for PO

                TLMORM00016 poEntity = this.BindPOData(poIssueEncashmentDTO);
                this.PODAO.Save(poEntity);

                #endregion

                poIssueEncashmentDTO.UpdatedUserId = poIssueEncashmentDTO.CreatedUserId;
                poIssueEncashmentDTO.UpdatedDate = poIssueEncashmentDTO.CreatedDate;
                poIssueEncashmentDTO.SettlementDate = this.SettlementDate;
                string toaccountNo = poEntity.PONo;

                encashNo = this.GetEncashCode(poIssueEncashmentDTO.CreatedUserId, poIssueEncashmentDTO.SourceBranch);
                this.ReDAO.UpdateReInfo(poIssueEncashmentDTO.RegisterNo, encashNo, toaccountNo, DateTime.Now, poIssueEncashmentDTO.SettlementDate, poIssueEncashmentDTO.UpdatedUserId, poIssueEncashmentDTO.UpdatedDate);

                this.ServiceResult.ErrorOccurred = false;
               // return poEntity.PONo;
                return TLFList;
            }
              
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90000";
                throw new Exception(this.ServiceResult.MessageCode);
            }
            
        }

        #endregion

        #region Convert DTO to ORM

        private TLMORM00016 BindPOData(TLMDTO00043 getPO)
        {
            TLMORM00016 po = new TLMORM00016();

            po.PONo = PaymentOrderNo;
            po.Amount = getPO.Amount;
            po.AccountNo = this.CoaSetupAccountNo;
            po.ADate = DateTime.Now;
            po.UserNo = getPO.UserNo;
            po.ACode = this.CoaSetupAccount;
            po.Budget = getPO.Budget;
            po.SourceBranchCode = getPO.SourceBranch;
            po.Currency = getPO.Currency;
            po.Rate = this.Rate;
            po.SettlementDate = this.SettlementDate;
            po.IDate = null;
            po.Status = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashPaymentStatus);
            po.ToAccountNo = null;
            po.CheckNo = null;
            po.CreatedUserId = getPO.CreatedUserId;
            po.CreatedDate = DateTime.Now;
            po.AccountSign = null;
            po.Active = true;
            return po;
        }
       
        private PFMORM00054 GetTLF(TLMDTO00043 entity)
        {
            PFMORM00054 tlf = new PFMORM00054();
            tlf.AccountNo = CoaSetupAccountNo;
            tlf.PaymentOrderNo = PaymentOrderNo;
            tlf.Amount = entity.Amount;
            tlf.Acode = CoaSetupAccountNo;
            tlf.SettlementDate = this.SettlementDate;
            tlf.DateTime = DateTime.Now;
            tlf.Channel = this.Channel;
            tlf.TransactionCode = this.TransactionCodeDebit;
            tlf.Status = this.TransactionTypeDebitStatus;
            tlf.Description = this.CoaDTO.AccountName;
            tlf.Narration = "RE " + entity.RegisterNo + " " + this.PaymentOrderNo;
            tlf.SourceBranchCode = entity.SourceBranch;
            tlf.Rate = this.Rate;
            tlf.CurrencyCode = entity.Currency;
            CurrencyDTO curdto = CXCOM00011.Instance.GetScalarObject<CurrencyDTO>("Cur.HomeCur.Select", new object[] { true });
            tlf.SourceCurrency = curdto.Cur;
            tlf.UserNo = entity.CreatedUserId.ToString();
            tlf.HomeAmt = entity.Amount * this.Rate;
            tlf.HomeOAmt = 0;
            tlf.LocalAmt = entity.Amount;
            tlf.LocalOAmt = 0;
            tlf.HomeAmount = tlf.HomeAmt + ((tlf.HomeOAmt == null) ? 0 : tlf.HomeOAmt.Value);
            tlf.LocalAmount = tlf.LocalAmt + ((tlf.LocalOAmt == null) ? 0 : tlf.LocalOAmt.Value);
            tlf.ReferenceType = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.RemittanceCode); //For RE
            tlf.DeliverReturn = false;
            tlf.DateTime = DateTime.Now;
            tlf.Active = true;
            tlf.CreatedUserId = entity.CreatedUserId;
            tlf.CreatedDate = DateTime.Now;
            return tlf;
        }

        #endregion

        #region "Helper Methods"
        public string GetEncashCode(int updateduserid, string sourceBranch)
        {
            try
            {
                encashNo = this.CodeGenerator.GetGenerateCode("encashCode", string.Empty, updateduserid, sourceBranch, new object[] { });
                return encashNo;
            }

            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.Message;
                return string.Empty;
            }
        }
        #endregion

    }
}