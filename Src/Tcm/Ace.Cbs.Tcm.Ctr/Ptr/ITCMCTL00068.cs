using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;


namespace Ace.Cbs.Tcm.Ctr.Ptr
{
    public interface ITCMCTL00068 : IPresenter
    {

        ITCMVEW00068 View { get; set; }
        void Process();
        void BindSettlementDate();
        DateTime GetSystemDate(string sourceBr);
    }

    public interface ITCMVEW00068
    {
        DateTime CurrentSettlementDate { get; set; }
        DateTime NextSettlementDate { get; set; }
        string SourceBranchCode { get; set; }
        bool CutoffStatus { get; set; }
        ITCMCTL00068 Controller { get; set; }
        //void ShowInformationMessage(string message);
    }
}
