using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Dao;
using NHibernate;
using Spring.Transaction.Interceptor;
using Spring.Transaction;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00085 : DataRepository<LOMORM00085>, ILOMDAO00085
    {
        public IList<LOMDTO00085> SelectAcctNoWhoseCloseDateIsNull(string sourceBr)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("FarmLiDAO.SelectAcctNoWhoseCloseDateIsNull");
                query.SetString("sourceBr", sourceBr);
                return query.List<LOMDTO00085>();
            }
            catch { throw; }
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateFarmLoanInterest(decimal totalInt,decimal lastInt,decimal m1,decimal m2,decimal m3, decimal m4,
            decimal m5,decimal m6,decimal m7,decimal m8,decimal m9,decimal m10, decimal m11,
            decimal m12,DateTime updatedDate,int updatedUserId,string lno,string acctno,string sourceBr)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("FarmLiDAO.UpdateFarmLoanInterest");
                query.SetDecimal("totalInt", totalInt);
                query.SetDecimal("lastInt", lastInt);
                query.SetDecimal("m1", m1);
                query.SetDecimal("m2", m2);
                query.SetDecimal("m3", m3);
                query.SetDecimal("m4", m4);
                query.SetDecimal("m5", m5);
                query.SetDecimal("m6", m6);
                query.SetDecimal("m7", m7);
                query.SetDecimal("m8", m8);
                query.SetDecimal("m9", m9);
                query.SetDecimal("m10", m10);
                query.SetDecimal("m11", m11);
                query.SetDecimal("m12", m12);
                query.SetDateTime("updatedDate", DateTime.Now);
                query.SetInt32("updatedUserId", updatedUserId);
                query.SetString("lno",lno);
                query.SetString("acctNo",acctno);
                query.SetString("sourceBr",sourceBr);
                return query.ExecuteUpdate() > 0;
            }
            catch { throw; }
        }

        public IList<LOMDTO00085> SelectAcctNoWhoseCloseDateIsNullAndBudgetYear(string sourceBr,string budgetYear)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("FarmLiDAO.SelectFarmLIWhoseCloseDateIsNullAndBudgetYear");
                query.SetString("sourceBr", sourceBr);
                query.SetString("budget", budgetYear);
                return query.List<LOMDTO00085>();
            }
            catch { throw; }
        }

        public IList<LOMDTO00085> SelectFarmLiInfoByLnoAndSourceBr(string lno, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("FarmLiDAO.SelectFarmLiInfoByLnoAndSourceBr");
            query.SetString("sourceBr", sourceBr);
            query.SetString("lno", lno);
            return query.List<LOMDTO00085>();
        }

        [Transaction(TransactionPropagation.Required)]
        public string CalculateFarmLoanInterestMonthly(string lno,string smonthDate,string emonthDate,string month)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SP_FarmLoanInterestCalculationByMonthly");
                query.SetString("LNO", lno);
                query.SetString("SMonthDate", smonthDate); //input format "yyyy/mm/dd"
                query.SetString("EMonthDate", emonthDate); //input format "yyyy/mm/dd"
                query.SetString("Month", month); //name of month column to update
                query.SetDecimal("RINTEREST", 0);
                return query.UniqueResult().ToString();
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public string CalculateFarmLoanInterestByMonth(string lno, string smonthDate, string emonthDate)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SP_FarmLoan_InterestCalculationByMonth");
                query.SetString("LNO", lno);
                query.SetString("SDate", smonthDate); //input format "yyyy/mm/dd"
                query.SetString("Endate", emonthDate); //input format "yyyy/mm/dd"
                query.SetDecimal("RInterest", 0);
                return query.UniqueResult().ToString();
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public string CalculateFarmLoanInterestByDate(string lno, string smonthDate, string emonthDate)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SP_FarmLoan_InterestCalculationByDate");
                query.SetString("LNO", lno);
                query.SetString("SDate", smonthDate); //input format "yyyy/mm/dd"
                query.SetString("Endate", emonthDate); //input format "yyyy/mm/dd"
                query.SetDecimal("RInterest", 0);
                return query.UniqueResult().ToString();
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        //Updated by HWKO (16-Mar-2017)
        [Transaction(TransactionPropagation.Required)]
        public bool UpdateFarmLI(decimal month, string budget, string SourceBranchCode, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("FarmLiDAO.UpdateFarmLI");
            query.SetDecimal("month", month);
            query.SetString("budget", budget);
            query.SetString("sourceBr", SourceBranchCode);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        //Updated by HWKO (16-Mar-2017)
        public IList<LOMDTO00085> SelectAll(string SourceBranchCode)
        {
            IQuery query = this.Session.GetNamedQuery("FarmLiDAO.SelectAll");
            query.SetString("sourceBr", SourceBranchCode);
            return query.List<LOMDTO00085>();
        }
    }
}
