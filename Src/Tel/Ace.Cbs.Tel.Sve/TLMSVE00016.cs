//----------------------------------------------------------------------
// <copyright file="TLMSVE00016.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Su Su Wai</CreatedUser>
// <CreatedDate>09/06/2013</CreatedDate>
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
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Ser.Dao;

namespace Ace.Cbs.Tel.Sve
{
    /// <summary>
    /// PO Refund By Cash Service
    /// </summary>
    public class TLMSVE00016 : BaseService, ITLMSVE00016
    {
        #region DAO Properties
        public ICXSVE00002 CodeGenerator { get; set; }        
        public ITLMDAO00016 PODAO { get; set; }
        public IPFMDAO00054 TLFDAO { get; set; }
        public ITLMDAO00015 CashDenoDAO { get; set; }
        public ITLMDAO00009 DepoDenoDAO { get; set; }
               
        #endregion

        #region DTO Properties
        private string CoaSetupAccountNo { get; set; }
        private ChargeOfAccountDTO CoaDTO { get; set; }       
        private DateTime SettlementDate { get; set; }
        private decimal Rate { get; set; }
        private string Channel { get; set; }
        private string TransactionCode { get; set; }
        private string TransactionTypeStatus { get; set; }
        private decimal TotalAmount { get; set; }
        #endregion

        #region Main Method
        [Transaction(TransactionPropagation.Required)]
        public string Save(IList<TLMDTO00041> poList,string sourceBr)
        {
            this.CoaSetupAccountNo = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { "Sundry Deposit", poList[0].CurrencyCode, poList[0].SourceBranchCode, true });
            this.CoaDTO = CXCOM00011.Instance.GetScalarObject<ChargeOfAccountDTO>("COA.Server.SelectAccountName", new object[] { this.CoaSetupAccountNo, poList[0].SourceBranchCode, true });
            if (this.CoaDTO == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME00021; // Client Data Not Found.
                return null;
            }

