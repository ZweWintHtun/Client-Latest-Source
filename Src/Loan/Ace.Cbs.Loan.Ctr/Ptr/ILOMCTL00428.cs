using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00428 : IPresenter
    {
        ILOMVEW00428 View { get; set; }
        string SaveBlackLists_ExternalCust(int userId, string branchCode);
        LOMDTO00427 SelectUserMakerCheckerApproveByUserId();

    }
    public interface ILOMVEW00428
    {
        ILOMCTL00428 Controller { get; set; }
        string Name { get; set; }
        string NRC { get; set; }
        string FName { get; set; }
        string CName { get; set; }
        DateTime DOB { get; set; }
        string Address { get; set; }
    }
}
