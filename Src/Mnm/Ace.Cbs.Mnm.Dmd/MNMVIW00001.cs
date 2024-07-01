using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
    [Serializable]
    public class MNMVIW00001 : EntityBase<MNMVIW00001>
    {
        public MNMVIW00001()
        {
        }
        public virtual string ACODE { get; set; }
        public virtual string Status_Letter_One { get; set; }
        public virtual string SOURCECUR { get; set; }
        public virtual string SOURCEBR { get; set; }
        public virtual string WorkStation { get; set; }
        public virtual System.Nullable<DateTime> DATE_TIME { get; set; }
        public virtual string CheckTime { get; set; }
        public virtual decimal LocalAmt { get; set; }
        public virtual decimal HomeAmt { get; set; }
        public virtual decimal LocalOAmt { get; set; }
        public virtual decimal HomeOAmt { get; set; }
        public virtual decimal Clearing_Amount { get; set; }
        public virtual decimal Clearing_HomeAmount { get; set; }
        public virtual decimal Cash_LocalAmt { get; set; }
        public virtual decimal Cash_HomeAmt { get; set; }

    }
    

}
