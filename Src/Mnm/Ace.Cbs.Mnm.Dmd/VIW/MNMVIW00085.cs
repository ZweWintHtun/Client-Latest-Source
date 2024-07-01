using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Mnm.Dmd
{
    /// <summary>
    /// VW_FIXEDINTWITH
    /// </summary>
    ///  
    [Serializable]
   public class MNMVIW00085
    {
        public MNMVIW00085() { }
        public virtual int Id { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual DateTime Date_Time { get; set; }
        public virtual string CreditAccountNo { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual string Currency { get; set; }
        public virtual DateTime SettlementDate { get; set; }
    }
}
