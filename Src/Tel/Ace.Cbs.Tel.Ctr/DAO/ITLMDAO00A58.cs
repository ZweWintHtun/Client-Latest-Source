//----------------------------------------------------------------------
// <copyright file="ITLMDAO00A58.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate> 2013-09-19 </CreatedDate>
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
   public interface ITLMDAO00A58:IDataRepository<TLMVIW00C16>
    {
       IList<TLMDTO00017> SelectDataForEncashRemittanceAllByTransactionDate(DateTime startDate, DateTime endDate);
       IList<TLMDTO00017> SelectDataForEncashRemittanceAllBySettlementDate(DateTime startDate, DateTime endDate);
       IList<TLMDTO00017> SelectDataForEncashRemittanceByBranchByTransactionDate(DateTime startDate, DateTime endDate, string bankno);
       IList<TLMDTO00017> SelectDataForEncashRemittanceByBranchBySettlementDate(DateTime startDate, DateTime endDate, string bankno);
       IList<TLMDTO00017> SelectAmountForEncashRemittanceByTransactionDate(DateTime startDate, DateTime endDate, decimal startamount, decimal endamount);
       IList<TLMDTO00017> SelectAmountForEncashRemittanceBySettlementDate(DateTime startDate, DateTime endDate, decimal startamount, decimal endamount);
    }
}
