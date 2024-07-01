using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00209 : IPresenter
    {
        ILOMVEW00209 View { get; set; }
        //void Print(string rptName, string stockGroupCode, DateTime startDate, DateTime endDate, string sourceBr);
        void Print(string rptName, string stockGroupCode, string sourceBr);
    }
    public interface ILOMVEW00209
    {
        ILOMCTL00209 Controller { get; set; }
        string Currency { get; set; }
        string SourceBr { get; set; }
        //DateTime Date { get; set; }
    }
}
