using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// DTO for VW_FARMLOAN_TOTALDAILYINCOME
    /// Created By HWKO (24-Apr-2017)
    /// </summary>
    ///
    [Serializable]
    public class LOMDTO00309 : Supportfields<LOMDTO00309>
    {
        public LOMDTO00309() { }

        public LOMDTO00309(int id, DateTime repaymentDate, string lno, string repayNo, string villageCode,
            string villageDesp, string name, string loanProductType, decimal amount, decimal interest,
            decimal penalties, string cur, string sourceBr, bool active)
        {
            this.Id = id;
            this.RepaymentDate = repaymentDate;
            this.Lno = lno;
            this.REPAYNO = repayNo;
            this.VillageCode = villageCode;
            this.VillageDesp = villageDesp;
            this.Name = name;
            this.LoanProductType = loanProductType;
            this.AMOUNT = amount;
            this.INTEREST = interest;
            this.PENALTIES = penalties;
            this.Cur = cur;
            this.SourceBr = sourceBr;
            this.Active = active;
        }

        public LOMDTO00309(DateTime startDate, DateTime endDate, string cur, string sourceBr)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Cur = cur;
            this.SourceBr = sourceBr;
        }

        public virtual int Id { get; set; }
        public virtual DateTime RepaymentDate { get; set; }
        public virtual string Lno { get; set; }
        public virtual string REPAYNO { get; set; }
        public virtual string VillageCode { get; set; }
        public virtual string VillageDesp { get; set; }
        public virtual string Name { get; set; }
        public virtual string LoanProductType { get; set; }
        public virtual decimal AMOUNT { get; set; }
        public virtual decimal INTEREST { get; set; }
        public virtual decimal PENALTIES { get; set; }
        public virtual string Cur { get; set; }
        public virtual string SourceBr { get; set; }

        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
    }
}
