//----------------------------------------------------------------------
// <copyright file="ITLMCTL00043.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate> 2013-08-21 </CreatedDate>
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
    public interface ITLMCTL00043:IPresenter
    {
        ITLMVEW00043 DenoOutstandingReportView { get; set; }
        IList<PFMDTO00054> GetPrintData();
    }
    public interface ITLMVEW00043
    {
        ITLMCTL00043 DenoOutstandingReportViewController { get; set; }
    }
}
