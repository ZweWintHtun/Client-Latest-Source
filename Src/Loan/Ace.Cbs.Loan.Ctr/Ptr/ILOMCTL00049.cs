using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00049 : IPresenter
    {
        ILOMVEW00049 View { get; set; }
        void Print();
    }

    public interface ILOMVEW00049
    {
        ILOMCTL00049 Controller { get; set; }

        DateTime RequiredDate { get; set; }
        string SourceBranch { get; set; }
        string Currency { get; set; }
    }
}
