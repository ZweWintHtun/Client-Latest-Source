using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    // State Code dto
    [Serializable]
    public class PFMDTO00013 : Supportfields<PFMDTO00013>
    {
        public PFMDTO00013() { }

        public PFMDTO00013(string code, string description) 
        {
            this.StateCode = code;
            this.Description = description;
        }

        public PFMDTO00013(string stateCode, string desp, string uSERNO, System.Nullable<DateTime> dATE_TIME, System.Nullable<DateTime> eDITDATE_TIME, string eDITUSER, System.Nullable<decimal> eDITTYPE)
        {
            this.StateCode = stateCode;
            this.Description = desp;
            this.UserNo = uSERNO;
            this.Date_Time = dATE_TIME;
            this.EditDate_Time = eDITDATE_TIME;
            this.EditUser = eDITUSER;
            this.EditType = eDITTYPE;
        }

        public PFMDTO00013(string stateCode, string desp, string uSERNO, System.Nullable<DateTime> dATE_TIME, System.Nullable<DateTime> eDITDATE_TIME, string eDITUSER, System.Nullable<decimal> eDITTYPE, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
        {
            this.StateCode = stateCode;
            this.Description = desp;
            this.UserNo = uSERNO;
            this.Date_Time = dATE_TIME;
            this.EditDate_Time = eDITDATE_TIME;
            this.EditUser = eDITUSER;
            this.EditType = eDITTYPE;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public virtual string StateCode { get; set; }
        public virtual string Description { get; set; }
        public virtual string UserNo { get; set; }
        public virtual System.Nullable<DateTime> Date_Time { get; set; }
        public virtual System.Nullable<DateTime> EditDate_Time { get; set; }
        public virtual string EditUser { get; set; }
        public virtual System.Nullable<decimal> EditType { get; set; }
        public virtual bool IsCheck { get; set; }
    }
}