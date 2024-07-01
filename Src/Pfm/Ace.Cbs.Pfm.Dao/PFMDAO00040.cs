using System;
using System.Collections.Generic;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Pfm.Dao
{
    /// <summary>
    /// Si Dao
    /// </summary>
    public class PFMDAO00040 : DataRepository<PFMORM00040>, IPFMDAO00040
    {
        [Transaction(TransactionPropagation.Required)]
        public bool UpdateCloseDate(string accountNo, Nullable<DateTime> closeDate, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00040.UpdateCloseDate");
            query.SetString("accountNo", accountNo);
            query.SetDateTime("closeDate", closeDate.Value);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);

            return query.ExecuteUpdate() > 0;
        }

        public object GetMonthlyAmount(string monthlyQuery, string accountNo)
        {
            string query = "select {0} from PFMORM00040 where AccountNo = :accountNo";

            IQuery hqlQuery = this.Session.CreateQuery(string.Format(query, new object[]{monthlyQuery}));
            hqlQuery.SetString("accountNo", accountNo);

            return hqlQuery.UniqueResult();
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateInterest(string accountNo, decimal amount, string file_month, int updatedUserId)      //NLKK
        {
            string dmlString = "update PFMORM00040 si set si." + "Month" + file_month.Substring(1) + " = :amount, si.UpdatedUserId = :updatedUserId, si.UpdatedDate = :updatedDate where si.AccountNo = :accountNo";
            IQuery query = this.Session.CreateQuery(dmlString);
            query.SetDecimal("amount", amount);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetString("accountNo", accountNo);
            return query.ExecuteUpdate() > 0;
        }

        public PFMDTO00040 SelectInterestByAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00040.SelectInterestByAccountNo");
            query.SetString("accountNo", accountNo);
            return query.UniqueResult<PFMDTO00040>();
        }

        public IList<PFMDTO00040> SelectAll(string SourceBranchCode)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00040.SelectALL");
            query.SetString("SourceBranchCode", SourceBranchCode);
            IList<PFMDTO00040> res = query.List<PFMDTO00040>();
            return res;
            //return query.List<PFMDTO00003>();
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateSi(decimal si_month, int accruedint, string budget, string SourceBranchCode, int UpdatedUserID)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00040.UpdateSi");
            query.SetDecimal("si_month", si_month);
            query.SetDecimal("si_month", si_month);
            query.SetDecimal("si_month", si_month);
            query.SetDecimal("si_month", si_month);
            query.SetDecimal("si_month", si_month);
            query.SetDecimal("si_month", si_month);
            query.SetDecimal("si_month", si_month);
            query.SetDecimal("si_month", si_month);
            query.SetDecimal("si_month", si_month);
            query.SetDecimal("si_month", si_month);
            query.SetDecimal("si_month", si_month);
            query.SetDecimal("si_month", si_month);
            query.SetInt32("accruedint", accruedint);
            query.SetString("budget", budget);
            query.SetString("SourceBranchCode", SourceBranchCode);
            query.SetInt32("updatedUserId", UpdatedUserID);
            query.SetDateTime("updatedDate", DateTime.Now);


            return query.ExecuteUpdate() > 0;
        }

        public IList<PFMDTO00040> SelectByCloseDate(string sourceBr, string cur)               //NLKK
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00040.SelectByCloseDate");
            query.SetString("sourceBr", sourceBr);
            query.SetString("cur", cur);
            IList<PFMDTO00040> SiList = query.List<PFMDTO00040>();
            return SiList;
        }

        public IList<PFMDTO00040> SelectByBudgetYear(string sourceBr, string cur, string BudgetYear)               //NLKK
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00040.SelectByBudgetYear");
            query.SetString("sourceBr", sourceBr);
            query.SetString("cur", cur);
            query.SetString("Budget", BudgetYear);
            IList<PFMDTO00040> SiList = query.List<PFMDTO00040>();
            return SiList;
        }

        [Transaction(TransactionPropagation.Required)]
        public void UpdateAccruedInt(decimal accruedInt, string accountNo,int updatedUserId)                      //NLKK
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00040.UpdateAccruedIntByAccountNo");
            query.SetDecimal("accruedInt", accruedInt);
            query.SetDateTime("updateDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetString("accountNo", accountNo);
            query.ExecuteUpdate();
        }

        public IList<string> SelectCurrency(string sourceBr)               //NLKK
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00040.SelectCurrency");
            query.SetString("sourceBr", sourceBr);
            IList<string> CurList = query.List<string>();
            return CurList;
        }

        [Transaction(TransactionPropagation.Required)]
        public void UpdateAccruedIntTo0(int updatedUserId)          //NLKK
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00040.UpdateAccruedIntTo0");
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.ExecuteUpdate();
        }

        [Transaction(TransactionPropagation.Required)]
        public void UpdateAccruedIntTo0ByAccountNo(int updatedUserId,string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00040.UpdateAccruedIntTo0ByAccountNo");
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetString("accountNo", accountNo);
            query.ExecuteUpdate();
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateAccruedIntByAccountNo(decimal amount, int updatedUserId,string accountno)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00040.UpdateAccruedByAccountNo");
            query.SetDecimal("amount", amount);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetString("accountNo", accountno);
            return query.ExecuteUpdate()>0;
        }  

    }
}