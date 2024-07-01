//----------------------------------------------------------------------
// <copyright file="IMNMCTL00008.cs" company="ACE Data Systems">
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
using System;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    /// <summary>
    /// interface Cash Voucher controller
    /// </summary>
    public interface IMNMCTL00008 : IPresenter
    {
        IMNMVEW00008 View { get; set; }

        void ClearControls();
        void Save();
        void mtxtEntryNo_CustomValidating(object sender, ValidationEventArgs e);
        IList<PFMDTO00054> GetAllCashVoucherInfoByEno();
        DateTime GetSystemDate(string sourceBr);
        DateTime GetLastSettlementDate(string sourceBr);
    }

    /// <summary>
    /// interface cash Voucher View
    /// </summary>
    public interface IMNMVEW00008
    {
        IMNMCTL00008 Controller { get; set; }
        string EntryNo { get; set; }
        string Narration { get; set; }
        PFMDTO00054 ViewEntity { get; set; }
        string Status { get; set; }
        
        IList<string> CashInfo { get; set; }

        void BindCashVoucherGrid(IList<PFMDTO00054> cashVoucherlist);
        void EnableDisable(bool flag, bool isSave);
        void Successful(string message, string accountCode);
        void Failure(string message);
    }
}