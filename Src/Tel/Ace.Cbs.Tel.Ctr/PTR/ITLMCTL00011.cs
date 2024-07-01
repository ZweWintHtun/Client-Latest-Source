using System;
using System.Drawing;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Cx.Com.Dmd;
namespace Ace.Cbs.Tel.Ctr.Ptr
{    
    public interface ITLMCTL00011
    {
        ITLMVEW00011 View { get; set; }
        bool Save();
        void ClearControls();
    }

    public interface ITLMVEW00011
    {
        IList<TLMDTO00012> DenoData { get; set; }
        string CounterNo { get; set; }
        string BranchCode { get; set; }
        decimal DefaultAmount { get; set; }
        decimal Amount { get; set; }
        decimal TotalAmount { get; set; }
        decimal RefundAmount { get; set; }
        string CurrencyCode { get; set; }
        string ParentFormId { get; set; }
        CXDMD00008 TransactionStatus { get; set; }
        void BindDenoInformation();
        decimal counttotal { get; set; }
    }
}
