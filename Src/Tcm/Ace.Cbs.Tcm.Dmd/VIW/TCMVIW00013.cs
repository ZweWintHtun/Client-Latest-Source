using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Tcm.Dmd
{
    [Serializable]
    public class TCMVIW00013 : EntityBase<TCMVIW00013>
    {
        public TCMVIW00013() { }
        public virtual string ACCTNO { get; set; }
        public virtual decimal CBAL { get; set; }
        public virtual decimal OVERDRAWN_AMOUNT { get; set; }
        public virtual decimal OVDLIMIT { get; set; }
        public virtual string NAME { get; set; }
        public virtual string WORKSTATION { get; set; }
        public virtual string SOURCECUR { get; set; }
        public virtual string ACSign { get; set; }

        public virtual PFMORM00028 CledgerAcctNo { get; set; }

    }
}
