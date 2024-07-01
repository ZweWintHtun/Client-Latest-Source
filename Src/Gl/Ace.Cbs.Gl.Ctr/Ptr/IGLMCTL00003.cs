using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter ;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Gl.Ctr.Ptr
{
    public interface IGLMCTL00003 : IPresenter
    {
        IGLMVEW00003 View { get; set; }
        IList<MNMDTO00010> GetCCOA();
        IList<MNMDTO00010> EditedDataList { get; set; }

        void UpdateYearlyBudgetEntry(bool IsDelete, IList<MNMDTO00010> checkedCCOADataList);
        void GetEditedCCOAList(MNMDTO00010 editeddto);
        void DeleteYearlyBudgetEntry();
    }
    public interface IGLMVEW00003
    {
        IGLMCTL00003 Controller { get; set; }
        IList<MNMDTO00010> CCOADataSource { get; set; }
        
        void Successful(string message);
        void Failure(string message);
    }
}
