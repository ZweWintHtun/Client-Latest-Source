using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// VW_MTHSCHARGE
    /// </summary>
    ///  
    [Serializable]
    public class LOMVIW00002
    {
        public LOMVIW00002() { }
        public virtual int Id { get; set; }
        public virtual string AcctNo { get; set; }       
        public virtual Nullable<decimal> Amount { get; set; }
        public virtual Nullable<DateTime> DATE_TIME { get; set; }
        public virtual string WorkStation { get; set; }
        public virtual string SourceBranch { get; set; }      
    }
}
