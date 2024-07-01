using System;
using System.Collections.Generic;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
    [Serializable]
    public class MNMDTO00077 : EntityBase<MNMDTO00077>
    {
      public MNMDTO00077() { }


      public MNMDTO00077(string acctno, string rNo, DateTime rDate, string desp, DateTime mDate, decimal amount, string renstat, string toaccountno,string cur)
       {
         this.AccountNo = acctno;
         this.ReceiptNo = rNo;
         this.RDate = rDate;
         this.Desp = desp;
         this.MatureDate = mDate;
        this.Amount = amount;
        this.Renstat = renstat;
        this.ToAccountNo = toaccountno;
        this.CurrencyCode = cur;
        
       }

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
        public virtual string JoinType { get; set; }
        public virtual string UserNo { get; set; }
        public virtual System.Nullable<DateTime> RDate { get; set; }
        public virtual string Status { get; set; }

        public virtual string CurrencyCode { get; set; } 
        public virtual string SourceBranchCode { get; set; }
        public virtual string ToAccountNo { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual bool AutoRenewal { get; set; }
        public bool IsMainMenu { get; set; }
        public bool IsReversalTransaction { get; set; }

        public virtual string DebitAccountNo { get; set; }
        public virtual string CreditAccountNo { get; set; }
        public virtual string ChequeNo { get; set; }
        public virtual decimal AccuredInterest { get; set; }
        public virtual string Nrc { get; set; }
        public virtual string Name { get; set; }

        public virtual string OldReceiptNo { get; set; }

        public virtual string TownshipCode { get; set; }
        public virtual string TownshipDescription { get; set; }
        public virtual string DurationTime { get; set; }
        public virtual string Address { get; set; }
        public virtual bool IsCheck { get; set; }
        public virtual string Description { get; set; }
        public virtual System.Nullable<DateTime> LastAccruedDate { get; set; }
        public virtual string Desp { get; set; }
        public virtual DateTime MatureDate { get; set; }
        public virtual string Renstat { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual System.Nullable<decimal> ClosingBalance { get; set; }



    }
}
