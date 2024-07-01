using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Gl.Ctr.Sve
{
    public interface IGLMSVE00003 : IBaseService
    {
        IList<MNMDTO00010> GetCCOADataList();
        bool UpdateCCOAListForYearlyBudgetEntry(IList<MNMDTO00010> CCOADataList, bool IsDelete);
    }
}
