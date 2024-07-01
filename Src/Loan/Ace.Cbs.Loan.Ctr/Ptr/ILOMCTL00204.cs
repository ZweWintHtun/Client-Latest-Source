//using Ace.Cbs.Loan.Dmd.DTO;
//using Ace.Cbs.Pfm.Dmd;
//using Ace.Windows.Core.Presenter;
//using System;
//using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00204 : IPresenter
    {
        ILOMVEW00204 View { get; set; }
        string HPLateFeesCalculationProcess(string sourceBr, int createdUserId, string userName);
    }
    public interface ILOMVEW00204
    {
        ILOMCTL00204 Controller { get; set; }
    }
}
