using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMORM00073 : EntityBase<LOMORM00073>
    {
        public LOMORM00073() { }

        public virtual string UMCode { get; set; }
        public virtual string UMDesp { get; set; }
        public virtual string USERNO { get; set; }
        public virtual Nullable<DateTime> DATE_TIME { get; set; }
    }
}
