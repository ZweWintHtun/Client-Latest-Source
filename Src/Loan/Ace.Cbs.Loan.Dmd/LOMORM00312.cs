using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMORM00312 : Supportfields<LOMORM00312>
    {
        public LOMORM00312() { }

        public virtual string PLNO { get; set; }
        public virtual int TermNo { get; set; }
        public virtual Nullable<decimal> InstallmentAmount { get; set; }
        public virtual Nullable<decimal> RemainingCapital { get; set; }
        public virtual Nullable<decimal> InterestRate { get; set; }
        public virtual Nullable<decimal> InterestAmount { get; set; }
        public virtual Nullable<decimal> InterestAmountPerDay { get; set; }
        public virtual Nullable<DateTime> InterestDate { get; set; }
        public virtual Nullable<decimal> TotalInterestAmount { get; set; }
        public virtual Nullable<DateTime> PaidDate { get; set; }
        public virtual Nullable<DateTime> DueDate { get; set; }
        public virtual Nullable<DateTime> AutoPayDate { get; set; }//Added by HWKO (02-Oct-2017)
        public virtual string Status { get; set; }
        public virtual Nullable<decimal> ODAmount { get; set; }
        public virtual string Acctno { get; set; }
        public virtual Nullable<decimal> TotalLateFees { get; set; }
        public virtual Nullable<decimal> LastInt { get; set; }
        public virtual Nullable<DateTime> LastDate { get; set; }
        public virtual Nullable<DateTime> LatefeesPaidDate { get; set; }
        public virtual string UserNo { get; set; }
        public virtual bool ReverseStatus { get; set; }
        public virtual Nullable<DateTime> RegDueDate { get; set; }
        public virtual bool Manual_Status { get; set; }
        public virtual string UId { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }
    }
}
