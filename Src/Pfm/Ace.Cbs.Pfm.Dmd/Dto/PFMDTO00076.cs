using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Counter DTO Entity
    /// </summary>
    [Serializable]
    public class PFMDTO00076 : EntityBase<PFMDTO00076>
    {
        public PFMDTO00076() { }

        public PFMDTO00076(string branchCode, string physicalAddress, bool isAlwaysValid, DateTime validStartDate, DateTime validEndDate, bool isNeedInstallerUpdate) 
        {
            this.BranchCode = branchCode;
            this.CounterPhysicalAddress = physicalAddress;
            this.IsAlwaysValid = isAlwaysValid;
            this.ValidStartDate = validStartDate;
            this.ValidEndDate = validEndDate;
            this.IsNeedInstallerUpdate = isNeedInstallerUpdate;
        }

        public virtual string BranchCode { get; set; }
        public virtual string CounterPhysicalAddress { get; set; }
        public virtual bool IsAlwaysValid { get; set; }
        public virtual Nullable<DateTime> ValidStartDate { get; set; }
        public virtual Nullable<DateTime> ValidEndDate { get; set; }
        public virtual bool IsNeedInstallerUpdate { get; set; }
    }
}