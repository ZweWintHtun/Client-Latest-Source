using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Tel.Ctr.Sve
{
     public interface ITLMSVE00080 : IBaseService
    {
        IList<PFMDTO00001> SelectByAccountNumber(string accountNo);
        IList<PFMDTO00054> SaveDepositLocal(IList<TLMDTO00038> DepositCollection, TLMDTO00038 depositInfo);

    }
}


