using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
    public interface ITLMCTL00079 : IPresenter
    {
        ITLMVEW00079 View { get; set; }

        bool CheckDate();
        void CLedgerMainPrint();
        void FAOFMainPrint();
        IList<PFMDTO00021> FledgerInfoLists { get; set; }
    }

    public interface ITLMVEW00079
    {
        ITLMCTL00079 Controller { get; set; }

        string AccountNo { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        bool isFixedAcc { get; set; }
        bool WithReversal { get; set; }
    }
}
