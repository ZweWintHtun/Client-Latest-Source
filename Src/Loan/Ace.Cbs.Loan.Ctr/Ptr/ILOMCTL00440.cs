using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00440 : IPresenter
    {
        ILOMVEW00440 View { get; set; }
        void Print();
    }

    public interface ILOMVEW00440
    {
        ILOMCTL00440 Controller { get; set; }

        string SourceBr { get; set; }
        string AccountType { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string rptName { get; set; }
    }
}
