//----------------------------------------------------------------------
// <copyright file="ITLMDAO00A40.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate> 2013-09-24 </CreatedDate>
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
    public interface ITLMDAO00A40:IDataRepository<TLMVIW00C16>
    {
        IList<TLMDTO00017> SelectNRCForEncashRemittanceByTransactionDate(DateTime startDate, DateTime endDate, string nrc);
        IList<TLMDTO00017> SelectNRCForEncashRemittanceBySettlementDate(DateTime startDate, DateTime endDate, string nrc);
        IList<TLMDTO00017> SelectNRCExactlyForEncashRemittanceByTransactionDate(DateTime startDate, DateTime endDate, string nrc);
        IList<TLMDTO00017> SelectNRCExactlyForEncashRemittanceBySettlementDate(DateTime startDate, DateTime endDate, string nrc);

        IList<TLMDTO00017> SelectNameForEncashRemittanceByTransactionDate(DateTime startDate, DateTime endDate, string name);
        IList<TLMDTO00017> SelectNameForEncashRemittanceBySettlementDate(DateTime startDate, DateTime endDate, string name);
        IList<TLMDTO00017> SelectNameExactlyForEncashRemittanceByTransactionDate(DateTime startDate, DateTime endDate, string name);
        IList<TLMDTO00017> SelectNameExactlyForEncashRemittanceBySettlementDate(DateTime startDate, DateTime endDate, string name);
    }
}
