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
    public class LOMDAO00059 : DataRepository<LOMVIW00059>, ILOMDAO00059
    {
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00059> SelectODLimitChangeByDate(DateTime startDate, DateTime endDate, string cur, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("LOMDAO00059.SelectODLimitChangeByDate");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("cur", cur);
            query.SetString("sourceBranchCode", sourceBr);
            IList<LOMDTO00059> multilist = query.List<LOMDTO00059>();
            return multilist;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00059> SelectODLimitChangeByAccount(DateTime startDate, DateTime endDate,string acctNo, string cur, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("LOMDAO00059.SelectODLimitChangeByAccount");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("acctNo", acctNo);
            query.SetString("cur", cur);
            query.SetString("sourceBranchCode", sourceBr);
            IList<LOMDTO00059> multilist = query.List<LOMDTO00059>();
            return multilist;
        }
    }
}
