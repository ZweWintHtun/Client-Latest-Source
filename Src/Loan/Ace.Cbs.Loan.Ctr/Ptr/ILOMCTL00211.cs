using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00211 : IPresenter
    {
        ILOMVEW00211 View { get; set; }
        void Print(string rptName, DateTime startDate, DateTime endDate, string stockGroup, string cur, string sourceBr);
    }
    public interface ILOMVEW00211
    {
        ILOMCTL00211 Controller { get; set; }
        string Currency { get; set; }
        string SourceBr { get; set; }
    }
}
