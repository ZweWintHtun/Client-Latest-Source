using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00201 : IPresenter
    {
        ILOMVEW00201 View { get; set; }
        string HPMonthlyAutoPaymentProc(string sourceBr, int createdUserId, string userName);
        bool CheckCutOffForToday();
    }
    public interface ILOMVEW00201
    {
        ILOMCTL00201 Controller { get; set; }
    }
}
