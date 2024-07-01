using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
    public interface ITCMCTL00017:IPresenter
    {
        ITCMVEW00017 View { get; set; }
        void GetCashDeno();
        IList<TLMDTO00015> GetGridData();
        void ClearCustomErrorMessage();
        void ClearingForm();
        void Save();
    }
    public interface ITCMVEW00017
    {
        ITCMCTL00017 Controller { get; set; }
        string TlfEntryNo { get; set; }
        IList<TLMDTO00015> CashDenoList { get; set; }
        decimal Totalamount { get; set; }
        string Currency { get; set; }
        void Failure(string message);
        void Successful(string message);
    }
}
