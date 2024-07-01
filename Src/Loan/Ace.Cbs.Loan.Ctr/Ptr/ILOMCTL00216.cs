using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00216 : IPresenter
    {
        ILOMVEW00216 View { get; set; }
        void Print(string rptName, DateTime startDate, DateTime endDate, string acctno, string sourceBr);
    }
    public interface ILOMVEW00216
    {
        ILOMCTL00216 Controller { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string AcctNo { get; set; }
        string SourceBr { get; set; }
    }
}
