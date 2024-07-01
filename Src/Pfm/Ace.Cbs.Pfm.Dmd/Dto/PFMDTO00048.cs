using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Message DTO Entity
    /// </summary>
    [Serializable]
    public class PFMDTO00048 : Supportfields<PFMDTO00048>
    {
        public PFMDTO00048() { }

                                //Code,Description,Active,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,TS
        public PFMDTO00048(string code, string description, bool active, DateTime createdDate, int createdUserId, Nullable<DateTime> updatedDate, Nullable<int> updatedUserId, byte[] ts)
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

        public PFMDTO00048(string code, string description, bool active, byte[] ts, DateTime createdDate, int createdUserId, DateTime updatedDate, int updatedUserId)
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

        public PFMDTO00048(string code, string description)
        {
            this.Code = code;
            this.Description = description;
        }

        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsCheck { get; set; }
    }
}