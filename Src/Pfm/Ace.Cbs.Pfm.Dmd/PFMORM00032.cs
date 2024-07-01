using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    // FReceipt entity
    [Serializable]
    public class PFMORM00032 : EntityBase<PFMORM00032>
    {
        public PFMORM00032() { }
        public virtual string ReceiptNo { get; set; }
        
        public virtual decimal Amount { get; set; }
        public virtual decimal Duration { get; set; }
        public virtual System.Nullable<DateTime> WithdrawDate { get; set; }
        public virtual System.Nullable<DateTime> LastInterestDate { get; set; }
        public virtual int PrintTime { get; set; }
        public virtual decimal LastPrintBalance { get; set; }
        public virtual decimal BudgetEndAccount { get; set; }
        public virtual decimal BudgetEndTax { get; set; }
        public virtual decimal Accrued { get; set; }
        public virtual decimal DebitAccrued { get; set; }
        public virtual string AuthorizedPerson { get; set; }
        public virtual string AccountSign { get; set; }
        public virtual decimal InterestRate { get; set; }
        public virtual string AccuredStatus { get; set; }
        public virtual string FirstReceiptNo { get; set; }
        public virtual string UserNo { get; set; }
        public virtual System.Nullable<DateTime> RDate { get; set; }

        public virtual string CurrencyCode { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual string ToAccountNo { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual System.Nullable<DateTime> LastAccruedDate { get; set; }
    }
}