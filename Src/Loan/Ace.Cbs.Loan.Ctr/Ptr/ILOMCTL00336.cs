using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00336
    {
        ILOMVEW00336 View { get; set; }

        void Print();
        bool CheckPLAccountNo(string acctNo);
    }

    public interface ILOMVEW00336
    {
        ILOMCTL00336 Controller { get; set; }

        string SourceBranch { get; set; }
        string AcctNo { get; set; }
        DateTime DateFromView { get; set; }
        string Reason { get; set; }
    }
}
