using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// Hire Purchase Stock Group DTO Entity
    /// </summary>
    /// 
    [Serializable]
    public class LOMDTO00068 : Supportfields<LOMDTO00068>
    {
        public LOMDTO00068() { }

        public LOMDTO00068(string groupCode, string description, string prefix, bool active, byte[] ts, DateTime createdDate, int createdUserId, DateTime updatedDate, int updatedUserId)
        {
            this.GroupCode = groupCode;
            this.Description = description;
            this.PreFix = prefix;
            this.Active = active;
            this.TS = ts;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public LOMDTO00068(string groupCode, string description, string prefix)
        {
            this.GroupCode = groupCode;
            this.Description = description;
            this.PreFix = prefix;
        }

        public virtual string GroupCode { get; set; }
        public virtual string Description { get; set; }
        public virtual string PreFix { get; set; }
        public virtual bool IsCheck { get; set; }
    }
}
