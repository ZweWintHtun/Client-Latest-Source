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
using NHibernate.Transform;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00316 : DataRepository<LOMVIW00316>, ILOMDAO00316
    {
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00316> SelectByPLNO(string acctNo, string sourceBr)
        {
            var query = this.Session.GetNamedQuery("PLRepaymentScheduleListingDAO.SelectByPLNO")
            .SetString("acNo", acctNo)
            .SetString("sourceBranchCode", sourceBr)
            .SetResultTransformer(Transformers.AliasToBean<LOMDTO00316>()).List<LOMDTO00316>();
            IList<LOMDTO00316> multilist = query.ToList<LOMDTO00316>();
            return multilist;
        }

        //Currently Not Use >> Comment by HMW (20-03-2023) : For the preformance issue (Server Header Data Receving Error)
        /*
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00316> SelectByDueDateForPLIntDuePreListing(DateTime startDate,DateTime endDate, string sourceBr,string currency)
        {
            var query = this.Session.GetNamedQuery("PLRepaymentScheduleListingDAO.SelectByDueDateForPLIntDuePreListing")
            .SetDateTime("startDate", startDate)
            .SetDateTime("endDate", endDate)
            .SetString("sourceBranchCode", sourceBr)
            .SetString("cur", currency)
            .SetTimeout(72000)
            .SetResultTransformer(Transformers.AliasToBean<LOMDTO00316>()).List<LOMDTO00316>();
            IList<LOMDTO00316> multilist = query.ToList<LOMDTO00316>();
            return multilist;
        }
        */

        //Added by HMW at 20-03-2023 : Query to Script change, For the preformance issue (Server Header Data Receving Error)
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00316> SelectByDueDateForPLIntDuePreListing(DateTime startDate, DateTime endDate, string sourceBr, string currency)
        {
            IQuery query = this.Session.GetNamedQuery("SP_PLInterest_Due_PreListing");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("cur", currency);
            query.SetString("sourcebr", sourceBr);                       

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00316)));
            IList<LOMDTO00316> multilist = query.List<LOMDTO00316>();
            return multilist;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00316> SelectPLOverdrawnListing(string sourceBr, string currency,DateTime startDate,DateTime endDate)
        {
            IQuery query = this.Session.GetNamedQuery("SP_PL_GetOverdrawnAccountListing");
            query.SetString("sourcebr", sourceBr);
            query.SetString("cur", currency);
            query.SetDateTime("startDate",startDate);
            query.SetDateTime("endDate", endDate);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00316)));
            IList<LOMDTO00316> multilist = query.List<LOMDTO00316>();
            return multilist;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00316> SelectPLOverdrawnListingByCompanyName(string sourceBr, string currency,string companyName)
        {
            IQuery query = this.Session.GetNamedQuery("SP_PL_GetOverdrawnWithCompanyNameListing");
            query.SetString("sourcebr", sourceBr);
            query.SetString("cur", currency);
            query.SetString("companyname", companyName);
            query.SetTimeout(72000);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00316)));
            IList<LOMDTO00316> multilist = query.List<LOMDTO00316>();
            return multilist;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00316> SelectCompanyName()
        {
            IQuery query = this.Session.GetNamedQuery("PLRepaymentScheduleListingDAO.SelectCompanyName");
            IList<LOMDTO00316> multilist = query.List<LOMDTO00316>();
            return multilist;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00316> SelectPLRepaymentListing(DateTime startDate, DateTime endDate, string sourceBr, string currency)
        {
            IQuery query = this.Session.GetNamedQuery("SP_PLRepaymentListing");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("sourceBranchCode", sourceBr);
            query.SetString("cur", currency);
            query.SetTimeout(72000);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00316)));
            IList<LOMDTO00316> multilist = query.List<LOMDTO00316>();
            return multilist;
        }

       


    }
}
