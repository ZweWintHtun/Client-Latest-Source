using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
    [Serializable]
    public class MNMVIW00071 : Supportfields<MNMVIW00071>
    {
        public MNMVIW00071() { }

        public virtual int Id { get; set; }        
        public virtual string AccountNo { get; set; }
        public virtual string AccountSignature { get; set; }
        public virtual Nullable<DateTime> CloseDate { get; set; }
        public virtual string Status { get; set; }
        public virtual string Budget { get; set; }
        public virtual decimal LastInt { get; set; }
        public virtual Nullable<decimal> AccruedInt { get; set; }
        public virtual decimal Month1 { get; set; }
        public virtual decimal Month2 { get; set; }
        public virtual decimal Month3 { get; set; }
        public virtual decimal Month4 { get; set; }
        public virtual decimal Month5 { get; set; }
        public virtual decimal Month6 { get; set; }
        public virtual decimal Month7 { get; set; }
        public virtual decimal Month8 { get; set; }
        public virtual decimal Month9 { get; set; }
        public virtual decimal Month10 { get; set; }
        public virtual decimal Month11 { get; set; }
        public virtual decimal Month12 { get; set; }

        public virtual string SourceBranchCode { get; set; }
        public virtual Nullable<DateTime> DATE_TIME { get; set; }
        public virtual string CurrencyCode { get; set; }
        public virtual Nullable<decimal> Amount { get; set; }
        public virtual string ACNAME { get; set; }

    }
}
