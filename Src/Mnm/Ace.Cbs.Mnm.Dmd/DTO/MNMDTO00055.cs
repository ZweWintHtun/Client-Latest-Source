using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Mnm.Dmd
{
     [Serializable]
    public class MNMDTO00055
    {
        public virtual IList<PFMDTO00001> InformationList { get; set; }
        public virtual TLMDTO00015 CashDenoDto { get; set; }
    }
}
