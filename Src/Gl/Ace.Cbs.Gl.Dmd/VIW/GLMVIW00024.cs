using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Gl.Dmd
{
    [Serializable]
    public class GLMVIW00024 : EntityBase<GLMVIW00024>
    {
        //VW_LEDGERLISTING_Monthly_Posting
        public GLMVIW00024() {}
        public virtual int Id { get; set; }
        public virtual System.Nullable<decimal> HomeoAmt { get; set; }
        public virtual string ACode { get; set; }
        public virtual char DateTime { get; set; }
        public virtual string ACType { get; set; }
        public virtual string Desp { get; set; }
        public virtual string Workstation { get; set; }
        public virtual string Currency { get; set; }
        public virtual string Sourcebr { get; set; }
        public virtual System.Nullable<decimal> CreditAmt { get; set; }
        public virtual System.Nullable<decimal> DebitAmt { get; set; }
        public virtual System.Nullable<Int32> Cash { get; set; }
    }
}
