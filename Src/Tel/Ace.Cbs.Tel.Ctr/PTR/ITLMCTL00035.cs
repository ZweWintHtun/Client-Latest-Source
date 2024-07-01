//----------------------------------------------------------------------
// <copyright file="ITLMCTL00035.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate> 2013-07-17 </CreatedDate>
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
    public interface ITLMCTL00035 : IPresenter
    {
        ITLMVEW00035 BankCashScrollView { get; set; }
        void Print();
        PFMDTO00042 GetViewData();
    }

    public interface ITLMVEW00035
    {
        ITLMCTL00035 BankCashScrollController { get; set; }
        string BranchNo { get; set; }
        string BranchCode { get; set; }
        string DateType { get; set; }
        bool IsAllBranch { get; set; }
       // bool IsAllBranches { get; set; }
        string CurrencyType { get; set; }
        bool IsWithReversal { get; set; }
        bool IsHomeCurrency { get; set; }
        string Currency { get; set; }
        DateTime RequiredDate { get; set; }
        //  PFMDTO00042 ReportTLFDTO { get; set; }
    }
}
