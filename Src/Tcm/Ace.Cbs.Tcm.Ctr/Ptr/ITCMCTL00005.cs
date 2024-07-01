using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
    //Fixed Deposit Transfer Interface
    public interface ITCMCTL00005 : IPresenter
    {        
        ITCMVEW00005 View { get; set; }
        bool Save(PFMDTO00016 entity);
        void PRN_FilePrinting(string accountNo);
    }

    public interface ITCMVEW00005
    {
        string AccountNo { get; set; }
        decimal Amount { get; set; }
        string SourceBranchCode { get; set; }
        string FormCaption { get; }
        PFMDTO00016 Entity { get; set; }
        ITCMCTL00005 Controller { get; set; }
    }
}
