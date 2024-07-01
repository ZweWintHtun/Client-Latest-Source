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
    public class PFMDAO00006 : DataRepository<PFMORM00006>, IPFMDAO00006
    {
        public PFMDTO00006 SelectStartNoAndEndNoByChequeBookNo(string accountNo, string chequeBookNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00006.SelectStartNoAndEndNoByChequeBookNo");
            query.SetString("accountNo", accountNo);
            query.SetString("chequeBookNo", chequeBookNo);
            PFMDTO00006 chequeDTO = query.UniqueResult<PFMDTO00006>();
            return chequeDTO;           
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateCloseDate(string accountNo, DateTime closeDate, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00006.UpdateCloseDate");
            query.SetString("accountNo", accountNo);
            query.SetDateTime("closeDate", closeDate);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        public IList<PFMDTO00006> SelectByChequeBookNoByAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00006.SelectByChequeBookNoByAccountNo");
            query.SetString("accountNo", accountNo);
            IList<PFMDTO00006> chequeBookDTO = query.List<PFMDTO00006>();

            return chequeBookDTO;           
            
        }

        public IList<PFMDTO00006> SelectListByChequeBookNoByAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00006.SelectByChequeBookNoByAccountNo");
            query.SetString("accountNo", accountNo);
            IList<PFMDTO00006> chequeBookDTOList = query.SetFirstResult(0).SetMaxResults(3).List<PFMDTO00006>();         
            return chequeBookDTOList;
        }

        public PFMDTO00006 GetChequeInfoByChequeBookNo(string chequeBookNo,string branchCode)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00006.Select.ChequeInfoByChequeBookNo");
            query.SetString("chequebookno", chequeBookNo);
            query.SetString("branchCode", branchCode);

            return query.UniqueResult<PFMDTO00006>();
        }

        public PFMDTO00006 CheckStartChequeNo(string accountNo, string startNo, string branch)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00006.CheckStartChequeNo");
            query.SetString("accountNo", accountNo);
            query.SetString("chequeNo", startNo);
            query.SetString("branchCode", branch);
            PFMDTO00006 list = query.UniqueResult<PFMDTO00006>();
            return list;
        }


        public bool UpdateChequeInfoByChequeBookNo(string chequeBookNo, string startNo, string endNo, string sourcebr, System.Nullable<int> updatedUserId, System.Nullable<DateTime> updatedDate)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00006.UpdateChequeInfoByChequeBookNo");
            query.SetString("chequebookno", chequeBookNo);
            query.SetString("startno", startNo);
            query.SetString("endno", endNo);
            query.SetString("sourcebr", sourcebr);
            query.SetInt32("updatedUserId", updatedUserId.Value);
            query.SetDateTime("updatedDate", updatedDate.Value);

            return query.ExecuteUpdate() > 0;
        }

        public IList<PFMDTO00006> SelectIssuedChequeByDate(DateTime startDate, DateTime endDate,string branch)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00006.SelectIssuedChequeByDate");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("branch", branch);
            IList<PFMDTO00006> list = query.List<PFMDTO00006>();
            return list;
        }

        public IList<PFMDTO00006> SelectIssuedChequeByAccount(string accountNo,string branch)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00006.SelectIssuedChequeByAccount");
            query.SetString("accountNo", accountNo);
            query.SetString("branch", branch);
            IList<PFMDTO00006> list = query.List<PFMDTO00006>();
            return list;
        }
    }
}