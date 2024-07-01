using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Dao;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using NHibernate;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00303 : DataRepository<LOMVIW00303>, ILOMDAO00303
    {
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00303> SelectAll(DateTime dueDate, string cur, string sourceBr,string villageCode,string townshipCode)
        {
            IQuery query = this.Session.GetNamedQuery("FarmLoanOSTReportDAO.SelectAll");
            query.SetDateTime("dueDate", dueDate);
            query.SetString("cur", cur);
            query.SetString("sourceBranchCode", sourceBr);
            query.SetString("villageCode", villageCode);
            query.SetString("townshipCode", townshipCode);
            IList<LOMDTO00303> multilist = query.List<LOMDTO00303>();
            return multilist;
        }

        [Transaction(TransactionPropagation.Required)]
        public object CalculateFarmLoanInterest(string lno,decimal samt,
            string withdrawDate,string todayDate,string sourceBr)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SP_FarmLoan_GetOutstandingInterest");
                query.SetString("LNO",lno);
                query.SetDecimal("OUTAMU",samt);
                query.SetString("SDate",withdrawDate);
                query.SetString("Endate",todayDate);
                query.SetString("SourceBr", sourceBr);
                query.SetDecimal("RInterest", 0);
                return query.UniqueResult();
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public object CalculateFarmLoanPenalFee(string lno, decimal samt, string sourceBr)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SP_FarmLoan_GetOutstandingPenalFee");
                query.SetString("LNO", lno);
                query.SetDecimal("OUTAMU", samt);
                query.SetString("SourceBr", sourceBr);
                query.SetDecimal("RInterest", 0);
                return query.UniqueResult();
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}
