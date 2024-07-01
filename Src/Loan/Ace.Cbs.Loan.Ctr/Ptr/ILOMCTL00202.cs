using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using System;
using System.Collections.Generic;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00202 : IPresenter
    {
        ILOMVEW00202 View { get; set; }
        void Print(string rptName, string sourceBr, string currency, DateTime startDate, DateTime endDate);
    }
    public interface ILOMVEW00202
    {
        ILOMCTL00202 Controller { get; set; }
        string Currency { get; set; }
        string SourceBr { get; set; }
    }
}
