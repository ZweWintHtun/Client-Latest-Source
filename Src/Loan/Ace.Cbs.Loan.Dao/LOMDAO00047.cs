using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Ctr.Dao;
using NHibernate;
using Ace.Cbs.Loan.Dmd;
using Spring.Transaction.Interceptor;
using Spring.Transaction;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00047 : DataRepository<LOMVIW00047>, ILOMDAO00047
    {
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00047> SelectLoansRepaymentScheduleByDate(DateTime startDate, DateTime endDate, string loansNo, string cur, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("LOMDAO00047.SelectLoansRepaymentScheduleByDate");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("cur", cur);
            query.SetString("sourceBranchCode", sourceBr);
            query.SetString("loansNo", loansNo);
            IList<LOMDTO00047> multilist = query.List<LOMDTO00047>();
            return multilist;
        }
    }
}
