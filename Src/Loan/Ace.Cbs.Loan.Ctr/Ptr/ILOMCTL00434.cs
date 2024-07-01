using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00434 :IPresenter
    {
        ILOMVEW00434 View { get; set; }
        void Print();
    }
    public interface ILOMVEW00434
    {
        ILOMCTL00434 Controller { get; set; }

        string SourceBr { get; set; }
        string AccountType { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        bool TypeofCust { get; set; }
        string rptName { get; set; } 
    }
}
