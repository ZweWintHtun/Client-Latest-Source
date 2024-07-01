using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Mnm.Ctr;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00059 : IBaseService
    {
        IList<PFMDTO00001> CheckingAccount(string accountNo, string branchCode);
        IList<MNMDTO00035> SelectFReceiptInfo(string acctno, string cur, string branchno);
    }
}
