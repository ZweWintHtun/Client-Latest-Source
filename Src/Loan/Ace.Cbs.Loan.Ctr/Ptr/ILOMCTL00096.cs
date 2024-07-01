using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00096 : IPresenter
    {
        ILOMVEW00096 View { get; set; }
        void Print(string rptName, string sourceBr, string currency, DateTime startDate, DateTime endDate, string stockGroup);
    }
    public interface ILOMVEW00096
    {
        ILOMCTL00096 Controller { get; set; }
        string Currency { get; set; }
        string SourceBr { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
    }
}
