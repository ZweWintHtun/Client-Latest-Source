using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// Type Of AGLoans DTO Entity
    /// </summary>
    /// 
    [Serializable]
    public class LOMDTO00075 : EntityBase<LOMDTO00075>
    {
        public LOMDTO00075() { }

        //Id,Code,Description,Active,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,TS
        public LOMDTO00075(string id, string productCode, string seasonCode, string uMCode, string startDay, string startMonth, string endDay, string endMonth, string deadLineDay, string deadLineMonth, string userNo, DateTime dateTime, bool active, byte[] ts, DateTime createdDate, int createdUserId, Nullable<DateTime> updatedDate, Nullable<int> updatedUserId)
        {
            this.AGLoanProductTypeItemId = id;
            this.ProductCode = productCode;
            this.SeasonCode = seasonCode;
            this.UMCode = uMCode;
            this.SDay = startDay;
            this.SMonth = startMonth;
            this.EDay = endDay;
            this.EMonth = endMonth;
            this.DeadLineDay = deadLineDay;
            this.DeadLineMonth = deadLineMonth;
            this.USERNO = userNo;
            this.DATE_TIME = dateTime;
            this.Active = active;
            this.TS = ts;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }
        public LOMDTO00075(string id, string productCode, string seasonCode, string uMCode, string startDay, string startMonth, string endDay, string endMonth, string deadLineDay, string deadLineMonth, string userNo, DateTime dateTime)
        {
            this.AGLoanProductTypeItemId = id;
            this.ProductCode = productCode;
            this.SeasonCode = seasonCode;
            this.UMCode = uMCode;
            this.SDay = startDay;
            this.SMonth = startMonth;
            this.EDay = endDay;
            this.EMonth = endMonth;
            this.DeadLineDay = deadLineDay;
            this.DeadLineMonth = deadLineMonth;
            this.USERNO = userNo;
            this.DATE_TIME = dateTime;
        }

        public LOMDTO00075(string id, string productCode, string seasonCode, string uMCode, string startDay, string startMonth, string endDay, string endMonth, string deadLineDay, string deadLineMonth)
        {
            this.AGLoanProductTypeItemId = id;
            this.ProductCode = productCode;
            this.SeasonCode = seasonCode;
            this.UMCode = uMCode;
            this.SDay = startDay;
            this.SMonth = startMonth;
            this.EDay = endDay;
            this.EMonth = endMonth;
            this.DeadLineDay = deadLineDay;
            this.DeadLineMonth = deadLineMonth;
        }

        public LOMDTO00075(string id, string productdesp, string productCode, string seasonCode, string uMCode, string seasonDesp, string uMDesp, string startDay, string startMonth, string endDay, string endMonth,
                            string deadLineDay, string deadLineMonth, string userNo, DateTime dateTime, bool active, DateTime createdDate, int createdUserId, DateTime updatedDate, int updatedUserId
		                  )
        {
            this.AGLoanProductTypeItemId = id;
            this.ProductCode = productCode;
            this.SeasonCode = seasonCode;
            this.UMCode = uMCode;
            ProductDesp = productdesp;
            this.SeasonDesp = seasonDesp;
            this.UMDesp = uMDesp;
            this.SDay = startDay;
            this.SMonth = startMonth;
            this.EDay = endDay;
            this.EMonth = endMonth;
            this.DeadLineDay = deadLineDay;
            this.DeadLineMonth = deadLineMonth;
            this.USERNO = userNo;
            this.DATE_TIME = dateTime;
            this.Active = active;
            //this.TS = ts;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }
        public LOMDTO00075(string id, string productdesp,string seasonDesp, string uMDesp, string startDay, string startMonth, string endDay, string endMonth,
                          string deadLineDay, string deadLineMonth, string userNo, DateTime dateTime, bool active, DateTime createdDate, int createdUserId, DateTime updatedDate, int updatedUserId
                        )
        {
            this.AGLoanProductTypeItemId = id;
            ProductDesp = productdesp;
            this.SeasonDesp = seasonDesp;
            this.UMDesp = uMDesp;
            this.SDay = startDay;
            this.SMonth = startMonth;
            this.EDay = endDay;
            this.EMonth = endMonth;
            this.DeadLineDay = deadLineDay;
            this.DeadLineMonth = deadLineMonth;
            this.USERNO = userNo;
            this.DATE_TIME = dateTime;
            this.Active = active;
            //this.TS = ts;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public virtual string AGLoanProductTypeItemId { get; set; }
        public virtual string ProductCode { get; set; }
        public virtual string SeasonCode { get; set; }
        //public virtual string CropCode { get; set; }
        public virtual string UMCode { get; set; }
        //public virtual string StartDate { get; set; }
        //public virtual string EndDate { get; set; }
        //public virtual string DeadLineDate { get; set; }
        public virtual string USERNO { get; set; }
        public virtual DateTime DATE_TIME { get; set; }

        public virtual string SDay { get; set; }
        public virtual string SMonth { get; set; }
        public virtual string EDay { get; set; }
        public virtual string EMonth { get; set; }
        public virtual string DeadLineDay { get; set; }
        public virtual string DeadLineMonth { get; set; }

        public virtual bool IsCheck { get; set; }
        public virtual string SourceBranchCode { get; set; }


        public string ProductDesp { get; set; }
        public string SeasonDesp { get; set; }
        public string UMDesp { get; set; }
    }
}
