using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
    public interface ITCMCTL00045 :IPresenter
    {
        ITCMVEW00045 View { get; set; }
        void SearchCustomerId();
        void ClearControls();
        //void Search(string customerId);
    }

    public interface ITCMVEW00045
    {
        ITCMCTL00045 Controller { get; set; }

        string CustomerID { get; set; }
        string CustomerName { get; set; }
        string NRC { get; set; }
        string NumOfAccountOpened { get; set; }
        string NumOfAccountClosed { get; set; }
        bool IsVIP { get; set; }
        void Successful(string message);
        void Failure(string message);
        void BindSAOFCAOFFAOFGridview(IList<TCMDTO00045> dtolist);
        void BindAccountCountGridview(IList<TCMDTO00045> dtolist);
        void BindLoanGuaranteeGridView(IList<TLMDTO00018> dtolist);
    }
}
