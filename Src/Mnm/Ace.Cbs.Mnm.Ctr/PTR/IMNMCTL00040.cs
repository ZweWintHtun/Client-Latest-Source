using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00040 : IPresenter
    {
        IMNMVEW00040 View { get; set; }
        void Print();        
    }
    public interface IMNMVEW00040
    {
        string FormName { get; set; }
        bool SortByAcctNo { get; set; }
        bool SortByTime { get; set; }
        bool IsReversal { get; set; }
        string CurrencyCode { get; set; }
        DateTime Date { get; set; }
        void Successful(string message);
        void Failure(string message);
        IMNMCTL00040 Controller { get; set; }
    }
}
