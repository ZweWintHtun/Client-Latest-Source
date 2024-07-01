using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Gl.Dmd;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Gl.Ctr.Ptr
{
    public interface IGLMCTL00009 : IPresenter
    {
        IGLMVEW00009 View { get; set; }
        void Preview();
    }

    public interface IGLMVEW00009
    {
        IGLMCTL00009 Controller { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        bool IsCheckHomeCurrency { get; set; }
        bool IsTransactionDate { get; set; }
        string Currency { get; set; }
    }
}
