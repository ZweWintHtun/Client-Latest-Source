using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00225 : IPresenter
    {
        ILOMVEW00225 View { get; set; }
        IList<string> GetAllPersonalLoansCompanyName(string sourceBr);
        void Print(string rptName, string sourceBr, string companyName);
    }
    public interface ILOMVEW00225
    {
        ILOMCTL00225 Controller { get; set; }
        string Currency { get; set; }
        string SourceBr { get; set; }

    }
}
