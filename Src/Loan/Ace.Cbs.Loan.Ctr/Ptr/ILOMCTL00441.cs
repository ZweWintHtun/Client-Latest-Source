using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00441
    {
        ILOMVEW00441 View { get; set; }
        IList<LOMDTO00219> GetLateFeeInfoByACNo(string AccountNo, string SourceBr);
        //string SaveLateFeeException(int userId, string branchCode, string DOB);
        string SaveLateFeeExceptionInfo(IList<LOMDTO00219> LateFeeInfoListToSave);
        LOMDTO00427 SelectUserMakerCheckerApproveByUserId();
    }

    public interface ILOMVEW00441
    {
        ILOMCTL00441 ControllerLateFeeInfo { get; set; }
        string AccountNo { get; set; }
        string Name { get; set; }
        string WorkingCompanyName { get; set; }
        string termArray { get; set; }
        //IList<LOMDTO00219> LateFeeInfo { get; set; }
    }
}
