using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Dao;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Cbs.Loan.Dmd.DTO;
using NHibernate;
using NHibernate.Transform;
using Microsoft.SqlServer.Server;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00444 : DataRepository<LOMORM00010>, ILOMDAO00444
    {
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00444> GetLimitExtendList(DateTime date, string sortby)
        {
            IQuery query = this.Session.GetNamedQuery("SP_GetBLLimitEntendList");
            query.SetDateTime("date", date);
            query.SetString("acctno", sortby);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00444)));
            return query.List<LOMDTO00444>();
        }

        
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00423> GetNeedToExtendAccountInfo(string acctno)
        {
            IQuery query = this.Session.GetNamedQuery("SP_GetNeedToExtendAccountInfo");
            query.SetString("acctno", acctno);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00423)));
            return query.List<LOMDTO00423>();
        }

        [Transaction(TransactionPropagation.Required)]
        public string SaveLimitExtendInfo(string totalExtendDuration, string accountNo, string docFeeNew, string intRateNew, string userID, string sourceBr, string preExtend, string sChargeNew)
        {
            IQuery query = this.Session.GetNamedQuery("SP_SaveExtendListInfo");
            query.SetInt32("extduration", Convert.ToInt32(totalExtendDuration));
            query.SetString("acctno", accountNo);
            query.SetDecimal("docfee", Convert.ToDecimal(docFeeNew));
            query.SetDecimal("intrate", Convert.ToDecimal(intRateNew));
            query.SetString("userid", userID);
            query.SetString("sourcebr", sourceBr);
            query.SetString("preextend", preExtend);
            query.SetDecimal("scharge", Convert.ToDecimal(sChargeNew));
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00423)));
            LOMDTO00423 multilist = query.UniqueResult<LOMDTO00423>();
            return multilist.saveResult;
        }

        [Transaction(TransactionPropagation.Required)]
        public LOMDTO00423 Get_BL_SanctionAmountInfo(string accountNo,string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_GetSanctionAmountInfo");            
            query.SetString("acctno", accountNo);
            query.SetString("sourcebr",sourceBr);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00423)));
            LOMDTO00423 multilist = query.UniqueResult<LOMDTO00423>();
            return query.UniqueResult<LOMDTO00423>();
        }

       
    }
}
