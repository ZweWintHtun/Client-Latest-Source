//----------------------------------------------------------------------
// <copyright file="ITCMSVE00027.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ye Mann Aung</CreatedUser>
// <CreatedDate>24/11/2013</CreatedDate>
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
    /// Daily Closing Clearing Report Service Interface
    /// </summary>
    public interface ITCMSVE00027 : IBaseService
    {
        IList<PFMDTO00042> GetScheduleReportData(bool isTransaction, DateTime selectedDate, string workstartion, int currentUserId, string sourceBr, string currnecy);
        IList<PFMDTO00042> GetAbstractReportData(bool isTransaction, DateTime selectedDate, string workstartion, int currentUserId, string sourceBr, string currnecy);
        IList<TCMDTO00027> GetScrollData(string workstation, DateTime date_time, string currnecy, bool isTransactionDate, bool isReserval, int currentUserId,string sourceBr);
    }
}
