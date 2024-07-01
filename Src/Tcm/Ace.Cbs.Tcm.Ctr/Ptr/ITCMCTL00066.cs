using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tcm.Dmd;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
    public interface ITCMCTL00066 : IPresenter
    {
        ITCMVEW00066 View { get; set; }
        void Preview();
        bool CheckDate();
    }

    public interface ITCMVEW00066
    {
        ITCMCTL00066 Controller { get; set; }
        string transactionType { get; set; }
        string currencyType { get; set; }
        string typeofSort { get; set; }
        string currency { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
    }
}
