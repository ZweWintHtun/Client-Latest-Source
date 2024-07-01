using System;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Pfm.Ctr.PTR
{
    /// <summary>
    /// Saving Account Closing Controller
    /// </summary>
    public interface IPFMCTL00010 : IPresenter
    {
        IPFMVEW00010 View { get; set; }
        void SaveSavingAccountClose();
        void ClearControls();
        string GetBranchCode();
    }

    /// <summary>
    /// Saving Account Closing View
    /// </summary>
    public interface IPFMVEW00010
    {
        IPFMCTL00010 Controller { get; set; }

        string AccountNo { get; set; }
        string AccountSignature { get; set; }
        string BranchCode { get; set; }
        string CurrencyCode { get; set; }
        DateTime OpenDate { get; set; }
        DateTime CloseDate { get; set; }
        decimal Balance { get; set; }
        decimal Charges { get; set; }
        Dictionary<string, string> Customers { get; set; }
        decimal BeforeTax { get; set; }
        decimal Tax { get; set; }
        decimal AfterTax { get; set; }
        decimal TotalInterest { get; set; }
        decimal NewBalance { get; set; }
        string DebitCreditStatus { get; set; }
        void BindCustomer();
    }
}