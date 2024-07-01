//----------------------------------------------------------------------
// <copyright file="ITLMDAO00C52.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate> 2013-10-28 </CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Tel.Dmd;
using System;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Tel.Ctr.Dao
{
  public interface ITLMDAO00C52:IDataRepository<TLMVIW00C52>
    {
      IList<PFMDTO00042> SelecteWithoutReversalByForAllBranchAndSourceCurSettlementDate(PFMDTO00042 bankCashDTO);
      IList<PFMDTO00042> SelecteWithoutReversalByForAllBranchAndSourceCurTransactionDate(PFMDTO00042 bankCashDTO);
    }
}
