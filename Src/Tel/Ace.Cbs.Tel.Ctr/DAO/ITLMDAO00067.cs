//----------------------------------------------------------------------
// <copyright file="ITLMDAO00067.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate> 2013-09-06 </CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using System;

namespace Ace.Cbs.Tel.Ctr.Dao
{
    public interface ITLMDAO00067 : IDataRepository<TLMVIW00024>
    {
        IList<PFMDTO00042> SelectWithdrawalListingByCounterNoReport(DateTime startDate, DateTime endDate, string workstation, string counterno); 
    }
}
