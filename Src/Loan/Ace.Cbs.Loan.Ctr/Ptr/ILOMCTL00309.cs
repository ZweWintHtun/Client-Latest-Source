using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    //Created By HWKO (24-Apr-2017)
    public interface ILOMCTL00309 : IPresenter
    {
        ILOMVEW00309 View { get; set; }
        void Print();
    }

    public interface ILOMVEW00309
    {
        ILOMCTL00309 Controller { get; set; }

        string SourceBranch { get; set; }
        string Currency { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string BudgetYear { get; set; }
    }
}
