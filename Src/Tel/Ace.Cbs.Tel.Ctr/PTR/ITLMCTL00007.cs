//----------------------------------------------------------------------
// <copyright file="ITLMCTL00007.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-06-11</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Drawing;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
    public interface ITLMCTL00007 : IPresenter
    {
        ITLMVEW00007 POReceiptView { get; set; }
        void Save();
        void ClearControls();          
        TLMDTO00016 PODTO { get; set; }

        string GetBudYear();//added by zms for budget end flexible 2018/09/21
    }

    public interface ITLMVEW00007
    {
        ITLMCTL00007 POReceiptController { get; set; }
        string PaySlipNo { get; set; }      
        string PaymentOrderNo { get; set; }
        string BudgetYear { get; set; }
        string ReceivedAccountNo { get; set; }
        string OtherBank { get; set; }
        string Currency { get; set; }
        decimal Amount { get; set; }
        void Successful(string message, string payslipNo);
        void Failure(string message);
        void BudgetYearInitializeControls();      
        void InitializeControls();

        string CurrentBCode { get; set; }

    }
}
