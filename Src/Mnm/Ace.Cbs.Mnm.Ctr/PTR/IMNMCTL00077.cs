using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter ;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00077 : IPresenter
    {
        IMNMVEW00077 View { get; set; }
        bool Validate_Form();
        void Print();
    }
    public interface IMNMVEW00077
    {
        IMNMCTL00077 Controller { get; set; }
        string FormName { get; set; }
        bool IsTransactionDate { get; set; }
        bool IsSettlementDate { get; set; }
        DateTime RequiredDate { get; set; }
        string BranchCode { get; set; }
    }
}
