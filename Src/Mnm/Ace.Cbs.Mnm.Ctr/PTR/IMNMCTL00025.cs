using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tel.Dmd;
namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00025:IPresenter
    {
        IMNMVEW00025 View { get; set; }
        void UpdateREInfo(TLMDTO00001 entity);
    }

    public interface IMNMVEW00025
    {
        IMNMCTL00025 Controller { get; set; }
        string RegisterNo { get; set; }
        string DraweeBank { get; set; }
        string PayeeName { get; set; }
        string PayeeNRC { get; set; }
        string PayeeAddress { get; set; }
        string PayeePhoneNo { get; set; }
        string RemitterName { get; set; }
        string RemitterNRC { get; set; }
        string RemitterPhoneNo { get; set; }
        bool SaveStatus { get; set; }
        void ClearControls();
        void disablecontrol();
    }
}
