using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00064 : IPresenter
    {
        IMNMVEW00064 View { get; set; }
        void Print();
    }
    public interface IMNMVEW00064
    {
        IMNMCTL00064 Controller { get; set; }
        string RequiredYear { get; set; }
        string FormName { get; set; }
    }
}
