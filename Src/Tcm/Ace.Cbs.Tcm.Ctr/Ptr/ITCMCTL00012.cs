using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
    public interface ITCMCTL00012:IPresenter
    {
        ITCMVEW00012 View { get; set; }
        void Save();
        string CheckCheque();
        void ClearControls();
    }

    public interface ITCMVEW00012
    {
        ITCMCTL00012 Controller { get; set; }

        string AccountNo { get; set; }
        string CheckBookNo { get; set; }
        string StartSerialNo { get; set; }
        string EndSerialNo { get; set; }
        string Name { get; set; }
        string NRC { get; set; }
     
        void Successful(string message);
        void Failure(string message);
    }

}
