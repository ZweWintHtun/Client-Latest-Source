using System.Collections.Generic;
//using System.Drawing;
using Ace.Cbs.Tcm.Dmd;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
    public interface ITCMCTL00004 : IPresenter
    {
        ITCMVEW00004 View { get; set; }      
        void ClearControls();
        void ClearTextBox();
        void ClearErrors();      
        void Save();
    }
    public interface ITCMVEW00004
    {
        ITCMCTL00004 Controller { get; set; }
        string PONo { set; }
        string SourceBranchCode { get; set; }
        string BudgetYear { get; set; }
        string RegisterNo { get; set; }
        string Currency { get; set; }
        string Name { get; set; }
        decimal Amount { get; set; }
        void Successful(string message);
        void Failure(string message);
        void Failure(string message, string registerNo);
        void SetFocusOnRegisterNo();
    }
}
