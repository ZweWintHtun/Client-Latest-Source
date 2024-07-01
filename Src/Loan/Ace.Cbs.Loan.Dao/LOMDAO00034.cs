using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;


namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00034 : DataRepository<LOMVIW00034>, ILOMDAO00034
    {
        public IList<LOMDTO00034> SelectLoanListing(string loans, DateTime startDate, DateTime endDate, string sourceBranchCode, string cur)
        {
            IQuery query = this.Session.GetNamedQuery("LoanRegistrationListingDAO.SelectLoanListing");
            query.SetString("loans", loans);
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("sourceBranchCode", sourceBranchCode);
            query.SetString("cur", cur);
       
            return query.List<LOMDTO00034>();
        }
        public IList<LOMDTO00034> SelectLoanListingAll(DateTime startDate, DateTime endDate, string sourceBranchCode, string cur)
        {
            IQuery query = this.Session.GetNamedQuery("LoanRegistrationListingDAO.SelectLoanListingAll");
            //query.SetString("loans", loans);
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("sourceBranchCode", sourceBranchCode);
            query.SetString("cur", cur);
            //IList<LOMDTO00034> LoanList = query.List<LOMDTO00034>();
            //return LoanList;
            return query.List<LOMDTO00034>();
        }
    }
}
