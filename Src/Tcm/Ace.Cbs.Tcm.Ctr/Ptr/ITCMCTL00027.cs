using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
    public interface ITCMCTL00027
    {
        ITCMVEW00027 View { get; set; }
        void ClearingCustomerErrorMessage();
        void Print();
    }

    public interface ITCMVEW00027
    {
        bool isSchdule { get; set; }
        bool isAbstract { get; set; }
        bool isScroll { get; set; }
        bool isTransactionDate { get; set; }
        bool isSettlementDate { get; set; }
        DateTime SelectedDateTime { get; set; }
        bool isReserval { get; set; }
        string Currency { get; set; }
        ITCMCTL00027 Controller { get; set; }
    }
}
