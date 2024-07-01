using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    //Created By HWKO (14-Jul-2017)
    public interface ILOMCTL00318 : IPresenter
    {
        ILOMVEW00318 View { get; set; }
        //void Print();
        IList<string> GetAllPersonalLoansCompanyName(string sourceBr);// Added and Modified By AAM (08-Dec-2017)
        void Print(string companyName, string interestPaidStatus); // Added and Modified By AAM (08-Dec-2017)
    }

    public interface ILOMVEW00318
    {
        ILOMCTL00318 Controller { get; set; }

        string SourceBranch { get; set; }
        string Currency { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string BudgetYear { get; set; }

        // Added By AAM (08-Dec-2017)
        string CompanyName { get; set; }
        string InterestPaidStatus { get; set; }
    }

}
