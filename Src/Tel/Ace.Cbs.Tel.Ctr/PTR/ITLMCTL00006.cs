//----------------------------------------------------------------------
// <copyright file="ITLMCTL00006.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Su Su Wai</CreatedUser>
// <CreatedDate>24/07/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using System.Drawing;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
    /// <summary>
    /// Entry -> Clearing -> Delivered Entry & Entry -> Clearing -> Receipt Entry Controller Interface
    /// </summary>
    public interface ITLMCTL00006:IPresenter
    {
        ITLMVEW00006 View { get; set; }
        void Save();
        void ClearControls();

    }
    /// <summary>
    /// Entry -> Clearing -> Delivered Entry & Entry -> Clearing -> Receipt Entry Interface
    /// </summary>
    public interface ITLMVEW00006
    {
        ITLMCTL00006 Controller { get; set; }
        string TransactionStatus { get; }
        string BankDescriptionLabel { set; }
        string OtherBankLabel { set; }
        string ChequeNoLabel { set; }
        string AccountNoLabel { set; }
        string PayInSlipNo { set; }
        string AccountNo { get; set; }
        string ReceiptAccountNo { get; set; }
        string CurrencyCode { get; set; }
        string OtherBank { get; set; }
        decimal Amount { get; set; }
        string ChequeNo { get; set; }
        string AccountName { set; get; }
        IList<TLMDTO00040> BCodeList { get; set; }       
        void Successful(string message, string paySilpNo);
        void Failure(string message);
        void EnableDisableCurrencyCombo(bool enable);
        void EnableDisableControls(bool enable);
        void EnableDisableControlForDomesticReceipt(bool enable);
        void InitializedState();
        void IsDomestic(bool enable);
        bool isDeliver { get; set; }
        void DeliverDomesticFormCleaning();
        void FoucsCursorOnChequeNo();
    }
}
