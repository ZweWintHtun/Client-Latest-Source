using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00431 :IPresenter
    {
        ILOMVEW00431 View { get; set; }
        void Print();
        //IList<LOMDTO00001> BindLoansBType();
    }
    public interface ILOMVEW00431
    {
        ILOMCTL00431 Controller { get; set; }

        string SourceBr { get; set; }
        string AccountType { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        bool TypeofCust { get; set; }
        string rptName { get; set; } 
    }
}
