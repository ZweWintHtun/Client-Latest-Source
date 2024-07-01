using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00004 : IPresenter
    {
        IMNMVEW00004 View { get; set; }
        DateTime SelectSysDate();
        void Save();
    }

    public interface IMNMVEW00004
    {
        IMNMCTL00004 Controller { get; set; }

        PFMDTO00056 ViewData { get; set; }

        DateTime RenewalStartDate { get; set; }

        DateTime RenewalEndDate { get; set; }

        int start { get; set; }
    }
}
