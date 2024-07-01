using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Gl.Dmd;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Gl.Ctr.Ptr
{
    public interface IGLMCTL00021 : IPresenter
    {
        IGLMVEW00021 View { get; set; }
        bool Send();
    }

    public interface IGLMVEW00021
    {
        IGLMCTL00021 Controller { get; set; }
        int FromLineNo { get; set; }
        int ToLineNo { get; set; }
    }
}
