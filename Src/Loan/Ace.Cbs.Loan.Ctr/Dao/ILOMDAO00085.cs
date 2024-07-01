using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00085 : IDataRepository<LOMORM00085>
    {
        IList<LOMDTO00085> SelectAcctNoWhoseCloseDateIsNull(string sourceBr);
        bool UpdateFarmLoanInterest(decimal totalInt, decimal lastInt, decimal m1, decimal m2, decimal m3, decimal m4,
            decimal m5, decimal m6, decimal m7, decimal m8, decimal m9, decimal m10, decimal m11,
            decimal m12, DateTime updatedDate, int updatedUserId, string lno, string acctno, string sourceBr);
        IList<LOMDTO00085> SelectAcctNoWhoseCloseDateIsNullAndBudgetYear(string sourceBr, string budgetYear);
        IList<LOMDTO00085> SelectFarmLiInfoByLnoAndSourceBr(string lno, string sourceBr);
        string CalculateFarmLoanInterestMonthly(string lno, string smonthDate, string emonthDate, string month);
        string CalculateFarmLoanInterestByMonth(string lno, string smonthDate, string emonthDate);
        string CalculateFarmLoanInterestByDate(string lno, string smonthDate, string emonthDate);
        bool UpdateFarmLI(decimal month, string budget, string SourceBranchCode, int updatedUserId);//Updated by HWKO (16-Mar-2017)
        IList<LOMDTO00085> SelectAll(string SourceBranchCode);//Updated by HWKO (16-Mar-2017)
    }
}
