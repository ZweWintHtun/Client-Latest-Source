using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00230 : IPresenter
    {
        ILOMVEW00230 View { get; set; }
        void Print(string rptName, DateTime startDate, DateTime endDate, string currency, string sourceBr);
    }
    public interface ILOMVEW00230
    {
        ILOMCTL00230 Controller { get; set; }
        string Currency { get; set; }
        string SourceBr { get; set; }

    }
}
