using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00087 : IPresenter
    {
        ILOMVEW00087 View { get; set; }
        IList<PFMDTO00078> SelectSolidarityByGroupNo(string groupNo);
        IList<LOMDTO00078> SelectFarmLoanByGroupNo(string groupNo);
    }

    public interface ILOMVEW00087
    {
        ILOMCTL00087 Controller { get; set; }

        string GroupNo { get; set; }
        IList<PFMDTO00078> SolidarityList { get; set; }
        IList<LOMDTO00078> FarmLoanList { get; set; }
    }
}
