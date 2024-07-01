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
    public class LOMDTO00071 : Supportfields<LOMDTO00071>
    {
        public LOMDTO00071() { }

         public LOMDTO00071(string code, string description,string userNo,DateTime dateTime,bool active,byte[] ts, DateTime createdDate, int createdUserId, Nullable<DateTime> updatedDate, Nullable<int> updatedUserId)
        {            
            this.Code = code;
            this.Description = description;
            this.USERNO = userNo;
            this.DATE_TIME = dateTime;
            this.Active = active;
            this.TS = ts;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }
         public LOMDTO00071(string code, string description, bool active, byte[] ts, DateTime createdDate, int createdUserId, DateTime updatedDate, int updatedUserId)
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

        public LOMDTO00071(string code, string description)
        {
            this.Code = code;
            this.Description = description;
        }        
        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsCheck { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual string USERNO { get; set; }
        public virtual DateTime DATE_TIME { get; set; }
    }
}
