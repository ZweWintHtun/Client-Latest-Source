using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Sam.Dmd
{
    // NRCCode dto
    [Serializable]
    public class SAMDTO00054 : Supportfields<SAMDTO00054>
    {
        public SAMDTO00054() { }

        public SAMDTO00054(string TownshipCode, string TownshipDesp, string StateCode)
        {
            this.TownshipCode = TownshipCode;
            this.TownshipDesp = TownshipDesp;
            this.StateCode = StateCode;
        }

        public SAMDTO00054(int Id, string TownshipCode, string TownshipDesp, string StateCode, bool active, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId, byte[] tS)
        {
            this.Id = Id;
            this.TownshipCode = TownshipCode;
            this.TownshipDesp = TownshipDesp;
            this.StateCode = StateCode;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }


        public SAMDTO00054(int Id, string TownshipCode, string TownshipDesp, string StateCode, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
        {
            this.Id = Id;
            this.TownshipCode = TownshipCode;
            this.TownshipDesp = TownshipDesp;
            this.StateCode = StateCode;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        //primary key
        public virtual int Id { get; set; }
        public virtual string TownshipCode { get; set; }
        public virtual string TownshipDesp { get; set; }
        public virtual string StateCode { get; set; }
        public virtual bool IsCheck { get; set; }


    }
}
