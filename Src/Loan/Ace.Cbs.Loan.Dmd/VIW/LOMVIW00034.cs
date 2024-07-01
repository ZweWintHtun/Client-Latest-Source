using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// VW_LOAN_DAILY_POSITION
    /// </summary>
    ///  
    [Serializable]
    public class LOMVIW00034
    {
        public LOMVIW00034() { }
        public virtual int Id { get; set; }
        public virtual string LNO { get; set; }
        public virtual string ACCTNO { get; set; }
        public virtual decimal SAMT { get; set; }
        public virtual string CUR { get; set; }
        public virtual DateTime SDATE { get; set; }
        public virtual decimal FIRSTSAMT { get; set; }
        public virtual DateTime EXPIREDATE { get; set; }
        public virtual bool LEGALCASE { get; set; }
        public virtual bool NPLCASE { get; set; }
        public virtual string NAME{ get; set; }
        public virtual decimal CBAL { get; set; }
        public virtual string ATYPE { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string LOANS_TYPE { get; set; }
        public virtual decimal FORCE_SALE_VALUE { get; set; }
        public virtual bool Active { get; set; }
    }
}

