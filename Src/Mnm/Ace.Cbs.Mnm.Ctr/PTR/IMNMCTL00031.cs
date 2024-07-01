using System;
using System.Drawing;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using System.Collections.Generic;


namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    /// <summary>
    /// Individual Controller
    /// </summary>
    public interface IMNMCTL00031 : IPresenter
    {
        IMNMVEW00031 View { get; set; }
        bool SaveStaus { get; set; }
        bool AddCustomer();
        void Save();
        void ClearControls(bool isClearCustomerId);  

      
      
    }

    public interface IMNMVEW00031
    {
        IMNMCTL00031 Controller { get; set; }
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
        string oldCustomerID { get; set; }
        decimal MinimumBalance { get; set; }
        string AcSign { get; set; }
        bool SaveStatus { get; set; }
        void Successful(string message);
        void EnableDisableInputControls(bool status);
        void FillData(PFMDTO00001 CustomerInfo);
        void Failure(string message);
        void BindCustomer();
        void SetDisable();
        void SetEnable();
        

    }
}
