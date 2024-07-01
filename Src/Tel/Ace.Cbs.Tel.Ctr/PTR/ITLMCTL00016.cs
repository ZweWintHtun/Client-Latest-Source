//----------------------------------------------------------------------
// <copyright file="ITLMCTL00016.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Su Su Wai</CreatedUser>
// <CreatedDate>09/06/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using System.Drawing;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Presenter;
using System;
namespace Ace.Cbs.Tel.Ctr.Ptr
{
    /// <summary>
    /// PO Refund By Cash Entry Controller Interface
    /// </summary>
    public interface ITLMCTL00016 : IPresenter
    {
        ITLMVEW00016 View { get; set; }
        decimal _totalAmt { get; set; }
        void ClearControls();
        void ClearTextBox();
        bool AddPaymentOrder();
        bool EditPaymentOrder(int index);
        //void txtBudgetYear_CustomValidating(object sender, ValidationEventArgs e);
        void Save();

        string GetBudYear();//added by HMW for budget end flexible 2019/04/08

        DateTime GetSystemDate(string sourceBr);
        DateTime GetLastSettlementDate(string sourceBr);
    }
    /// <summary>
    /// PO Refund By Cash Form Interface
    /// </summary>
    public interface ITLMVEW00016
    {
        ITLMCTL00016 Controller { get; set; }
        string VoucherNoLabel { get; set; }
        string BudgetYear { get; set; }
        string PaymentOrderNo { get; set; }
        string GroupNo { set; }
        string CurrencyCode { get; set; }
        string RegisterNo { get; set; }
        double Amount { get; set; }//Modified by HMW at 3-Oct-2019
        double TotalAmount { get; set; }//Modified by HMW at 3-Oct-2019
        int EditRowIndex { get; set; }       
        string SourceBranchCode { get; set; }
        IList<TLMDTO00041> PaymentOrderDataSource { get; set; }       
        void BindPaymentOrder();
        void Successful(string message, string groupCode);
        void Failure(string message, string poNo);
        void Failure(string message, string string1,string string2);
        bool isAdd { get; set; }
        bool HasNotToAdd { get; set; }
        void FocusOnPOTextBox();
    }

}
