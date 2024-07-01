using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// VW_REPAYSCHEDULE
    /// </summary>
    /// 
    [Serializable]    
    public class LOMVIW00047
    {
        public LOMVIW00047() { }
        public virtual int Id { get; set; }
        public virtual string LNO { get; set; }
        public virtual string ACCTNO { get; set; }
        public virtual Nullable<decimal> SAMT { get; set; }
        public virtual string NAME { get; set; }
        public virtual string REPAYNO { get; set; }
        public virtual Nullable<decimal> FIRSTSAMT { get; set; }
        public virtual bool Partial { get; set; }
        public virtual string CUR { get; set; }
        public virtual string SOURCEBR { get; set; }
        public virtual Nullable<DateTime> DATE_TIME { get; set; }
        public virtual Nullable<decimal> AMOUNT { get; set; }
        public virtual Nullable<decimal> INTEREST { get; set; }

    }
}
