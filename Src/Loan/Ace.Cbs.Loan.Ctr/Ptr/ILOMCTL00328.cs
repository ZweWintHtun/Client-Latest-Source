using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    //Created By HWKO (27-Oct-2017)
    public interface ILOMCTL00328 : IPresenter
    {
        ILOMVEW00328 View { get; set; }
        void Print();
    }

    public interface ILOMVEW00328
    {
        ILOMCTL00328 Controller { get; set; }

        string SourceBranch { get; set; }
        string Currency { get; set; }
        string BudgetYear { get; set; }
    }
}
