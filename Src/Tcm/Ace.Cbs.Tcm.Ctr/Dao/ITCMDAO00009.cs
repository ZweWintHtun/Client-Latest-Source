using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Tcm.Ctr.Dao
{
    public interface ITCMDAO00009:IDataRepository<TCMORM00009>
    {
        bool DeleteForCashClosing(string branchCode, DateTime fromDate, DateTime toDate, DateTime updatedDate, int updatedUserId);
        IList<TCMDTO00009> SelectTotalAmountsForCashClosing(string branchCode, DateTime datetime);
        IList<TCMDTO00009> SelectDenoDeatilForCashClosing(string currency, string counterNo, string branchCode, DateTime datetime);
        DateTime SelectMaximunDate(string currency, string counterNo, string branchCode);
        DateTime SelectMaximunDateForCashControl(string datetimestring);
        int SelectMaxId();
        
    }
}
