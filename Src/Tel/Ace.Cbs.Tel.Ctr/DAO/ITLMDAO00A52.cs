//----------------------------------------------------------------------
// <copyright file="ITLMDAO00A52.cs" company="ACE Data Systems">
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
   public interface ITLMDAO00A52:IDataRepository<TLMVIW00A52>
    {
       IList<PFMDTO00042> SelectWithReversalByForAllBranchAndSourceCurBySettlementDate(PFMDTO00042 bankCashDTO);
       IList<PFMDTO00042> SelectTranDateWithReversalByForAllBranchAndSourceCur(PFMDTO00042 bankCashDTO);
    }
}
