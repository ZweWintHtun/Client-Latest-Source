using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using System.Drawing;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00063 : IPresenter
    {
        IMNMVEW00063 View { get; set; }
        void Print();
    }

    public interface IMNMVEW00063
    {
        IMNMCTL00063 Controller { get; set; }

        decimal StartAmount { get; set; }
        decimal EndAmount { get; set; }
        string Currency { get; set; }
        string IsrdoCurrent { get; set; }
        bool IscheckAllCurrency { get; set; }
        string ParentFormName { get; set; }
    }
}
