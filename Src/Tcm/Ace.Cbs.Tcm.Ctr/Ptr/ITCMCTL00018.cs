using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
    public interface ITCMCTL00018
    {
        ITCMVEW00018 View { get; set; }
        void ClearingForm();
        void ClearCustomErrorMessage();
        bool ValidateAmount();
        DateTime GetSystemDate(string sourceBr);
        DateTime GetLastSettlementDate(string sourceBr);
    }

    public interface ITCMVEW00018
    {
        ITCMCTL00018 Controller { get; set; }
        string Currency { get; set; }
        decimal Amount { get; set; }
        decimal TotalAmount { get; set; }
        decimal DenoAmount { get; set; }
        IList<TLMDTO00012> Deno { get; set; }
        IList<TLMDTO00012> DenoData { get; set; }

    }
}
