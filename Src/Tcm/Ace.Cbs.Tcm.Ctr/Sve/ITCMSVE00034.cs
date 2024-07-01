//----------------------------------------------------------------------
// <copyright file="ITCMSVE00034.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>♠ Ye Mann Aung ♠</CreatedUser>
// <CreatedDate>12/12/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;

using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tcm.Dmd;
using Ace.Windows.Core.Service;

namespace Ace.Cbs.Tcm.Ctr.Sve
{
    /// <summary>
    /// Clearing Paid Cheque Report Service Interface
    /// </summary>
    public interface ITCMSVE00034 : IBaseService
    {
        IList<PFMDTO00042> GetPrintData(DateTime startdate, DateTime enddate, int currentUserId, string workstation, string transactionStatus,string sourceBr);
    }
}
