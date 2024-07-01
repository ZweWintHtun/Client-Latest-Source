using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using System;
using System.Collections.Generic;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00219 : IPresenter
    {
        ILOMVEW00219 View { get; set; }
        IList<LOMDTO00217> PLAbsentHistory_Enquiry(string acctNo, string sourceBr);
        void Print(string rptName, string acctNo, string sourceBr);
    }
    public interface ILOMVEW00219
    {
        ILOMCTL00219 Controller { get; set; }
        string AcctNo { get; set; }
        string SourceBr { get; set; }
    }
}
