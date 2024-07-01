using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
    public interface ITCMCTL00026:IPresenter
    {
        ITCMVEW00026 View { get; set; }
        void Print();
        void ClearCustomErrorMessage();
        PFMDTO00042 GetViewData();
    }

    public interface ITCMVEW00026
    {
        ITCMCTL00026 Controller { get; set; }

        bool IsAllBranch { get; set; }
        string Branch { get; set; }
        string BranchCode { get; set; }
        DateTime Date { get; set; }
        string Currency { get; set; }
        //bool AllBranches { get; set; }
        bool IsWithReversal { get; set; }
        bool IsByHomeCurrency { get; set; }
        string CurrencyType { get; set; }
        string DateType { get; set; }
    }
}
