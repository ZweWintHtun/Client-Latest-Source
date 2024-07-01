//----------------------------------------------------------------------
// <copyright file="ITLMCTL00009.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Yu Thandar Aung</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System.Drawing;
using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Presenter;


namespace Ace.Cbs.Tel.Ctr.Ptr
{
    /// <summary>
    /// Fixed Deposit DepositEntry Presenter Interface
    /// </summary>
    public interface ITLMCTL00009 : IPresenter
    {
        ITLMVEW00009 View { get; set; }
        bool Save();
        void ClearControls();
        void Printing();
        PFMDTO00032 BindReceiptInfo();
        string Status { get; set; }
    }
    
    /// <summary>
    /// Fixed Deposit DepositEntry View Interface
    /// </summary>
    public interface ITLMVEW00009
    {
        ITLMCTL00009 Controller { get; set; }
     
        string AccountNo { get; set; }
        string ReceiptNo { get; set; }
        string Duration { get; set; }
        decimal Amount { get; set; }
        Image Photo { get; set; }
        Image Signature { get; set; }
        IList<PFMDTO00032> FReceiptList { get; set; }
        string CurrencyCode { get; set; }
        string ParentFormId { get; set; }

        void gvCustomer_DataBind(IList<PFMDTO00001> custList);
        void BindReceiptNo();
        void EnableControls();
        void DisableControls();
        void Successful(string message, string VoucherNo);
        void Failure(string message);
    }
}
