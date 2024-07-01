using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00093 : IPresenter
    {
        ILOMVEW00093 View { get; set; }

        void Print();
    }

    public interface ILOMVEW00093
    {
        ILOMCTL00093 Controller { get; set; }

        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string SourceBranch { get; set; }
        string Currency { get; set; }
        string SeasonType { get; set; }
        string CropType { get; set; }
        string ReportType { get; set; }
        string ParentFormName { get; set; }
    }
}
