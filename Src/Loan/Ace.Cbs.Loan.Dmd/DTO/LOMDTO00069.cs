using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// Hire Purchase Stock Sub Item Code Registeration DTO Entity
    /// </summary>
    /// 
    [Serializable]
    public class LOMDTO00069 : Supportfields<LOMDTO00069>
    {
        public LOMDTO00069() { }

        public LOMDTO00069(string groupCode, string subCode, string desp, bool active, byte[] ts, DateTime createdDate, int createdUserId, DateTime updatedDate, int updatedUserId)
        {
            this.GroupCode = groupCode;
            this.SubCode = subCode;
            this.Description = desp;
            this.Active = active;
            this.TS = ts;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public LOMDTO00069(string groupCode, string subCode, string desp)
        {
            this.GroupCode = groupCode;
            this.Description = desp;
            this.SubCode = subCode;
        }

        public virtual string GroupCode { get; set; }
        public virtual string Description { get; set; }
        public virtual string SubCode { get; set; }
        public virtual bool IsCheck { get; set; }
    }
}
