using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00232 : IPresenter
    {
        ILOMVEW00232 View { get; set; }
        void Print(string rptName, DateTime startDate, DateTime endDate, string currency,string sourceBr);
    }
    public interface ILOMVEW00232
    {
        ILOMCTL00232 Controller { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string SourceBr { get; set; }
        string Currency { get; set; }
    }
}
