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
    public class LOMDAO00035 : DataRepository<LOMVIW00035>, ILOMDAO00035
    {
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00035> SelectByLoansType(DateTime startDate, DateTime endDate, string loansType, string cur, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("LOMDAO00035.SelectODListingByLoansType");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("cur", cur);
            query.SetString("sourceBranchCode", sourceBr);
            query.SetString("loansType", loansType);
            IList<LOMDTO00035> multilist = query.List<LOMDTO00035>();
            return multilist;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00035> SelectAll(DateTime startDate, DateTime endDate, string cur, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("LOMDAO00035.SelectAllODListing");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("cur", cur);
            query.SetString("sourceBranchCode", sourceBr);
            IList<LOMDTO00035> multilist = query.List<LOMDTO00035>();
            return multilist;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00035> SelectAllByLoansType(DateTime startDate, DateTime endDate, string loansType, string cur, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("LOMDAO00035.SelectAllByLoansType");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("loansType", loansType);
            query.SetString("cur", cur);
            query.SetString("sourceBranchCode", sourceBr);
            IList<LOMDTO00035> multilist = query.List<LOMDTO00035>();
            return multilist;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00035> SelectAllLoansOD(DateTime startDate, DateTime endDate, string cur, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("LOMDAO00035.SelectAll");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("cur", cur);
            query.SetString("sourceBranchCode", sourceBr);
            IList<LOMDTO00035> multilist = query.List<LOMDTO00035>();
            return multilist;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00035> SelectAllLoansDailyPositionByCur(string cur, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("LOMDAO00035.SelectAllLoansDailyPositionByCur");
            query.SetString("cur", cur);
            query.SetString("sourceBranchCode", sourceBr);
            IList<LOMDTO00035> multilist = query.List<LOMDTO00035>();
            return multilist;
        }
    }
}
