using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tcm.Dmd;

namespace Ace.Cbs.Tcm.Ctr.Sve
{
    public interface ITCMSVE00012:IBaseService
    {
        IList<PFMDTO00011> GetCustomersByAccountNumber(string accountNo);
        IList<PFMDTO00011> GetSChequeInfoByChequeBookNo(string accountNo, string chequeBookNo, string branchCode);
        void UpdateSCheckData(PFMDTO00011 sChequeData);
    }
}
