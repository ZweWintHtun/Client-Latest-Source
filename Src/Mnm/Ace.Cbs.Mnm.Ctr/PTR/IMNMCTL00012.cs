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
    public interface IMNMCTL00012 : IPresenter
    {
        IMNMVEW00012 View { get; set; }
        void ClearCustomErrorMessage();
        IList<PFMDTO00054> GetPORInfoByEno();        
        //TLMDTO00016 GetPOInfoByPONO(string PoNo);
        
        void Save();

        DateTime GetSystemDate(string sourceBr);
        DateTime GetLastSettlementDate(string sourceBr);
    }

    public interface IMNMVEW00012
    {
        IMNMCTL00012 Controller { get; set; }

        string Eno { get; set; }
        string PaymentOrderNo { get; set; }
        decimal Amount { get; set; }
        string OtherBank { get; set; }
        string Budget { get; set; }

        PFMDTO00054 ViewData { get; set; }
    }
}
