using System;
using System.Collections.Generic;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;

namespace Ace.Cbs.Pfm.Dao
{
   
    public class PFMDAO00014 : DataRepository<PFMORM00014>,IPFMDAO00014
    {
       //Print Cheque Dao
        
       //Select ChequeNo List to Compare that is already existed in PrintCheque tbl
        public IList<PFMDTO00014> SelectByChequeBookNo(string accountNo, string chequeBookNo)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("PFMDAO00014.PrintCheque_SelectByChequeBookNo");
                query.SetString("accountNo", accountNo);
                query.SetString("chequeBookNo", chequeBookNo);
                IList<PFMDTO00014> list = query.List<PFMDTO00014>();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PFMDTO00006 CheckStartChequeNo(string accountNo, string chequeNo, string startNo, string branch)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.CheckStartChequeNo");
            query.SetString("accountNo", accountNo);
            query.SetString("chequeBookNo", chequeNo);
            query.SetString("chequeNo", startNo);
            query.SetString("branchCode", branch);
            PFMDTO00006 list = query.UniqueResult<PFMDTO00006>();
            return list;
        }

        public PFMDTO00006 CheckEndChequeNo(string accountNo, string chequeNo, string endNo, string branch)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.CheckEndChequeNo");
            query.SetString("accountNo", accountNo);
            query.SetString("chequeBookNo", chequeNo);
            query.SetString("chequeNo", endNo);
            query.SetString("branchCode", branch);
            PFMDTO00006 list = query.UniqueResult<PFMDTO00006>();
            return list;
        }

        public IList<PFMDTO00014> SelectPrintedChequeByDate(DateTime startDate, DateTime endDate,string branch)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00006.SelectPrintedChequeByDate");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("branch", branch);
            IList<PFMDTO00014> list = query.List<PFMDTO00014>();
            return list;
        }

        public IList<PFMDTO00014> SelectPrintedChequeByAccount(string accountNo,string branch)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00006.SelectPrintedChequeByAccount");
            query.SetString("accountNo", accountNo);
            query.SetString("branch", branch);
            IList<PFMDTO00014> list = query.List<PFMDTO00014>();
            return list;
        }

    }
}