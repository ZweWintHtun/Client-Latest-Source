//----------------------------------------------------------------------
// <copyright file="ITLMSVE00051.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-09-05</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Service;
using System;

namespace Ace.Cbs.Tel.Ctr.Sve
{
    public interface ITLMSVE00051 : IBaseService
    {
        //IList<PFMDTO00042> GetGenerateDataForBankStatementDTOReportList(DateTime startDate, DateTime endDate, string accountno,bool isAllCustomers,string accountType, string budgetMonth, string budgetYear,string workStation,int createdUserId,string sourceBr);
        PFMDTO00042 GetSumMonth(string budgetmonthcalculate, string budgetYear, string accountNo);
        IList<PFMDTO00042> GetGenerateDataForBankStatementDTOReportList(DateTime startDate, DateTime endDate, string accountno, bool isAllCustomers, string accountType, string budgetMonth, string budgetYear, int createdUserId, string sourceBr, bool withReversal, string workStation);
        //IList<PFMDTO00042> GetGenerateDataForBankStatementDTOReportList(DateTime startDate, DateTime endDate, string accountno, bool isAllCustomers, string accountType, string budgetMonth, string budgetYear, string workStation, int createdUserId, string sourceBr, bool withReversal);
    }
}