            this.SettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), poList[0].SourceBranchCode ,true });
            if (this.SettlementDate == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME00021; // Client Data Not Found.
                return null;
            }
            this.Rate = CXCOM00010.Instance.GetExchangeRate(poList[0].CurrencyCode, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType));
            if (this.Rate == 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME00021; // Client Data Not Found.
                return null;
            }
            this.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
            this.TransactionCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PaymentOrderRefundCash);
            TLMDTO00005 tranTypeDTO = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { this.TransactionCode });
            if (tranTypeDTO == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not Found.
                return null;
            }
            this.TransactionTypeStatus = tranTypeDTO.Status;

            string voucherNo = string.Empty;
            string groupNo = poList.Count > 1 ? this.CodeGenerator.GetGenerateCode("GroupVoucher", string.Empty, poList[0].CreatedUserId, poList[0].SourceBranchCode, new object[] { this.SettlementDate.Day.ToString().PadLeft(2, '0'), this.SettlementDate.Month.ToString().PadLeft(2, '0'), this.SettlementDate.Year.ToString().Substring(2) }) : string.Empty;           
            for (int i = 0; i < poList.Count; i++)
            {
                voucherNo = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, poList[i].CreatedUserId, poList[0].SourceBranchCode, new object[] { this.SettlementDate.Day.ToString().PadLeft(2, '0'), this.SettlementDate.Month.ToString().PadLeft(2, '0'), this.SettlementDate.Year.ToString().Substring(2) });               
                PFMORM00054 tlfEntity = this.GetTLF(poList[i]);
                tlfEntity.Eno = voucherNo;
                this.TLFDAO.Save(tlfEntity);
                this.TotalAmount += poList[i].Amount;
                if (poList.Count > 1)
                {
                    TLMORM00009 depoDenoEntity = this.GetDepoDeno(poList[i]);
                    depoDenoEntity.GroupNo = groupNo;
                    depoDenoEntity.Tlf_Eno = voucherNo;
                    depoDenoEntity.SourceBranchCode=sourceBr;
                    this.DepoDenoDAO.Save(depoDenoEntity);
                }
                //Wrong
                if (this.PODAO.UpdatePORefundByPONoAndBudgetYear(DateTime.Now, this.SettlementDate, "C", poList[i].BudgetYear, poList[i].PaymentOrderNo,poList[i].AccountNo,poList[i].CreatedUserId) == false)
                {
                    // Update Error
                    throw new Exception(CXMessage.ME90001);
                }
            }
            if (poList.Count > 0)  //comfirm by ks win
            {
                poList[0].GroupNo = String.IsNullOrEmpty(groupNo) ? voucherNo : groupNo;
               this.CashDenoDAO.Save(this.GetCashDeno(poList[0]));  //bug No.31 (\\cbssvr\CBS\001 Engineering\007 Integrated Test\Bugs\Implementation_Bug(14.03.2015) 
                                                                             //if not save in cashdeno , can't show denoOutstanding report
                this.ServiceResult.ErrorOccurred = false;
                return poList[0].GroupNo ;
            }
            else{
                return voucherNo;
            }          
        }        
        #endregion

        #region Convert DTO to ORM
        private PFMORM00054 GetTLF(TLMDTO00041 entity)
        {
            PFMORM00054 tlf = new PFMORM00054();
            tlf.Id = this.TLFDAO.SelectMaxId() + 1;
            tlf.AccountNo = this.CoaSetupAccountNo;
            tlf.Amount = entity.Amount;
            tlf.Acode = this.CoaSetupAccountNo;
            tlf.SettlementDate = this.SettlementDate;
            tlf.DateTime = DateTime.Now;
            tlf.Channel = this.Channel;
            tlf.TransactionCode = this.TransactionCode;
            tlf.Status = this.TransactionTypeStatus;
            tlf.Description = this.CoaDTO.AccountName;
            tlf.Narration = entity.PaymentOrderNo + " Refund.";
            tlf.SourceBranchCode = entity.SourceBranchCode;
            tlf.Rate = this.Rate;
            tlf.PaymentOrderNo = entity.PaymentOrderNo;
            tlf.CurrencyCode = entity.CurrencyCode;
            CurrencyDTO curdto = CXCOM00011.Instance.GetScalarObject<CurrencyDTO>("Cur.HomeCur.Select", new object[] { true });
            tlf.SourceCurrency = curdto.Cur;
            tlf.UserNo = entity.CreatedUserId.ToString();
            tlf.HomeAmt = entity.Amount * this.Rate;
            tlf.LocalAmt = entity.Amount;
            tlf.HomeAmount = tlf.HomeAmt + ((tlf.HomeOAmt == null)? 0 : tlf.HomeOAmt.Value);
            tlf.LocalAmount = tlf.LocalAmt + ((tlf.LocalOAmt == null) ? 0 : tlf.LocalOAmt.Value);
            tlf.HomeOAmt = 0;
            tlf.LocalOAmt = 0;
            tlf.ReferenceVoucherNo = entity.PaymentOrderNo;
            tlf.ReferenceType = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PaymentOrderAccountNoName);
            tlf.Active = true;
            tlf.CreatedUserId = entity.CreatedUserId;
            tlf.CreatedDate = DateTime.Now;
            return tlf;
        }

        /*Modified by HWH.*/
 //private TLMORM00015 GetCashDeno(TLMDTO00041 poEntity,string poNoForSingle)
        //{
        //    TLMORM00015 cashDeno = new TLMORM00015();
        //    cashDeno.AccountType = poNoForSingle;
        //    cashDeno.Amount = this.TotalAmount;
        //    cashDeno.UserNo = poEntity.CreatedUserId.ToString();
        //    cashDeno.Status = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PaymentCashStatus);//P
        //    cashDeno.CounterNo = poEntity.CounterNo;
        //    cashDeno.SourceBranchCode = poEntity.SourceBranchCode;
        //    if(poEntity.GroupNo.Contains("G"))
        //        cashDeno.CashDate = null;
        //    if (poEntity.GroupNo.Contains("G"))
        //        cashDeno.SettlementDate =  this.SettlementDate ;
        //    //cashDeno.DenoDetail = denoString.DenoString;
        //    //cashDeno.DenoRate = denoString.DenoRateString;
        //    //cashDeno.DenoRefundDetail = denoString.RefundString;
        //    //cashDeno.DenoRefundRate = denoString.RefundRateString;
        //    cashDeno.Currency = poEntity.CurrencyCode;
        //    //cashDeno.Rate = this.Rate;
        //    cashDeno.Active = true;
        //    cashDeno.CreatedUserId = poEntity.CreatedUserId;
        //    cashDeno.CreatedDate = DateTime.Now;
        //    cashDeno.Reverse = false;
        //    cashDeno.TlfEntryNo = poEntity.GroupNo;
        //    return cashDeno;
        //}

        private TLMORM00015 GetCashDeno(TLMDTO00041 poEntity)
        {
            TLMORM00015 cashDeno = new TLMORM00015();
            cashDeno.TlfEntryNo = poEntity.GroupNo;
            cashDeno.AccountType = poEntity.GroupNo.Contains("G") ? null : poEntity.PaymentOrderNo;            
            cashDeno.Amount = this.TotalAmount;
            cashDeno.AdjustAmount = 0;
            cashDeno.UserNo = poEntity.CreatedUserId.ToString();
            cashDeno.Status = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PaymentCashStatus);//P
            cashDeno.CounterNo = null;
            cashDeno.SourceBranchCode = poEntity.SourceBranchCode;            
            cashDeno.CashDate = null;            
            cashDeno.SettlementDate = this.SettlementDate;
            cashDeno.Currency = poEntity.CurrencyCode;
           
            cashDeno.Active = true;
            cashDeno.CreatedUserId = poEntity.CreatedUserId;
            cashDeno.CreatedDate = DateTime.Now;
            cashDeno.Reverse = false;            
            return cashDeno;
        }


        private TLMORM00009 GetDepoDeno(TLMDTO00041 entity)
        {
       
            TLMORM00009 depoDeno = new TLMORM00009();
            decimal zeroAmount = 0;
            depoDeno.AccountType = entity.PaymentOrderNo;
            depoDeno.Amount = entity.Amount;
            depoDeno.SourceBranchCode = entity.SourceBranchCode;
            depoDeno.Currency = entity.CurrencyCode;

            depoDeno.Income = Convert.ToDecimal(string.Format("{0:0.00}", zeroAmount));
            depoDeno.Communicationcharge = Convert.ToDecimal(string.Format("{0:0.00}", zeroAmount));
           
            depoDeno.Active = true;
            depoDeno.CreatedUserId = entity.CreatedUserId;
            depoDeno.CreatedDate = DateTime.Now;
            return depoDeno;
        }
        #endregion

        # region Helper Method

        //Added by HMW For the new budget year change
        public string GetBudYear(int service, DateTime reqDate, string sourceBr)
        {
            try
            {              
                string Return = string.Empty;
                string budYear = PODAO.GetBudget_Month_Year_Quarter(service, reqDate, sourceBr, Return);  // For 2018/09/17 => active budget from BLF as 2018/2019
                return budYear;
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;

                throw new Exception(ex.Message);
            }
        }
        #endregion
      
    }
}
