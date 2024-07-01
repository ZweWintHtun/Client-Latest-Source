using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00438 : IPresenter
    {
        ILOMVEW00438 View { get; set; }
        void Print();
    }
    public interface ILOMVEW00438
    {
        ILOMCTL00438 Controller { get; set; }

        string SourceBr { get; set; }
        string AccountType { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string rptName { get; set; }
    }
}
