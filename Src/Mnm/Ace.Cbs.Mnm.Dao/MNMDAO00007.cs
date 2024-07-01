using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.Core;
using NHibernate;

namespace Ace.Cbs.Mnm.Dao
{
    public class MNMDAO00007:DataRepository<MNMORM00007>,IMNMDAO00007
    {
        public IList<MNMDTO00007> SelectByCloseDate(string sourceBr, string cur)
        {
            IQuery query = this.Session.GetNamedQuery("MNMDAO00007.SelectByCloseDate");
            query.SetString("sourceBr", sourceBr);
            query.SetString("cur", cur);
            return query.List<MNMDTO00007>();
        }

        public IList<MNMDTO00007> SelectByBudgetYear(string sourceBr, string cur, string BudgetYear)
        {
            IQuery query = this.Session.GetNamedQuery("MNMDAO00007.SelectByBudgetYear");
            query.SetString("sourceBr", sourceBr);
            query.SetString("cur", cur);
            query.SetString("Budget", BudgetYear);
            return query.List<MNMDTO00007>();
        }

        public IList<MNMDTO00007> SelectUnionAllSI(string budgetyear, string sourceBr)
        {            
            IQuery query = this.Session.GetNamedQuery("MNMDAO00007.SelectUnionAllSI");
            query.SetString("budgetyear", budgetyear);
            query.SetString("sourceBr", sourceBr);
            return query.List<MNMDTO00007>();
        }
    }
}
