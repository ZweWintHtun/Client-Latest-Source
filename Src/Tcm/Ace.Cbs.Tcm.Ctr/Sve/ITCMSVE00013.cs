using System;
using System.Collections.Generic;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Tcm.Ctr.Sve
{
    public interface ITCMSVE00013 : IBaseService
    {
        IList<PFMDTO00032> SelectFReceiptByAccountNo(string accountNo, string branchCode);
        void Update(PFMDTO00032 fReceiptDTO);
        void Delete(PFMDTO00032 fReceiptDTO);
    }
}
