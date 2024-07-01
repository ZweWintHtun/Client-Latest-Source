//----------------------------------------------------------------------
// <copyright file="ITLMCTL00039.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate> 2013-09-21 </CreatedDate>
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
   public interface ITLMCTL00039:IPresenter
    {
       ITLMVEW00039 DrawingRemittanceEncashAmountView { get; set; }
       IList<TLMDTO00017> MainPrint(string typename);
    }

   public interface ITLMVEW00039
   {
       ITLMCTL00039 DrawingRemittanceEncashAmountController { get; set; }
       DateTime StartDate { get; set; }
       DateTime EndDate { get; set; }
       decimal StartAmount { get; set; }
       decimal EndAmount { get; set; }
       string TransactionStatus { get; }
   }
}
