using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMDTO00072 : Supportfields<LOMDTO00072>
    {
        public LOMDTO00072() { }

        public LOMDTO00072(string cropCode, string desp, string userNO, DateTime date_Time, bool active, byte[] ts, DateTime createdDate, int createdUserId, DateTime updatedDate, int updatedUserId)
        {
            this.CropCode = cropCode;
            this.Desp = desp;
            this.USERNO = userNO;
            this.DATE_TIME = date_Time;
            this.Active = active;
            this.TS = ts;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public LOMDTO00072(string cropCode, string desp, string userNO, DateTime date_Time)
        {
            this.CropCode = cropCode;
            this.Desp = desp;
            this.USERNO = userNO;
            this.DATE_TIME = date_Time;
        }

        public LOMDTO00072(string cropCode, string desp)
        {
            this.CropCode = cropCode;
            this.Desp = desp;
        }

        public virtual string CropCode { get; set; }
        public virtual string Desp { get; set; }
        public virtual string USERNO { get; set; }
        public virtual Nullable<DateTime> DATE_TIME { get; set; }
        public virtual bool IsCheck { get; set; }
    }
}
