using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00210 : IPresenter
    {
        ILOMVEW00210 View { get; set; }
        void Print(string rptName, DateTime startDate, DateTime endDate, string stockGroup, string sourceBr);
    }
    public interface ILOMVEW00210
    {
        ILOMCTL00210 Controller { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string SourceBr { get; set; }
        string Currency { get; set; }
    }
}
