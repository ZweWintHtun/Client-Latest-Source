//----------------------------------------------------------------------
// <copyright file="ITLMCTL00027.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-07-04</CreatedDate>
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
   public interface ITLMCTL00027:IPresenter
    {
       ITLMVEW00027 WithdrawalListingByAllView { get; set; }
      // PFMDTO00054 Print();
       bool CheckDate();
       void MainPrint();
       void ClearCustomErrorMessage();
       
    }

   public interface ITLMVEW00027
   {
       ITLMCTL00027 WithdrawalListingByAllController { get; set; }
       string AccountNo { get; set; }
       string EnterTellerNo { get; set; }
       string TransactionStatus { get;}
       DateTime StartDate { get; set; }
       DateTime EndDate { get; set; }
    
      
   }
}
