using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00437 : IPresenter
    {
        ILOMVEW00437 View { get; set; }
        IList<LOMDTO00429> SelectAllWarningListsForRemove();
        string SaveWarningListsRemove();
        LOMDTO00427 SelectUserMakerCheckerApproveByUserId();
    }

    public interface ILOMVEW00437
    {
        ILOMCTL00437 Controller { get; set; }

        string idArray { get; set; }
        string remove { get; set; }
    }
}
