using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00425 : IPresenter
    {
        ILOMVEW00425 View { get; set; }
        IList<LOMDTO00423> GetAllCustomerInformation();
    }
    public interface ILOMVEW00425
    {
        ILOMCTL00425 Controller { get; set; }
        string Name { get; set; }
        string NRC { get; set; }
        bool NameExact { get; set; }
        bool NrcExact { get; set; }

        string ACType { get; set; }
        string FormName { get; set; }
        string searchType { get; set; }
    }
}
