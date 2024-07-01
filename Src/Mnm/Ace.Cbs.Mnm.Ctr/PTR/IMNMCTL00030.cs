using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Pfm.Dmd;


namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00030 : IPresenter
    {
        IMNMVEW00030 View { get; set; }

        IList<PFMDTO00032> SelectFReceiptData();
        void DirectPrint(IList<PFMDTO00032> printLists); //Updated by HWKO (27-Apr-2017)
        void DirectPrintUsingRDLC(IList<PFMDTO00032> printLists); //Updated by HWKO (11-May-2017)
    }

    public interface IMNMVEW00030
    {
        IMNMCTL00030 Controller { get; set; }
        
        DateTime Date { get; set; }

        void Successful(string message);
        void Failure(string message);
    }
}
