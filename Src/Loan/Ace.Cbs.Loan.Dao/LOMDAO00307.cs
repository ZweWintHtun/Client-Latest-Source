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
    public class LOMDAO00307 : DataRepository<LOMVIW00307>, ILOMDAO00307
    {
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00307> SelectAll(DateTime startDate, DateTime endDate, string cur, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("FarmLoanTotalDailyIncomeReportDAO.SelectAll");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("cur", cur);
            query.SetString("sourceBranchCode", sourceBr);
            IList<LOMDTO00307> multilist = query.List<LOMDTO00307>();
            return multilist;
        }
    }
}
