//----------------------------------------------------------------------
// <copyright file="TLMDTO00015.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San </CreatedUser>
// <CreatedDate>2013-05-22</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Tel.Dmd
{
    /// <summary>
    /// CashDeno DTO Entity
    /// </summary>
    [Serializable]
    public class TLMDTO00015 : EntityBase<TLMDTO00015>
    {

        public TLMDTO00015() { }

        public TLMDTO00015(int id)
        {
            this.Id = id;
        }
        public TLMDTO00015(string branchCode)
        {
            this.BranchCode = branchCode;
        }

        public TLMDTO00015(string tlfeno,DateTime cashdate,DateTime settlementdate)
        {
            this.TlfEntryNo = tlfeno;
            this.CashDate = cashdate;
            this.SettlementDate = settlementdate;
        }

        public TLMDTO00015(string status,decimal amount,decimal rate,string denoDetail,string denoReundDetail)
        {
            this.Status = status;
            this.Amount = amount;
            this.Rate = rate;
            this.DenoDetail = denoDetail;
            this.DenoRefundDetail = denoReundDetail;
        }

        public TLMDTO00015(string denoentryNo, string tlfentryNo, string accountType, string receiptNo, string fromType, DateTime cashdate,DateTime settlementdate, string counterno, string status, bool reverse, string denoDetail, string denoRate, string sourcebranchcode, string currency, decimal amount, string userno, decimal rate)
        {
            this.DenoEntryNo = denoentryNo;
            this.TlfEntryNo = tlfentryNo;
            this.AccountType = accountType;
            this.ReceiptNo = receiptNo;
            this.FromType = fromType;
            this.CashDate = cashdate;
            this.SettlementDate = settlementdate;
            this.CounterNo = counterno;
            this.Status = status;
            this.Reverse = reverse;
            this.DenoDetail = denoDetail;
            this.DenoRate = denoRate;
            this.SourceBranchCode = sourcebranchcode;
            this.Currency = currency;
            this.Amount = amount;
            this.UserNo = userno;
            this.Rate = rate;
        }

        public TLMDTO00015(int id, string deno_Eno, string tlf_Eno, string acType, string fromType, string branchCode, string receiptNo, decimal amount, System.Nullable<decimal> adjustAmt, System.Nullable<DateTime> cash_Date, string deno_Detail, string denoRefund_Detail, string userNo, string counterNo, string status, System.Nullable<bool> reverse, string uId, string sourceBr, string cur, string denoRate, string denoRefundRate, System.Nullable<DateTime> settlementDate, string allDenoRate, System.Nullable<decimal> rate, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
        {
            this.Id = id;
            this.DenoEntryNo = deno_Eno;
            this.TlfEntryNo = tlf_Eno;
            this.AccountType = acType;
            this.FromType = fromType;
            this.BranchCode = branchCode;
            this.ReceiptNo = receiptNo;
            this.Amount = amount;
            this.AdjustAmount = adjustAmt;
            this.CashDate = cash_Date;
            this.DenoDetail = deno_Detail;
            this.DenoRefundDetail = denoRefund_Detail;
            this.UserNo = userNo;
            this.CounterNo = counterNo;
            this.Status = status;
            this.Reverse = reverse;
            this.UniqueId = uId;
            this.SourceBranchCode = sourceBr;
            this.Currency = cur;
            this.DenoRate = denoRate;
            this.DenoRefundRate = denoRefundRate;
            this.SettlementDate = settlementDate;
            this.AllDenoRate = allDenoRate;
            this.Rate = rate;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }		



        //public TLMDTO00015(string tlfeno, DateTime cashdate/*, string accountType, decimal amount, decimal income, decimal communicationcharges, string currency*/)
        //{
        //    this.TlfEntryNo = tlfeno;
        //    this.CashDate = cashdate;
        //    //this.AccountType = accountType;
        //    //this.Amount = amount;
        //    //this.IncomeCharges = income;
        //    //this.CommunicationCharges = communicationcharges;
        //    //this.Currency = currency;
        //}

        public TLMDTO00015(string tlfeno, DateTime cashdate, string accountType, decimal amount, decimal income, decimal communicationcharges, string currency)
        {
            this.TlfEntryNo = tlfeno;
            this.CashDate = cashdate;
            this.AccountType = accountType;
            this.Amount = amount;
            this.IncomeCharges = income;
            this.CommunicationCharges = communicationcharges;
            this.Currency = currency;
        }

        public TLMDTO00015(string tlfeno, DateTime cashdate, decimal amount , string currency)
        {
            this.TlfEntryNo = tlfeno;
            this.CashDate = cashdate;
            this.Amount = amount;
            this.Currency = currency;
        }

        public TLMDTO00015(string tlfeno, bool active)
        {
            this.TlfEntryNo = tlfeno;
            this.Reverse = active;
            //Check EntryNo is valid or invalid
        }

        public TLMDTO00015(int id
            , string denoEntryNo
            , string tlfEntryNo
            , string accountType
            , string fromType
            , string branchCode
            , string receiptNo
            , decimal amount
            , decimal adjustAmount
            , DateTime cashDate
            , string denoDetail
            , string denoRefundDetail
            , string userNo
            , string counterNo
            , string status
            , bool reverse
            , string uniqueId
            , string sourceBranchCode
            , string currency
            , string denoRate
            , string denoRefundRate
            , DateTime settlementDate
            , string allDenoRate
            , decimal rate
            , bool active
            , DateTime createdDate
            , int createdUserId
            , DateTime updatedDate
            , int updatedUserId)
        {
            this.Id = id;
            this.DenoEntryNo = denoEntryNo;
            this.TlfEntryNo = tlfEntryNo;
            this.AccountType = accountType;
            this.FromType = fromType;
            this.BranchCode = branchCode;
            this.ReceiptNo = receiptNo;
            this.Amount = amount;
            this.AdjustAmount = adjustAmount;
            this.CashDate = cashDate;
            this.DenoDetail = denoDetail;
            this.DenoRefundDetail = denoRefundDetail;
            this.UserNo = userNo;
            this.CounterNo = counterNo;
            this.Status = status;
            this.Reverse = reverse;
            this.UniqueId = uniqueId;
            this.SourceBranchCode = sourceBranchCode;
            this.Currency = currency;
            this.DenoRate = denoRate;
            this.DenoRefundRate = denoRefundRate;
            this.SettlementDate = settlementDate;
            this.AllDenoRate = allDenoRate;
            this.Rate = rate;
            this.Active = active;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }


        //selectCashDenoData for TCMSVE00007 and SelectCashDenoInfoByACType for TLMDAO00015
        public TLMDTO00015(string eno, string tlfEno, string acType, string recNo, string fType, DateTime cashDate, DateTime setDate, string userNo, string counterNo, string status, bool rev, string denoDetail, string denoRefDetail, string denoRate, string sourceBrCode, string cur, decimal amt, decimal rate, string denoRefRate, string allDenoRate)
        {
            this.DenoEntryNo = eno;
            this.TlfEntryNo = tlfEno;
            this.AccountType = acType;
            this.ReceiptNo = recNo;
            this.FromType = fType;
            this.CashDate = cashDate;
            this.SettlementDate = setDate;
            this.UserNo = userNo;
            this.CounterNo = counterNo;
            this.Status = status;
            this.Reverse = rev;
            this.DenoDetail = denoDetail;
            this.DenoRefundDetail = denoRefDetail;
            this.DenoRate = denoRate;
            this.SourceBranchCode = sourceBrCode;
            this.Currency = cur;
            this.Amount = amt;
            this.Rate = rate;
            this.DenoRefundRate = denoRefRate;
            this.AllDenoRate = allDenoRate;
        }
        //IndividualDenominationDelete
        //public TLMDTO00015(string tlfEno, string acType,string userNo, string counterNo,decimal amt,string sourceBrCode)
        //{
        //    this.TlfEntryNo = tlfEno;
        //    this.AccountType = acType;        
        //    this.UserNo = userNo;
        //    this.CounterNo = counterNo;
        //    this.Amount = amt;
        //    this.SourceBranchCode = sourceBrCode;     
           
           
        //}
        ////IndividualDenominationDelete
        //public TLMDTO00015(int id, string deno_Eno, string tlf_Eno, string acType, string fromType, string branchCode, string receiptNo, decimal amount, System.Nullable<decimal> adjustAmt, System.Nullable<DateTime> cash_Date, string deno_Detail, string denoRefund_Detail, string userNo, string counterNo, string status, System.Nullable<bool> reverse, string uId, string sourceBr, string cur, string denoRate, string denoRefundRate, System.Nullable<DateTime> settlementDate, string allDenoRate, System.Nullable<decimal> rate, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
        //{
        //    this.Id = id;
        //    this.DenoEntryNo = deno_Eno;
        //    this.TlfEntryNo = tlf_Eno;
        //    this.AccountType = acType;
        //    this.FromType = fromType;
        //    this.BranchCode = branchCode;
        //    this.ReceiptNo = receiptNo;
        //    this.Amount = amount;
        //    this.AdjustAmount = adjustAmt;
        //    this.CashDate = cash_Date;
        //    this.DenoDetail = deno_Detail;
        //    this.DenoRefundDetail = denoRefund_Detail;
        //    this.UserNo = userNo;
        //    this.CounterNo = counterNo;
        //    this.Status = status;
        //    this.Reverse = reverse;
        //    this.UniqueId = uId;
        //    this.SourceBranchCode = sourceBr;
        //    this.Currency = cur;
        //    this.DenoRate = denoRate;
        //    this.DenoRefundRate = denoRefundRate;
        //    this.SettlementDate = settlementDate;
        //    this.AllDenoRate = allDenoRate;
        //    this.Rate = rate;
        //    this.Active = active;
        //    this.TS = tS;
        //    this.CreatedDate = createdDate;
        //    this.CreatedUserId = createdUserId;
        //    this.UpdatedDate = updatedDate;
        //    this.UpdatedUserId = updatedUserId;
        //}		

        public TLMDTO00015(string tlfeno,string status,string cur,decimal rate,DateTime settlementdate,string sourcebr)
        {
            this.TlfEntryNo = tlfeno;
            this.Status = status;
            this.Currency = cur;
            this.Rate = rate;
            this.SettlementDate = settlementdate;
            this.SourceBranchCode = sourcebr;
        }

        /*Drawing Cash Deposit Denomination Entry */
        public TLMDTO00015(string accountype, DateTime cashdate, decimal amount, bool reverse,string currency)
        {
            this.AccountType = accountype;
            if (cashdate == System.DateTime.MinValue)
            {
                this.CashDate = null;
            }
            else
            {
                this.CashDate = cashdate;
            }
            this.Amount = amount;
            this.Reverse = reverse;
            this.Currency = currency;
        }

        // Added by ZMS (Insert Cash Deno For Multiple Withdraw and Deposit Reversal)
        public TLMDTO00015(int id
           , string denoEntryNo, string tlfEntryNo, string accountType, string branchCode, decimal amount , decimal adjustAmount
           , string denoDetail , string denoRefundDetail, string userNo, string counterNo, string status, bool reverse
           , string sourceBranchCode, string currency, string denoRate, string denoRefundRate, DateTime settlementDate
           , decimal rate, bool active, int createdUserId,string message)
        {
            this.Id = id;
            this.DenoEntryNo = denoEntryNo;
            this.TlfEntryNo = tlfEntryNo;
            this.AccountType = accountType;
            this.BranchCode = branchCode;
            this.Amount = amount;
            this.AdjustAmount = adjustAmount;
            this.DenoDetail = denoDetail;
            this.DenoRefundDetail = denoRefundDetail;
            this.UserNo = userNo;
            this.CounterNo = counterNo;
            this.Status = status;
            this.Reverse = reverse;
            this.SourceBranchCode = sourceBranchCode;
            this.Currency = currency;
            this.DenoRate = denoRate;
            this.DenoRefundRate = denoRefundRate;
            this.SettlementDate = settlementDate;
            this.Rate = rate;
            this.Active = active;
            this.CreatedUserId = createdUserId;
            this.ErrorMessage = message;
        }
        public TLMDTO00015(int userid, DateTime date, string eno, string sourceBr)
        {
            this.UpdatedUserId= userid;
            this.UpdatedDate = date;
            this.TlfEntryNo = eno;
            this.SourceBranchCode = sourceBr;
        }
        // 
        #region Vault Withdrawl Denomination Form
        public virtual string DebitEno { get; set; }
        public virtual string CreditEno { get; set; }
        public virtual string FromType { get; set; }
        public virtual string ToType { get; set; }
        public virtual bool IsEnableToType { get; set; }
        public virtual decimal DebitAmount { get; set; }
        public virtual decimal CreditAmount { get; set; }
        #endregion

        public virtual int Id { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual string DenoEntryNo { get; set; }
        public virtual string TlfEntryNo { get; set; }
        public virtual string AccountNo { get; set; }  
        public virtual string AccountType { get; set; }
        public virtual string BranchCode { get; set; }
        public virtual string ReceiptNo { get; set; }        
        public virtual System.Nullable<decimal> AdjustAmount { get; set; }
        public virtual System.Nullable<DateTime> CashDate { get; set; }
        public virtual string DenoDetail { get; set; }
        public virtual string DenoRefundDetail { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string CounterNo { get; set; }
        public virtual string Status { get; set; }
        public virtual System.Nullable<bool> Reverse { get; set; }
        public virtual string UniqueId { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual string Currency { get; set; }
        public virtual string DenoRate { get; set; }
        public virtual string DenoRefundRate { get; set; }
        public virtual System.Nullable<DateTime> SettlementDate { get; set; }
        public virtual string AllDenoRate { get; set; }
        public virtual System.Nullable<decimal> Rate { get; set; }
        public virtual bool IsCheck { get; set; }
        public virtual string DenostringForCenterTable { get; set; }
        public virtual string RegisterNo { get; set; }
        public string ReturnValue { get; set; }
        public string ErrorMessage { get; set; }
        public string VirtualStatus { get; set; }
        public decimal IncomeCharges { get; set; }
        public decimal CommunicationCharges { get; set; }
        public decimal DepoDenoAmount { get; set; }

        public string WithdrawEntryStatus { get; set; }   //added by ASDA
    }
}
