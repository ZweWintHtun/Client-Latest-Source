//----------------------------------------------------------------------
// <copyright file="IMNMCTL00013.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>11/21/2013</CreatedDate>
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
    /// Controller interface 
    /// Saving Interest Withdrawal Reversal
    /// </summary>
    public interface IMNMCTL00013 : IPresenter
    {
        IMNMVEW00013 View { get; set; }
        void BindSavingInterestWithdrawReversal();
        void ClearControls();
        void Save();
        void Print();

        DateTime GetSystemDate(string sourceBr);
        DateTime GetLastSettlementDate(string sourceBr);
    }

    /// <summary>
    ///  Saving Interest Withdrawal Reversal View Interface
    /// </summary>
    public interface IMNMVEW00013
    {
        IMNMCTL00013 Controller { get; set; }
        string EntryNo { get; set; }
        string Narration { get; set; }
        string WithdrawBy { get; set; }
        string InterestAccount { get; set; }
        IList<PFMDTO00054> GridViewDatasource { get; set; }
        void BindgvSavingInterestWithReversalGridView();
        void SetGridViewDataSourceNull();
        void EnableDisablePrintButton(bool isCash);
    }
}