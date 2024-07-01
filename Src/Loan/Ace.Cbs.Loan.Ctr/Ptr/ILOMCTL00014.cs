using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr 
{
    public interface ILOMCTL00014 : IPresenter
    {
        ILOMVEW00014 View { get; set; }
        void Save();
    }
    public interface ILOMVEW00014
    {
        ILOMCTL00014 Controller { set; get; }

        string LoanNo { get; set; }
        string AccountNo { get; set; }
        string AdvanceType { get; set; }
        decimal SanctionAmount { get; set; }
        decimal IntRateUsed { get; set; }
        decimal IntRateUnused { get; set; }
        string UserName { get; set; }
        void SetFocus();
    }
}
