using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMDTO00094 : Supportfields<LOMDTO00094>
    {
        public LOMDTO00094() { }

        public LOMDTO00094(DateTime startDate, DateTime endDate, string sourceBranch, string currency, string loanType)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.SourceBr = sourceBranch;
            this.Cur = currency;
            this.LoanType = loanType;
        }
        
        public LOMDTO00094(string sourceBranch, string currency, string loanType, DateTime startDate, DateTime endDate)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.SourceBr = sourceBranch;
            this.Cur = currency;
            this.LoanType = loanType;
        }

        public LOMDTO00094(string name, string fatherName, string lno, string village,
            string businessType, string loanProductType, string groupNo,
            DateTime withdrawDate, DateTime expireDate, decimal intRate,
            decimal penalties, decimal loanAmtPerAcre, decimal totalAcre,
            decimal samt, string sourceBr, string cur)
        {
            this.Name = name;
            this.FatherName = fatherName;
            this.Lno = lno;
            this.VillageDesp = village;
            this.LSBusinessDesp = businessType;
            this.LoanProductType = loanProductType;
            this.GroupNo = groupNo;
            this.WithdrawDate = withdrawDate;
            this.ExpireDate = expireDate;
            this.IntRate = intRate;
            this.Penalties = penalties;
            this.LoanAmtPerAcre = loanAmtPerAcre;
            this.TotalAcre = totalAcre;
            this.SAmt = samt;
            this.SourceBr = sourceBr;
            this.Cur = cur;
        }

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string FatherName { get; set; }
        public virtual string Lno { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string LoanType { get; set; }
        public virtual string LoanProductType { get; set; }
        public virtual string VillageCode { get; set; }
        public virtual string VillageDesp { get; set; }
        public virtual string LSBusinessCode { get; set; }
        public virtual string LSBusinessDesp { get; set; }
        public virtual decimal SAmt { get; set; }
        public virtual DateTime ExpireDate { get; set; }
        public virtual decimal IntRate { get; set; }
        public virtual decimal Penalties { get; set; }
        public virtual string GroupNo { get; set; }
        public virtual DateTime WithdrawDate { get; set; }
        public virtual decimal LoanAmtPerAcre { get; set; }
        public virtual decimal TotalAcre { get; set; }
        public virtual string Cur { get; set; }
        public virtual string SourceBr { get; set; }

        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
    }
}
