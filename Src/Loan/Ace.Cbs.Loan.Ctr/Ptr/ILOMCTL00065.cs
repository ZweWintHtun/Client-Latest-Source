using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00065 : IPresenter
    {
        ILOMVEW00065 View { get; set; }
        void Print();
    }

    public interface ILOMVEW00065
    {
        ILOMCTL00065 Controller { get; set; }

        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string SourceBranch { get; set; }
        string Currency { get; set; }
        string ParentFormName { get; set; }
    }
}
