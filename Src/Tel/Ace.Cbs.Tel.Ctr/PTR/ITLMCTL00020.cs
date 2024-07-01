//----------------------------------------------------------------------
// <copyright file="ITLMCTL00020.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>7.6.2013</CreatedDate>
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
  public interface ITLMCTL00020:IPresenter
    {
      ITLMVEW00020 View { get; set; }
      IList<TLMDTO00001> GetEncashData();
      string GetEncashAmount(string branchCode, string currency, string sourceBranchCode);
      string GetCOADescription(string acode, string currency, string sourceBranchCode);
      IList<TLMDTO00050> GetGridData(IList<TLMDTO00001> tempEncashList);
      void ClearForm();    
      void Save();
    }

  public interface ITLMVEW00020
  {
      ITLMCTL00020 Controller { get; set; }
      string RegisterNo { get; set; }
      //TLMDTO00050 ViewData { get; set; }
      void Successful(string message, string voucherNo);
      void Failure(string message);
      void BindRegisterNoBoxes();
      void BindGridView(IList<TLMDTO00050> list);
      
      string TransactionStatus { get; }
     
      string EBank { get; set; }    

      string EncashAccount { get; set; }

      string Description { get; set; }

      string Currency { get; set; }

      decimal Amount { get; set; }

      string ToAccountNo { get; set; }

      string ToName { get; set; }

      string AccountSign { get; set; }

      string Parameter { get; set; }

      string AccountNo { get; set; }

      IList<TLMDTO00001> TempEncashList { get; set; }

      IList<TLMDTO00050> tempEncashList { get; set; }

      string _Name { get; set; }
  }
}
