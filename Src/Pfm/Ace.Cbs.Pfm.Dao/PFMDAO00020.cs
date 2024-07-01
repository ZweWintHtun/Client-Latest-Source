using System;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using System.Collections.Generic;
using NHibernate;
using Spring.Transaction.Interceptor;
using Spring.Transaction;

namespace Ace.Cbs.Pfm.Dao
{
    public class PFMDAO00020 : DataRepository<PFMORM00020>, IPFMDAO00020
    {
        [Transaction(TransactionPropagation.Required)]
        public bool UpdateUsedChequeNo(string AccountNo, string ChequeNo, string SourceBranchCode, int UpdatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00020.UpdateUsedChequeNo");
            query.SetString("AccountNo", AccountNo);
            query.SetString("chequeNo", ChequeNo);
            query.SetInt32("UpdatedUserId", UpdatedUserId);
            query.SetDateTime("UpdatedDate", DateTime.Now);
            query.SetString("SourceBranchCode", SourceBranchCode);
            return query.ExecuteUpdate() > 0;
        }

        public IList<PFMDTO00020> GetUCheckData(DateTime startDate, DateTime endDate, string branch)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00020.SelectUCheckData");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("branch", branch);
            IList<PFMDTO00020> list = query.List<PFMDTO00020>();
            return list;
        }

        //PFMSVE00015
        public IList<PFMDTO00020> SelectUchequeByAccountNoChequeNo(string accountNo, string chequeNo, string activeBranch)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00020.UCheque.SelectUchequeByAccountNoChequeNo");
            query.SetString("AccountNo", accountNo);
            //query.SetString("ChequeNo", chequeNo);
            query.SetString("ActiveBranch", activeBranch);
            IList<PFMDTO00020> list = query.List<PFMDTO00020>();
            return list;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool DeletefromUCheckbyId(int id, int UpdatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00020.DeletefromUCheckbyId");
            query.SetDateTime("UpdatedDate", DateTime.Now);
            query.SetInt32("UpdatedUserId", UpdatedUserId);
            query.SetInt32("id", id);
            return query.ExecuteUpdate() > 0;
        }
    }
}