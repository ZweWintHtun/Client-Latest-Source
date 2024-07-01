using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00206: IPresenter
    {
        ILOMVEW00206 View { get; set; }
        void Print(string rptName, string month, string year, int createdUserId, string sourceBr);
    }
    public interface ILOMVEW00206
    {
        ILOMCTL00206 Controller { get; set; }
        string Currency { get; set; }
        string SourceBr { get; set; }
        string Month { get; set; }
        string Year { get; set; }
    }
}
