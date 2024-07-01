using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMDTO00312 : Supportfields<LOMDTO00312>
    {
        public LOMDTO00312() { }

        public virtual string PLNO { get; set; }
        public virtual int TermNo { get; set; }
        public virtual decimal InstallmentAmount { get; set; }
        public virtual decimal RemainingCapital { get; set; }
        public virtual decimal InterestRate { get; set; }
        public virtual decimal InterestAmount { get; set; }
        public virtual decimal InterestAmountPerDay { get; set; }
        public virtual DateTime InterestDate { get; set; }
        public virtual decimal TotalInterestAmount { get; set; }
        public virtual DateTime PaidDate { get; set; }
        public virtual DateTime DueDate { get; set; }
        public virtual DateTime AutoPayDate { get; set; }//Added by HWKO (02-Oct-2017)
        public virtual string Status { get; set; }
        public virtual decimal ODAmount { get; set; }
        public virtual string Acctno { get; set; }
        public virtual decimal TotalLateFees { get; set; }
        public virtual decimal LastInt { get; set; }
        public virtual DateTime LastDate { get; set; }
        public virtual DateTime LatefeesPaidDate { get; set; }
        public virtual string UserNo { get; set; }
        public virtual bool ReverseStatus { get; set; }
        public virtual DateTime RegDueDate { get; set; }
        public virtual bool Manual_Status { get; set; }
        public virtual string UId { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }

    }
}
