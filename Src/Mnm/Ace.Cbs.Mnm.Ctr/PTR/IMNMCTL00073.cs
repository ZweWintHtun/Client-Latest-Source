using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00073 : IPresenter 
    {
        IMNMVEW00073 View { get; set; }
        void Print();
    }
    public interface IMNMVEW00073
    {
        IMNMCTL00073 Controller { get; set; } 
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        bool IsTransactionDate { get; set; }        
        string FormName { get; set; }
        string Parameter { get; set; }
    }
}
