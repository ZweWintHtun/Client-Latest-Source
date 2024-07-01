using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00430 : IPresenter
    {
        ILOMVEW00430 View { get; set; }
        IList<LOMDTO00429> SelectAllBlackListsForRemove();
        string SaveBlackListsRemove();
        LOMDTO00427 SelectUserMakerCheckerApproveByUserId();

    }
    public interface ILOMVEW00430
    {
        ILOMCTL00430 Controller { get; set; }

        string idArray { get; set; }
        string remove { get; set; }
    }
}
