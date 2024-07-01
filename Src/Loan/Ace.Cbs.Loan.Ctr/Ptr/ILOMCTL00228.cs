using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00228 : IPresenter
    {
        ILOMVEW00228 View { get; set; }
        IList<string> GetAllPersonalLoansCompanyName(string sourceBr);
        void Print(string rptName, DateTime startDate, DateTime endDate, string currency, string sourceBr, string companyName);
    }
    public interface ILOMVEW00228
    {
        ILOMCTL00228 Controller { get; set; }
        string Currency { get; set; }
        string SourceBr { get; set; }

    }
}
