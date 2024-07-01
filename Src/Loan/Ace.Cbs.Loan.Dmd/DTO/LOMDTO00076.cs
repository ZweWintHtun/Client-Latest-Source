using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// LSBusiness DTO Entity
    /// </summary>
    [Serializable]
    public class LOMDTO00076 : Supportfields<LOMDTO00076>
    {
        public LOMDTO00076() { }

        public LOMDTO00076(string code, string description, string userNo, Nullable<DateTime> date_Time, bool active, byte[] ts, DateTime createdDate, int createdUserId, Nullable<DateTime> updatedDate, Nullable<int> updatedUserId)
        {            
            this.Code = code;
            this.Description = description;
            this.UserNo = userNo;
            this.Date_Time = date_Time;
            this.Active = active;
            this.TS = ts;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;            
        }

        public LOMDTO00076(string code, string description, string userNo, Nullable<DateTime> date_Time, bool active, DateTime createdDate, int createdUserId, Nullable<DateTime> updatedDate, Nullable<int> updatedUserId)
        {
            this.Code = code;
            this.Description = description;
            this.UserNo = userNo;
            this.Date_Time = date_Time;
            this.Active = active;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public LOMDTO00076(string code, string description, string userNo, Nullable<DateTime> date_Time)
        {
            this.Code = code;
            this.Description = description;
            this.UserNo = userNo;
            this.Date_Time = date_Time;
        }

        public LOMDTO00076(string code, string description)
        {
            this.Code = code;
            this.Description = description;
        }

        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
        public virtual string UserNo { get; set; }
        public bool IsCheck { get; set; }
        public virtual Nullable<DateTime> Date_Time { get; set; }
    }
}
