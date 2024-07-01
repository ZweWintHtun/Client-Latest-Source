using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00227 : IPresenter
    {
        ILOMVEW00227 View { get; set; }
        void Print(string rptName, DateTime startDate, DateTime endDate, string currency, string sourceBr, string stockGroup);
    }
    public interface ILOMVEW00227
    {
        ILOMCTL00227 Controller { get; set; }
        string Currency { get; set; }
        string SourceBr { get; set; }

    }
}
