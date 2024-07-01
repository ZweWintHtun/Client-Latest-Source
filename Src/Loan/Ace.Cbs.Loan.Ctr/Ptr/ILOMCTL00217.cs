using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00217 : IPresenter
    {
        ILOMVEW00217 View { get; set; }
        void Print(string rptName, DateTime startDate, DateTime endDate, string acctno, string sourceBr);
    }
    public interface ILOMVEW00217
    {
        ILOMCTL00217 Controller { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string AcctNo { get; set; }
        string SourceBr { get; set; }
    }
}
