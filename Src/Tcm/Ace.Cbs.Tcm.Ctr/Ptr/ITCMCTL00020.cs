using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
    public interface ITCMCTL00020:IPresenter
    {
        ITCMVEW00020 View { get; set; }
        bool Save();
        void ClearControls();
    }

    public interface ITCMVEW00020
    {
        ITCMCTL00020 Controller { get; set; }

        string AccountNo { get; set; }
        decimal OldMinimumLimit { get; set; }
        decimal NewMinimumLimit { get; set; }
        string Remark { get; set; }
        string Information { get; set; }

        void gvCustomer_DataBind(IList<PFMDTO00001> custList);
        void Successful(string message);
        void Failure(string message);
        void SetFocus();
    }
}
