using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00014:IPresenter
    {
        IMNMVEW00014 View { get; set; }
        bool Edit();
        void Save();
        void Delete();
        void ClearControls();
    }

    public interface IMNMVEW00014
    {
        IMNMCTL00014 Controller { get; set; }

        string GroupNo { get; set; }
        string PaymentOrderNo { get; set; }
        string BudgetYear{ get; set; }
        string Currency { get; set; }
        decimal Amount { get; set; }
        decimal Charges { get; set; }
        string Date { get; set; }
        string ParentFormId { get; set; }
        string Status { get; set; }
        bool MultiCheck { get; set; }

        void Successful(string message);
        void Failure(string message);
    }
}
