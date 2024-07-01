﻿//----------------------------------------------------------------------
// <copyright file="ITLMCTL00066.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-09-05</CreatedDate>
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

   public interface ITLMCTL00051:IPresenter
    {
       ITLMVEW00051 BankStatementListingReportView { get; set; }
       IList<PFMDTO00042> GetBankStatementReportList();
    }
   public interface ITLMVEW00051
   {
       ITLMCTL00051 BankStatementListingReportController { get; set; }
       DateTime StartDate { get; set; }
       DateTime EndDate { get; set; }
       string AccountNo { get; set; }
       Boolean WithReversal { get; set; }
   }
}
