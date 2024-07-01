using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00085 : IBaseService
    {
        IList<LOMDTO00085> SelectFarmLiCloseDateIsNull(string sourceBr, string budgetYear);
        IList<LOMDTO00085> SelectFarmLiInfoByLnoAndSourceBr(string lno, string sourceBr);
        void CalculateInterestMonthly(string budgetyear, DateTime startDate, DateTime endDate);
        void CalculateInterestFromMonthToMonth(string budgetyear, DateTime startDate, DateTime endDate);
        bool CalculateFarmLoanInterestMonthly(IList<LOMDTO00085> farmLiList, DateTime startDate, DateTime endDate, string butgetyear);
        bool CalculateFarmLoanInterestByMonth(IList<LOMDTO00085> farmLiList, DateTime startDate, DateTime endDate);
        bool CalculateFarmLoanInterestByDate(IList<LOMDTO00085> farmLiList, DateTime startDate, DateTime endDate);
    }
}
