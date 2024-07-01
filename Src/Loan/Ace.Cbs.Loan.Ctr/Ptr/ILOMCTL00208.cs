using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00208 : IPresenter
    {
        ILOMVEW00208 View { get; set; }
        string GetHPLateFeesRepayment_Amount(string hpNo, int startTerm, int endTerm, string sourceBr);
        string HPAccountExistsOrValid(string hpNo, string sourceBr);
        string HPLateFeesRepaymentProcess(string hpNo, int startTerm, int endTerm, decimal totalLateFeesAmount, string eno, string sourceBr, int createdUserId, string userName);
        DateTime GetSystemDate(string sourceBr);
        DateTime GetLastSettlementDate(string sourceBr);
    }
    public interface ILOMVEW00208
    {
        ILOMCTL00208 Controller { get; set; }
        string HPNo { get; set; }
        int StartTerm { get; set; }
        int EndTerm { get; set; }
        string TotalLateFeesAmount { get; set; }
    }
}