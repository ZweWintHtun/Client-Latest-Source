using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00156 : IPresenter
    {
        IMNMVEW00156 DrawingRemittanceMonthlyClosingView { get; set; }
        //IList<TLMDTO00017> MainPrint(string typeName);
        IList<TLMDTO00017> MainDrawingPrint(string typename);
        IList<TLMDTO00001> MAinEncashPrint(string typename);
    }

    public interface IMNMVEW00156
    {
        IMNMCTL00156 DrawingRemittanceMonthlyClosingController { get; set; }
        string TransactionStatus { get;}
        string RequiredYear { get; set; }
        string RequiredMonth { get; set; }
    }
}
