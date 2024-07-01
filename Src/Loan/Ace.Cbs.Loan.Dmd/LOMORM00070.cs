using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMORM00070 : EntityBase<LOMORM00070>
    {
        public LOMORM00070() { }

        public virtual string VillageCode { get; set; }
        public virtual string Desp { get; set; }
        public virtual string USERNO { get; set; }
        public virtual Nullable<DateTime> DATE_TIME { get; set; }
    }
}
