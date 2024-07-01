using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00029
    {
        IMNMVEW00029 View { get; set; }
        void ClearControls();
        void PrintPassbook();
    }

    public interface IMNMVEW00029
    {
        IMNMCTL00029 Controller { get; set; }
        string AccountNo { get; set; }
        string CustomerName { get; set; }
        string CustomerNRC { get; set; }
        string Fathername { get; set; }
        string Address { get; set; } 
    }
}
