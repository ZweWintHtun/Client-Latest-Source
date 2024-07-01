using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Gl.Ctr.Dao;
using NHibernate;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Gl.Dmd;

namespace Ace.Cbs.Gl.Dao
{
    class GLMDAO00001 : DataRepository<Currency>, IGLMDAO00001
    {
        public IList<CXDMD00013> SelectAllCurrency()
        {
            IQuery query = this.Session.GetNamedQuery("GLMDAO00001.SelectAllCurrencyRate");
            return query.List<CXDMD00013>();
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateCurrencyRateByCur(CXDMD00013 currency, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("GLMDAO00001.UpdateCurrencyRateByCur");
            query.SetDecimal("month1Amount", currency.Month1Ammount);
            query.SetDecimal("month2Amount", currency.Month2Ammount);
            query.SetDecimal("month3Amount", currency.Month3Ammount);
            query.SetDecimal("month4Amount", currency.Month4Ammount);
            query.SetDecimal("month5Amount", currency.Month5Ammount);
            query.SetDecimal("month6Amount", currency.Month6Ammount);
            query.SetDecimal("month7Amount", currency.Month7Ammount);
            query.SetDecimal("month8Amount", currency.Month8Ammount);
            query.SetDecimal("month9Amount", currency.Month9Ammount);
            query.SetDecimal("month10Amount", currency.Month10Ammount);
            query.SetDecimal("month11Amount", currency.Month11Ammount);
            query.SetDecimal("month12Amount", currency.Month12Ammount);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetString("cur", currency.Cur);
            query.SetString("symbol", currency.Symbol);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool DeleteCurrencyRateByCur(CXDMD00013 currency, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("GLMDAO00001.DeleteCurrencyRateByCur");
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetString("cur", currency.Cur);
            query.SetString("symbol", currency.Symbol);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool DeleteAllCurrencyRate(int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("GLMDAO00001.DeleteAllCurrencyRate");
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

    }
}
