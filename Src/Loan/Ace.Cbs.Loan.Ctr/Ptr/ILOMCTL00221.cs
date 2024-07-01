using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00221 : IPresenter
    {
        ILOMVEW00221 View { get; set; }
        void Print(string rptName, string currency, string sourceBr);
    }
    public interface ILOMVEW00221
    {
        ILOMCTL00221 Controller { get; set; }
        string Currency { get; set; }
        string SourceBr { get; set; }
    }
}
