using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00027 : IPresenter
    {
        IMNMVEW00027 View { get; set; }
        void ClearControls();
        void Save();
    }

    public interface IMNMVEW00027
    {
        IMNMCTL00027 Controller { get; set; }
        string DrawingRegisterNo { get; set; }
        string GroupNo { get; set; }
        string SourceBranchCode { get; set; }
        string CurrencyCode { get; set; }
        TLMDTO00017 Drawingremittancedto { get; set; }
        IList<TLMDTO00017> Listdrawingremittancedto { get; set; }
        object GridDataSource { get; set; }
        int updatedUserId { get; set; }
        bool IsVoucher { get; set; }
        bool SaveStatus { get; set; }
        void GridDataBind();
    }
}
