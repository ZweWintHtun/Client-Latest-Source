using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00312 : IPresenter
    {
        ILOMVEW00312 View { get; set; }
        string PLMonthlyAutoPaymentProc(string sourceBr, int createdUserId, string userName); //Modified by HMW at (06-08-2019) : To prevent "Voucher No Loss Issue" in every already run (or) no need to run case.
        bool CheckCutOffForToday();
    }

    public interface ILOMVEW00312
    {
        ILOMCTL00312 Controller { get; set; }
    }
}
