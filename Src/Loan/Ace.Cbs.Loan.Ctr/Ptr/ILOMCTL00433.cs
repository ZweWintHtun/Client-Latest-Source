using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00433
    {
        ILOMVEW00433 View { get; set; }
        IList<LOMDTO00427> BindUser();
        IList<LOMDTO00427> BindBlackListApprover();
        string DeleteBlackListUser();
        string SaveBlackListUser();

    }
    public interface ILOMVEW00433
    {
        ILOMCTL00433 Controller { get; set; }
        string ApproveType { get; set; }
        string idArray { get; set; }
        string UserName { get; set; }
    }
}
