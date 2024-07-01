using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    //Created By HWKO (17-Jul-2017)
    public interface ILOMCTL00320 : IPresenter
    {
        ILOMVEW00320 View { get; set; }
        void Print();
    }

    public interface ILOMVEW00320
    {
        ILOMCTL00320 Controller { get; set; }

        string SourceBranch { get; set; }
        string Currency { get; set; }
        string BudgetYear { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
    }
}
