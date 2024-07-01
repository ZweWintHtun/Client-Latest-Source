using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Tel.Ctr.Sve
{
   public interface ITLMSVE00072 :IBaseService
    {
       IList<PFMDTO00043> GetPrintTransactionByAccountNo(string accountNo);
       bool UpdateAndDeleteByAccountNo(string accountNo, IList<PFMDTO00043> prnFileList, bool isCledgerStatus, int LedgerPrintLineNo, int updatedUserId);
       int GetPrintLineNumberByAccountNo(string accountNo);
    }
}
