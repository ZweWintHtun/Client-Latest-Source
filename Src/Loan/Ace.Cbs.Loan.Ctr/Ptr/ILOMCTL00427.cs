using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00427 : IPresenter
    {
        ILOMVEW00427 View { get; set; }
        IList<LOMDTO00427> GetLoansAccountInfoByACNo();
        string SaveBlackLists(int userId, string branchCode,string DOB);
        LOMDTO00427 SelectUserMakerCheckerApproveByUserId();
    }
    public interface ILOMVEW00427
    {
        ILOMCTL00427 Controller { get; set; }
        string AccountNo{ get; set; }
        string Name { get; set; }
        string NRC { get; set; }
        string FName { get; set; }
        string CName { get; set; }
        string AbsentTerm { get; set; }
        string DOB { get; set; }
        string Address { get; set; }
    }
}
