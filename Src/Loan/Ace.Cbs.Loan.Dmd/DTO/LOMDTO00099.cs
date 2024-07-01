using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMDTO00099 : Supportfields<LOMDTO00099>
    {
        public LOMDTO00099() { }

        public LOMDTO00099(int id, string reno, string businessType, decimal um)
        {
            this.Id = id;
            this.Eno = reno;
            this.BusinessType = businessType;
            this.UM = um;
        }
        public LOMDTO00099(string eno, string businessType, string loanType, string townshipCode, string villageCode, string financialYear, string businessCode,
            DateTime suspendDate, decimal suspendAmu, DateTime deliverDate, string totalGroup, string population, string acre, 
            decimal sanctionAmu, DateTime refundDate, decimal refundAmu, string refundVrNo, DateTime date_Time, string userNo, string sourceBr, bool active, byte[] ts)
        {
            this.Eno = eno;
            this.BusinessType = businessType;
            this.LoanType = loanType;
            this.TownshipCode = townshipCode;
            this.VillageCode = villageCode;
            this.FinancialYear = financialYear;
            this.BusinessCode = businessCode;
            this.SuspendDate = suspendDate;
            this.SuspendAmu = suspendAmu;
            this.DeliverDate = deliverDate;
            this.TotalGroup = totalGroup;
            this.Population = population;
            this.Acre = acre;
            this.SanctionAmu = sanctionAmu;
            this.RefundDate = refundDate;
            this.RefundAmu = refundAmu;
            this.RefundVrNo = RefundVrNo;
            this.Date_Time = date_Time;
            this.UserNo = userNo;
            this.SourceBr = sourceBr;
            this.Active = active;
            this.TS = ts;
        }

        public LOMDTO00099(int id, string reno, string businessType, decimal um, bool active, DateTime createdDate, int createdUserId)
        {
            this.Id = id;
            this.Eno = reno;
            this.BusinessType = businessType;
            this.UM = um;
            this.Active = active;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
        }

        public virtual int Id { get; set; }
        public virtual string Eno { get; set; }
        public virtual string BusinessType { get; set; }
        public virtual decimal UM { get; set; }

        /* Loan Record */
        public virtual string LoanType { get; set; }
        public virtual string TownshipCode { get; set; }
        public virtual string VillageCode { get; set; }
        public virtual string FinancialYear { get; set; }
        public virtual string BusinessCode { get; set; }
        public virtual DateTime SuspendDate { get; set; }
        public virtual decimal SuspendAmu { get; set; }
        public virtual DateTime DeliverDate { get; set; }
        public virtual string TotalGroup { get; set; }
        public virtual string Population { get; set; }
        public virtual string Acre { get; set; }
        public virtual decimal SanctionAmu { get; set; }
        public virtual DateTime RefundDate { get; set; }
        public virtual decimal RefundAmu { get; set; }
        public virtual string RefundVrNo { get; set; }
        public virtual DateTime Date_Time { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string SourceBr { get; set; }
    }
}
