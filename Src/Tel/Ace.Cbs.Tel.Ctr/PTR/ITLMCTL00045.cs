//----------------------------------------------------------------------
// <copyright file="ITLMCTL00045.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-06-19</CreatedDate>
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
    public interface ITLMCTL00045 : IPresenter
    {
        ITLMVEW00045 View { get; set; }
        IList<TLMDTO00016> GetPrintData(string SourceBr);
    }


    public interface ITLMVEW00045
    {
        ITLMCTL00045 POOutstandingNormalReportController { get; set; }
        TLMDTO00016 DenoOutstandingReportDTO { get; set; }
        
    }
}
