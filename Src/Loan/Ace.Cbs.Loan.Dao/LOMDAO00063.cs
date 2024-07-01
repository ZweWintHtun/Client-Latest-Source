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
    public class LOMDAO00063 : DataRepository<LOMVIW00001>, ILOMDAO00063
    {
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00013> SelectNonPerformanceLoansCase(string cur, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("LOMDAO00063.SelectNonPerformanceLoansCase");
            query.SetString("cur", cur);
            query.SetString("sourceBranchCode", sourceBr);
            IList<LOMDTO00013> multilist = query.List<LOMDTO00013>();
            return multilist;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00013> SelectLegalSueCaseList(DateTime startDate,DateTime endDate,string cur, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("LOMDAO00063.SelectLegalSueCaseList");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("cur", cur);
            query.SetString("sourceBranchCode", sourceBr);
            IList<LOMDTO00013> multilist = query.List<LOMDTO00013>();
            return multilist;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00013> SelectLegalSueCaseClose(DateTime startDate, DateTime endDate, string cur, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("LOMDAO00063.SelectLegalSueCaseClose");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("cur", cur);
            query.SetString("sourceBranchCode", sourceBr);
            IList<LOMDTO00013> multilist = query.List<LOMDTO00013>();
            return multilist;
        }
    }
}
