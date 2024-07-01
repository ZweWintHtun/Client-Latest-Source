using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00045 : IPresenter
    {
        ILOMVEW00045 View { get; set; }
        void Print();
    }

    public interface ILOMVEW00045
    {
        ILOMCTL00045 Controller { get; set; }

        string RequiredYear { get; set; }
        string SourceBranch { get; set; }
        string Currency { get; set; }
        string Quater { get; set; }
    }
}
