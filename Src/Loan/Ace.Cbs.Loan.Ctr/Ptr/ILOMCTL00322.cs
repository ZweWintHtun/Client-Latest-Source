using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    //Created By HWKO (17-Jul-2017)
    public interface ILOMCTL00322 : IPresenter
    {
        ILOMVEW00322 View { get; set; }
        LOMDTO00316 GetViewData();
        void Print();
    }

    public interface ILOMVEW00322
    {
        ILOMCTL00322 Controller { get; set; }

        string CompanyName { get; set; }
        string SourceBranch { get; set; }
        string Currency { get; set; }
        string BudgetYear { get; set; }
    }
}
