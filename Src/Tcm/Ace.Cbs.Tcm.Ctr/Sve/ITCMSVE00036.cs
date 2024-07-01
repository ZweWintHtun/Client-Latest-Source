//----------------------------------------------------------------------
// <copyright file="ITCMSVE00036.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2014-02-06</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;

namespace Ace.Cbs.Tcm.Ctr.Sve
{
  public interface ITCMSVE00036:IBaseService
    {
      IList<PFMDTO00042> GetClearingDeliveredReverseService(DateTime startDate, DateTime endDate,string userNo,int createdUserId,string sourceBranch);
    }
}
