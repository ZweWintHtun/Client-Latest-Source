using System;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Gl.Ctr.Ptr
{
    public interface IGLMCTL00004
    {
        IGLMVEW00004 View { get; set; }
        IList<MNMDTO00010> EditedCCOAList { get; set; }
        IList<MNMDTO00010> GetCCOA();
        void GetEditedCCOAList(MNMDTO00010 editeddto);
        void UpdateMonthlyBudgetedEntry(bool isDelete, IList<MNMDTO00010> checkedCCOAList);
        void DeleteAllMonthlyBudgetedEntry();
    }

    public interface IGLMVEW00004
    {
        IGLMCTL00004 Controller { get; set; }
        IList<MNMDTO00010> CCOADto { get; set; }
        void Successful(string message);
        void Failure(string message);
        bool IsHomeCurrency { get; set; }
        void InitializeControls();
    }
}
