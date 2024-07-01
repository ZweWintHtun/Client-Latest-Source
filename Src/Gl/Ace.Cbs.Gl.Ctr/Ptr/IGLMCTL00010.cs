using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Gl.Dmd;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Gl.Ctr.Ptr
{
    public interface IGLMCTL00010 : IPresenter
    {
        IGLMVEW00010 View { get; set; }
        void Preview();
       
    }

    public interface IGLMVEW00010
    {
        IGLMCTL00010 Controller { get; set; }
        string Year { get; set; }
        string Month { get; set; }
        int actualMonth { get; set; }
        string branchCode { get; set; }
    }
}
