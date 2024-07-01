using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    //Created By HWKO (11-Jul-2017)
    public interface ILOMCTL00316 : IPresenter
    {
        ILOMVEW00316 View { get; set; }

        void Print();
        bool CheckPersonalLoanAccountNo(string acctNo);
    }

    public interface ILOMVEW00316
    {
        ILOMCTL00316 Controller { get; set; }

        string SourceBranch { get; set; }
        string AcctNo { get; set; }
    }
}
