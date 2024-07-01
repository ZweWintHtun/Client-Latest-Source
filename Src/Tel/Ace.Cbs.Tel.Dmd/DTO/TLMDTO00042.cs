using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Tel.Dmd
{
    [Serializable]
    public class TLMDTO00042 : Supportfields<TLMDTO00042>
    {
        public TLMDTO00042() { }

        public TLMDTO00042(string poNo , decimal amount , decimal charges , string currency,string sourceBranch) 
        {
            this.PONo = poNo;
            this.Amount = amount;
            this.Charges = charges;
            this.Currency = currency;
            this.SourceBranch = sourceBranch;
        }

        public virtual string PONo { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual decimal Charges { get; set; }
        public virtual decimal AdjustAmount { get; set; }
        public virtual string Currency { get; set; }
        public virtual string RegisterNo { get; set; }
        public virtual string SourceBranch { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string CounterNo { get; set; }
    }
}
