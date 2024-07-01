using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Dto;

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
    public interface ITCMCTL00029 : IPresenter
    {
        ITCMVEW00029 View { get; set; }
        void ClearingCustomerErrorMessage();
        void Print();
    }

    public interface ITCMVEW00029
    {
        ITCMCTL00029 Controller { get; set; }
        bool IsTransactionDate { get; set; }
        DateTime SelectedDateTime { get; set; }
        string Currency { get; set; }
        bool isReversal { get; set; }
        bool SortByTime { get; set; }
    }
}
