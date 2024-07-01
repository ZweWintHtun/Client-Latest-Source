using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMORM00077 : EntityBase<LOMORM00077>
    {
        public LOMORM00077() { }

        public virtual string LSProductTypeItemId { get; set; }
        public virtual string ProductCode { get; set; }
        public virtual string LSBusinessCode { get; set; }
        public virtual string UMCode { get; set; }
        public virtual int DurationMonths { get; set; }
        public virtual string USERNO { get; set; }
        public virtual Nullable<DateTime> DATE_TIME { get; set; }
    }
}
