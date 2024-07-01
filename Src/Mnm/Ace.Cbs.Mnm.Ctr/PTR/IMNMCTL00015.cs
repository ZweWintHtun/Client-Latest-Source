using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00015
    {
        IMNMVEW00015 View { get; set; }
        string GetBudgetYear();
        void Save();
    }

    public interface IMNMVEW00015
    {
        IMNMCTL00015 Controller { get; set; }
        string PONo { get; set; }
        string AccountNo { get; set; }
        void ShowData(IList<TLMDTO00016> PO);
        void ClearControls();
    }
}
