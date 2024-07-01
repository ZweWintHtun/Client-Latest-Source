using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00418: IPresenter
    {
        ILOMVEW00418 View { get; set; }
        string BusinessLoansLateFeesAutoPayVoucherProcess(string eno, string sourceBr, int createdUserId, string userName);
        //DateTime GetSystemDate(string sourceBr);
    }
    public interface ILOMVEW00418
    {
        ILOMCTL00418 Controller { get; set; }
    }
}
