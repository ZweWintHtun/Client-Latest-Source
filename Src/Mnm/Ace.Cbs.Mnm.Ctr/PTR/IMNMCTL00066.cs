using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00066 : IPresenter
    {
        IMNMVEW00066 View { get; set; }
        bool Validate_Form();
        void Print();
    }
    public interface IMNMVEW00066
    {
        IMNMCTL00066 Controller { get; set; }
        DateTime RequiredDate { get; set; }
        string Currency { get; set; }
        string FormName { get; set; }
        IList<PFMDTO00042> PrintDataList { get; set; }
    }
}
