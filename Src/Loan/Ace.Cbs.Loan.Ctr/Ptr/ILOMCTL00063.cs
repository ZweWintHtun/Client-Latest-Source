using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00063
    {
        ILOMVEW00063 View { get; set; }
        void Print();
    }

    public interface ILOMVEW00063
    {
        ILOMCTL00063 Controller { get; set; }

        string SourceBranch { get; set; }
        string Currency { get; set; }
    }
}
