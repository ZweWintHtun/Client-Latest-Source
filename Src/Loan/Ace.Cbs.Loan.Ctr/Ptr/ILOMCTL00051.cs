using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00051 : IPresenter
    {
        ILOMVEW00051 View { get; set; }
        void Print();
    }

    public interface ILOMVEW00051
    {
        ILOMCTL00051 Controller { get; set; }

        string RequiredYear { get; set; }
        string RequiredMonth { get; set; }
        string SourceBranch { get; set; }
        string Currency { get; set; }
    }
}
