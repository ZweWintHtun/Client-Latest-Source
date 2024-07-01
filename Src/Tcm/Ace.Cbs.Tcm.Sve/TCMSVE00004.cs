//----------------------------------------------------------------------
// <copyright file="TCMSVE00004.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Khaing Su Wai</CreatedUser>
// <CreatedDate>12/09/2013</CreatedDate>
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
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Cle;

namespace Ace.Cbs.Tcm.Sve
{
    public class TCMSVE00004 : BaseService, ITCMSVE00004
    {
        #region DAO Properties      
        public ITLMDAO00016 PODAO { get; set; }      
        public ICXSVE00002 CodeGenerator { get; set; }
        public ITLMDAO00005 TranTypeDAO { get; set; }
        public IPFMDAO00054 TLFDAO { get; set; }
        public ITLMDAO00001 REDAO { get; set; }       
        public decimal balance { get; set; }
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
        public string COAACName { get; set; }
        #endregion

        #region Method
        public string GetEncashCode(int updateduserid, string sourceBranch)
        {
            string encashNo = string.Empty;
            try
            {
                encashNo = this.CodeGenerator.GetGenerateCode("encashCode", string.Empty, updateduserid, sourceBranch, new object[] { });
                return encashNo;
            }

            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.Message;
                throw new Exception(this.ServiceResult.MessageCode);
                
            }
        }

        //public string GetVoucherNo(DateTime settlementDate, int CreatedUserID)
        //{
        //    return this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, CreatedUserID, CurrentUserEntity.BranchCode, new object[] { settlementDate.Day.ToString().PadLeft(2, '0'), settlementDate.Month.ToString().PadLeft(2, '0'), settlementDate.Year.ToString().Substring(2) });
        //}

        public string GetPONo(DateTime settlementDate, int CreatedUserID,string sourceBranch)
        {
            //return this.CodeGenerator.GetGenerateCode("PONO.Code", string.Empty, CreatedUserID, CurrentUserEntity.BranchCode, new object[] { settlementDate.Day.ToString().PadLeft(2, '0'), settlementDate.Month.ToString().PadLeft(2, '0'), settlementDate.Year.ToString().Substring(2) });
            return this.CodeGenerator.GetGenerateCode("PONO.Code", string.Empty, CreatedUserID, sourceBranch, new object[] { settlementDate.Day.ToString().PadLeft(2, '0'), settlementDate.Month.ToString().PadLeft(2, '0'), settlementDate.Year.ToString().Substring(2) });
        }

        #endregion

        #region MainMethod

        public TLMDTO00001 GetREInfoByRegisterNo(string registerNo)
        {
            TLMDTO00001 reInfo = this.REDAO.GetREInfoByRegtisterNo(registerNo);
            return reInfo;
        }


