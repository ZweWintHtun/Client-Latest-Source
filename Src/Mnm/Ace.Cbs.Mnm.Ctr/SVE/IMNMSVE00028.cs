using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00028
    {
        TLMDTO00001 GetReInfo(string registerNo, string sourceBr);
        IList<PFMDTO00054> Save(string registerNo, int updatedUserId, string sourceBr);
    }
}
