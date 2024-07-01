using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00233 : IPresenter
    {
        ILOMVEW00233 View { get; set; }
        void Print(string rptName, DateTime startDate, DateTime endDate, string currency, string sourceBr);
    }
    public interface ILOMVEW00233
    {
        ILOMCTL00233 Controller { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string SourceBr { get; set; }
        string Currency { get; set; }
    }
}
