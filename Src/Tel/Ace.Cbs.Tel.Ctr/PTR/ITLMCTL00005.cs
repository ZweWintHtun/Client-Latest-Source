//----------------------------------------------------------------------
// <copyright file="ITLMCTL00005.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hnin Thazin Shwe</CreatedUser>
// <CreatedDate>07/11/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
using System.Collections.Generic;
using System.Drawing;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using System;


namespace Ace.Cbs.Tel.Ctr.Ptr
{
    /// <summary>
    /// Counter Withdrawal Entry
    /// </summary>
  public   interface ITLMCTL00005 :IPresenter
    {
      ITLMVEW00005 View { get; set; }
      void Save();
      void ClearControls();
      DateTime GetSystemDate(string sourceBr);
      DateTime GetLastSettlementDate(string sourceBr);
    }

  public interface ITLMVEW00005
  {

      string EntryNo { get; set; }
      string CounterNo { get; set; }
      string CurrencyCode { get; set; }
      string Center { get; set; }
      decimal Amount { get; set; }
      ITLMCTL00005 Controller { get; set; }
      TLMDTO00015 ViewData { get; set; }
      void Failure(string message);
      void Successful(string message);
  
  }
}
