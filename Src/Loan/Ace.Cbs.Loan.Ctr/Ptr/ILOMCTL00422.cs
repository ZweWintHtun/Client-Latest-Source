using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00422 : IPresenter
    {
        ILOMVEW00422 View { get; set; }
        IList<LOMDTO00080> GetAllDealerInformation(string sourceBr);
    }

    public interface ILOMVEW00422
    {
        ILOMCTL00422 Controller { get; set; }
    }
}