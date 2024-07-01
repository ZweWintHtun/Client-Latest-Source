//----------------------------------------------------------------------
// <copyright file="ITLMDAO00013.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>AK</CreatedUser>
// <CreatedDate>08/01/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Tel.Ctr.Dao
{
    /// <summary>
    /// TLMDAO00012 Interface
    /// </summary>
    public interface ITLMDAO00013 : IDataRepository<TLMORM00013>
    {
        IList<TLMDTO00013> SelectCounterInfoForCashClosing(string branchCode);
        IList<TLMDTO00013> SelectCashSetupForCashClosing();
    }
}