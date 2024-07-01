using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Gl.Ctr.Ptr
{
    public interface IGLMCTL00028 : IPresenter
    {
        IGLMVEW00028 View { get; set; }
        string GetBudYear();
        void Print();
    }

    public interface IGLMVEW00028
    {
        IGLMCTL00028 Controller { get; set; }

        string SourceBranch { get; set; }
        string Currency { get; set; }
        string RequireYear { get; set; }
        string RequireMonth { get; set; }
        string BudgetYear { get; set; }
        string CurrentBCode { get; set; }
    }
}
