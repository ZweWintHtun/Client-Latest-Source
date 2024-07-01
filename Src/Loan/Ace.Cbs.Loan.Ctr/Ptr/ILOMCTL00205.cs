using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00205 : IPresenter
    {
        ILOMVEW00205 View { get; set; }
        IList<string> GetAllPersonalLoansCompanyName(string sourceBr);
        void Print(string rptName, DateTime startDate, DateTime endDate,string companyName);
        //void PrintByCompany(string rptName, string companyName);
    }
    public interface ILOMVEW00205
    {
        ILOMCTL00205 Controller { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string SourceBr { get; set; }
        string Currency { get; set; }
        string CompanyName { get; set; }
    }
}
