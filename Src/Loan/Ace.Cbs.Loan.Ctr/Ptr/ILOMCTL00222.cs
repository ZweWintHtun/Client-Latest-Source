using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00222 : IPresenter
    {
        ILOMVEW00222 View { get; set; }
        void Print(string rptName, string currency, string sourceBr, string stockGroup);
    }
    public interface ILOMVEW00222
    {
        ILOMCTL00222 Controller { get; set; }
        string Currency { get; set; }
        string SourceBr { get; set; }
        string SortType {get;set;}

    }
}
