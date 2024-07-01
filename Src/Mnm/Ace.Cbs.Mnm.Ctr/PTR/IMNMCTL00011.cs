//----------------------------------------------------------------------
// <copyright file="IMNMCTL00011.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KTRHMS</CreatedUser>
// <CreatedDate>11/08/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using System.Drawing;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Presenter;
using System.Windows.Forms;
using System;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    /// <summary>
    /// interface Deliver and Receipt Reverse controller
    /// </summary>
    public interface IMNMCTL00011 : IPresenter
    {
        IMNMVEW00011 View { get; set; }
       
        void txtPaySlipNo_CustomValidating(object sender, ValidationEventArgs e);
        void Save();
        void Delete();
        void ClearCustomErrorMessage();   
        PFMDTO00054 GetTlfInformation();
        //IList<TLMDTO00040> GetBCode();
        string GetName(string entityacctno);

        DateTime GetSystemDate(string sourceBr);
        DateTime GetLastSettlementDate(string sourceBr);
    }

    /// <summary>
    /// interface Deliver and Receipt Reverse view
    /// </summary>
    public interface IMNMVEW00011
    {
        IMNMCTL00011 Controller { get; set; }
        string TransactionStatus { get; }
        string PayInSlipNo { get; set; }
        string AccountNo { get; set; }
        string Currency { get; set; }
        string Note { get; set; }
        decimal Amount { get; set; }
        string OtherBankCheque { get; set; }
        string ChequeNo { get; set; }
        string OCheque { get; set; }
        string PaidBank { get; set; }
        string ReceiptNo { get; set; }
        string Status { get; set; }
        string StatusCheque { get; set; }
        ListBox CustomerList { get; set; }

        //void BindBCode();
        void SetEnable(bool flag);
        void SetEnable(bool flag, bool flag2);
        void SetDisable(bool flag, bool flag2);
        void SetFocus(bool isAccountno);
        void SetFocusAmount();
        void ClearControl();
        void Successful(string message, string accountCode);
        void Failure(string message);
        int GetMenuIDPermission();
        void SetFocus();
    }
}