//----------------------------------------------------------------------
// <copyright file="ITCMCTL00046.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2014-02-06</CreatedDate>
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
    /// <summary>
    /// Interface of Clearing Delivered Reversal Controller
    /// </summary>
   public interface ITCMCTL00036:IPresenter
    {
       ITCMVEW00036 ClearingdeliveredReversalView { get; set; }
       void GetClearingDeliveredReversalListing();
       bool CheckDate();

    }
   public interface ITCMVEW00036
   {
       ITCMCTL00036 ClearingDeliveredReversalController { get; set; }
       void InitializeControls();
       DateTime StartDate { get; set; }
       DateTime EndDate { get; set; }
   }
}
