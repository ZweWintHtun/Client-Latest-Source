using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00054 : IPresenter
    {
        ILOMVEW00054 View { get; set; }
        void Print();
    }

    public interface ILOMVEW00054
    {
        ILOMCTL00054 Controller { get; set; }

        string RequiredYear { get; set; }
        string SourceBranch { get; set; }
        string Currency { get; set; }
        string Quater { get; set; }
    }
}
