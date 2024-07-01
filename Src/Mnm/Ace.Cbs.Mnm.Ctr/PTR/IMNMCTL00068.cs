using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using System.Drawing;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00068 : IPresenter
    {
        IMNMVEW00068 View { get; set; }
        void Print();
    }

    public interface IMNMVEW00068
    {
        IMNMCTL00068 Controller { get; set; }

        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string ParentFormName { get; set; }
    }
}
