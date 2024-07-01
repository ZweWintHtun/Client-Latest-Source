using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Sam.Dmd;

namespace Ace.Cbs.Sam.Ctr.PTR
{
    public interface ISAMCTL00031 : IPresenter
    {
        ISAMVEW00031 InterestRateListingView { get; set; }
        IList<SAMDTO00056> SelectRateFileList(string rateActiveStatus);
        IList<SAMDTO00056> SelectRateFileList();
    }
    public interface ISAMVEW00031
    {
        ISAMCTL00031 Controller { get; set; }
        IList<SAMDTO00056> RateFileList { get; set; }
        string RateType { get; set; }
        string Status { get; set; }
        string SelectedRate { get; set; }
    }
}
