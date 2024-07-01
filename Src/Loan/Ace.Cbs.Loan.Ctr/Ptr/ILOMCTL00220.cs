using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00220 : IPresenter
    {
        ILOMVEW00220 View { get; set; }
        void Print(string rptName, string currency, string sourceBr, DateTime startDate, DateTime endDate, int searchBy);
        DateTime GetSystemDate(string sourceBr);
    }
    public interface ILOMVEW00220
    {
        ILOMCTL00220 Controller { get; set; }
        string Currency { get; set; }
        string SourceBr { get; set; }
    }
}
