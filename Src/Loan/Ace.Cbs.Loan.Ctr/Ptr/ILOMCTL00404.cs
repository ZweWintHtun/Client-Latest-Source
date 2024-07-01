using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00404 : IPresenter
    {
        ILOMVEW00404 View { get; set; }
        string BusinessLoansMonthlyAutoPaymentProc(string sourceBr, int createdUserId, string userName);
    }

    public interface ILOMVEW00404
    {
        ILOMCTL00404 Controller { get; set; }
        DateTime nextSettlementdate { get; set; }
    }
}
