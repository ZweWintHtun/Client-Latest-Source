using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Gl.Dmd;

namespace Ace.Cbs.Gl.Ctr.Ptr
{
    public interface IGLMCTL00013 : IPresenter
    {
        IGLMVEW00013 view { get; set; }
        IList<GLMDTO00013> SelectDataVW_COA_List();
    }

    public interface IGLMVEW00013
    {
        IGLMCTL00013 Controller { get; set; }
    }
}
