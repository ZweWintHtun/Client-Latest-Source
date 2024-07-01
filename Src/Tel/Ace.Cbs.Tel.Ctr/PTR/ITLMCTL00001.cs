//----------------------------------------------------------------------
// <copyright file="ITLMCTL00001.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Khin Thiyi Hay Mar Soe </CreatedUser>
// <CreatedDate>18.6.2013</CreatedDate>
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
    public interface ITLMCTL00001 : IPresenter
    {
        ITLMVEW00001 View { get; set; }
        void Save();
        void ClearControls();
        DateTime GetSystemDate(string sourceBr);
        DateTime GetLastSettlementDate(string sourceBr);
    }

    public interface ITLMVEW00001
    {
        ITLMCTL00001 Controller { get; set; }

        string VoucherNo { get; set; }
        string CurrencyCode { get; set; }
        string DomesticAccountNo{ get; set; }
        string Description { get; set; }
        string Narration{ get; set; }
        decimal Amount { get; set; }
        string ParentFormId { get; set; }
        string Status { get; set; }
        
        void Successful(string message, string VoucherNo);
        void Failure(string message);
    }
}
