using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Tcm.Ctr.Sve
{
    public interface ITCMSVE00063
    {
        string Save(IList<TLMDTO00008> Dep_TLFCollection, TLMDTO00038 depositEntity);
        PFMDTO00028 AccountCheck(string AccountNo, string CurrencyCode);
    }
}
