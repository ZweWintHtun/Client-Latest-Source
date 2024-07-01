using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00223 : IPresenter
    {
        ILOMVEW00223 View { get; set; }
        IList<string> GetAllPersonalLoansCompanyName(string sourceBr);
        void Print(string rptName, string currency, string sourceBr, string companyName);
    }
    public interface ILOMVEW00223
    {
        ILOMCTL00223 Controller { get; set; }
        string Currency { get; set; }
        string SourceBr { get; set; }
        string SortType { get; set; }

    }
}
