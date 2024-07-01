//----------------------------------------------------------------------
// <copyright file="TLMDTO00045.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-06-11</CreatedDate>
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
   /// PO Receipt DTO
   /// </summary>
  [Serializable]
   public class TLMDTO00045:Supportfields<TLMDTO00045>
    {
       public TLMDTO00045() { }

        public string Eno { get; set; }
        public string AccountNo { get; set; }
        public decimal Amount { get; set; }
        public string Acode { get; set; }
        public System.Nullable<decimal> HomeAmount { get; set; }
        public System.Nullable<decimal> HomeAmt { get; set; }
        public System.Nullable<decimal> HomeOAmt { get; set; }
        public System.Nullable<decimal> LocalAmount { get; set; }
        public System.Nullable<decimal> LocalAmt { get; set; }
        public System.Nullable<decimal> LocalOAmt { get; set; }
        public string PaymentOrderNo { get; set; }
        public string Description { get; set; }
        public string Narration { get; set; }
        public DateTime DateTime { get; set; }
        public string Status { get; set; }
        public string TransactionCode { get; set; }
        public string UserNo { get; set; }
        public string OtherBank { get; set; }
        public string OtherBankAcctNo { get; set; }
        public string CLRPostStatus { get; set; }
        public string SourceCurrency { get; set; }
        public string SourceBranch { get; set; }
        public System.Nullable<decimal> Rate { get; set; }
        public System.Nullable<DateTime> SettlementDate { get; set; }
        public string Channel { get; set; }
        public string ReferenceType { get; set; }
        public string ReferenceVoucherNo { get; set; }
        public Nullable<DateTime> IssueDate { get; set; }
        public string Budget { get; set; }
        public byte[] Logo { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }





    }
}
