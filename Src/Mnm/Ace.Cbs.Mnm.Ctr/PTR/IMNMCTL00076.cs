using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Mnm.Dmd;
using System.Drawing;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00076 : IPresenter
    {
        IMNMVEW00076 View { get; set; }
        IList<MNMDTO00076> SelectPONO(string SourceBr);
    }

    public interface IMNMVEW00076
    {
        IMNMCTL00076 Controller { get; set; }

    }
}
