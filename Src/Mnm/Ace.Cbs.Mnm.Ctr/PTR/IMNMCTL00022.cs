using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tel.Dmd;
namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00022:IPresenter
    {
        IMNMVEW00022 View { get; set; }
        void UpdateRDInfo(TLMDTO00017 entity);

    }

    public interface IMNMVEW00022
    {
        string RegisterNo { get; set; }
        string DBank { get; set; }
        string PayerAccountNo { get; set; }
        string PayerName { get; set; }
        string PayerNRC { get; set; }
        string PayerAddress { get; set; }
        string PayerPhoneNo { get; set; }
        string Narration { get; set; }
        string PayeeAccountNo { get; set; }
        string PayeeName { get; set; }
        string PayeeNRC { get; set; }
        string PayeeAddress { get; set; }
        string PayeePhoneNo { get; set; }
        bool SaveStatus { get; set; }
        //string Cur { get; set; }

        void ClearControl();
        void DisableControl();
    }
}
