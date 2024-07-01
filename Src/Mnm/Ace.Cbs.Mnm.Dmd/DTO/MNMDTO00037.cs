using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
    [Serializable]
    public class MNMDTO00037 : Supportfields<MNMDTO00037>
    {
        public MNMDTO00037() { }

        public MNMDTO00037(DateTime startDate, DateTime endDate, string branch)
        {
            this.CloseDate = startDate;
            this.CloseDate = endDate;
            this.SourceBr = branch;
        }

        public MNMDTO00037(DateTime startDate, DateTime endDate, string cur, string branch)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Cur = cur;
            this.SourceBr = branch;
        }

        public MNMDTO00037(string aCode, string aName, decimal closingBalance)
        {
            this.ACode = aCode;
            this.ACName = aName;
            this.closingBalance = closingBalance;
        }

        public MNMDTO00037(DateTime getStartDate, DateTime getEndDate)
        {
            this.getStartDate = getStartDate;
            this.getEndaDate = getEndDate;
        }

        public MNMDTO00037(string acctNo, string name, DateTime closeDate, int cBal, string cur, string sourceBranch)
        {
            this.AcctNo = acctNo;
            this.Name = name;
            this.CloseDate = closeDate;
            this.CloseDateString = closeDate.ToShortDateString();
            this.CBal = cBal;
            this.Cur = cur;
            this.SourceBr = sourceBranch;
        }

        public virtual string AcctNo { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime CloseDate { get; set; }
        public virtual string CloseDateString { get; set; }
        public virtual int CBal { get; set; }
        public virtual string Cur { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual DateTime getStartDate { get; set; }
        public virtual DateTime getEndaDate { get; set; }
        public virtual string ACName { get; set; }
        public virtual string ACode { get; set; }
        public virtual decimal closingBalance { get; set; }
        public virtual bool IsHomeCurrency { get; set; }
        public virtual bool IsTransactionDate { get; set; }
    }
}
