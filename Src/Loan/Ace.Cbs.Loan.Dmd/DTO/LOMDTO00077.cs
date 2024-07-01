using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMDTO00077 : Supportfields<LOMDTO00077>
    {
        public LOMDTO00077() { }

        public LOMDTO00077(string lsProductTypeItemId, string productTypeCode, string lsBusinessCode, string umCode, int durationMonth,
            string userNo,DateTime date_time, bool active, byte[] ts, DateTime createdDate, 
            int createdUserId, DateTime updatedDate, int updatedUserId)
        {
            this.LSProductTypeItemId = lsProductTypeItemId;
            this.ProductCode = productTypeCode;
            this.LSBusinessCode = lsBusinessCode;
            this.UMCode = umCode;
            this.DurationMonths = durationMonth;
            this.USERNO = userNo;
            this.DATE_TIME = date_time;
            this.Active = active;
            this.TS = ts;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public LOMDTO00077(string lsProductTypeItemId, string productTypeCode, string lsBusinessCode, string umCode, int durationMonth,
            string userNo, DateTime date_time)
        {
            this.LSProductTypeItemId = lsProductTypeItemId;
            this.ProductCode = productTypeCode;
            this.LSBusinessCode = lsBusinessCode;
            this.UMCode = umCode;
            this.DurationMonths = durationMonth;
            this.USERNO = userNo;
            this.DATE_TIME = date_time;
        }

        public LOMDTO00077(string lsProductTypeItemId, string productTypeCode, string lsBusinessCode, string umCode, int durationMonth)
        {
            this.LSProductTypeItemId = lsProductTypeItemId;
            this.ProductCode = productTypeCode;
            this.LSBusinessCode = lsBusinessCode;
            this.UMCode = umCode;
            this.DurationMonths = durationMonth;
        }

        public LOMDTO00077(string lsProductTypeItemId, string productTypeCode,string productTypeDesp, string lsBusinessCode,string lsBusinessDesp,
            string umCode,string umDesp, int durationMonth,string userNo, DateTime date_time, bool active, byte[] ts, DateTime createdDate,
            int createdUserId, DateTime updatedDate, int updatedUserId)
        {
            this.LSProductTypeItemId = lsProductTypeItemId;
            this.ProductCode = productTypeCode;
            this.ProductDesp = productTypeDesp;
            this.LSBusinessCode = lsBusinessCode;
            this.LSBusinessDesp = lsBusinessDesp;
            this.UMCode = umCode;
            this.UMDesp = umDesp;
            this.DurationMonths = durationMonth;
            this.USERNO = userNo;
            this.DATE_TIME = date_time;
            this.Active = active;
            this.TS = ts;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public virtual string LSProductTypeItemId { get; set; }
        public virtual string ProductCode { get; set; }
        public virtual string LSBusinessCode { get; set; }
        public virtual string UMCode { get; set; }
        public virtual int DurationMonths { get; set; }
        public virtual string USERNO { get; set; }
        public virtual Nullable<DateTime> DATE_TIME { get; set; }
        public virtual bool IsCheck { get; set; }

        public string ProductDesp { get; set; }
        public string LSBusinessDesp { get; set; }
        public string UMDesp { get; set; }
    }
}
