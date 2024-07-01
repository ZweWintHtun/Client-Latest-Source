using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00235 : IPresenter
    {
        ILOMVEW00235 View { get; set; }
        void Print_HP_AccountClosed_Listing(string rptName, DateTime startDate, DateTime endDate, string currency, string sourceBr);
        void Print_PL_AccountClosed_Listing(string rptName, DateTime startDate, DateTime endDate, string currency, string sourceBr);
        void Print_BL_AccountClosed_Listing(string rptName, DateTime startDate, DateTime endDate, string currency, string sourceBr);
    }
    public interface ILOMVEW00235
    {
        ILOMCTL00235 Controller { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string SourceBr { get; set; }
        string Currency { get; set; }
    }
}
