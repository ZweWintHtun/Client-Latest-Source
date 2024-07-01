using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMDTO00073 : Supportfields<LOMDTO00073>
    {
        public LOMDTO00073() { }

        public LOMDTO00073(string umCode, string desp, string userNO, DateTime date_Time, bool active, byte[] ts, DateTime createdDate, int createdUserId, DateTime updatedDate, int updatedUserId)
        {
            this.UMCode = umCode;
            this.UMDesp = desp;
            this.USERNO = userNO;
            this.DATE_TIME = date_Time;
            this.Active = active;
            this.TS = ts;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public LOMDTO00073(string umCode, string desp, string userNO, DateTime date_Time)
        {
            this.UMCode = umCode;
            this.UMDesp = desp;
            this.USERNO = userNO;
            this.DATE_TIME = date_Time;
        }
        public LOMDTO00073(string umCode, string desp)
        {
            this.UMCode = umCode;
            this.UMDesp = desp;
        }

        public virtual string UMCode { get; set; }
        public virtual string UMDesp { get; set; }
        public virtual string USERNO { get; set; }
        public virtual Nullable<DateTime> DATE_TIME { get; set; }
        public virtual bool IsCheck { get; set; }
    }
}
