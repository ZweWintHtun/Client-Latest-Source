using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMDTO00086 : Supportfields<LOMDTO00086>
    {
        public LOMDTO00086() { }

        public LOMDTO00086(int id)
        {
            this.Id = id;
        }

        public LOMDTO00086(int id, string eNo, string loanType, string townshipCode, string villageCode, string financialYear, string businessCode, DateTime suspendDate, decimal suspendAmu, DateTime deliverDate, string totalGroup, string population, string acre, decimal sanctionAmu, DateTime refundDate, decimal refundAmu, string refundVrNo, DateTime date_time, string userNo, string sourceBr, bool active, byte[] ts, DateTime createdDate, int createdUserId, DateTime updatedDate, int updatedUserId, string businessTypeUm)
        {
            this.Id = id;
            this.Eno = eNo;
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
            this.RefundVrNo = refundVrNo;
            this.Date_Time = date_time;
            this.UserNo = userNo;
            this.SourceBr = sourceBr;
            this.Active = active;
            this.TS = ts;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
            this.BusinessTypeUM = businessTypeUm;
        }

        public LOMDTO00086(int id, string eNo, string loanType, string townshipCode, string villageCode, string financialYear, string businessCode, DateTime suspendDate, decimal suspendAmu, DateTime deliverDate, string totalGroup, string population, string acre, decimal sanctionAmu, DateTime refundDate, decimal refundAmu, string refundVrNo, DateTime date_time, string userNo, string sourceBr, bool active, byte[] ts, string businessTypeUm)
        {
            this.Id = id;
            this.Eno = eNo;
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
            this.RefundVrNo = refundVrNo;
            this.Date_Time = date_time;
            this.UserNo = userNo;
            this.SourceBr = sourceBr;
            this.Active = active;
            this.TS = ts;
            this.BusinessTypeUM = businessTypeUm;
        }

        public virtual int Id { get; set; }
        public virtual string Eno { get; set; }
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
        public virtual string BusinessTypeUM { get; set; }
    }
}
