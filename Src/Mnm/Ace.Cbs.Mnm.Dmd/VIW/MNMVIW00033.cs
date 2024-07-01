using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
    /// <summary>
    /// VW_MOB3511
    /// </summary>
    /// 
    [Serializable]
    public class MNMVIW00033 : EntityBase<MNMVIW00033>
    {
        public virtual string PONo { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual Nullable<DateTime> ADate { get; set; }
        public virtual Nullable<DateTime> IDate { get; set; }
        public virtual string Status { get;set; }
        public virtual string ToAcctNo { get; set; }
        public virtual string ACode { get; set; }
        public virtual string ACNoName { get; set; }
        public virtual string RegisterNo { get; set; }
        public virtual string Cur{ get; set; }
        public virtual Nullable<DateTime> SettlementDate { get; set; }
        public virtual Nullable<DateTime> RefundsDate { get; set; }
        public virtual string SourceBr { get; set; }
    }   
}
