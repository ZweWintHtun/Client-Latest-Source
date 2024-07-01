using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Sys001 DTO Entity
    /// </summary>
    [Serializable]
    public class PFMDTO00056 : Supportfields<PFMDTO00056>
    {
        public PFMDTO00056() { }

        

        public PFMDTO00056(int id, string name, string sysMonYear, string status, DateTime sysDate, string sysQty)
        {
            this.Id = id;
            this.Name = name;
            this.SysMonYear = sysMonYear;
            this.Status = status;
            this.SysDate = sysDate;
            this.SysQty = sysQty;

        }

                             //Id,Name,SysMonYear,Status,SysDate,SysQty,BranchCode,Active,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,TS
        public PFMDTO00056(int id, string name, string sysMonYear, string status,System.Nullable<DateTime> sysDate,
            string sysQty, string sourceBr, bool active, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId, byte[] tS)
        {
            this.Id = id;
            this.Name = name;
            this.SysMonYear = sysMonYear;
            this.Status = status;
            this.SysDate = sysDate;
            this.SysQty = sysQty;
            this.BranchCode = sourceBr;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public PFMDTO00056(int id, string name, string sysMonYear, string status, string sysQty, string sourceBr, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
        {
            this.Id = id;
            this.Name = name;
            this.SysMonYear = sysMonYear;
            this.Status = status;
            this.SysQty = sysQty;
            this.BranchCode = sourceBr;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public PFMDTO00056(int id, string name, string sysMonYear, string status,DateTime sysDate, string sysQty, string sourceBr, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
        {
            this.Id = id;
            this.Name = name;
            this.SysMonYear = sysMonYear;
            this.Status = status;
            this.SysDate = sysDate;
            this.SysQty = sysQty;
            this.BranchCode = sourceBr;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }
      
        public PFMDTO00056(string name, string sourceBr, DateTime sysDate)
        {
            this.Name = name;
            this.SysDate = sysDate;
            this.BranchCode = sourceBr;
        }

        public PFMDTO00056(DateTime sysdate,string name,string sysmonthyear,string status,string sysqty,string branchcode)
        {
            this.SysDate = sysdate;
            this.Name = name;
            this.SysMonYear = sysmonthyear;
            this.Status = status;
            this.SysQty = sysqty;
            this.BranchCode = branchcode;
        }

        public PFMDTO00056(int id, string name, string status, DateTime sysDate, string sourceBr, bool active)
        {
            this.Id = id;
            this.Name = name;           
            this.Status = status;
            this.SysDate = sysDate;           
            this.BranchCode = sourceBr;
            this.Active = active;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string SysMonYear { get; set; }
        public string Status { get; set; }
        public DateTime NextSettlementDate { get; set; }
        public DateTime CurrentSettlementDate { get; set; }
        public System.Nullable<DateTime> SysDate { get; set; }
        public string SysQty { get; set; }
        public string BranchCode { get; set; }
        public virtual bool IsCheck { get; set; }
        public string checkStatus { get; set; }
        public int Count { get; set; }


        public DateTime BLInterestDate { get; set; }
        public DateTime PLMonthlyAutoPayDate { get; set; }
        public DateTime HPMonthlyAutoPayDate { get; set; }
        public DateTime HPLateFeesAutoRun { get; set; }
        public DateTime BLLateFeesVoucherDate { get; set; }

        public DateTime HPLateFeesAutoVoucherDate { get; set; }
        public DateTime PLLateFeesAutoVoucherDate { get; set; }//Added by HWKO (16-Oct-2017)

    }

}
