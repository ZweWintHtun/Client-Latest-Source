using System.Collections.Generic;
using System.Drawing;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Pfm.Ctr.PTR
{
    public interface IPFMCTL00018:IPresenter
    {
        IPFMVEW00018 View { get; set; }
        void ClearControls();
        bool AddCustomer();
        void Print();
    }

    public interface IPFMVEW00018
    {
        IList<PFMDTO00001> CustomerDataSource { get; set; }
        IPFMCTL00018 Controller { get; set; }
        string TransactionStatus { get; }
        string CurrencyCode { get; set; }
        int NoOfPersonSign { get; set; }
        string IntroducedBy { get; set; }
        string JoinType { get; set; }
        Image Photo { get; set; }
        Image Signature { get; set; }
        void BindCustomer();
    }
}
