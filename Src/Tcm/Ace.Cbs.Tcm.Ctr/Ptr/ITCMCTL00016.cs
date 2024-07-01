using System;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
    //Fixed Deposit Transfer Interface
    public interface ITCMCTL00016 : IPresenter
    {
        ITCMVEW00016 View { get; set; }
        void Process();
        void BindSettlementDate();
    }

    public interface ITCMVEW00016
    {
        DateTime CurrentSettlementDate { get; set; }
        DateTime NextSettlementDate { get; set; }
        string SourceBranchCode { get; set; }
        
        ITCMCTL00016 Controller { get; set; }
        void ShowInformationMessage(string message);
    }
}
