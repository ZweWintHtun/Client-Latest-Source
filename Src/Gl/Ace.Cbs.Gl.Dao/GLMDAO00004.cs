using System;
using System.Collections.Generic;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using Ace.Windows.Core.DataModel;
using Ace.Windows.Admin.DataModel;
using NHibernate;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using NHibernate.Transform;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Gl.Ctr.Dao;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Gl.Dao
{
    public class GLMDAO00004 : DataRepository<CurrencyChargeOfAccount>, IGLMDAO00004
    {
        /// <summary>
        /// To get Budget Entry Data for GLMVEW00004
        /// </summary>
        /// <returns></returns>
        [Transaction(TransactionPropagation.Required)]
        public IList<MNMDTO00010> GetCCOAData(bool isHomeCur)
        {
            IQuery query;
            if(isHomeCur)
                query = this.Session.GetNamedQuery("GLMVEW00004.MonthlyBudgetedEntryHomeCurrency");
            else
                query = this.Session.GetNamedQuery("GLMVEW00004.MonthlyBudgetedEntry");
            return query.List<MNMDTO00010>();
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateGetCCOAData(MNMDTO00010 dto, bool isDelete)
        {
            IQuery query = this.Session.GetNamedQuery("GLMVEW00004.MonthlyBudgetedEntryUpdate");
            if (isDelete)
            {
                query.SetDecimal("bf1", 0);
                query.SetDecimal("bf2", 0);
                query.SetDecimal("bf3", 0);
                query.SetDecimal("bf4", 0);
                query.SetDecimal("bf5", 0);
                query.SetDecimal("bf6", 0);
                query.SetDecimal("bf7", 0);
                query.SetDecimal("bf8", 0);
                query.SetDecimal("bf9", 0);
                query.SetDecimal("bf10", 0);
                query.SetDecimal("bf11", 0);
                query.SetDecimal("bf12", 0);
            }
            else
            {
                query.SetDecimal("bf1", dto.BF1.Value);
                query.SetDecimal("bf2", dto.BF2.Value);
                query.SetDecimal("bf3", dto.BF3.Value);
                query.SetDecimal("bf4", dto.BF4.Value);
                query.SetDecimal("bf5", dto.BF5.Value);
                query.SetDecimal("bf6", dto.BF6.Value);
                query.SetDecimal("bf7", dto.BF7.Value);
                query.SetDecimal("bf8", dto.BF8.Value);
                query.SetDecimal("bf9", dto.BF9.Value);
                query.SetDecimal("bf10", dto.BF10.Value);
                query.SetDecimal("bf11", dto.BF11.Value);
                query.SetDecimal("bf12", dto.BF12.Value);
            }
            query.SetString("acode", dto.ACODE);
            query.SetString("dcode", dto.DCODE);
            query.SetString("currency", dto.CUR);
            query.SetInt32("updatedUserId", dto.UpdatedUserId.Value);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateGetCCOADataForHomeCurrency(MNMDTO00010 dto, bool isDelete)
        {
            IQuery query = this.Session.GetNamedQuery("GLMVEW00004.MonthlyBudgetedEntryHomeCurrencyUpdate");
            if (isDelete)
            {
                query.SetDecimal("bfsrc1", 0);
                query.SetDecimal("bfsrc2", 0);
                query.SetDecimal("bfsrc3", 0);
                query.SetDecimal("bfsrc4", 0);
                query.SetDecimal("bfsrc5", 0);
                query.SetDecimal("bfsrc6", 0);
                query.SetDecimal("bfsrc7", 0);
                query.SetDecimal("bfsrc8", 0);
                query.SetDecimal("bfsrc9", 0);
                query.SetDecimal("bfsrc10", 0);
                query.SetDecimal("bfsrc11", 0);
                query.SetDecimal("bfsrc12", 0);
            }
            else
            {
                query.SetDecimal("bfsrc1", dto.BF1.Value);
                query.SetDecimal("bfsrc2", dto.BF2.Value);
                query.SetDecimal("bfsrc3", dto.BF3.Value);
                query.SetDecimal("bfsrc4", dto.BF4.Value);
                query.SetDecimal("bfsrc5", dto.BF5.Value);
                query.SetDecimal("bfsrc6", dto.BF6.Value);
                query.SetDecimal("bfsrc7", dto.BF7.Value);
                query.SetDecimal("bfsrc8", dto.BF8.Value);
                query.SetDecimal("bfsrc9", dto.BF9.Value);
                query.SetDecimal("bfsrc10", dto.BF10.Value);
                query.SetDecimal("bfsrc11", dto.BF11.Value);
                query.SetDecimal("bfsrc12", dto.BF12.Value);
            }
            query.SetString("acode", dto.ACODE);
            query.SetString("dcode", dto.DCODE);
            query.SetString("currency", dto.CUR);
            query.SetInt32("updatedUserId", dto.UpdatedUserId.Value);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }
    }
}
