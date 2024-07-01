using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    public class PFMORM00036 : EntityBase<PFMORM00036>
    {
        public PFMORM00036() { }
        public virtual string CurrencyCode { get; set; }
        public virtual Nullable<DateTime> Date_Time { get; set; }
        public virtual Nullable<decimal> Balance { get; set; }
        public virtual Nullable<decimal> HomeAmount { get; set; }
        public virtual string SourceBranchCode { get; set; }
    }
}