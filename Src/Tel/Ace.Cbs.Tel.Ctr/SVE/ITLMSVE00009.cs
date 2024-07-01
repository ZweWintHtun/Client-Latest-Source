//----------------------------------------------------------------------
// <copyright file="ITLMSVE00009.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Yu Thandar Aung</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Windows.Core.Service;



namespace Ace.Cbs.Tel.Ctr.Sve
{
    /// <summary>
    /// Fixed Deposit DepositEntry Service InterfAce.
    /// </summary>
    public interface ITLMSVE00009:IBaseService
    {
        TLMDTO00005 SaveFixedDeposit(TLMDTO00041 fixedDeposit);
        IList<PFMDTO00001> GetCustomerInfoandDepositReceiptNoByAccountNo(string accountNo);
    }
}
