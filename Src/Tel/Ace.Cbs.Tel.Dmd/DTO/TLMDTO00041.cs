//----------------------------------------------------------------------
// <copyright file="TLMDTO00041.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San </CreatedUser>
// <CreatedDate></CreatedDate>
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
    [Serializable]
    // Fixed Deposit DTO
    public class TLMDTO00041 : Supportfields<TLMDTO00041>   {
      

        public TLMDTO00041() { }
        public virtual string ReceiptNo { get; set; } 
        public virtual string AccountNo { get; set; }             
        public virtual string RegisterDuration { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual string Acode { get; set; }
        public virtual string Narration { get; set; }
        public virtual string Description { get; set; }
        public virtual string Status { get; set; }
        public virtual string TranscationCode { get; set; }
        public virtual string Channel { get; set; }
        public virtual string DenoDetail { get; set; }
        public virtual string DenoRate { get; set; }
        public virtual string DenoRefundDetail { get; set; }
        public virtual string DenoRefundRate { get; set; }
        public virtual string CounterNo { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual string CashStatus { get; set; }
        public virtual DateTime SettlementDate { get; set; }
        public virtual decimal Rate { get; set; }
        public virtual string CurrencyCode { get; set; }
        public virtual decimal HomeAmount { get; set; }
        public virtual decimal HomeAmt { get; set; }
        public virtual decimal LocalAmount { get; set; }
        public virtual decimal LocalAmt { get; set; }
        public virtual string PaymentOrderNo { get; set; }
        public virtual string BudgetYear { get; set; }
        public virtual string ReferenceType { get; set; }
        public virtual string RegisterNo { get; set; }
        public virtual decimal TotalAmount { get; set; }
        public virtual string VoucherNo { get; set; }
        public virtual string RegisterDate { get; set; }
        public virtual decimal AvailableInterestAfterTax { get; set; }       
        public virtual decimal NoOfPersonSign { get; set; }      
        public virtual string CustomerId { get; set; }
        public virtual string Name { get; set; }
        public virtual string NRC { get; set; }
        public virtual string JoinType { get; set; }
        public virtual byte[] Image { get; set; }
        public virtual byte[] Signature { get; set; }
        public virtual string AccountSignature { get; set; }
        public virtual string UserNo { get; set; }
        public virtual decimal Duration { get; set; }
        public virtual  string AccuredStatus { get; set; }
        public virtual  DateTime LastIntDate { get; set; }
        public virtual decimal InterestRate { get; set; }
        public virtual decimal Surplus { get; set; }
        public virtual decimal Shortage { get; set; }
        public virtual decimal AdjustAmount { get; set; }
        public virtual string GroupNo { get; set; }
        public virtual decimal Charges { get; set; }
        public virtual bool MultiCheck { get; set; }

    }
}
