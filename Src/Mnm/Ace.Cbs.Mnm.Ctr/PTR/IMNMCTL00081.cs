using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.Core.Presenter;
using System.Drawing;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00081 : IPresenter
    {
        IMNMVEW00081 View { get; set; }
        IList<MNMDTO00081> SelectFreceipt();
    }

    public interface IMNMVEW00081
    {
        IMNMCTL00081 Controller { get; set; }

    }
}
