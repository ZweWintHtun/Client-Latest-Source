using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00207 : IPresenter
    {
        ILOMVEW00207 View { get; set; }
        void Print(string rptName, DateTime startDate, DateTime endDate);
    }
    public interface ILOMVEW00207
    {
        ILOMCTL00207 Controller { get; set; }
        string Currency { get; set; }
        string SourceBr { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
    }
}
