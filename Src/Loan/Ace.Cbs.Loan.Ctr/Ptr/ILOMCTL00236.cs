using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00236 : IPresenter
    {
        ILOMVEW00238 View { get; set; }
        void Transfer_Transaction_Listing(string rptName, string dateOption, DateTime startDate, DateTime endDate, string voucherStatus, string requiredType, int reverseStatus, string currency, string sourceBr);
    }
    public interface ILOMVEW00238
    {
        ILOMCTL00236 Controller { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string SourceBr { get; set; }
        string Currency { get; set; }
    }
}
