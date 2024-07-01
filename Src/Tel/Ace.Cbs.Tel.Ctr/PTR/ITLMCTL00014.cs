//----------------------------------------------------------------------
// <copyright file="ITLMCTL00014.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
    public interface ITLMCTL00014 : IPresenter
    {
        ITLMVEW00014 View { get; set; }

        void ClearControls(bool isCancel);
        bool ValidateAdd();
        
        //IList<TLMDTO00047> AddWithdrawInfo();
        TLMDTO00047 AddWithdrawInfo();
        bool SaveWithdraw(IList<TLMDTO00047> withdraws);
        TLMDTO00047 GetWithdrawalEntity();
        bool Validate();
        void Printing(IList<TLMDTO00047> withdraws);
        DateTime GetSystemDate(string sourceBr);
        DateTime GetLastSettlementDate(string sourceBr);
    }

    public interface ITLMVEW00014
    {
        ITLMCTL00014 Controller { get; set; }

        string AccountNo { get; set; }
        string ToBranch { get; set; }
        decimal Amount { get; set; }
        string ChequeNo { get; set; }
        int NoOfPersonSign { get; set; }
        string JoinType { get; set; }
        decimal Comissions { get; set; }
        decimal CommunicationCharges { get; set; }
        bool VIPCustomer { get; set; }
        bool PrintStatus { get; set; }
        bool InputIncomeAmount { get; set; }
        bool IncomeByCash { get; set; }
        bool IncomeByTransfer { get; set; }
        string CurrentAccountSign { get; }
        string SavingAccountSign { get; }
        string CurrencyCode { get; set; }
        string Name { get; set; }
        bool IsAutoLink { get; set; }
        bool IsLastWithdrawal { get; set; }
        string GroupNo { get; set; }
        decimal TotalAmount { get; set; }
        decimal TotalCharges { get; set; }
        bool LocalWithdrawType { get; set; }
        bool OnlineWithdrawType { get; set; }
        bool IsEdit { get; set; }  //added by ASDA
        void SetFocusOnAmount();
        IList<TLMDTO00047> WithdrawLists {get;set;}
        
        void DisableControlsforView(string name);
        void Successful(string message, string name, string VoucherNo);     
        void Failure(string message);
        string LocalBranchCode { get; }
        void EnableControlsForController(string name);
        void DisableControlsForController(string name);
        void SetFocusOnCheque();
        bool IsCheckGrid { get; set; }
        string Status { get; set; }
        void BindgvMultiAccountWithdrawlInformation(IList<TLMDTO00047> withdrawList);
        void CalculateTotalAmount(IList<TLMDTO00047> withdrawList);
        void CheckedJoinType();
        bool IsCloseAccount { get; set; } //Added by AAM(12_Sep_2018)



    }
}
