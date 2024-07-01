using System.Collections.Generic;
using System.Drawing;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using System;

namespace Ace.Cbs.Pfm.Ctr.PTR
{
    /// <summary>
    /// CurrentCompanyController
    /// </summary>
    public interface IPFMCTL00002 : IPresenter
    {
        IPFMVEW00002 View { get; set; }
        void Save();
        void ClearControls();
        bool AddCustomer();
        void GetDebitLinkAccount();
    }

    /// <summary>
    /// CurrentCompanyView
    /// </summary>
    public interface IPFMVEW00002
    {   
        IPFMCTL00002 Controller { get; set; }

        PFMDTO00032 FReceipt { get; set; }
        IList<PFMDTO00001> CustomerDataSource { get; set; }

        string TransactionStatus { get; }
        string AccountNo { get; set; }
        string NameOfFirm { get; set; }
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
        //Added by HWKO (15-Aug-2017)
        string CompanyRegNo { get; set; }
        DateTime CompanyRegDate { get; set; }
        DateTime CompanyRegExpDate { get; set; }
        //End Region
        void Successful(string message, string accountCode);
        void Failure(string message);
        string GetFormNameString(string parameter);
        void BindCustomer();
    }
}