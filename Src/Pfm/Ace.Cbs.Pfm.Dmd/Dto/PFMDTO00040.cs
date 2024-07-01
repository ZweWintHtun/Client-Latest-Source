using System;
using Ace.Windows.Core.DataModel;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    // SI dto
    [Serializable]
    public class PFMDTO00040 : Supportfields<PFMDTO00040>
    {
        public PFMDTO00040() { }

        public PFMDTO00040(decimal interest) 
        {
            this.AccruedInt = interest;
        }

        public PFMDTO00040(int id, string acctno, string accountsignature, System.Nullable<DateTime> closedate, string status, string budget, decimal lastint, decimal accruedint, decimal m1, decimal m2, decimal m3, decimal m4, decimal m5, decimal m6, decimal m7, decimal m8, decimal m9, decimal m10, decimal m11, decimal m12, string sourcebranchcode, DateTime date_time, string sourcecur, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
        {
            this.Id = id;
            this.AccountNo = acctno;
            this.AccountSignature = accountsignature;
            this.CloseDate = closedate;
            this.Status = status;
            this.Budget = budget;
            this.LastInt = lastint;
            this.AccruedInt = accruedint;
            this.Month1 = m1;
            this.Month2 = m2;
            this.Month3 = m3;
            this.Month4 = m4;
            this.Month5 = m5;
            this.Month6 = m6;
            this.Month7 = m7;
            this.Month8 = m8;
            this.Month9 = m9;
            this.Month10 = m10;
            this.Month11 = m11;
            this.Month12 = m12;
            this.CurrencyCode = sourcecur;
            this.SourceBranchCode = sourcebranchcode;
            this.DATE_TIME = date_time;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public virtual int Id { get; set; }

        // Considering
        public virtual string AccountNo { get; set; }
        public virtual string AccountSignature { get; set; }
        public virtual Nullable<DateTime> CloseDate { get; set; }
        public virtual string Status { get; set; }
        public virtual string Budget { get; set; }
        public virtual decimal LastInt { get; set; }
        public virtual Nullable<decimal> AccruedInt { get; set; }
        public virtual decimal Month1 { get; set; }
        public virtual decimal Month2 { get; set; }
        public virtual decimal Month3 { get; set; }
        public virtual decimal Month4{ get; set; }
        public virtual decimal Month5 { get; set; }
        public virtual decimal Month6 { get; set; }
        public virtual decimal Month7 { get; set; }
        public virtual decimal Month8 { get; set; }
        public virtual decimal Month9 { get; set; }
        public virtual decimal Month10 { get; set; }
        public virtual decimal Month11 { get; set; }
        public virtual decimal Month12 { get; set; }

        public virtual string SourceBranchCode { get; set; }
        public virtual Nullable<DateTime> DATE_TIME { get; set; }
        public virtual string CurrencyCode { get; set; }

        // Currency relation
        public virtual CurrencyDTO Currency { get; set; }

        // Source Branch relation
        public virtual Branch Branch { get; set; }
    }
}