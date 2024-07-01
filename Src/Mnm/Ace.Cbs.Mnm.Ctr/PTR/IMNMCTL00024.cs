using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00024 : IPresenter
    {
        IMNMVEW00024 View { get; set; }
        void Save();
        
    }

    public interface IMNMVEW00024
    {
        IMNMCTL00024 Controller { get; set; }
        string RegisterNo { get; set; }
        string RegisterNo_New { get; set; }
        string RegisterNo_ToChange { get; set; }
        string DraweeBank { get; set; }
        decimal Amount { get; set; }
        string PayerAccountNo { get; set; }
        string PayerName { get; set; }
        string PayerNRC { get; set; }
        string PayerAddress { get; set; }
        string RemitterName { get; set; }
        string RemitterNRC { get; set; }

        void Successful(string message);
        void Failure(string message);
        void InitializeControls();
        //void FocusControl();
        
    }
}
