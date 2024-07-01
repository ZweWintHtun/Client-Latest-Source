using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Sam.Ctr.PTR
{
    public interface ISAMCTL00054 : IPresenter
    {
        ISAMVEW00054 View { get; set; }
        IList<BranchDTO> SelectBranch();
        IList<TLMDTO00032> SelectRmitRate();
    }

    public interface ISAMVEW00054 
    {
        ISAMCTL00054 Controller { get; set; }
        string StateCode { get; set; }
    }


}
