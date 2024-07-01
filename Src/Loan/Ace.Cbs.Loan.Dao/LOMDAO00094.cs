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
    public class LOMDAO00094 : DataRepository<LOMVIW00094>, ILOMDAO00094
    {
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00094> SelectAllByLoanType(DateTime startDate, DateTime endDate, string cur, string sourceBr, string loanType)
        {
            IQuery query = this.Session.GetNamedQuery("LSFarmLoanReportDAO.SelectAllByLoanType");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("cur", cur);
            query.SetString("sourceBranchCode", sourceBr);
            query.SetString("loanType", loanType);
            IList<LOMDTO00094> multilist = query.List<LOMDTO00094>();
            return multilist;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00094> SelectAllByLoanTypeByBusinessType(DateTime startDate, DateTime endDate, string cur, string sourceBr,string businessType, string loanType)
        {
            IQuery query = this.Session.GetNamedQuery("LSFarmLoanReportDAO.SelectAllByLoanTypeByBusinessType");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("cur", cur);
            query.SetString("sourceBranchCode", sourceBr);
            query.SetString("businessType", businessType);
            query.SetString("loanType", loanType);
            IList<LOMDTO00094> multilist = query.List<LOMDTO00094>();
            return multilist;
        }

        //[Transaction(TransactionPropagation.Required)]
        //public IList<LOMDTO00094> SelectAllByLoanTypeByCropType(DateTime startDate, DateTime endDate, string cur, string sourceBr, string cropType, string loanType)
        //{
        //    IQuery query = this.Session.GetNamedQuery("FarmLoanReportDAO.SelectAllByLoanTypeByCropType");
        //    query.SetDateTime("startDate", startDate);
        //    query.SetDateTime("endDate", endDate);
        //    query.SetString("cur", cur);
        //    query.SetString("sourceBranchCode", sourceBr);
        //    query.SetString("businessType", cropType);
        //    query.SetString("loanType", loanType);
        //    IList<LOMDTO00094> multilist = query.List<LOMDTO00094>();
        //    return multilist;
        //}

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00094> SelectAll(DateTime startDate, DateTime endDate, string cur, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("LSFarmLoanReportDAO.SelectAll");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("cur", cur);
            query.SetString("sourceBranchCode", sourceBr);
            IList<LOMDTO00094> multilist = query.List<LOMDTO00094>();
            return multilist;
        }

        //[Transaction(TransactionPropagation.Required)]
        //public IList<LOMDTO00094> SelectAllBySeasonType(DateTime startDate, DateTime endDate, string cur, string sourceBr, string seasonType)
        //{
        //    IQuery query = this.Session.GetNamedQuery("FarmLoanReportDAO.SelectAllBySeasonType");
        //    query.SetDateTime("startDate", startDate);
        //    query.SetDateTime("endDate", endDate);
        //    query.SetString("cur", cur);
        //    query.SetString("sourceBranchCode", sourceBr);
        //    query.SetString("seasonType", seasonType);
        //    IList<LOMDTO00094> multilist = query.List<LOMDTO00094>();
        //    return multilist;
        //}

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00094> SelectAllByBusinessType(DateTime startDate, DateTime endDate, string cur, string sourceBr, string businessType)
        {
            IQuery query = this.Session.GetNamedQuery("LSFarmLoanReportDAO.SelectAllByBusinessType");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("cur", cur);
            query.SetString("sourceBranchCode", sourceBr);
            query.SetString("businessType", businessType);
            IList<LOMDTO00094> multilist = query.List<LOMDTO00094>();
            return multilist;
        }
    }
}
