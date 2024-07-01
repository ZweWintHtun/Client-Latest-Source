using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00028 : IPresenter
    {
        IMNMVEW00028 View { get; set; }
        void Save();
    }

    public interface IMNMVEW00028
    {
        IMNMCTL00028 Controller { get; set; }
        bool SaveStatus { get; set; }
        string RegisterNo { get; set; }

        void ClearControl();
        void BindInformation(IList<TLMDTO00001> reList);
    }
}
