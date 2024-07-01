using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using System;
using System.Collections.Generic;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00421 : IPresenter
    {
        ILOMVEW00421 View { get; set; }
        IList<LOMDTO00406> BlAbsentHistory_Enquiry(string acctNo, string sourceBr);
        void Print(string rptName, string acctNo, string sourceBr);
    }
    public interface ILOMVEW00421
    {
        ILOMCTL00421 Controller { get; set; }
        string AcctNo { get; set; }
        string SourceBr { get; set; }
    }
}
