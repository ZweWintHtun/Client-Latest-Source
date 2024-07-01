using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{    
    /// <summary>
    /// Counter ORM Entity
    /// </summary>
    [Serializable]
    public class PFMORM00075 : EntityBase<PFMORM00075>
    {
        /// <summary>
        /// Counter ORM Entity
        /// </summary>
        public PFMORM00075() { }

        public virtual string BranchCode { get; set; }
        public virtual string CounterPhysicalAddress { get; set; }
        public virtual bool IsAlwaysValid { get; set; }
        public virtual Nullable<DateTime> ValidStartDate { get; set; }
        public virtual Nullable<DateTime> ValidEndDate { get; set; }
        public virtual bool IsNeedInstallerUpdate { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var t = obj as PFMORM00075;
            if (t == null)
                return false;
            if (BranchCode == t.BranchCode && CounterPhysicalAddress == t.CounterPhysicalAddress)
                return true;
            return false;
        }
        public override int GetHashCode()
        {
            return (BranchCode + "|" + CounterPhysicalAddress).GetHashCode();
        }
    }
}