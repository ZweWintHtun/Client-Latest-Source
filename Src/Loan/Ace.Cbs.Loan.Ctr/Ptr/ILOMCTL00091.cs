using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00091 : IPresenter
    {
        ILOMVEW00091 View { get; set; }

        void CalculateInterestFromMonthToMonth(string budgetyear, DateTime startDate, DateTime endDate);//(budget year,start date, end date)
        bool CalculateFarmLoanInterestByMonth(IList<LOMDTO00085> farmLiList, DateTime startDate, DateTime endDate);
        IList<LOMDTO00085> SelectFarmLiCloseDateIsNull(string sourceBr, string budgetYear);
    }

    public interface ILOMVEW00091
    {
        ILOMCTL00091 Controller { get; set; }
    }
}
