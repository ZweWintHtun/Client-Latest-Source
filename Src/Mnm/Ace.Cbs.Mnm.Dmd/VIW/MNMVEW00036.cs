using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
        [Serializable]
    public class MNMVEW00036 : EntityBase<MNMVEW00036>
    {

            public MNMVEW00036() { }
            public virtual string AcctNo { get; set; }
            public virtual string Name { get; set; }
            public virtual decimal Fbal { get; set; }
            public virtual decimal BudEndAcc { get; set; }
            public virtual decimal Duration { get; set; }
            public virtual System.Nullable<DateTime> RDATE { get; set; }
            public virtual System.Nullable<DateTime> WDate { get; set; }
            public virtual System.Nullable<DateTime> LasIntDate { get; set; }
            public virtual decimal Amount { get; set; }
            public virtual string RNo { get; set; }
            public virtual decimal Accrued { get; set; }
            public virtual decimal DrAccured { get; set; }
            public virtual string SourceBr { get; set; }
            public virtual string Cur { get; set; }
    }
}
