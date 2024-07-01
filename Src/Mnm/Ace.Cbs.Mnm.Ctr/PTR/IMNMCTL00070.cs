using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using System.Drawing;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00070 : IPresenter
    {
        IMNMVEW00070 View { get; set; }
        void Print();
    }

    public interface IMNMVEW00070
    {
        IMNMCTL00070 Controller { get; set; }

        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string SourceBranch { get; set; }
        string Currency { get; set; }
        string Township { get; set; }
        string ParentFormName { get; set; }
    }
}
