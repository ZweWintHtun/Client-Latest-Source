//----------------------------------------------------------------------
// <copyright file="ITLMCTL00004.cs" company="ACE Data Systems">
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
using Ace.Windows.Admin.DataModel;
using System;

namespace Ace.Cbs.Tel.Ctr.Ptr
{ 
    /// <summary>
    /// Chief Cashier Entry ->Vault Withdrawl Denomination Controller Interface
    /// </summary>
    public interface ITLMCTL00004 : IPresenter
    {
        ITLMVEW00004 View { get; set; }
        void ClearControls();              
        void Save();
        IList<CounterInfoDTO> GetAllCounterListBySourceBranchCode(string sourceBranchCode);
        void ntxtDebitFromAmount_CustomValidate();
        void ntxtCreditToAmount_CustomValidate();
        DateTime GetSystemDate(string sourceBr);
        DateTime GetLastSettlementDate(string sourceBr);
    }

    /// <summary>
    /// Chief Cashier Entry ->Vault Withdrawl Denomination Form Interface
    /// </summary>
    public interface ITLMVEW00004
    {

        ITLMCTL00004 Controller { get; set; }
        TLMDTO00015 CashDeno { get; set; }
        string Currency { get; set; }
        string DebitEno { set; }
        string CreditEno { set; }
        string DebitFrom { get; set; }
        string CreditTo { get; set; }
        bool isDebitCounterCheck { get; }
        bool isCreditCounterCheck { get; set; }
        bool isDebitVaultCheck { get; set; }
        bool isCreditVaultCheck{get;set;}
        bool CboToEnable { set; }
        decimal DebitAmount { get; set; }
        decimal CreditAmount { get; set; }
        string FromTypeSelectedText { get; }
        string ToTypeSelectedText { get; }
        string BranchCode { get; set; }    
        void Successful(string message);
        void Failure(string message);
        void EnableDisableSaveButton(bool saveEnable);
        void BindToComboBox();
        IList<CounterInfoDTO> toCashSetupList { get; set; }
        IList<TLMDTO00013> FfromCashSetupList { get; set; }
        string VirtualStatus { get; }
        bool isBranchCheck { get; }
    }
}
