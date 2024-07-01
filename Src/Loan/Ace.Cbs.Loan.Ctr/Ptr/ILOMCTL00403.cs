using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00403 
    {
        ILOMVEW00403 View { get; set; }
        string BusinessLoansLateFeesCalculationProcess(string sourceBr, int createdUserId, string userName);
    }
    public interface ILOMVEW00403 
    {
        ILOMCTL00403 Controller { get; set; }
        DateTime lastSettlementdate { get; set; }
        DateTime nextSettlementdate { get; set; }
    }
}
