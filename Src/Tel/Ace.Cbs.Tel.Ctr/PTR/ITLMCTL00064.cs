using System;
using System.Drawing;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
    public interface ITLMCTL00064 : IPresenter
    {
        ITLMVEW00064 View { get; set; }
        IList<PFMDTO00042> ShowDepositByAccountNoReport();
    }

    public interface ITLMVEW00064 
    {
        ITLMCTL00064 Controller { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string AccountNo { get; set; }
    }
}
