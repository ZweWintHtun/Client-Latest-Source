//----------------------------------------------------------------------
// <copyright file="ITLMDAO00051.cs" company="ACE Data Systems">
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


namespace Ace.Cbs.Tel.Ctr.Dao
{
    public interface ITLMDAO00051 : IDataRepository<TLMVIW00009>
    {
        Nullable<decimal> SelectSumM1Data(string accountNo, string budgetYear);
        Nullable<decimal> SelectSumM2Data(string accountNo, string budgetYear);
        Nullable<decimal> SelectSumM3Data(string accountNo, string budgetYear);
        Nullable<decimal> SelectSumM4Data(string accountNo, string budgetYear);
        Nullable<decimal> SelectSumM5Data(string accountNo, string budgetYear);
        Nullable<decimal> SelectSumM6Data(string accountNo, string budgetYear);
        Nullable<decimal> SelectSumM7Data(string accountNo, string budgetYear);
        Nullable<decimal> SelectSumM8Data(string accountNo, string budgetYear);
        Nullable<decimal> SelectSumM9Data(string accountNo, string budgetYear);
        Nullable<decimal> SelectSumM10Data(string accountNo, string budgetYear);
        Nullable<decimal> SelectSumM11Data(string accountNo, string budgetYear);
        Nullable<decimal> SelectSumM12Data(string accountNo, string budgetYear);

    }
}
