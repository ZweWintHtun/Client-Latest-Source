using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00442
    {
        ILOMVEW00442 View { get; set; }
        IList<LOMDTO00219> GetLateFeeInfoAllForChecker();
        string UpdateLateFeeExceptionInfo(IList<LOMDTO00219> latefeeinfo, string ApproveReject);
        LOMDTO00427 SelectUserMakerCheckerApproveByUserId();
    }

    public interface ILOMVEW00442
    {
        ILOMCTL00442 Controller { get; set; }
        //string termArray { get; set; }
    }
}
