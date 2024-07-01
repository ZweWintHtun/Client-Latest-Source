//----------------------------------------------------------------------
// <copyright file="ITLMDAO00B52.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate> 2013-09-11 </CreatedDate>
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
    public interface ITLMDAO00B52 : IDataRepository<TLMVIW00B52>
    {
       IList<PFMDTO00042> SelectByBankCashWithoutReversalByCurCodeTransactionDate(PFMDTO00042 bankCashDTO);
       IList<PFMDTO00042> SelectAllWithoutReversalByHomeTransactionDate(PFMDTO00042 bankCashDTO);
       IList<PFMDTO00042> SelectAllWithoutReversalByHomeSettlementDate(PFMDTO00042 bankCashDTO);
       IList<PFMDTO00042> SelectByBankCashWithoutReversalByCurCodeSettlementDate(PFMDTO00042 bankCashDTO);
    }
}
