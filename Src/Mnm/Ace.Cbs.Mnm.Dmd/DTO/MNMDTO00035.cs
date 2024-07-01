using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Mnm.Dmd
{
     [Serializable]
    public class MNMDTO00035
    {
        public MNMDTO00035() { }

        MNMDTO00035(string acctno,decimal cbal,decimal odamt,decimal odlimit,string name,string cur,string sourcebr,string acsign)
        {
            this.AcctNo = acctno;
            this.Cbal = cbal;
            this.ODAmt = odamt;
            this.ODLimit = odlimit;
            this.Name = name;
            this.Cur = cur;
            this.SourceBr = sourcebr;
            this.AcSign = acsign;
        }

        MNMDTO00035(string name, string acctno, decimal cbal)
        {
            this.AcctNo = acctno;
            this.Name = name;
            this.Cbal = cbal;
        }

        MNMDTO00035(string name, string acctno, decimal cbal, DateTime maturedate, string rno, DateTime rdate)
        {
            this.AcctNo = acctno;
            this.Name = name;
            this.Cbal = cbal;
            this.MatureDate = maturedate;
            this.Rno = rno;
            this.Rdate = rdate;
        }

        public MNMDTO00035(string acctno,string name,string rno, DateTime rdate, decimal duration, DateTime maturedate, decimal cbal)
        {
            this.AcctNo = acctno;
            this.Name = name;
            this.Rno = rno;
            this.Rdate = rdate;
            this.Duration = duration;
            this.MatureDate = maturedate;
            this.Cbal = cbal;
        }

        public MNMDTO00035(string acctno, string name, decimal cbal, decimal odamt, decimal odlimit, string cur, string sourcebr)
        {
            this.AcctNo = acctno;
            this.Name = name;
            this.Cbal = cbal;
            this.ODAmt = odamt;
            this.ODLimit = odlimit;
            this.Cur = cur;
            this.SourceBr = sourcebr;
        }

        public virtual int Id { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual decimal Cbal { get; set; }
        public virtual decimal ODAmt { get; set; }
        public virtual decimal ODLimit { get; set; }
        public virtual string Name { get; set; }
        public virtual string Cur { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string AcSign { get; set; }
        public virtual string Rno { get; set; }
        public virtual DateTime Rdate { get; set; }
        public virtual decimal Duration { get; set; }
        public virtual DateTime MatureDate { get; set; }
    }
}
