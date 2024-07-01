//----------------------------------------------------------------------
// <copyright file="TLMDTO00008.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>AK</CreatedUser>
// <CreatedDate>2013-05-22</CreatedDate>
// <UpdatedUser>Nyo Me San</UpdatedUser>
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
    public class TLMDTO00038 : Supportfields<TLMDTO00038>
    {
        public TLMDTO00038() { }

        public virtual int SerialNo { get; set; }
        public virtual string Currency { get; set; }
        public virtual string ACode { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual decimal CurrentBalance { get; set; }
        public virtual string Name { get; set; }
        public virtual string NRC { get; set; }
        public virtual string Narration { get; set; }
        public virtual string FromBranchCode { get; set; }
        public virtual string BranchCode { get; set; }
        public virtual string DenoString { get; set; }
        public virtual string RefundString { get; set; }
        public virtual string Description { get; set; }
        public virtual string ChequeNo { get; set; }
        public virtual string DenoRate { get; set; }
        public virtual string AllDenoRate { get; set; }
        public virtual string RefundRate { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual decimal NetAmount { get; set; }
        public virtual decimal OverdraftAmount { get; set; }
        public virtual decimal TotalAmount { get; set; }
        public virtual decimal TotalCharges { get; set; }
        public virtual decimal AdjustAmount { get; set; }
        public virtual string CounterNo { get; set; }
        public virtual string Channel { get; set; }
        public virtual bool IsCurrentAccount { get; set; }
        public virtual bool IsIncomeByCash { get; set; }
        public virtual bool IsIncomeByTransfer { get; set; }
        public virtual bool IsDebit { get; set; }
        public virtual bool IsCredit { get; set; }
        public virtual bool IsVIP { get; set; }
        public virtual string VoucherType { get; set; }
        public virtual string AccountSign { get; set; }
        public virtual bool IsAutoLink { get; set; }
        public virtual bool IsCheckGridview { get; set; }
        public virtual bool IsCheckCustomAccountValidation { get; set; }
        public virtual string CommissionAccount { get; set; }
        public virtual string CommunicationAccount { get; set; }
        public virtual string IBSAccount { get; set; }
        public virtual decimal LinkAmount { get; set; }
        public virtual decimal CommunicationCharges { get; set; }
        public virtual decimal Commissions { get; set; }
        public virtual Nullable<decimal> HomeExchangeRate { get; set; }
        public virtual bool IsPrintTransaction { get; set; }
        public virtual Nullable<DateTime> NextSettlementDate { get; set; }
        public virtual int NoOfPersonSign { get; set; }
        public virtual string JoinType { get; set; }
        public virtual bool AllowedPrinting { get; set; }
        public virtual bool IsDomesticAccount { get; set; }
        public virtual string SourceBranch { get; set; }
        public virtual string ToCurrency { get; set; }
        public virtual decimal CurrentBal { get; set; }
        public virtual decimal TransactionCount { get; set; }
        public virtual int PrintLineNo { get; set; }

        //Added by HWKO (05-Dec-2017) // For Transfer voucher printing
        public virtual string AmountInWords { get; set; }
        public virtual string DrAcctForCr { get; set; }
        public virtual string CrAcctForDr { get; set; }

        //Added by HMW (25-Mar-2019)// For Seperating EOD: Checking Settlement Date based on System Start Date for all backdate TXNs
        public virtual Nullable<DateTime> SystemStartupDate { get; set; }
        public virtual Nullable<DateTime> LastSettlementDate { get; set; }
        public virtual DateTime TransactionDate { get; set; }
    }
}
