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
    public class PFMDAO00036 : DataRepository<PFMORM00036>, IPFMDAO00036
    {
        public PFMDTO00036 GetTopCS99(DateTime datetime, string currency,string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("CS99#00.SelectTopOneData");
            query.SetString("datetime", datetime.ToString("yyyy/MM/dd"));
            query.SetString("currencycode", currency);
            query.SetString("sourcebr", sourcebr);
            PFMDTO00036 CS99DTO = query.SetFirstResult(0).SetMaxResults(1).UniqueResult<PFMDTO00036>();
            return CS99DTO;

        }

        public PFMDTO00036 GetTopCS99WithoutCurrency(DateTime datetime,string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("CS99#00.SelectTopOneDataWithoutCurrency");
            query.SetString("datetime", datetime.ToString("yyyy/MM/dd"));
            query.SetString("sourcebr", sourcebr);
            PFMDTO00036 balance = query.UniqueResult<PFMDTO00036>();
            return balance;

        }

        public PFMDTO00036 GetTopCS99Currency(DateTime datetime,string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("CS99#00.SelectTopOneDataWithoutCurrency");
            query.SetString("datetime", datetime.ToString("yyyy/MM/dd"));
            query.SetString("sourcebr", sourcebr);
            PFMDTO00036 balance = query.UniqueResult<PFMDTO00036>();
            return balance;

        }

        [Transaction(TransactionPropagation.Required)]
        public bool DeleteForCashClosing(string branchCode,DateTime fromDate,DateTime toDate, DateTime updatedDate,int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("CS99#00.DeleteForCashClosing");
            query.SetDateTime("fromDate", fromDate);
            query.SetDateTime("toDate", toDate);
            query.SetString("branchCode", branchCode);
            //query.SetDateTime("updatedDate", updatedDate);
            //query.SetInt32("updatedUserId", updatedUserId);
            return query.ExecuteUpdate() > 0;
        }

        public decimal GetOpeningBalancefromCS99(DateTime datetime, string sourcebr)   // // call from TCMSVE00028
        {
            IQuery query = this.Session.GetNamedQuery("CS99#00.SelectTopOneDataWithoutCurrency");
            query.SetDateTime("datetime", datetime);
            query.SetString("sourcebr", sourcebr);
            decimal balance = Convert.ToDecimal(query.UniqueResult<PFMDTO00036>().Balance);
            return balance;
        }

        public IList<PFMDTO00036> SelectByDateTime(DateTime date_time,string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("CS99#00.SelectDateTime");
            query.SetString("date_time", date_time.ToString("yyyy/MM/dd"));
            query.SetString("sourceBr", sourceBr);
            return query.List<PFMDTO00036>();
        }
        public int SelectMaxId()
        {
            IQuery query = this.Session.GetNamedQuery("selectByMaxID_CS99");
            return query.UniqueResult<PFMDTO00036>().Id;
        }
    }
}