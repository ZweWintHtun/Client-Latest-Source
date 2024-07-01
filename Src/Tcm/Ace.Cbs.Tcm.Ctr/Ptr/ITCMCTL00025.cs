using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
    public interface ITCMCTL00025:IPresenter
    {
        ITCMVEW00025 View { get; set; }
        void ClearCustomErrorMessage();
        void Print();
    }

    public interface ITCMVEW00025
    {
        ITCMCTL00025 Controller { get; set; }

        DateTime Date { get; set; }
        string Currency { get; set; }
        bool IsWithReversal { get; set; }
    }
}
