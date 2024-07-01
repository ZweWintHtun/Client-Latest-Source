using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00215 : IPresenter
    {
        ILOMVEW00215 View { get; set; }
        string HPLateFeesAutoPayVoucherProcess(string eno, string sourceBr, int createdUserId, string userName);
    }
    public interface ILOMVEW00215
    {
        ILOMCTL00215 Controller { get; set; }
    }
}
