//----------------------------------------------------------------------
// <copyright file="ITLMCTL00002" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>18.6.2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
    /// <summary>
    /// Encash Remit Registration Controller Interface
    /// </summary>
    public interface ITLMCTL00002:IPresenter
    {
        ITLVEW00002 View { get; set; }

        void ClearControls();
        void GetFixRegisterNo();       
        string Save();
        bool GetCustomerByAccountNo();
        void Printing();
    }

  /// <summary>
    /// Encash Remit Registration View Interface
  /// </summary>
    public interface ITLVEW00002
    {
        ITLMCTL00002 Controller { get; set; }
        bool POStatus { get; set; }
        string BranchCode { get; set; }
        string Currency { get; set; }
        decimal Amount { get; set; }
        string FixRegisterNo { get; set; }
        string RegisterNo { get; set; }
        string AccountNo { get; set; }
        string RemitterName { get; set; }
        string RemitterNRC { get; set; }
        string RemitterPhoneNo { get; set; }
        string PayeeName { get; set; }
        string PayeeNRC { get; set; }
        string PayeeAddress { get; set; }
        string PayeePhoneNo { get; set; }
        string AccountSign { get; set; }
        string TransactionStatus { get; set; }
        string PONo { get; set; }
        string BudgetYear { get; set; }       
        void ReadOnlyControls(bool enable);
        void ComboValidate(string data);
        void Shows();
        void Successful(string message, string PONo);
        void Failure(string message);
        void RegisterNoFocus();
        void Disable();
      
    }
}
