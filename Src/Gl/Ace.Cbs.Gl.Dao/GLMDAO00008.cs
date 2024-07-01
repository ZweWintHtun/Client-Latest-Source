using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Gl.Ctr.Dao;
using NHibernate;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using NHibernate.Transform;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Gl.Dao
{
    public class GLMDAO00008 : DataRepository<MNMDTO00010>, IGLMDAO00008
    {
        [Transaction(TransactionPropagation.Required)]
        public MNMDTO00010 GetCCOAAndCOAInfo(string accountcode, string currencyCode, string branchCode)
        {
            IQuery query = this.Session.GetNamedQuery("CXCOM00010.SelectByACODEAndCurrency");
            query.SetString("aCode", accountcode);
            query.SetString("cur", currencyCode);
            query.SetString("sourceBr", branchCode);
            MNMDTO00010 CCOAandCOAInfo = new MNMDTO00010();
            CCOAandCOAInfo = query.UniqueResult<MNMDTO00010>();

            return CCOAandCOAInfo;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<MNMDTO00010> GetCCOADataListForOpeningBalance()
        {
            IQuery query = this.Session.GetNamedQuery("GLMVEW00002.OpeningBalanceEntry");
            return query.List<MNMDTO00010>();
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateCCOAForOpeningBalanceEntry(MNMDTO00010 ccoaData, bool IsDelete)
        {
            IQuery query = this.Session.GetNamedQuery("GLMVEW00002.OpeningBalanceEntryUpdate");
            if (IsDelete)
            {
                query.SetDecimal("obal", 0);
                query.SetDecimal("hobal", 0);
            }
            else
            {
                query.SetDecimal("obal", ccoaData.OBAL.Value);
                query.SetDecimal("hobal", ccoaData.HOBAL.Value);
            }
            query.SetString("acode", ccoaData.ACODE);
            query.SetString("dcode", ccoaData.DCODE);
            query.SetString("currency", ccoaData.CUR);
            query.SetInt32("updatedUserId", ccoaData.UpdatedUserId.Value);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<MNMDTO00010> GetCCOADataListForYearlyBudgetEntry()
        {
            IQuery query = this.Session.GetNamedQuery("GLMVEW00003.YearlyBudgetEntry");
            return query.List<MNMDTO00010>();
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateCCOAForYearlyBudgetEntry(MNMDTO00010 ccoaData, bool IsDelete)
        {
            IQuery query = this.Session.GetNamedQuery("GLMVEW00003.YearlyBudgetEntryUpdate");
            if (IsDelete)
            {
                query.SetDecimal("bf", 0);                
            }
            else
            {
                query.SetDecimal("bf", ccoaData.BF.Value);               
            }
            query.SetString("acode", ccoaData.ACODE);
            query.SetString("dcode", ccoaData.DCODE);
            query.SetString("currency", ccoaData.CUR);
            query.SetInt32("updatedUserId", ccoaData.UpdatedUserId.Value);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

    }
}
