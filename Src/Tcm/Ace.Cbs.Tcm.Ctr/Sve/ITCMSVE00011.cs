using System;
using System.Collections.Generic;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Tcm.Ctr.Sve
{
    public interface  ITCMSVE00011: IBaseService
    {
        TLMDTO00015 GetCashDenoByEntryNo(string entryNo, string branchCode);
        string Save(TLMDTO00015 cashDenoHistoryEntity);
    }
}
