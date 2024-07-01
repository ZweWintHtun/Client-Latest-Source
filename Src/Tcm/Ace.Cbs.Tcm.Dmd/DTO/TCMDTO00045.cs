using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Tcm.Dmd
{
     [Serializable]
    public class TCMDTO00045:Supportfields<TCMDTO00045>
    {
        public TCMDTO00045() { }
        public TCMDTO00045(string column1, string column2, string column3)
        {
            this.Column_1 = column1;
            this.Column_2 = column2;
            this.Column_3 = column3;
        }
        public TCMDTO00045(string column1, string column2, string column3,DateTime closeDate)
        {
            this.Column_1 = column1;
            this.Column_2 = column2;
            this.Column_3 = column3;
            this.CloseDate = closeDate;
        }

        public virtual string Column_1 { get; set; }
        public virtual string Column_2 { get; set; }
        public virtual string Column_3 { get; set; }
        public virtual string AccountType { get; set; }
        public virtual int AccountCount { get; set; }
        public virtual string LoansNo { get; set; }
        public virtual string LoansAccountNo { get; set; }

        public virtual string AccountNo { get; set; }
        public virtual decimal OverdraftLimit { get; set; }
        //public virtual System.Nullable<DateTime> LastCalculateDate { get; set; }
        public virtual string LastCalculateDate { get; set; }
        public virtual decimal Rate { get; set; }
        public virtual decimal InterestOfLastDate { get; set; }
        public virtual decimal InterestMonth1 { get; set; }
        public virtual decimal InterestMonth2 { get; set; }
        public virtual decimal InterestMonth3 { get; set; }
        public virtual decimal InterestTotal { get; set; }
        public virtual string BranchCode { get; set; }
        public virtual Nullable<DateTime> CloseDate { get; set; }
        
        
    }
}
