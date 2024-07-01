using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    // Occupation_Code dto
    [Serializable]
    public class PFMDTO00004: Supportfields<PFMDTO00004>
    {
        public PFMDTO00004() { }

        public PFMDTO00004(string code, string description) 
        {
            this.Occupation_Code = code;
            this.Description = description;
        }

        public PFMDTO00004(string occupationCode, string desp, string uSERNO, DateTime dATE_TIME, DateTime eDITDATE_TIME, string eDITUSER, decimal eDITTYPE, bool dEFAULTS)
        {
            this.Occupation_Code = occupationCode;
            this.Description = desp;
            this.UserNo = uSERNO;
            this.Date_Time = dATE_TIME;
            this.EditDate_Time = eDITDATE_TIME;
            this.EditUser = eDITUSER;
            this.EditType = eDITTYPE;
            this.Defaults = dEFAULTS;
        }

        //Occupation_Code,Description,UserNo,Date_Time,EditDate_Time,EditUser,EditType,Defaults,Active,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,TS
        public PFMDTO00004(string occupationCode, string desp, string uSERNO, Nullable<DateTime> dATE_TIME, Nullable<DateTime> eDITDATE_TIME, string eDITUSER, Nullable<decimal> eDITTYPE,
            Nullable<bool> dEFAULTS, bool active, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId, byte[] tS)
        {
            this.Occupation_Code = occupationCode;
            this.Description = desp;
            this.UserNo = uSERNO;
            this.Date_Time = dATE_TIME;
            this.EditDate_Time = eDITDATE_TIME;
            this.EditUser = eDITUSER;
            this.EditType = eDITTYPE;
            this.Defaults = dEFAULTS;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }


        public PFMDTO00004(string occupationCode, string desp, string uSERNO, Nullable<DateTime> dATE_TIME, Nullable<DateTime> eDITDATE_TIME, string eDITUSER, Nullable<decimal> eDITTYPE, Nullable<bool> dEFAULTS, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
        {
            this.Occupation_Code = occupationCode;
            this.Description = desp;
            this.UserNo = uSERNO;
            this.Date_Time = dATE_TIME;
            this.EditDate_Time = eDITDATE_TIME;
            this.EditUser = eDITUSER;
            this.EditType = eDITTYPE;
            this.Defaults = dEFAULTS;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public PFMDTO00004(string occupationCode, string desp, string uSERNO, Nullable<DateTime> dATE_TIME, Nullable<DateTime> eDITDATE_TIME, string eDITUSER, Nullable<decimal> eDITTYPE, Nullable<bool> dEFAULTS, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId,string userName)
        {
            this.Occupation_Code = occupationCode;
            this.Description = desp;
            this.UserNo = uSERNO;
            this.Date_Time = dATE_TIME;
            this.EditDate_Time = eDITDATE_TIME;
            this.EditUser = eDITUSER;
            this.EditType = eDITTYPE;
            this.Defaults = dEFAULTS;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
            this.UserNo = userName;
        }
       
        //primary key
        public virtual string Occupation_Code { get; set; }

        public virtual string Description { get; set; }
        public virtual string UserNo { get; set; }
        public virtual System.Nullable<DateTime> Date_Time { get; set; }
        public virtual System.Nullable<DateTime> EditDate_Time { get; set; }
        public virtual string EditUser { get; set; }
        public virtual System.Nullable<decimal> EditType { get; set; }
        public virtual System.Nullable<bool> Defaults { get; set; }
        public virtual bool IsCheck { get; set; }
        public string UserName { get; set; }


    }
}