using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;


namespace Ace.Cbs.Tcm.Ctr.Ptr
{
    public interface ITCMCTL00028 : IPresenter
    {
        ITCMVEW00028 View { get; set; }
        void Print();
        void ClearCustomErrorMsg();

    }

    public interface ITCMVEW00028
    {
        ITCMCTL00028 Controller { get; set; }

        DateTime Date { get; set; }
        string Currency { get; set; }


        void Successful(string message);
        void Failure(string message);
    }
}
