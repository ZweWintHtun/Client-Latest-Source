using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
    public interface ITLMCTL00028:IPresenter
    {
        ITLMVEW00028 View { get; set; }
        void Print(string forReversalCase);
    }

    public interface ITLMVEW00028
    {
        ITLMCTL00028 Controller { get; set; }
        string TranType { get; set; }
        string BranchCode { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        //string OnlineBranchCode { get; set; }
        //bool AllBranch { get; set; }
        bool isActive { get; set; }
        bool isReversal { get; set; }
        string FormName { get; set; }

        string GetTranType();

    }
}
