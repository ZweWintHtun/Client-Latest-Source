using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMDTO00047 : Supportfields<LOMDTO00035>
    {
        public LOMDTO00047() { }

        public LOMDTO00047(int id,string lno,string acctNo,decimal sAmt,
            string name, string repayNo, decimal firstAmt,bool partial,
            string cur, DateTime date_Time,decimal amount, decimal interest) 
        {
            this.Id = id;
            this.Lno = lno;
            this.AcctNo = acctNo;
            this.SAmt = sAmt;
            this.Name = name;
            this.RepayNo = repayNo;
            this.FirstSAmt = firstAmt;
            this.Partial = partial;
            this.Cur = cur;
            this.Date_Time = date_Time;
            this.Amount = amount;
            this.Interest = interest;
        }

        public virtual int Id { get; set; }
        public virtual string Lno { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual decimal SAmt { get; set; }
        public virtual string Name { get; set; }
        public virtual string RepayNo { get; set; }
        public virtual decimal FirstSAmt { get; set; }
        public virtual bool Partial { get; set; }
        public virtual string Cur { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual DateTime Date_Time { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual decimal Interest { get; set; }

        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
    }
}
