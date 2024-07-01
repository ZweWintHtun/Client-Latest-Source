//----------------------------------------------------------------------
// <copyright file="ITLMSVE00063" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>2.9.2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
// Added by JZT (06-Feb-2018)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Tel.Ctr.Sve
{
    public interface ITLMSVE00066 : IBaseService
    {
        IList<PFMDTO00042> SelectWithdrawlListingByAll(DateTime startDate, DateTime endDate, int CurrentUserId, string workstation, string sourceBr);
        IList<PFMDTO00042> SelectWithdrawlListingByCounter(DateTime startDate, DateTime endDate, int createdUserId, string workStation, string counterNo, string sourceBr);
        IList<PFMDTO00042> SelectWithdrawlListingByGrade(DateTime startDate, DateTime endDate, int createdUserId, string workStation, decimal minimumAmount, decimal maximumAmount, string accountSign, string sourceBr);
        IList<PFMDTO00042> SelectDepositListingByGrade(DateTime startDate, DateTime endDate, int createdUserId, int workStation, decimal minimumAmount, decimal maximumAmount, string accountSign, string sourceBr);
    }
}
