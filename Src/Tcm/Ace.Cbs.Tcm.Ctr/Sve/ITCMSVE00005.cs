using System;
using System.Collections.Generic;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Tcm.Ctr.Sve
{
    public interface ITCMSVE00005 : IBaseService
    {
        PFMDTO00016 SelectByAccountNumber(string accountNo,string sourceBranch,DateTime todaydate);
        string Withdrawal(PFMDTO00016 entity);
        string Transfer(PFMDTO00016 entity);
    }
}
