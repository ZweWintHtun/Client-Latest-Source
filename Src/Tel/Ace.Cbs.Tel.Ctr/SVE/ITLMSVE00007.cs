//----------------------------------------------------------------------
// <copyright file="ITLMSVE00007.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-06-11</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Service;
using System.Collections.Generic;
using System;

namespace Ace.Cbs.Tel.Ctr.Sve
{
    /// <summary>
    /// POReceipt Service Interface
    /// </summary>
  public interface ITLMSVE00007:IBaseService
    {
      string Save(TLMDTO00045 POReceiptDTO);   
      string GetBudYear(int service, DateTime reqDate, string sourceBr);//added by ZMS to get active Budget from BLF (2018/09/21)
     
    }
}
