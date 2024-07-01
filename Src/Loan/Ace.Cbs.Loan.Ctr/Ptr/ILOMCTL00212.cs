using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00212 : IPresenter
    {
        ILOMVEW00212 View { get; set; }
        void Print(string rptName, DateTime startDate, DateTime endDate, string currency, string sourceBr, string stockGroup);
    }
    public interface ILOMVEW00212
    {
        ILOMCTL00212 Controller { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string SourceBr { get; set; }
        string Currency { get; set; }
    }
}
