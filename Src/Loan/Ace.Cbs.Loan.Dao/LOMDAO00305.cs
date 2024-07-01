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
    public class LOMDAO00305 : DataRepository<LOMVIW00305>, ILOMDAO00305
    {
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00305> SelectAll(DateTime withdrawDate, string cur, string sourceBr, string villageCode, string townshipCode)
        {
            IQuery query = this.Session.GetNamedQuery("FarmLoanOSTByWithdrawDateReportDAO.SelectAll");
            query.SetDateTime("withdrawDate", withdrawDate);
            query.SetString("cur", cur);
            query.SetString("sourceBranchCode", sourceBr);
            query.SetString("villageCode", villageCode);
            query.SetString("townshipCode", townshipCode);
            IList<LOMDTO00305> multilist = query.List<LOMDTO00305>();
            return multilist;
        }

    }
}
