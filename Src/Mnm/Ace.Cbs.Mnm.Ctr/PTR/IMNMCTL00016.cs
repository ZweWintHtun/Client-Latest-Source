using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00016:IPresenter
    {
        IMNMVEW00016 View { get; set; }
        //bool Edit();
        void Save();
        //void Delete();
        void ClearControls();
        DateTime GetSystemDate(string sourceBr);
        DateTime GetLastSettlementDate(string sourceBr);
    }

    public interface IMNMVEW00016
    {
        IMNMCTL00016 Controller { get; set; }

        string GroupNo { get; set; }
        string PaymentOrderNo { get; set; }
        string BudgetYear { get; set; }
        string Currency { get; set; }
        decimal Amount { get; set; }
        string CreditedAccountNo { get; set; }
        string Name { get; set; }
        string ParentFormId { get; set; }
        //string Status { get; set; }
        //bool MultiCheck { get; set; }
        void VisibleTransferRefund(bool enable);
        void VisibleCurrency(bool enable);
        void Successful(string message);
        void Failure(string message);
    }
}
