using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// For Loan Record Report
    /// </summary>
    [Serializable]
    public class LOMDTO00102 : Supportfields<LOMDTO00102>
    {
        public LOMDTO00102() { }

        public LOMDTO00102(string eno, string townshipName, string villageName, DateTime suspendDate, decimal suspendAmu, DateTime deliverDate,
            decimal totalGroup, decimal population, string acre, decimal sanctionAmu, DateTime refundDate, string refundVrNo, decimal refundAmu,
            string businessType)
        {
            this.Eno = eno;
            this.TownshipName = townshipName;
            this.VillageName = villageName;
            this.SuspendDate = suspendDate;
            this.SuspendAmu = suspendAmu;
            this.DeliverDate = deliverDate;
            this.TotalGroup = totalGroup;
            this.Population = population;
            this.Acre = acre;
            this.SanctionAmu = sanctionAmu;
            this.RefundDate = refundDate;
            this.RefundVrNo = refundVrNo;
            this.RefundAmu = refundAmu;
            this.BusinessType = businessType;
        }

        public int No { get; set; }
        public string Eno{get;set;}
        public string TownshipName{get;set;}
        public string VillageName { get; set; }
        public DateTime SuspendDate { get; set; }
        public decimal SuspendAmu { get; set; }
        public DateTime DeliverDate{get;set;}
        public decimal TotalGroup { get; set; }
        public decimal Population { get; set; }
        public string Acre { get; set; }
        public decimal SanctionAmu { get; set; }
        public DateTime RefundDate { get; set; }
        public string RefundVrNo { get; set; }
        public decimal RefundAmu { get; set; }
        public string BusinessType{get;set;}
        public decimal UM { get; set; }

        #region Report_View
        public DateTime startDate { get; set; }
        public DateTime endDate{get;set;}
        public string townshipCode{get;set;}
        public string loanType { get; set; }
        #endregion
    }
}
