using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Mnm.Dmd;


namespace Ace.Cbs.Gl.Ctr.Ptr
{
    public interface IGLMCTL00002 : IPresenter
    {
        IGLMVEW00002 View{ get; set; }
        IList<MNMDTO00010> GetCCOA();
        void UpdateOpeningBalanceEntry(bool IsDelete);
        void GetEditedCCOAList(MNMDTO00010 editeddto);
        void DeleteOpeningBalanceEntry();
    }
    public interface IGLMVEW00002
    {
        IGLMCTL00002 Controller { get; set; }
        IList<MNMDTO00010> DataSource { get; set; }
        decimal OutOfBalance { get; set; }
         void Successful(string message);
         void Failure(string message);         
    }
}
