using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Gl.Dmd;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Gl.Ctr.Ptr
{
    public interface IGLMCTL00019 : IPresenter
    {
        IGLMVEW00019 View { get; set; }
        //bool Send();
    }

    public interface IGLMVEW00019
    {
        IGLMCTL00019 Controller { get; set; }
        int LineNo { get; set; }
        string AccountNo { get; set; }
        string Department { get; set; }
        string ParentFormId { get; set; }
    }
}
