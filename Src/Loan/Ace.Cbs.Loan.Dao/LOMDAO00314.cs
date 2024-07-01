using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;
using NHibernate;
using Spring.Transaction.Interceptor;
using Spring.Transaction;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00314 : DataRepository<LOMVIW00314>, ILOMDAO00314
    {
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00314> SelectAll(string sourceBr,DateTime expireddate)
        {
            IQuery query = this.Session.GetNamedQuery("ExpireLandLeaseListingDAO.SelectAll");
            //query.SetString("cur", cur);
            query.SetString("sourceBranchCode", sourceBr);
            DateTime endtemp = Convert.ToDateTime(expireddate.ToString("yyyy/MM/dd"));
            query.SetDateTime("expireddate", endtemp);
            IList<LOMDTO00314> multilist = query.List<LOMDTO00314>();
            return multilist;
        }
    }
}
