using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00313
    {
        ILOMVEW00313 View { get; set; }

        string PLLateFeesCalculationProcess(string sourceBr, int createdUserId, string userName);
        bool CheckCutOffForToday();
    }

    public interface ILOMVEW00313
    {
        ILOMCTL00313 Controller { get; set; }
    }
}
