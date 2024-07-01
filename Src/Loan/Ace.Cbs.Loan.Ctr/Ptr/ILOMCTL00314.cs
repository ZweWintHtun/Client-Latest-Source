using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    //Created By HWKO (11-Jul-2017)
    public interface ILOMCTL00314 : IPresenter
    {
        ILOMVEW00314 View { get; set; }

        void Print();
    }

    public interface ILOMVEW00314
    {
        ILOMCTL00314 Controller { get; set; }

        string SourceBranch { get; set; }
        DateTime SelectedDate { get; set; }
    }
}
