using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Dao;
using NHibernate;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00093 : DataRepository<LOMVIW00093>, ILOMDAO00093
    {
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00093> SelectAllByLoanType(DateTime startDate, DateTime endDate, string cur, string sourceBr, string loanType)
        {
            IQuery query = this.Session.GetNamedQuery("FarmLoanReportDAO.SelectAllByLoanType");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("cur", cur);
            query.SetString("sourceBranchCode", sourceBr);
            query.SetString("loanType", loanType);
            IList<LOMDTO00093> multilist = query.List<LOMDTO00093>();
            return multilist;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00093> SelectAllByLoanTypeBySeasonType(DateTime startDate, DateTime endDate, string cur, string sourceBr, string seasonType, string loanType)
        {
            IQuery query = this.Session.GetNamedQuery("FarmLoanReportDAO.SelectAllByLoanTypeBySeasonType");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("cur", cur);
            query.SetString("sourceBranchCode", sourceBr);
            query.SetString("seasonType", seasonType);
            query.SetString("loanType", loanType);
            IList<LOMDTO00093> multilist = query.List<LOMDTO00093>();
            return multilist;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00093> SelectAllByLoanTypeByCropType(DateTime startDate, DateTime endDate, string cur, string sourceBr, string cropType, string loanType)
        {
            IQuery query = this.Session.GetNamedQuery("FarmLoanReportDAO.SelectAllByLoanTypeByCropType");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("cur", cur);
            query.SetString("sourceBranchCode", sourceBr);
            query.SetString("businessType", cropType);
            query.SetString("loanType", loanType);
            IList<LOMDTO00093> multilist = query.List<LOMDTO00093>();
            return multilist;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00093> SelectAll(DateTime startDate, DateTime endDate, string cur, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("FarmLoanReportDAO.SelectAll");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("cur", cur);
            query.SetString("sourceBranchCode", sourceBr);
            IList<LOMDTO00093> multilist = query.List<LOMDTO00093>();
            return multilist;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00093> SelectAllBySeasonType(DateTime startDate, DateTime endDate, string cur, string sourceBr, string seasonType)
        {
            IQuery query = this.Session.GetNamedQuery("FarmLoanReportDAO.SelectAllBySeasonType");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("cur", cur);
            query.SetString("sourceBranchCode", sourceBr);
            query.SetString("seasonType", seasonType);
            IList<LOMDTO00093> multilist = query.List<LOMDTO00093>();
            return multilist;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00093> SelectAllByCropType(DateTime startDate, DateTime endDate, string cur, string sourceBr, string cropType)
        {
            IQuery query = this.Session.GetNamedQuery("FarmLoanReportDAO.SelectAllByCropType");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("cur", cur);
            query.SetString("sourceBranchCode", sourceBr);
            query.SetString("businessType", cropType);
            IList<LOMDTO00093> multilist = query.List<LOMDTO00093>();
            return multilist;
        }
    }
}
