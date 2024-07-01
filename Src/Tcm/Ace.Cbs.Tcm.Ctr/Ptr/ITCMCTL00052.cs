using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
    public interface ITCMCTL00052 : IPresenter
    {
        ITCMVEW00030 View { get; set; }
        void Preview();
    }

    public interface ITCMVEW00030
    {
        ITCMCTL00052 Controller { get; set; }
        DateTime PostDate { get; set; }
        string Currency { get; set; }
    }
}
