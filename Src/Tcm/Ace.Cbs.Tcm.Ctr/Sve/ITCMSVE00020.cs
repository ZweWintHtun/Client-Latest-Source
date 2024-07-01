using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tcm.Dmd;

namespace Ace.Cbs.Tcm.Ctr.Sve
{
    public interface ITCMSVE00020:IBaseService
    {
        IList<PFMDTO00001> GetCustomerByAccountNumber(string accountNo);
        void SaveMinimumBalance(TCMDTO00007 balanceDTO);
    }
}
