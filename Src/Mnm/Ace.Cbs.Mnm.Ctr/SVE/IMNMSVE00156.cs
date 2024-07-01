using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00156 : IBaseService
    {
        //IList<TLMDTO00017> GetDrawingEncashRemittanceLists(string typename, string sourceBr, string budgetYear);
        IList<TLMDTO00017> GetDrawingRemittanceLists(string typename, string sourceBr, string budgetYear);
        IList<TLMDTO00001> GetEncashRemittanceLists(string typename, string sourceBr, string budgetYear);
        //IList<TLMDTO00001> GetEncashRemittanceLists(string typename, string sourceBr, string budgetYear);
    }
}
