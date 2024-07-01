//----------------------------------------------------------------------
// <copyright file="ITCMCTL00061.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate> 2013-08-21 </CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;
namespace Ace.Cbs.Tcm.Ctr.Ptr
{
   public interface ITCMCTL00061:IPresenter
    {
       ITCMVEW00061 POPrintingReportView { get; set; }
       IList<TLMDTO00001> SelectPOReportLists(IList<TLMDTO00001> relists);
    }
   public interface ITCMVEW00061
   {
       ITCMCTL00061 POPrintingReportController { get; set; }
   }
}
