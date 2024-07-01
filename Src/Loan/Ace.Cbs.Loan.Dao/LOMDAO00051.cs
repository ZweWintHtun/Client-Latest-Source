using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Dao;
using Spring.Transaction.Interceptor;
using NHibernate;
using Spring.Transaction;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00051 : DataRepository<LOMVIW00051>, ILOMDAO00051
    {
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00035> SelectExpireLoansByCur(string year,string month, string cur, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("LOMDAO00051.SelectExpireLoansByCur");
            query.SetString("year", year);
            query.SetString("month", month);
            query.SetString("cur", cur);
            query.SetString("sourceBranchCode", sourceBr);
            IList<LOMDTO00035> multilist = query.List<LOMDTO00035>();
            return multilist;
        }
    }
}
