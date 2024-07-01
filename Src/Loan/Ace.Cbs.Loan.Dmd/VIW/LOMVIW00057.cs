using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMVIW00057
    {
        public LOMVIW00057() { }
        public virtual int Id { get; set; }
        public virtual string LNO { get; set; }
        public virtual string ACCTNO { get; set; }
        public virtual string DESP { get; set; }
        public virtual Nullable<DateTime> VOUDATE { get; set; }
        public virtual string CUR { get; set; }
        public virtual Nullable<decimal> AMOUNT { get; set; }
        public virtual bool LEGALCASE { get; set; }
        public virtual bool NPLCASE { get; set; }
        public virtual string SourceBr { get; set; }

    }
}
