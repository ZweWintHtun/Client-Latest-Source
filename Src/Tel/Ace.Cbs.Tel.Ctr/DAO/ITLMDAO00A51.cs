//----------------------------------------------------------------------
// <copyright file="ITLMDAO00A51.cs" company="ACE Data Systems">
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
using Ace.Cbs.Pfm.Dmd;
using System;


namespace Ace.Cbs.Tel.Ctr.Dao
{
    public interface ITLMDAO00A51:IDataRepository<TLMVIW000A9>
    {
        IList<PFMDTO00042> SelectWithdrawAmountAndDepositAmountBankStatement(string workstation, string accountno, DateTime firstdate, DateTime seconddate);
        IList<PFMDTO00042> SelectDatasFromBankStatement(string workstation, string accountno, DateTime startdate, DateTime enddate);
    }
}