        public string[] Save(TLMDTO00043 poIssueEncashmentDTO)
        {
            try
            {
                //For TLF Description require to save ACode Description
                this.CoaSetupAccountNo = poIssueEncashmentDTO.CoaSetupAccountNo1;
                this.COAACName = poIssueEncashmentDTO.COAACName1;
                if (this.COAACName == null)
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
                this.Rate = CXCOM00010.Instance.GetExchangeRate(poIssueEncashmentDTO.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType));
                if (this.Rate == 0)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; // Client Data Not Found.
                    return null;
                }
                this.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);

                this.TransactionCodeDebit = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.POIssueForEncashmentDebit); //EREMITDRTR
                TLMDTO00005 tranTypeDebitDTO = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { this.TransactionCodeDebit });
                if (tranTypeDebitDTO == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not Found.
                    return null;
                }
                this.TransactionCodeCredit = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.POIssueForEncashmentCredit); //POICRTR
                TLMDTO00005 tranTypeCreditDTO = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { this.TransactionCodeCredit });
                if (tranTypeCreditDTO == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not Found.
                    return null;
                }
                this.TransactionTypeDebitStatus = tranTypeDebitDTO.Status; //TDV
                this.TransactionTypeCreditStatus = tranTypeCreditDTO.Status; //TCV
                this.CoaSetupAccount = poIssueEncashmentDTO.CoaSetupAccountNo2;
                

                PONo = this.GetPONo(this.SettlementDate, poIssueEncashmentDTO.CreatedUserId,poIssueEncashmentDTO.SourceBranch);

                PaymentOrderNo = "IR" + poIssueEncashmentDTO.SourceBranch + "/" + this.PONo;

                poIssueEncashmentDTO.PONo = PONo;
                //VoucherNo = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, poIssueEncashmentDTO.CreatedUserId, CurrentUserEntity.BranchCode, new object[] { this.SettlementDate.Day.ToString().PadLeft(2, '0'), this.SettlementDate.Month.ToString().PadLeft(2, '0'), this.SettlementDate.Year.ToString().Substring(2) });
                VoucherNo = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, poIssueEncashmentDTO.CreatedUserId, poIssueEncashmentDTO.SourceBranch, new object[] { this.SettlementDate.Day.ToString().PadLeft(2, '0'), this.SettlementDate.Month.ToString().PadLeft(2, '0'), this.SettlementDate.Year.ToString().Substring(2) });

                PFMORM00054 tlfEntity = this.GetTLF(poIssueEncashmentDTO);
                tlfEntity.ReferenceVoucherNo = poIssueEncashmentDTO.RegisterNo;
                tlfEntity.Id = TLFDAO.SelectMaxId() + 1;

                tlfEntity.Eno = VoucherNo;
                this.TLFDAO.Save(tlfEntity);
               
                #region NextTlf
                tlfEntity = this.GetTLF(poIssueEncashmentDTO);
                tlfEntity.Eno = this.VoucherNo;
                tlfEntity.AccountNo = this.CoaSetupAccount;
                tlfEntity.Acode = this.CoaSetupAccount;
                tlfEntity.TransactionCode = TransactionCodeCredit;
                tlfEntity.Status = TransactionTypeCreditStatus;
                tlfEntity.Id = TLFDAO.SelectMaxId() + 1;
                tlfEntity.ReferenceVoucherNo = poIssueEncashmentDTO.RegisterNo;
                //For TLF Description require to save ACode Description
                this.COAACName = poIssueEncashmentDTO.COAACName2;
                if (this.COAACName == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; // Client Data Not Found.
                    return null;
                }

                tlfEntity.Description = this.COAACName;                
                this.TLFDAO.Save(tlfEntity);

                #endregion

                TLMORM00016 poentity = this.BindPOData(poIssueEncashmentDTO);
                this.PODAO.Save(poentity);

                poIssueEncashmentDTO.UpdatedUserId = poIssueEncashmentDTO.CreatedUserId;
                poIssueEncashmentDTO.UpdatedDate = poIssueEncashmentDTO.CreatedDate;
                poIssueEncashmentDTO.SettlementDate = this.SettlementDate;
                string[] Data = new string[2];
                Data[0] = poentity.PONo;
                Data[1] = this.VoucherNo;
                string toaccountNo = poentity.PONo;

                string encashNo = this.GetEncashCode(poIssueEncashmentDTO.CreatedUserId, poIssueEncashmentDTO.SourceBranch);
                this.REDAO.UpdateReInfo(poIssueEncashmentDTO.RegisterNo, encashNo, toaccountNo, DateTime.Now, poIssueEncashmentDTO.SettlementDate, poIssueEncashmentDTO.UpdatedUserId, poIssueEncashmentDTO.UpdatedDate);

                this.ServiceResult.ErrorOccurred = false;
                return Data;
            }
            catch(Exception  ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90000"; //Saving Error.
                throw new Exception(this.ServiceResult.MessageCode);
                //return null;
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
            tlf.PaymentOrderNo = this.PaymentOrderNo;
            tlf.Amount = entity.Amount;
            tlf.Acode = CoaSetupAccountNo;
            tlf.SettlementDate = this.SettlementDate;
            tlf.DateTime = DateTime.Now;
            tlf.Channel = this.Channel;
            tlf.TransactionCode = this.TransactionCodeDebit;
            tlf.Status = this.TransactionTypeDebitStatus;
            tlf.Description = this.COAACName;
            tlf.Narration = "RE" + entity.RegisterNo + " " + this.PaymentOrderNo;
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
            tlf.ReferenceType = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.RemittanceCode);//RE
            tlf.DeliverReturn = false;
            tlf.DateTime = DateTime.Now;
            tlf.Active = true;
            tlf.ERegisterNo = entity.RegisterNo;
            tlf.CreatedUserId = entity.CreatedUserId;
            tlf.CreatedDate = DateTime.Now;
            return tlf;
        }

        #endregion

    }
}
