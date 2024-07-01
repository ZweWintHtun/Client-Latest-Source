using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00435 : IPresenter
    {
        ILOMVEW00435 View { get; set; }
        IList<LOMDTO00427> GetLoansAccountInfoByACNo();
        string SaveWarningLists(int userId, string branchCode, string DOB);
        LOMDTO00427 SelectUserMakerCheckerApproveByUserId();
    }

    public interface ILOMVEW00435
    {
        ILOMCTL00435 Controller { get; set; }
        string AccountNo { get; set; }
        string Name { get; set; }
        string NRC { get; set; }
        string FName { get; set; }
        string CName { get; set; }
        string AbsentTerm { get; set; }
        string DOB { get; set; }
        string Address { get; set; }
    }
}
