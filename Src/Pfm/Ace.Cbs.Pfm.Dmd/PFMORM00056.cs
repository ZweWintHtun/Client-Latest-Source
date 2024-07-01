using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Sys001 ORM Entity.
    /// </summary>
    [Serializable]
    public class PFMORM00056 : EntityBase<PFMORM00056>
    {
        public PFMORM00056() { }

        //public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string SysMonYear { get; set; }
        public virtual string Status { get; set; }
        public virtual System.Nullable<DateTime> SysDate { get; set; }
        public virtual string SysQty { get; set; }
        public virtual string BranchCode { get; set; }
    }
}
