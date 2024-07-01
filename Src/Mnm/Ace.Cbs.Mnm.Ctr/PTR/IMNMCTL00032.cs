//----------------------------------------------------------------------
// <copyright file="IMNMCTL00032.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KTRHMS</CreatedUser>
// <CreatedDate>11/04/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using System.Drawing;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    /// <summary>
    /// interface joint controller
    /// </summary>
    public interface IMNMCTL00032 : IPresenter
    {
        IMNMVEW00032 View { get; set; }
        void Save();
        void ClearControls();
        bool AddCustomer();
        PFMDTO00067 GetAccountInformation(string accountNo, string acSign);
        void mtxtAccountNo_CustomValidating(object sender, ValidationEventArgs e);
        void txtMinBal_CustomValidating(object sender, ValidationEventArgs e);

    }
    /// <summary>
    /// interface joint view
    /// </summary>
    public interface IMNMVEW00032
    {
        IMNMCTL00032 Controller { get; set; }
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
        decimal MinBalance { get; set;}
        string Status { get; set; }
        IList<string> OldCustomers { get; set; }

        void BindJointData();
        void Successful(string message, string accountCode);
        void Failure(string message);
        void BindCustomer();
        void SetDisable();
        void SetEnable();
    }
}