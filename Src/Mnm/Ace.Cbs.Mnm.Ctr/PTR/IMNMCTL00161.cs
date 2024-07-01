using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00161 : IPresenter
    {
        IMNMVEW00161 FixedDepositInterestWithdrawListingView { get; set; }
        void MainPrint(string datetype);
    }
    public interface IMNMVEW00161
    {
        IMNMCTL00161 FixedDepositInterestWithdrawListingController { get; set; }
        string TransactionStatus { get; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
    }
}
