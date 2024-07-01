using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Dao
{
    public interface IMNMDAO00129
    {
        IList<PFMDTO00029> SelectForLinkAutoPriority(string SourceBr);
    }
}
