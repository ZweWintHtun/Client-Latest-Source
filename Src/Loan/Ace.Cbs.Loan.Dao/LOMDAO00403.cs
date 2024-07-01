using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Transaction.Interceptor;
using NHibernate;
using Spring.Transaction;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Dao;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00403 : DataRepository<LOMORM00403>, ILOMDAO00403
    {
        [Transaction(TransactionPropagation.Required)]
        public string BusinessLoansLateFeesCalculationProcess(string sourceBr, int createdUserId, string userName)
        {
            IQuery query = this.Session.GetNamedQuery("SP_Get_BusinessLoans_LateFeesForAllBLAccount");
            query.SetString("sourcebr", sourceBr);
            query.SetInt32("createduserid", createdUserId);
            query.SetString("username", userName);
            return query.UniqueResult().ToString();
        }
        [Transaction(TransactionPropagation.Required)]
        public string BusinessLoansMonthlyAutoPaymentProc(string sourceBr, int createdUserId, string userName)
        {
            IQuery query = this.Session.GetNamedQuery("SP_BL_Monthly_AutoPayment_ForAllBLAccount");            
            query.SetString("sourcebr", sourceBr);
            query.SetInt32("createduserid", createdUserId);
            query.SetString("username", userName);
            query.SetTimeout(10000); // Added By AAM(15_Aug_2018)            
            return query.UniqueResult().ToString();
        }
        

    }
}
