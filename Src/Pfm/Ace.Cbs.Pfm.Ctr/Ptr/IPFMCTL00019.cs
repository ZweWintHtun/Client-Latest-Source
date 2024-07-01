using System.Collections.Generic;
using System.Drawing;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Pfm.Ctr.PTR
{
    /// <summary>
    /// Current Company Printing Controller Interface
    /// </summary>
    public interface IPFMCTL00019 : IPresenter
    {
        IPFMVEW00019 View { get; set; }
        bool AddCustomer();
        void ClearControls();
        void PrintData();
    }

    /// <summary>
    /// Current Company Printing View Interface
    /// </summary>
    public interface IPFMVEW00019
    {
        IPFMCTL00019 Controller { get; set; }

        IList<PFMDTO00001> CustomerDataSource { get; set; }
        string TransactionStatus { get; }
        string CurrencyCode { get; set; }
        string NameOfFirm { get; set; }
        string Email { get; set; }
        string Address { get; set; }
        string CityCode { get; set; }
        string IntroducedBy { get; set; }
        string Phone { get; set; }
        string Fax { get; set; }
        string TownshipCode { get; set; }
        string StateCode { get; set; }
        int NoOfPersonSign { get; set; }
        Image Photo { get; set; }
        Image Signature { get; set; }

        void BindCustomer();
    }
}