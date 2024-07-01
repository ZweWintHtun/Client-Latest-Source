//----------------------------------------------------------------------
// <copyright file="ITLMSVE00038.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-09-18</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Service;
using System;

namespace Ace.Cbs.Tel.Ctr.Sve
{
   public interface ITLMSVE00038:IBaseService
    {
       IList<TLMDTO00017> GetDrawingEncashRemittanceDataAllandByBranchLists(string typename, DateTime startDate, DateTime endDate, string bankNo,string sourceBr);
    }
}
