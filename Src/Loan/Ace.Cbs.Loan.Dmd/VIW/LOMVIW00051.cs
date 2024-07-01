using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// VW_ExpLoans
    /// </summary>
    ///
    [Serializable]
    public class LOMVIW00051
    {
        public LOMVIW00051() { }
        public virtual int Id { get; set; }
        public virtual string Lno { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual Nullable<decimal> SAmt { get; set; }
        public virtual string Cur { get; set; }
        public virtual Nullable<DateTime> SDate { get; set; }
        public virtual Nullable<DateTime> ExpireDate { get; set; }
        public virtual string AType { get; set; }
        public virtual string SourceBr { get; set; }
    }
}
