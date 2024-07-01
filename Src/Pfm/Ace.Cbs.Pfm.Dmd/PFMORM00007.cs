using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    // Fixed Rate Entity
    [Serializable]
    public class PFMORM00007 : EntityBase<PFMORM00007>
    {
        public PFMORM00007() { }

        public virtual string Description { get; set; }
        public virtual System.Nullable<DateTime> DATE_TIME { get; set; }
        public virtual System.Nullable<bool> IsLastModify { get; set; }
        public virtual string UserNumber { get; set; }
        public virtual decimal Rate { get; set; }
        public virtual decimal Duration { get; set; }
    }
}