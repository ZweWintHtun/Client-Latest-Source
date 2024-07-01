using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMDTO00008 : Supportfields<LOMDTO00008>
    {
        public LOMDTO00008() { }

        public LOMDTO00008(string kind, string description)
        {
            this.Kind = kind;
            this.Description = description;
        }

        public LOMDTO00008(string kind, string description, bool active, byte[] tS, int createdUserId, DateTime createdDate, System.Nullable<int> updatedUserId, System.Nullable<DateTime> updatedDate)
        {
            this.Kind = kind;
            this.Description = description;
            this.Active = active;
            this.TS = tS;
            this.CreatedUserId = createdUserId;
            this.CreatedDate = createdDate;
            this.UpdatedUserId = updatedUserId;
            this.UpdatedDate = updatedDate;
        }

        public virtual string Kind { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsCheck { get; set; }
    }
}
