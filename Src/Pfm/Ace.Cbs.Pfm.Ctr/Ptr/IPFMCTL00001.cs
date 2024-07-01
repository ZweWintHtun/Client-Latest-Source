using System;
using System.Drawing;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Pfm.Ctr.PTR
{
    /// <summary>
    /// Individual Controller
    /// </summary>
    public interface IPFMCTL00001 : IPresenter
    {
        IPFMVEW00001 View { get; set; }
        bool AddCustomer();
        void AddReceipt();
        void Save();
        void ClearControls(bool isClearCustomerId);
        void GetDebitLinkAccount();
    }

    /// <summary>
    /// Individual View
    /// </summary>
    public interface IPFMVEW00001
    {
        IPFMCTL00001 Controller { get; set; }
        PFMDTO00032 FReceipt { get; set; }
        PFMDTO00001 Customer { get; set; }

        string TransactionStatus { get; }
        string AccountNo { get; set; }
        string CustomerName { get; set; }
        string NameOfFirm { get; set; }
        string FatherName { get; set; }
        string GuardianshipName { get; set; }
        string GuardianshipNRC { get; set; }
        string NRC { get; set; }
        Nullable<DateTime> DateOfBirth { get; set; }
        Nullable<DateTime> MatureDate { get; set; }
        string OccupationCode { get; set; }
        string Email { get; set; }
        string Address { get; set; }
        string CityCode { get; set; }
        string CurrencyCode { get; set; }
        string CurrencSymbol { get; set; }
        string Phone { get; set; }
        string Fax { get; set; }
        string TownshipCode { get; set; }
        string StateCode { get; set; }
        string Business { get; set; }
        string ReceiptNo { get; set; }
        string ChequeBookNo { get; set; }
        string ChequeStartNo { get; set; }
        string ChequeEndNo { get; set; }
        string DebitLinkAccount { get; set; }
        decimal DebitLimit { get; set; }
        string LinkAccountName { get; set; }
        string CustomerId { get; set; }
        Image Photo { get; set; }
        Image Signature { get; set; }
        void Successful(string message, string accountCode);
        void Failure(string message);
        void BindCustomer();
    }
}