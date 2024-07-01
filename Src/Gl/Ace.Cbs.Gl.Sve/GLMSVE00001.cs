using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Gl.Ctr.Sve;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Admin.Contracts.Dao;
using Ace.Cbs.Gl.Ctr.Dao;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Cbs.Cx.Com.Dmd;

namespace Ace.Cbs.Gl.Sve
{
    class GLMSVE00001 : BaseService, IGLMSVE00001
    {
        //private ICurrencyDAO CurDAO { get; set; }
        private IGLMDAO00001 CurrencyRateEntryDAO { get; set; }

        #region Method
        public IList<CXDMD00013> SelectAllCurrency()
        {
            //return this.CurDAO.SelectAll();
            return this.CurrencyRateEntryDAO.SelectAllCurrency();
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<CXDMD00013> UpdateCurrencyRate(IList<CXDMD00013> currencyList, int updatedUserId)
        {
            try
            {
                foreach (CXDMD00013 currency in currencyList)
                {
                    this.CurrencyRateEntryDAO.UpdateCurrencyRateByCur(currency, updatedUserId);
                }
                return this.CurrencyRateEntryDAO.SelectAllCurrency();
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                throw new Exception();
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<CXDMD00013> DeleteCurrencyRateByCur(IList<CXDMD00013> currencyList, int updatedUserId)
        {
            try
            {
                foreach (CXDMD00013 currency in currencyList)
                {
                    this.CurrencyRateEntryDAO.DeleteCurrencyRateByCur(currency, updatedUserId);
                }
                return this.CurrencyRateEntryDAO.SelectAllCurrency();
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                throw new Exception();
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<CXDMD00013> DeleteAllCurrencyRate(int updatedUserId)
        {
            try
            {
                this.CurrencyRateEntryDAO.DeleteAllCurrencyRate(updatedUserId);
                return this.CurrencyRateEntryDAO.SelectAllCurrency();
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                throw new Exception();
            }
        }

        #endregion
    }
}
