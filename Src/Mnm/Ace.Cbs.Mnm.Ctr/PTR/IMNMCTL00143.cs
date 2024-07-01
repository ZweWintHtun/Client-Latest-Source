using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00143 : IPresenter
    {

        IMNMVEW00143 View { get; set; }
        IList<MNMDTO00043> showReport(string formname);
    }

    public interface IMNMVEW00143
    {
        IMNMCTL00143 Controller { get; set; }
    }
}
