using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00327 : IPresenter
    {
        ILOMVEW00327 View { get; set; }
        string PLLateFeesAutoPayVoucherProcess(string eno, string sourceBr, int createdUserId, string userName);
    }
    public interface ILOMVEW00327
    {
        ILOMCTL00327 Controller { get; set; }
    }
}
