using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;


namespace Ace.Cbs.Sam.Dmd
{
    // Nationality_Code dto
    [Serializable]
    public class SAMDTO00053 : Supportfields<SAMDTO00053>
    {
        public SAMDTO00053() { }

        public SAMDTO00053(string code, string description) 
        {
            this.Nationality_Code = code;
            this.Description = description;
        }

        public SAMDTO00053(string nationalityCode, string desp, string uSERNO, DateTime dATE_TIME, DateTime eDITDATE_TIME, string eDITUSER, decimal eDITTYPE, bool dEFAULTS)
        {
            this.Nationality_Code = nationalityCode;
            this.Description = desp;
            this.UserNo = uSERNO;
            this.Date_Time = dATE_TIME;
            this.EditDate_Time = eDITDATE_TIME;
            this.EditUser = eDITUSER;
            this.EditType = eDITTYPE;
            this.Defaults = dEFAULTS;
        }

        //NationalityCode,Desp,USERNO,DATE_TIME,EDITDATE_TIME,EDITUSER,EDITTYPE,DEFAULTS,Active,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId
        public SAMDTO00053(string nationalityCode, string desp, string uSERNO, Nullable<DateTime> dATE_TIME, Nullable<DateTime> eDITDATE_TIME, string eDITUSER, Nullable<decimal> eDITTYPE,
            Nullable<bool> dEFAULTS, bool active, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId, byte[] tS)
        {
            this.Nationality_Code = nationalityCode;
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

        
        public SAMDTO00053(string nationalityCode, string desp, string uSERNO, Nullable<DateTime> dATE_TIME, Nullable<DateTime> eDITDATE_TIME, string eDITUSER, Nullable<decimal> eDITTYPE, Nullable<bool> dEFAULTS, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
        {
            this.Nationality_Code = nationalityCode;
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


        //primary key
        public virtual string Nationality_Code { get; set; }

        public virtual string Description { get; set; }
        public virtual string UserNo { get; set; }
        public virtual System.Nullable<DateTime> Date_Time { get; set; }
        public virtual System.Nullable<DateTime> EditDate_Time { get; set; }
        public virtual string EditUser { get; set; }
        public virtual System.Nullable<decimal> EditType { get; set; }
        public virtual System.Nullable<bool> Defaults { get; set; }
        public virtual bool IsCheck { get; set; }


    }
}
