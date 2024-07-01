using System.Collections.Generic;
using System.Drawing;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Pfm.Ctr.PTR
{
    /// <summary>
    /// interface joint controller
    /// </summary>
    public interface IPFMCTL00003:IPresenter
    {
        IPFMVEW00003 View { get; set; }
        PFMDTO00001 customerResult { get; set; }
        void Save();
        void ClearControls();
        bool AddCustomer();
        void GetDebitLinkAccount();
    }

    /// <summary>
    /// interface joint view
    /// </summary>
    public interface IPFMVEW00003
    {
        IPFMCTL00003 Controller { get; set; }
        PFMDTO00032 FReceipt { get; set; }
        IList<PFMDTO00001> CustomerDataSource { get; set; }

        string TransactionStatus { get; }
        string AccountNo { get; set; }
        string CurrencyCode { get; set; }
        string CurrencSymbol { get; set; }
        int NoOfPersonSign { get; set; }
        string ReceiptNo { get; set; }
        string ChequeBookNo { get; set; }
        string ChequeStartNo { get; set; }
        string ChequeEndNo { get; set; }
        string DebitLinkAccount { get; set; }
        decimal DebitLimit { get; set; }
        string LinkAccountName { get; set; }
        Image Photo { get; set; }
        Image Signature { get; set; }
        string JoinType { get; set; }
        void Successful(string message, string accountCode);
        void Failure(string message);
        void BindCustomer();
    }
}