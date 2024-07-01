using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
    public interface ITLMCTL00065 : IPresenter
    {
        ITLMVEW00065 View { get; set; }
        IList<PFMDTO00042> ShowDepositByAccountTypeReport();
    }

    public interface ITLMVEW00065
    {
        ITLMCTL00065 Controller { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string AccountSign { get; set; }
    }
}
