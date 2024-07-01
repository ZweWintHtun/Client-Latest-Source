using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00229 : IPresenter
    {
        ILOMVEW00229 View { get; set; }
        IList<LOMDTO00001> BindLoansBType();
        void Print(string rptName, DateTime startDate, DateTime endDate, string currency, string sourceBr, string businessType);
    }
    public interface ILOMVEW00229
    {
        ILOMCTL00229 Controller { get; set; }
        string Currency { get; set; }
        string SourceBr { get; set; }

    }
}
