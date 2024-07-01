using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using System;
using System.Collections.Generic;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00203 : IPresenter
    {
        ILOMVEW00203 View { get; set; }
        void Print(string rptName, string month);
    }
    public interface ILOMVEW00203
    {
        ILOMCTL00203 Controller { get; set; }
        string Currency { get; set; }
        string SourceBr { get; set; }
        string Month { get; set; }
    }
}
