using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00080 : IPresenter
    {
        ILOMVEW00080 View { get; set; }
        IList<LOMDTO00080> GetAllDealerInformation(string sourceBr);
        void DeleteDealerRegistration(string dealerNo, int createdUserId,string sourceBr);        
    }

    public interface ILOMVEW00080
    {
        ILOMCTL00080 Controller { get; set; }
    }
}
