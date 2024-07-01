//----------------------------------------------------------------------
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>11/01/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using System.Drawing;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00033 : IPresenter
    {
        IMNMVEW00033 View { get; set; }
        void Save();
        void ClearControls();
        bool AddCustomer();
        //void GetDebitLinkAccount();
    }

    public interface IMNMVEW00033
    {
        IMNMCTL00033 Controller { get; set; }

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
        string AcSign { get; set; }
        Image Photo { get; set; }
        Image Signature { get; set; }
        bool SaveStatus { get; set; }
        IList<string> OldCustomers { get; set; }
        decimal MinBal { get; set; }
        string JointType { get; set; } // Added By AAM (05-Feb-2018)

        void Successful(string message);
        void Failure(string message);
        void BindCustomer();
        void EnableDisableInputControls(bool status);
        void FillData(PFMDTO00050 bindData);
        void EnableDisableControls();
        void SetFocus();
        void SetDisable();
        void SetEnable();
    }
}
