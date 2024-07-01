//----------------------------------------------------------------------
// <copyright file="TLMDTO00016.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San </CreatedUser>
// <CreatedDate>2013-05-22</CreatedDate>
// <UpdatedUser>Htet Mon Win</UpdatedUser>
// <UpdatedDate>2013-05-28</UpdatedDate>
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
    /// PO DTO Entity
    /// </summary>
    [Serializable]
    public class TLMDTO00016 : Supportfields<TLMDTO00016>
    {
        public TLMDTO00016() { }


        public TLMDTO00016(string poNo, decimal amount, string accountNo, Nullable<DateTime> aDate, Nullable<DateTime> iDate, string status,
                          string toAcctNo, string checkNo, string income, string userNo, string acSign, Nullable<decimal> charges, string acode, string budget,/*string uniqueId,*/
                          string sourceBranchCode, string currency, Nullable<decimal> rate, Nullable<DateTime> settlementDate, Nullable<DateTime> refundDate)
        {
            this.PONo = poNo;
            this.Amount = amount;
            this.AccountNo = accountNo;
            this.ADate = aDate;
            this.IDate = iDate;
            this.Status = status;
            this.ToAccountNo = toAcctNo;
            this.CheckNo = checkNo;
            this.Income = income;
            this.UserNo = userNo;
            this.AcSign = acSign;
            this.Charges = charges;
            this.ACode = acode;
            this.Budget = budget;
            /*this.UniqueId = uniqueId;*/
            this.SourceBranchCode = sourceBranchCode;
            this.Currency = currency;
            this.Rate = rate;
            this.SettlementDate = settlementDate;
            this.RefundDate = refundDate;
        }

        public TLMDTO00016(string poNo, string acode,Nullable<DateTime> iDate, decimal amount)
        {
            this.PONo = poNo;
            this.ACode = acode;
            this.IDate = iDate;
            this.Amount = amount;
        }

        public TLMDTO00016(decimal amount)
        {
            this.Amount = amount;
        }

        public TLMDTO00016(string acode, string pono, Nullable<DateTime> adate, Nullable<DateTime> idate, decimal amount, string status, string currency)
        {
            this.ACode = acode;
            this.PONo = pono;
            this.ADate = adate;
            this.IDate = idate;
            this.Amount = amount;
            this.Status = status;
            this.Currency = currency;
        }

        public TLMDTO00016(string pono)
        {
            this.PONo = pono;

        }
        public TLMDTO00016(string poNo, decimal amount, string accountNo, Nullable<DateTime> aDate, Nullable<DateTime> iDate, string status,
                         string toAcctNo, string checkNo, string income, string userNo, string acSign, Nullable<decimal> charges, string acode, string budget, string uniqueId, string sourceBranchCode, string currency, Nullable<decimal> rate, Nullable<DateTime> settlementDate, Nullable<DateTime> refundDate)
        {
            this.PONo = poNo;
            this.Amount = amount;
            this.AccountNo = accountNo;
            this.ADate = aDate;
            this.IDate = iDate;
            this.Status = status;
            this.ToAccountNo = toAcctNo;
            this.CheckNo = checkNo;
            this.Income = income;
            this.UserNo = userNo;
            this.AcSign = acSign;
            this.Charges = charges;
            this.ACode = acode;
            this.Budget = budget;
            this.UniqueId = uniqueId;
            this.SourceBranchCode = sourceBranchCode;
            this.Currency = currency;
            this.Rate = rate;
            this.SettlementDate = settlementDate;
            this.RefundDate = refundDate;
        }

        public TLMDTO00016(string currency, decimal amount)
        {
            this.Currency = currency;
            this.Amount = amount;
        }

        public TLMDTO00016(string currency, decimal amount, string acode, Nullable<DateTime> idate)
        {
            this.Currency = currency;
            this.Amount = amount;
            this.ACode = acode;
            this.IDate = idate;
        }

        //For PO editting by Transfer
        public TLMDTO00016(string poNo,string currency, decimal amount, Nullable<DateTime> idate, string budget)
        {
            this.PONo = poNo;
            this.Currency = currency;
            this.Amount = amount;
            this.IDate = idate;
            this.Budget = budget;
        }

        public string PONo { get; set; }
        public decimal Amount { get; set; }
        public string AccountNo { get; set; }
        public Nullable<DateTime> ADate { get; set; } //Register Date
        public Nullable<DateTime> IDate { get; set; } //Refund Date
        public string Status { get; set; }
        public string ToAccountNo { get; set; }
        public string CheckNo { get; set; }
        public string Income { get; set; }
        public string UserNo { get; set; }
        public string AcSign { get; set; }
        public Nullable<decimal> Charges { get; set; }
        public string ACode { get; set; }
        public string Budget { get; set; }
        public string UniqueId { get; set; }
        public string SourceBranchCode { get; set; }
        public string Currency { get; set; }
        public byte[] BankLogo { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string CustomerName { get; set; }
        public bool IsCOAAccount { get; set; }
        public string VoucherNo { get; set; }
        public string ChequeOne { get; set; }
        public string ChequeTwo { get; set; }
        public string ChequeThree { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<DateTime> SettlementDate { get; set; }
        public Nullable<DateTime> RefundDate { get; set; }
        public string CreditAcode { get; set; }

        public virtual TLMDTO00015 CashDenoDTO { get; set; }
        public virtual TLMDTO00009 DepoDenoDTO { get; set; }
        public virtual string Channel { get; set; }
        public virtual string GroupNo { get; set; }
        public virtual string Tlf_ENo { get; set; }
        public virtual decimal OldAmount { get; set; }
        public virtual decimal OldCharges { get; set; }

    }
}
