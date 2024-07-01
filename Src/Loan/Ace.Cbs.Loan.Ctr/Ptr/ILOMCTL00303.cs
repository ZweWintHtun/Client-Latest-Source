using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    //Created By HWKO (21-Mar-2017)
    public interface ILOMCTL00303 : IPresenter
    {
        ILOMVEW00303 View { get; set; }
        void Print();
    }

    public interface ILOMVEW00303
    {
        ILOMCTL00303 Controller { get; set; }

        string SourceBranch { get; set; }
        string Currency { get; set; }
        string Village { get; set; }
        string Township { get; set; }
        DateTime DueDate { get; set; }
        string BudgetYear { get; set; }
    }
}
