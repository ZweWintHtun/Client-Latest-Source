using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using System;
using System.Collections.Generic;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00218 : IPresenter
    {
        ILOMVEW00218 View { get; set; }
        IList<LOMDTO00216> HPAbsentHistory_Enquiry(string acctNo, string sourceBr);
        void Print(string rptName,string acctNo, string sourceBr);
    }
    public interface ILOMVEW00218
    {
        ILOMCTL00218 Controller { get; set; }
        string AcctNo { get; set; }
        string SourceBr { get; set; }
    }
}
