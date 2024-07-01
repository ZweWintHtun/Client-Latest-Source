using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMDTO00059
    {
        public LOMDTO00059() { }

        public LOMDTO00059(int id,string acctno,string lno,decimal oldlimit,
            decimal ovdlimit,DateTime date_time,string userno,string cur,string sourcebr) 
        {
            this.Id = id;
            this.AcctNo = acctno;
            this.LoanNo = lno;
            this.OLDLimit = oldlimit;
            this.OVDLimit = ovdlimit;
            this.Date_Time = date_time;
            this.UserNo = userno;
            this.Cur = cur;
            this.SourceBr = sourcebr;
        }

        public LOMDTO00059(int id, string acctno,string name, string lno, decimal oldlimit,
            decimal ovdlimit, DateTime date_time, string userno, string cur, string sourcebr)
        {
            this.Id = id;
            this.AcctNo = acctno;
            this.Name = name;
            this.LoanNo = lno;
            this.OLDLimit = oldlimit;
            this.OVDLimit = ovdlimit;
            this.Date_Time = date_time;
            this.UserNo = userno;
            this.Cur = cur;
            this.SourceBr = sourcebr;
        }

        public virtual int Id { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string LoanNo { get; set; }
        public virtual Nullable<decimal> OVDLimit { get; set; }
        public virtual Nullable<decimal> OLDLimit { get; set; }
        public virtual Nullable<DateTime> Date_Time { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string Cur { get; set; }
        public virtual string SourceBr { get; set; }

        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }

        public virtual string Name { get; set; }
    }
}
