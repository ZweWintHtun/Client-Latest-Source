using System;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using System.Collections.Generic;


namespace Ace.Cbs.Pfm.Dao
{
    public class PFMDAO00023 :DataRepository<PFMORM00023>,IPFMDAO00023
    {
        #region IPFMDAO00023 Members

        public PFMDTO00023 SelectACSignAndCurByAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00023.SelectACSignAndCurByAccountNo");
            query.SetString("accountNo", accountNo);
            return query.UniqueResult<PFMDTO00023>();
        }

        //Update PrintLine Number.
        [Transaction(TransactionPropagation.Required)]
        public bool UpdatePrintLine(string accountNo, int lineNo, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00023.UpdatePrintLineNo");
            query.SetString("accountNo", accountNo);
            query.SetInt32("lineNo", lineNo);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        public int GetPrintLineNumberByAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00023.SelectPrintLineNo");
            query.SetString("accountNo", accountNo);
            return Convert.ToInt32(query.UniqueResult<PFMDTO00023>().PrintLineNo);
        }

        public decimal SelectFBalByAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00023.SelectFBalByAccountNo");
            query.SetString("accountNo", accountNo);
            return Convert.ToDecimal(query.UniqueResult<PFMDTO00023>().FixedBalance);
        }

        public bool UpdateFBalOfFLedgerForDeposit(string accountNo, decimal amount, int updatedUserId, DateTime updatedDate)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00023.UpdateFBalDeposit");
            query.SetString("accountNo", accountNo);
            query.SetDecimal("fbal", amount);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", updatedDate);
            return query.ExecuteUpdate() > 0;
        }


        public bool UpdateFBalOfFLedgerForWithdrawal(string accountNo, decimal amount, int updatedUserId, DateTime updatedDate)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00023.UpdateFBalWihdrawal");
            query.SetString("accountNo", accountNo);
            query.SetDecimal("fbal", amount);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", updatedDate);
            return query.ExecuteUpdate() > 0;
        }
        public IList<PFMDTO00023> SelectFledgerFBal(string SourceBranchCode)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00023.SelectFBal");
            query.SetString("SourceBranchCode", SourceBranchCode);
            return query.List<PFMDTO00023>();
        }

        //For shutdown Bal 
        public IList<PFMDTO00023> SelectSumFixedBal(string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("SelectSumFixedBalance");
            query.SetString("sourcebr", sourcebr);
            IList<PFMDTO00023> fledger = query.List<PFMDTO00023>();
            return fledger;
        }
        #endregion
    }
}