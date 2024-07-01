using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00090 : IPresenter
    {
        ILOMVEW00090 View { get; set; }

        IList<LOMDTO00085> SelectFarmLiCloseDateIsNull(string sourceBr, string budgetYear);
        void CalculateInterestMonthly(string budgetyear, DateTime startDate, DateTime endDate);
        bool CalculateFarmLoanInterestMonth(IList<LOMDTO00085> farmLiList, DateTime startDate, DateTime endDate, string budgetYear);
    }

    public interface ILOMVEW00090 
    {
        ILOMCTL00090 Controller { get; set; }
    }
}
