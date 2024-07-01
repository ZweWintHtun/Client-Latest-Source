using System;
using System.Drawing;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Pfm.Ctr.PTR
{
    public interface IPFMCTL00017 : IPresenter
    {
        IPFMVEW00017 View { get; set; }
        PFMDTO00001 GetCustomerData();
        void ClearControls();
        void PrintData(string parameter);
    }

    public interface IPFMVEW00017
    {
        string CustomerId { get; set; }
        string NameofFirm { get; set; }
        string FatherName { get; set; }
        string Address { get; set; }
        string FullAddress { get; set; }
        string Occupation { get; set; }
        string Nationality { get; set; }
        string NRC { get; set; }
        string EMail { get; set; }
        string IntroducedBy { get; set; }
        string Phone { get; set; }
        string city { get; set; }
        string state { get; set; }
        string townshipcode { get; set; }
        string BankName { get; set; }
        string BranchName { get; set; }
        string Currency { get; set; }
        string CurrencyCode { get; set; }
        string Fax { get; set; }
        string GuardianName { get; set; }
        string GuardianNRC { get; set; }
        DateTime DateOfBirth { get; set; }
        string TransactionStatus { get; set; }

        void CheckValidCustomer(bool isValid);
        Image Photo { get; set; }
        Image Signature { get; set; }
        PFMDTO00060 IndividualDTO { get; set; }
        PFMDTO00001 CustomerIdDTO { get; set; }
        IPFMCTL00017 IndividualPrintingController { get; set; }
    }
}