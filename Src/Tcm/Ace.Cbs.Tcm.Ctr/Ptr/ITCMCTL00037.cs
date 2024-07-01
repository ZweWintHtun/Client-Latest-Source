using System;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;
using Ace.Windows.CXClient.Controls;

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
    ///Clearing Reverse -> 
    ///Receipt Reverse Interface
    ///

    public interface ITCMCTL00037 : IPresenter
    {
        ITCMVEW00037 View { get; set; }
        void GetClearingReceiptReversalListing();
        bool CheckDate();
    }

    public interface ITCMVEW00037
    {       
        ITCMCTL00037 Controller { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
    }
}
