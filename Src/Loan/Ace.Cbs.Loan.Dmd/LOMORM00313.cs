using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMORM00313 : Supportfields<LOMORM00313>
    {
        public LOMORM00313() { }

        public virtual string PLNO { get; set; }
        public virtual string COMPANYNAME { get; set; }
        public virtual string NAME { get; set; }
        public virtual string NRC { get; set; }
        public virtual string PHONE { get; set; }
        public virtual Nullable<DateTime> CLOSEDATE { get; set; }
        public virtual string UId { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }

    }
}
