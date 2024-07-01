using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00429 : IPresenter
    {
        ILOMVEW00429 View { get; set; }
        IList<LOMDTO00429> SelectAllBlackListsForApproveReject();
        string SaveBlackListsApproveReject();
        LOMDTO00427 SelectUserMakerCheckerApproveByUserId();

    }
    public interface ILOMVEW00429
    {
        ILOMCTL00429 Controller { get; set; }

        string idArray { get; set; }
        string approveReject { get; set; }    
    }
}
