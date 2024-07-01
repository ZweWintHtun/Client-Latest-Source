using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00338
    {
        ILOMVEW00338 View { get; set; }

        void Print();
        bool CheckBLAccountNo(string acctNo);
    }

    public interface ILOMVEW00338
    {
        ILOMCTL00338 Controller { get; set; }

        string SourceBranch { get; set; }
        string AcctNo { get; set; }
        DateTime DateFromView { get; set; }
    }
}
