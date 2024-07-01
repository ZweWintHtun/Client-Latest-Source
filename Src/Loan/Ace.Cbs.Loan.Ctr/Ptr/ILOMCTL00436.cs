using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00436 : IPresenter
    {
        ILOMVEW00436 View { get; set; }
        IList<LOMDTO00429> SelectAllWarningListsForApproveReject();
        string SaveWarningListsApproveReject();
        LOMDTO00427 SelectUserMakerCheckerApproveByUserId();
    }

    public interface ILOMVEW00436
    {
        ILOMCTL00436 Controller { get; set; }

        string idArray { get; set; }
        string approveReject { get; set; }
    }
}
