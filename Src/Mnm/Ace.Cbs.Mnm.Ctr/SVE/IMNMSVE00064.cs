using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00064 : IBaseService
    {
        IList<MNMDTO00007> GetPrintDataList(string requiredYear, string sourceBr);
    }
}
