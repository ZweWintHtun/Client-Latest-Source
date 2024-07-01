using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMVIW00061
    {
        public LOMVIW00061() { }
        public virtual int Id { get; set; }
        public virtual string AcctNo {get;set;}
        public virtual string NAME { get; set; }
        public virtual string LoanNo  {get;set;}
        public virtual decimal OVDLimit {get;set;}
        public virtual decimal OLDLimit {get;set;}
        public virtual DateTime Date_Time { get; set; }
        public virtual string UserNo {get;set;}
        public virtual string Cur {get;set;}
        public virtual string SourceBr {get;set;}
    }
}
