//----------------------------------------------------------------------
// <copyright file="ITLMDAO00058.cs" company="ACE Data Systems">
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
    public interface ITLMDAO00058: IDataRepository<TLMVIW00A16>
    {
        IList<TLMDTO00017> SelectDataForDrawingRemittanceAllByTransactionDate(DateTime startDate, DateTime endDate);
        IList<TLMDTO00017> SelectDataForDrawingRemittanceAllBySettlementDate(DateTime startDate, DateTime endDate);
        IList<TLMDTO00017> SelectDataForDrawingRemittanceByBranchByTransactionDate(DateTime startDate, DateTime endDate, string bankno);
        IList<TLMDTO00017> SelectDataForDrawingRemittanceByBranchBySettlementDate(DateTime startDate, DateTime endDate, string bankno);
        IList<TLMDTO00017> SelectAmountForDrawingRemittanceByTransactionDate(DateTime startDate, DateTime endDate, decimal startamount, decimal endamount);
        IList<TLMDTO00017> SelectAmountForDrawingRemittanceBySettlementDate(DateTime startDate, DateTime endDate, decimal startamount, decimal endamount);
    }
}
