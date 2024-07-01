using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
    public interface ITCMCTL00032:IPresenter
    {
        ITCMVEW00032 View { get; set; }
        void ClearCustomErrorMessage();
        void Print();
    }

    public interface ITCMVEW00032
    {
        ITCMCTL00032 Controller { get; set; }

        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
    }
}
