using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// Type Of Advance DTO Entity
    /// </summary>
    /// 
    [Serializable]
    public class LOMDTO00002 : Supportfields<LOMDTO00002>
    {
        public LOMDTO00002() { }

                                //Id,Code,Description,Active,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,TS
        public LOMDTO00002(string code, string description, bool active, DateTime createdDate, int createdUserId, Nullable<DateTime> updatedDate, Nullable<int> updatedUserId, byte[] ts)
        {            
            this.Code = code;
            this.Description = description;
            this.Active = active;
            this.TS = ts;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public LOMDTO00002(string code, string description, bool active, byte[] ts, DateTime createdDate, int createdUserId, DateTime updatedDate, int updatedUserId)
        {            
            this.Code = code;
            this.Description = description;
            this.Active = active;
            this.TS = ts;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public LOMDTO00002(string code, string description)
        {
            this.Code = code;
            this.Description = description;
        }

        
        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsCheck { get; set; }
        public virtual string SourceBranchCode { get; set; }
    }
}
