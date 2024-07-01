using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
    //Individual Denomination Delete
    public interface ITCMCTL00011 : IPresenter
    {
        ITCMVEW00011 View { get; set; }
        void Save();
       
    }
    public interface ITCMVEW00011
    {
        ITCMCTL00011 Controller { get; set; }
        string EntryNo { get; set; }
        string Type { get; set; }
        decimal Amount { get; set; }
        string UserNo { get; set; }
        string CounterNo { get; set; }
        void Failure(string message);
        void Successful(string message);
        void ClearControls();
        void InitializeControl();
    }
}
