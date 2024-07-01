using System;
using System.Drawing;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
    public interface ITLMCTL00012
    {
        ITLMVEW00012 View { get; set; }
        bool Save();
        void ClearControls();
    }

    public interface ITLMVEW00012
    {
        IList<TLMDTO00012> DenoData { get; set; }
        decimal TotalAmount { get; set; }
        decimal DefaultRefundAmount { get; set; }
        decimal RefundAmount { get; set; }
        decimal SurPlus { get; set; }
        decimal Shortage { get; set; }
        string RefundString { get; set; }
        decimal DenoAdjustAmount { get; set; }
        string ParentFormId { get; set; }

        void BindDenoInformation();
    }
}
