using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMORM00099 : EntityBase<LOMORM00099>
    {
        public LOMORM00099() { }

        public virtual int Id { get; set; }
        public virtual string RENO { get; set; }
        public virtual string BusinessType { get; set; }
        public virtual decimal UM { get; set; }

        public virtual LOMORM00086 LoanRecord { get; set; }
    }
}
