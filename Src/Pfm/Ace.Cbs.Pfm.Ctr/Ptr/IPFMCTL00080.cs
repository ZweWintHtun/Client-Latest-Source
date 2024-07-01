using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Pfm.Ctr.PTR
{
    public interface IPFMCTL00080 : IPresenter
    {

    }
    public interface IPFMVEW00080
    {
        IPFMCTL00080 Controller { set; get; }
    }
}
