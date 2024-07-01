//----------------------------------------------------------------------
// <copyright file="ITLMDAO00B40.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate> 2013-9-19 </CreatedDate>
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
    public interface ITLMDAO00B40 : IDataRepository<TLMVIW00A16>
    {
        IList<TLMDTO00017> SelectNRCForDrawingRemittanceByTransactionDate(DateTime startDate, DateTime endDate, string nrc);
        IList<TLMDTO00017> SelectNRCForDrawingRemittanceBySettlementDate(DateTime startDate, DateTime endDate, string nrc);
        IList<TLMDTO00017> SelectNRCExactlyForDrawingRemittanceByTransactionDate(DateTime startDate, DateTime endDate, string nrc);
        IList<TLMDTO00017> SelectNRCExactlyForDrawingRemittanceBySettlementDate(DateTime startDate, DateTime endDate, string nrc);

        IList<TLMDTO00017> SelectNameForDrawingRemittanceByTransactionDate(DateTime startDate, DateTime endDate, string nrc);
        IList<TLMDTO00017> SelectNameForDrawingRemittanceBySettlementDate(DateTime startDate, DateTime endDate, string nrc);
        IList<TLMDTO00017> SelectNameExactlyForDrawingRemittanceByTransactionDate(DateTime startDate, DateTime endDate, string nrc);
        IList<TLMDTO00017> SelectNameExactlyForDrawingRemittanceBySettlementDate(DateTime startDate, DateTime endDate, string nrc);
    }
}
