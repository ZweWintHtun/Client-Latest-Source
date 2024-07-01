using System;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Pfm.Ctr.PTR
{
    /// <summary>
    /// Current Account Closing Controller Interface
    /// </summary>
    public interface IPFMCTL00011 : IPresenter 
    {
        IPFMVEW00011 View { get; set; }
        void SaveCurrentAccountClose();
        void ClearControls(bool isAccountNo);
        string GetBranchCode();
    }

    /// <summary>
    /// Current Account Closing View Interface
    /// </summary>
    public interface IPFMVEW00011
    {
        IPFMCTL00011 Controller { get; set; }

        string AccountNo { get; set; }
        string AccountSignature { get; set; }
        string CurrencyCode { get; set; }
        string BranchCode { get; set; }
        DateTime CloseDate { get; set; }
        string ChequeNo { get; set; }
        decimal Balance { get; set; }
        decimal NetBalance { get; set; }
        decimal Charges { get; set; }
        Dictionary<string, string> Customers { get; set; }
        bool SaveStatus { get; set; }
        void BindCustomer();
    }
}