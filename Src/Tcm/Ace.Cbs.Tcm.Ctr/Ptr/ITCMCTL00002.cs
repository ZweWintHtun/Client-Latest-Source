//----------------------------------------------------------------------
// <copyright file="TCMSVE00014.cs" company="ACE Data Systems">
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

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
    /// <summary>
    /// PO Refund By Transfer Controller Interface
    /// </summary>
    public interface ITCMCTL00002 : IPresenter
    {
        ITCMVEW00002 View { get; set; }
        void ClearControls();
        void CheckPO();
        void Save();
        void Printing();

        string GetBudYear();//added by zms for budget end flexible 2018/09/21
        DateTime GetSystemDate(string sourceBr);
        DateTime GetLastSettlementDate(string sourceBr);
    }

    /// <summary>
    /// PO Refund By Transfer View Interface
    /// </summary>
    public interface ITCMVEW00002
    {
        ITCMCTL00002 Controller { get; set; }
        string PONo { get; set; }
        string BudgetYear { get; set; }
        string AccountNo { get; set; }
        string CustomerName { get; set; }
        string Currency { get; set; }
        double Amount { get; set; }//Modified by HMW at 3-Oct-2019 : Adding Thousand Seperators
        string Acode { get; set; }
        void POFocus();
        void AccountFocus();
        void EnableControlsforPrint();
        int MenuIdForPermission { get; }

        string CurrentBCode { get; set; }
    }
}
