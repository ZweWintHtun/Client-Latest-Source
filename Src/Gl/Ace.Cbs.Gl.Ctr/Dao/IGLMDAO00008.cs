using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Gl.Ctr.Dao
{
    public interface IGLMDAO00008 : IDataRepository<MNMDTO00010>
    {
        MNMDTO00010 GetCCOAAndCOAInfo(string accountcode, string currencyCode, string branchCode);       
        
        //Opeing Balance Entry
        IList<MNMDTO00010> GetCCOADataListForOpeningBalance();
        bool UpdateCCOAForOpeningBalanceEntry(MNMDTO00010 ccoaData, bool IsDelete);

        //Yearly Budget Entry
        IList<MNMDTO00010> GetCCOADataListForYearlyBudgetEntry();
        bool UpdateCCOAForYearlyBudgetEntry(MNMDTO00010 ccoaData, bool IsDelete);
        
    }
}
