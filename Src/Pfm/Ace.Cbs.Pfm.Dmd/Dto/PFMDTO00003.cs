using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    // Initial dto
    [Serializable]
    public class PFMDTO00003 : Supportfields<PFMDTO00003>
    {
        public PFMDTO00003() { }

        public PFMDTO00003(string initial, string description) 
        {
            this.Initial = initial;
            this.Description = description;
        }

                                //Initial,Description,Active,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,TS
        public PFMDTO00003(string initial, string description, bool active, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId, byte[] tS)
        {
            this.Initial = initial;
            this.Description = description;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public PFMDTO00003(string initial, string description, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
        {
            this.Initial = initial;
            this.Description = description;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public PFMDTO00003(string initial, string description, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId,string userName)
        {
            this.Initial = initial;
            this.Description = description;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
            this.UserName = userName;
        }

        // Primary key
        public virtual string Initial { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsCheck { get; set; }	
    }
}