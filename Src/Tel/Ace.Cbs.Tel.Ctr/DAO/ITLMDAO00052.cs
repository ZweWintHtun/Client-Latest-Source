//----------------------------------------------------------------------
// <copyright file="ITLMDAO00052.cs" company="ACE Data Systems">
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
    public interface ITLMDAO00052 : IDataRepository<TLMVIW00052>
    {
        IList<PFMDTO00042> SelectTransactionDateWithReversalByHome(PFMDTO00042 bankCashDTO);
        IList<PFMDTO00042> SelectWithReversalByCurrencyCodeSettlementDate(PFMDTO00042 bankCashDTO);
        IList<PFMDTO00042> SelectTransactionDateWithReversalByCurrencyCode(PFMDTO00042 bankCashDTO);
        IList<PFMDTO00042> SelectWithReversalByHomeSettlementDate(PFMDTO00042 bankCashDTO);
    }
}
