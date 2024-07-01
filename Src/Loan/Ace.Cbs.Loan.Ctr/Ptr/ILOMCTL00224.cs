using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00224 : IPresenter
    {
        ILOMVEW00224 View { get; set; }
        IList<LOMDTO00001> BindLoansBType();
        void Print(string rptName, string currency, string sourceBr, string businessType);
    }
    public interface ILOMVEW00224
    {
        ILOMCTL00224 Controller { get; set; }
        string Currency { get; set; }
        string SourceBr { get; set; }
        string SortType { get; set; }

    }
}
