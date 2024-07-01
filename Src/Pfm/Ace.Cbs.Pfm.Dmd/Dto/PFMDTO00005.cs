using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    // township code dto
    [Serializable]
    public class PFMDTO00005 : Supportfields<PFMDTO00005>
    {
        public PFMDTO00005() { }

        public PFMDTO00005(string code, string description) 
        {
            this.TownshipCode = code;
            this.Description = description;
        }

        public PFMDTO00005(string code, byte[] timestamp, string description, string userNo, DateTime dateTime, DateTime editDateTime, string editUser, decimal editType, bool active, DateTime createdDate, int createdUserId, Nullable<DateTime> updatedDate, int updatedUserId)
        {
            this.TownshipCode = code;
            this.TS = timestamp;
            this.Description = description;
            this.UserNo = userNo;
            this.Date_Time = dateTime;
            this.EditDate_Time = editDateTime;
            this.EditUser = editUser;
            this.Edit_Type = editType;
            this.Active = active;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }
        public PFMDTO00005(string code, string description, string userNo, DateTime dateTime, DateTime editDateTime, string editUser, decimal editType)
        {
            this.TownshipCode = code;
            this.Description = description;
            this.UserNo = userNo;
            this.Date_Time = dateTime;
            this.EditDate_Time = editDateTime;
            this.EditUser = editUser;
            this.Edit_Type = editType;
        }
        public string TownshipCode { get; set; }
        public string Description { get; set; }
        public string UserNo { get; set; }
        public System.Nullable<DateTime> Date_Time { get; set; }
        public System.Nullable<DateTime> EditDate_Time { get; set; }
        public string EditUser { get; set; }
        public System.Nullable<decimal> Edit_Type { get; set; }
        public bool IsCheck { get; set; }

    }
}