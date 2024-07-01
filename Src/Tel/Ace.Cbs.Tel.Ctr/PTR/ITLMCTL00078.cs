using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
    public interface ITLMCTL00078 : IPresenter
    {
        ITLMVEW00078 View { get; set; }
        void Save();
        void ClearCustomErrorMessage();
        DateTime GetSystemDate(string sourceBr);
        DateTime GetLastSettlementDate(string sourceBr);
    }
    public interface ITLMVEW00078
    {
        ITLMCTL00078 Controller { get; set; }
        string Eno { get; set; }
        string AccountNo { get; set; }
        string Description { get; set; }
        string status { get; set; }
        string PoNo { get; set; }
        string Currency { get; set; }
        decimal Amount { get; set; }
        void Successful(string message);
        void Failure(string message);
        void EnableDisableControls(bool status);
    }
}
