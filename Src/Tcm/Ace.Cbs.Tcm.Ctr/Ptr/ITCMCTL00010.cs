using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
    public interface ITCMCTL00010 : IPresenter
    {
        ITCMVEW00010 View { get; set; }
        void Delete();
        bool Check_Data();
    }

    public interface ITCMVEW00010
    {
        ITCMCTL00010 Controller { get; set; }
        string Status { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
    }
}
