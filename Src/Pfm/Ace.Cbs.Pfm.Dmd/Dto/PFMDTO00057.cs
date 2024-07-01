using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    //NewSetup dto
    [Serializable]
    public class PFMDTO00057 : Supportfields<PFMDTO00057>
    {
        public PFMDTO00057() { }

        public PFMDTO00057(string value)
        {
            this.Value = value;
        }

        public PFMDTO00057(string variable, string value)
        {
            this.Variable = variable;
            this.Value = value;
        }

                                  //Variable,Value,Status,Active,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,TS
        public PFMDTO00057(string variable, string value, bool active, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId, byte[] tS)
        {
            this.Variable = variable;
            this.Value = value;            
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }	

        public PFMDTO00057(string variable, string value, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
        {
            this.Variable = variable;
            this.Value = value;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }		

        public virtual string Variable { get; set; }
        public virtual string Value { get; set; }
        public virtual string Status { get; set; }
        public virtual bool IsCheck { get; set; }
    }
}