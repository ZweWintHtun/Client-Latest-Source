using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Admin.DataModel;
//using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{   
    public interface IMNMCTL00039 : IPresenter
    {
        IMNMVEW00039 View { get; set; }
        void Print();
        bool Validate_Form();
        void ClearCustomErrorMessages();
    }
    public interface IMNMVEW00039
    {
        IMNMCTL00039 Controller { get; set; }        
        DateTime RequiredDate { get; set; }
        bool IsWithReversal { get; set; }
        bool IsTransactionDate { get; set; }
        bool IsSettlementDate { get; set; }
        string Currency { get; set; }
    }
}
