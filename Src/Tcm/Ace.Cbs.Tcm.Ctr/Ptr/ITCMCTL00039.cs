using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
    public interface ITCMCTL00039:IPresenter
    {
        ITCMVEW00039 View { get; set; }
        void Print();
        void ClearErrorMessage();
    }

    public interface ITCMVEW00039
    {
        ITCMCTL00039 Controller { get; set; }

        string ChequeType { get; set; }
        string RequiredType { get;set;}
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string CurrentAccountNo { get; set; }
    }
}
