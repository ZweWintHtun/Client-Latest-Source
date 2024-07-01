using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00010 : IPresenter
    {
        ILOMVEW00010 GJKCodeView { set; get; }
        IList<LOMDTO00008> SelectAll();
        void Save(LOMDTO00008 entity);
        void Delete(IList<LOMDTO00008> itemList);
        LOMDTO00008 SelectByGjkCode(string gjkind);
    }

    public interface ILOMVEW00010
    {
        string Kind { get; set; }
        string Description { get; set; }
        string Status { get; set; }

        LOMDTO00008 ViewData { get; set; }
        IList<LOMDTO00008> GJKCodes { get; set; }
        LOMDTO00008 PreviousGJKDto { get; set; }
        ILOMCTL00010 Controller { set; get; }

        void ControlSetting(string name, bool isEnable);
        void Successful(string message);
        void Failure(string message);
    }
}
