using System;
using System.Collections.Generic;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Dmd;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Tcm.Ctr.Sve
{
    public interface ITCMSVE00016 : IBaseService
    {
        TLMDTO00012 CutOffAndClosing(string branchCode, DateTime NextSettlementDate, DateTime currentSettlementDate, int userId);
    }
}
