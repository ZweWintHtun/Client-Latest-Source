using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00129
    {
        IList<PFMDTO00029> SelectLinkAutoPriorityInfo(string SourceBr);
    }
}
