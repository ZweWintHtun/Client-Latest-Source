using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// DTO for VW_FARMLOAN_OutstandingReportByWithdrawDate
    /// Created By HWKO (04-Apr-2017)
    /// </summary>
    ///
    [Serializable]
    public class LOMDTO00305 : Supportfields<LOMDTO00305>
    {
        public LOMDTO00305() { }

        public LOMDTO00305(int id, string lno, DateTime withdrawDate,string name,string fatherName,string loanProductType,
            decimal principalAmount, DateTime repaymentDate, string repayNo, decimal amount, 
            decimal interest, decimal penalties, decimal sAmt, string villageCode, 
            string villageDesp, string townshipCode, string townshipDesp,
            DateTime expireDate, string cur, string sourceBr, bool active)
        {
            this.Id = id;
            this.Lno = lno;
            this.WithdrawDate = withdrawDate;
            this.Name = name;
            this.FatherName = fatherName;
            this.LoanProductType = loanProductType;
            this.PrincipalAmount = principalAmount;
            this.RepaymentDate = repaymentDate;
            this.REPAYNO = repayNo;
            this.AMOUNT = amount;
            this.INTEREST = interest;
            this.PENALTIES = penalties;
            this.SAmt = sAmt;
            this.VillageCode = villageCode;
            this.VillageDesp = villageDesp;
            this.TownshipCode = townshipCode;
            this.TownshipDesp = townshipDesp;
            this.ExpireDate = expireDate;
            this.Cur = cur;
            this.SourceBr = sourceBr;
            this.Active = active;
        }

        public LOMDTO00305(DateTime withdrawDate, string cur, string sourceBr,
            string villageCode, string townshipCode)
        {
            this.WithdrawDate = withdrawDate;
            this.Cur = cur;
            this.SourceBr = sourceBr;
            this.VillageCode = villageCode;
            this.TownshipCode = townshipCode;
        }

        public LOMDTO00305(string lno, decimal samt, DateTime withdrawDate, string sourceBr)
        {
            this.Lno = lno;
            this.SAmt = samt;
            this.WithdrawDate = withdrawDate;
            this.SourceBr = sourceBr;
        }

        public LOMDTO00305(string lno, decimal samt, string sourceBr)
        {
            this.Lno = lno;
            this.SAmt = samt;
            this.SourceBr = sourceBr;
        }

        public virtual int Id { get; set; }
        public virtual string Lno { get; set; }
        public virtual DateTime WithdrawDate { get; set; }
        public virtual string Name { get; set; }
        public virtual string FatherName { get; set; }
        public virtual string LoanProductType { get; set; }
        public virtual decimal PrincipalAmount { get; set; }
        public virtual DateTime RepaymentDate { get; set; }
        public virtual string REPAYNO { get; set; }
        public virtual decimal AMOUNT { get; set; }
        public virtual decimal INTEREST { get; set; }
        public virtual decimal PENALTIES { get; set; }
        public virtual decimal SAmt { get; set; }
        public virtual string VillageCode { get; set; }
        public virtual string VillageDesp { get; set; }
        public virtual string TownshipCode { get; set; }
        public virtual string TownshipDesp { get; set; }
        public virtual DateTime ExpireDate { get; set; }
        public virtual string Cur { get; set; }
        public virtual string SourceBr { get; set; }
    }
}
