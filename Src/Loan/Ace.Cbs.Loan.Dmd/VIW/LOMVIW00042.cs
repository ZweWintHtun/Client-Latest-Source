using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// VW_MOBLON001
    /// </summary>
    /// 
    [Serializable]
    public class LOMVIW00042
    {
        public LOMVIW00042() { }
        public virtual int Id { get; set; }
        public virtual string LNO { get; set; }
        public virtual string ACCTNO { get; set; }
        public virtual Nullable<DateTime> SDATE { get; set; }
        public virtual Nullable<DateTime> CLOSEDATE { get; set; }
        public virtual Nullable<decimal> SAMT { get; set; }
        public virtual string ATYPE { get; set; }
        public virtual bool LEGALCASE { get; set; }
        public virtual string CUR { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual bool Active { get; set; }
    }
}
