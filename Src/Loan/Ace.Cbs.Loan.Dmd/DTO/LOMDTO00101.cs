using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// Business DTO Entity
    /// </summary>
    /// 
    [Serializable]
    public class LOMDTO00101 : Supportfields<LOMDTO00101>
    {
         public LOMDTO00101() { }

                                //Id,Code,Description,Active,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,TS
        public LOMDTO00101(string code, string description, bool active, DateTime createdDate, int createdUserId, Nullable<DateTime> updatedDate, Nullable<int> updatedUserId, byte[] ts)
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

        public LOMDTO00101(string code, string description, bool active, byte[] ts, DateTime createdDate, int createdUserId, DateTime updatedDate, int updatedUserId)
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

        public LOMDTO00101(string code, string description)
        {
            this.Code = code;
            this.Description = description;
        }

        public LOMDTO00101(string code, string description,string glAcode, bool active, DateTime createdDate, int createdUserId, Nullable<DateTime> updatedDate, Nullable<int> updatedUserId, byte[] ts)
        {
            this.Code = code;
            this.Description = description;
            this.RelatedGLACode = glAcode;
            this.Active = active;
            this.TS = ts;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public LOMDTO00101(string code, string description, string glAcode, bool active, byte[] ts, DateTime createdDate, int createdUserId, DateTime updatedDate, int updatedUserId)
        {
            this.Code = code;
            this.Description = description;
            this.RelatedGLACode = glAcode;
            this.Active = active;
            this.TS = ts;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public LOMDTO00101(string code, string description, string glAcode)
        {
            this.Code = code;
            this.Description = description;
            this.RelatedGLACode = glAcode;
        }
        //public virtual int Id { get; set; } 
        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsCheck { get; set; }

        public virtual string RelatedGLACode { get; set; }
    }
}
