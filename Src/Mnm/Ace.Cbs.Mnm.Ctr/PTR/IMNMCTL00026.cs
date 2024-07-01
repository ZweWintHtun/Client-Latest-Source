using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00026
    {
        IMNMVEW00026 View { get; set; }
        void Save();
        void Delete();
    }

    public interface IMNMVEW00026
    {
        IMNMCTL00026 Controller { get; set; }
        string RegisterNo { get; set; }
        string DraweeBank { get; set; }
        string PayeeName { get; set; }
        string PayeeNRC { get; set; }
        string PayeeAddress { get; set; }
        string PayeePhoneNo { get; set; }
        string RemitterName { get; set; }
        string RemitterNRC { get; set; }
        string RemitterPhoneNo { get; set; }
        decimal Amount { get; set; }
        string PayeeAccountNo { get; set; }
        bool SaveStatus { get; set; }
        decimal OldAmount { get; set; }
        void ClearControls();
        void SaveDeleteButtonEnableDisable(bool status);
        void EnableControl(bool isEnable);
        void disablecontrol();
        void ReadOnlyControl();
        void SetFocus();
    }
}
