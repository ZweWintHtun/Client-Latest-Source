using System;
using System.Collections.Generic;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Tcm.Ctr.Sve
{
    public interface ITCMSVE00001 : IBaseService
    {
        PFMDTO00028 SelectByAccountNumber(string accountNo,string branchCode,DateTime todaydate);
        string Save(PFMDTO00032 freceiptentity);
    }
}
