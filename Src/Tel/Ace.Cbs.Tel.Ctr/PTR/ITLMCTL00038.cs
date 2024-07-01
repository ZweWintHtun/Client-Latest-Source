//----------------------------------------------------------------------
// <copyright file="ITLMCTL00038.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate> 2013-09-17 </CreatedDate>
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
   public interface ITLMCTL00038:IPresenter
    {
       ITLMVEW00038 DrawingRemittanceEncashAllByBranchView { get; set; }
       IList<TLMDTO00017> MainPrint(string typename);
    }

   public interface ITLMVEW00038
   {
       ITLMCTL00038 DrawingEncashController { get; set; }
       string TransactionStatus { get; }
       DateTime StartDate { get; set; }
       DateTime EndDate { get; set; }
       string BranchNo { get; set; }
   }
}
