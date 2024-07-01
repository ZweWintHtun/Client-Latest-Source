using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Tcm.Ctr.Dao;
using Ace.Windows.Core.Dao;
using Spring.Transaction;
using Spring.Transaction.Interceptor;


namespace Ace.Cbs.Tcm.Dao
{
    public class TCMDAO00009 : DataRepository<TCMORM00009>, ITCMDAO00009
    {
        [Transaction(TransactionPropagation.Required)]
        public bool DeleteForCashClosing(string branchCode, DateTime fromDate, DateTime toDate, DateTime updatedDate, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("TCMORM00009.DeleteForCashClosing");
            query.SetDateTime("fromDate", fromDate);
            query.SetDateTime("toDate", toDate);
            query.SetString("branchCode", branchCode);
            //query.SetDateTime("updatedDate", updatedDate);
            //query.SetInt32("updatedUserId", updatedUserId);
            return query.ExecuteUpdate() > 0;
        }

        public IList<TCMDTO00009> SelectTotalAmountsForCashClosing(string branchCode,DateTime datetime)
        {
            IQuery query = this.Session.GetNamedQuery("TCMORM00009.SelectTotalAmounts");
            query.SetString("branchCode", branchCode);
            query.SetDateTime("datetime", datetime);
            return query.List<TCMDTO00009>();
        }

        public IList<TCMDTO00009> SelectDenoDeatilForCashClosing(string currency,string counterNo,string branchCode, DateTime datetime)
        {
            IQuery query = this.Session.GetNamedQuery("TCMORM00009.SelectDenoDeatil");
            query.SetString("branchCode", branchCode);
            query.SetString("counterNo", counterNo);
            query.SetString("currency", currency);
            query.SetString("datetime", datetime.ToString("yyyy/MM/dd"));
            return query.List<TCMDTO00009>();
        }

        public DateTime SelectMaximunDate(string currency, string counterNo, string branchCode)
        {
            IQuery query = this.Session.GetNamedQuery("TCMORM00009.SelectMaxDate");
            query.SetString("branchCode", branchCode);
            query.SetString("counterNo", counterNo);
            query.SetString("currency", currency);
            return query.UniqueResult<TCMDTO00009>().Date.Value;
        }

        public DateTime SelectMaximunDateForCashControl(string datetimestring)
        {
            IQuery query = this.Session.GetNamedQuery("TCMORM00009.SelectMaxDateForCashControl");
            query.SetString("datetime", datetimestring);
            return query.UniqueResult<TCMDTO00009>().Date.Value;
        }

        public int SelectMaxId()
        {
            IQuery query = this.Session.GetNamedQuery("selectByMaxID");
            return query.UniqueResult<TCMDTO00009>().Id;
        }
    }
}
