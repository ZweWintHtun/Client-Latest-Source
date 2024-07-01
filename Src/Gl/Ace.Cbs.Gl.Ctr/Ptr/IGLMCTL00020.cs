using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Gl.Dmd;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Gl.Ctr.Ptr
{
    public interface IGLMCTL00020 : IPresenter
    {
        IGLMVEW00020 View { get; set; }
        bool send();
    }

    public interface IGLMVEW00020
    {
        IGLMCTL00020 Controller { get; set; }
        string FromAccountNo { get; set; }
        string ToAccountNo { get; set; }
        string ParentFormId { get; set; }
    }
}
