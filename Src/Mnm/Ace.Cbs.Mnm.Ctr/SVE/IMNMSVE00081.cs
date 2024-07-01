using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00081 : IBaseService
    {
        IList<MNMDTO00081> SelectFreceipt(string branchCode);
    }
}
