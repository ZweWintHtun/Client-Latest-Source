using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Pfm.Dmd;


namespace Ace.Cbs.Mnm.Ctr.Dao
{
    public interface IMNMDAO00007:IDataRepository<MNMORM00007>
    {
        IList<MNMDTO00007> SelectByCloseDate(string sourceBr, string cur);
        IList<MNMDTO00007> SelectByBudgetYear(string sourceBr, string cur, string BudgetYear);
        

        IList<MNMDTO00007> SelectUnionAllSI(string budgetyear, string sourceBr); 



    }
}
