using System.Collections.Generic;
using Ace.Windows.Core.DataModel;
using System;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Account Type DTO Object
    /// </summary>
    [System.Serializable]
    public class PFMDTO00015 : EntityBase<PFMDTO00015>
    {
        public PFMDTO00015()
        {
            this.UpdatedDate = new System.Nullable<DateTime>();
            this.UpdatedUserId = new System.Nullable<int>();
        }

        public PFMDTO00015(string code, string description)
        {
            this.Code = code;
            this.Description = description;
        }

        public PFMDTO00015(int id, string code, string description, string symbol)
        {
            this.Id = id;
            this.Code = code;
            this.Description = description;
            this.Symbol = symbol;
        }

        public PFMDTO00015(int id, string code, string description, string symbol, bool active, byte[] tS, int createdUserId, DateTime createdDate, System.Nullable<int> updatedUserId, System.Nullable<DateTime> updatedDate)
        {
            this.Id = id;
            this.Code = code;
            this.Description = description;
            this.Symbol = symbol;
            this.Active = active;
            this.TS = tS;
            this.CreatedUserId = createdUserId;
            this.CreatedDate = createdDate;
            this.UpdatedUserId = updatedUserId;
            this.UpdatedDate = updatedDate;
        }

        //Id,Code,Description,Symbol,Active,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,TS
        public PFMDTO00015(int id, string code, string description, string symbol, bool active, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId, byte[] tS)
        {
            this.Id = id;
            this.Code = code;
            this.Description = description;
            this.Symbol = symbol;
            this.Active = active;
            this.TS = tS;
            this.CreatedUserId = createdUserId;
            this.CreatedDate = createdDate;
            this.UpdatedUserId = updatedUserId;
            this.UpdatedDate = updatedDate;
        }

        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
        public virtual string Symbol { get; set; }
        public virtual bool IsCheck { get; set; }
        public virtual IList<PFMORM00022> SubAccountTypes { get; set; }
    }
}