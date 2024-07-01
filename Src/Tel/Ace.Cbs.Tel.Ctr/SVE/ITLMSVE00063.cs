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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Tel.Ctr.Sve
{
   public interface ITLMSVE00063:IBaseService
   {
       IList<PFMDTO00042> SelectDepositListingByAll(DateTime startDate, DateTime endDate, int CurrentUserId, string workstation, string sourceBr);
       IList<PFMDTO00042> SelectDepositListingByCounter(DateTime startDate, DateTime endDate, int createdUserId, string workStation, string counterNo, string sourceBr);
       IList<PFMDTO00042> SelectDepositListingByGrade(DateTime startDate, DateTime endDate, int createdUserId, string workStation, decimal minimumAmount, decimal maximumAmount, string accountSign, string sourceBr);
       IList<PFMDTO00042> SelectWithdrawListingByGrade(DateTime startDate, DateTime endDate, int createdUserId, int workStation, decimal minimumAmount, decimal maximumAmount, string accountSign, string sourceBr);
    }
}
