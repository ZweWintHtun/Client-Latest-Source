using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Dao;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using NHibernate;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00057 : DataRepository<LOMVIW00057>, ILOMDAO00057
    {
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00057> SelectServiceCharges(DateTime startDate, DateTime endDate, string cur, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("LOMDAO00057.SelectServiceCharges");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("cur", cur);
            query.SetString("sourceBranchCode", sourceBr);
            IList<LOMDTO00057> multilist = query.List<LOMDTO00057>();
            return multilist;
        }
    }
}
