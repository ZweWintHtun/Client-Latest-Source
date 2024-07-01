//----------------------------------------------------------------------
// <copyright file="ITLMCTL00041.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-08-05</CreatedDate>
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
   public interface ITLMCTL00041:IPresenter
    {
       ITLMVEW00041  CenterTableDepositApproveView { get; set; }
       void SaveCashDeno(IList<TLMDTO00015> CashDenoDTOsList);
    
      IList<TLMDTO00015> GetCashDenoList();
      DateTime GetSystemDate(string sourceBr);
      DateTime GetLastSettlementDate(string sourceBr);
    }


   public interface ITLMVEW00041
   {
       IList<TLMDTO00015> CashDenoList { get; set; }
       ITLMCTL00041 CenterTableDepositApproveController { get; set; }
       void Failure(string message, string voucher);
       void EnableNoOfCashierEntryNo();
   }
}
