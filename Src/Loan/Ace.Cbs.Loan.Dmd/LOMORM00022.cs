using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

/// <summary>
/// LrpLegal ORM
/// </summary>

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMORM00022 : EntityBase<LOMORM00022>
    {
        public LOMORM00022() { }

        public virtual string RepayNo { get; set; }
        public virtual string Lno { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual Nullable<DateTime> Date_Time { get; set; }        
        public virtual decimal Amount { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string DrAccountNo { get; set; }
        public virtual string AType { get; set; }      
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }
    }
}
