using System;
using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
using Spring.Data;
using Spring.Stereotype;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using System.Linq;
using Ace.Cbs.CBM.Ctr.Dao;


namespace Ace.Cbs.CBM.Dao
{
    public class CBMDAO00001 : DataRepository<PFMORM00042>, ICBMDAO00001
    {
        // SP_GetAll_CashInHandPosition       
        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00042> GetAll_CashInHandPosition(DateTime date, string Currency)
        {
            IQuery query = this.Session.GetNamedQuery("SP_GetAll_CashInHandPosition_CBM");
            query.SetDateTime("date", date);
            query.SetString("cur", Currency);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00042)));
            return query.List<PFMDTO00042>();
        }

        // SP_GetAll_CashFlowData_CBM    ///Cash receive and payment Report    
        [Transaction(TransactionPropagation.Required)]
        public PFMDTO00042 GetAll_CashFlowData_CBM(DateTime date, string Currency)
        {
            IQuery query = this.Session.GetNamedQuery("SP_GetAll_CashFlowData_CBM");
            string datestring = date.ToString("yyyy/MM/dd");
            query.SetString("date", datestring);
            query.SetString("cur", Currency);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00042)));
            return query.UniqueResult<PFMDTO00042>();
        }

        //[SP_GetAll_DailyPosition_CBM]
        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00042> GetAll_DailyPosition_CBM(DateTime date, string Currency)
        {
            IQuery query = this.Session.GetNamedQuery("SP_GetAll_DailyPosition_CBM");
            query.SetDateTime("date", date);
            query.SetString("cur", Currency);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00042)));
            return query.List<PFMDTO00042>();
        }

        //[SP_GetAll_FinancialStatement_CBM]
        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00042> GetAll_FinancialStatement_CBM(DateTime date, string Currency)
        {
            IQuery query = this.Session.GetNamedQuery("SP_GetAll_FinancialStatement_CBM");
            string datestring = date.ToString("yyyy/MM/dd");
            query.SetString("date", datestring);
            query.SetString("cur", Currency);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00042)));
            return query.List<PFMDTO00042>();
        }

        //[SP_GetAll_DailyImprovement_CBM]
        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00042> GetAll_DailyImprovement_CBM(DateTime date, int budgetMonth, string Currency)
        {
            IQuery query = this.Session.GetNamedQuery("SP_GetAll_DailyImprovement_CBM");
            query.SetString("date", date.ToString("yyyy/MM/dd"));
            query.SetInt32("budgetMonth", budgetMonth);
            query.SetString("cur", Currency);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00042)));
            return query.List<PFMDTO00042>();
        }

        //[SP_GetAll_DailyProgress_CBM]
        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00042> GetAll_DailyProgress_CBM(DateTime date, int budgetMonth, string Currency)
        {
            IQuery query = this.Session.GetNamedQuery("SP_GetAll_DailyProgress_CBM");
            query.SetString("date", date.ToString("yyyy/MM/dd"));//date.ToString("yyyy/MM/dd"));
            query.SetString("cur", Currency);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00042)));
            return query.List<PFMDTO00042>();
        }

        // SP_Get_Liquidity_Ratio_CBM       
        [Transaction(TransactionPropagation.Required)]
        public PFMDTO00042 Get_Liquidity_Ratio_CBM(DateTime date, string Currency)
        {
            IQuery query = this.Session.GetNamedQuery("SP_Get_Liquidity_Ratio_CBM");
            string datestring = date.ToString("yyyy/MM/dd");
            query.SetString("date", datestring);
            query.SetString("cur", Currency);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00042)));
            return query.UniqueResult<PFMDTO00042>();
        }

        //// Cash receive and payment Report //
        //[Transaction(TransactionPropagation.Required)]
        //public PFMDTO00042 Get_Liquidity_Ratio_CBM(DateTime date, string Currency)
        //{
        //    IQuery query = this.Session.GetNamedQuery("");
        //    string datestring = date.ToString("yyyy/MM/dd");
        //    query.SetString("date", datestring);
        //    query.SetString("cur", Currency);
        //    query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00042)));
        //    return query.UniqueResult<PFMDTO00042>();
        //}
    }
}
