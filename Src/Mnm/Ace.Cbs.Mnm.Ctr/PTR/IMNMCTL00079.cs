using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00079 : IPresenter
    {
        IMNMVEW00079 View { get; set; }
        void Print();
    }
    public interface IMNMVEW00079
    {
        IMNMCTL00079 Controller { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string FormName { get; set; }
      
    }
}
