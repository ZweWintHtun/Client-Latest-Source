using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00100 : IPresenter
    {
        ILOMVEW00100 View { get; set; }
        void Print(string rptName,string month,string year);
    }
    public interface ILOMVEW00100
    {
        ILOMCTL00100 Controller { get; set; }
        string Currency { get; set; }
        string SourceBr { get; set; }
        string Month { get; set; }
        string Year { get; set; }
    }
}
