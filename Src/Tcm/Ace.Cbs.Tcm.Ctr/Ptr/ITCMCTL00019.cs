using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
    public interface ITCMCTL00019:IPresenter
    {
        ITCMVEW00019 View { get; set; }
        void ClearCustomErrorMessage();
        void ClearingForm();
        void Save();
        bool ValidateAmount();
    }

    public interface ITCMVEW00019
    {
        ITCMCTL00019 Controller { get; set; }
        string DepositEntryNo { get; set; }
        string WithdrawalEntryNo { get; set; }
        decimal Amount { get; set; }
        decimal DenoAmount { get; set; }
        decimal TotalAmount { get; set; }
        string CounterNo { get; set; }
        string CounterType { get; set; }
        IList<TLMDTO00012> DepositDeno { get; set; }
        IList<TLMDTO00015> ListCashDenoDTO { get; set; }
        IList<TLMDTO00012> DenoData { get; set; }
    }
}
