using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// VW_PLRepaymentScheduleListing
    /// Created By HWKO (13-Jul-2017)
    /// </summary>
    ///
    [Serializable]
    public class LOMVIW00316
    {
        public LOMVIW00316() { }
        public virtual int Id { get; set; }
        public virtual string PLNO { get; set; }
        public virtual string ACNo { get; set; }
        public virtual string NAME { get; set; }
        public virtual Nullable<decimal> MonthlyIncome { get; set; }
        public virtual string ADDRESS { get; set; }
        public virtual Nullable<decimal> FirstSAmt { get; set; }
        public virtual decimal IntRate { get; set; }
        public virtual int TermNo { get; set; }
        public virtual Nullable<decimal> InstallmentAmount { get; set; }
        public virtual Nullable<decimal> InterestAmount { get; set; }
        public virtual Nullable<DateTime> DueDate { get; set; }
        public virtual Nullable<DateTime> PaidDate { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual Nullable<decimal> RemainingCapital { get; set; }
        public virtual string PHONE { get; set; }
        public virtual Nullable<DateTime> InterestDate { get; set; }
        public virtual Nullable<decimal> TotalLateFees { get; set; }
        public virtual Nullable<decimal> ODAmount  { get; set; }
        public virtual string Cur { get; set; }
        public virtual string Status { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual decimal LedgerBalance { get; set; }
        public virtual string NRC { get; set; }
    }
}
