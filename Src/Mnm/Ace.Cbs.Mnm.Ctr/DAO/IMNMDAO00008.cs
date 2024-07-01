//--------------------------------------------------- Contract ------------------------------------------------//
//----------------------------------------------------------------------
// <copyright file="IMNMDAO00008.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Banking</CreatedUser>
// <CreatedDate>11/15/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Mnm.Dmd;
using System;

namespace Ace.Cbs.Mnm.Ctr.Dao
{
    /// <summary>
    /// MNMDAO00008 Interface
    /// </summary>
    public interface IMNMDAO00008 : IDataRepository<MNMORM00008>
    {
        IList<MNMDTO00008> SelectAllOI(string SourceBranchCode);
        bool UpdateOI(decimal month, string budget, string SourceBranchCode,int updatedUserId);
        IList<string> SelectCurrency();
        MNMDTO00008 SelectByAccountNo(string accountNo,string sourceBr);
        bool UpdateOI(decimal lastCalculateInt, DateTime intDate, string accountNo, string curMth, int updatedUserId);
        bool UpdateOIForInterestEdit(string loanNo, decimal lastCalculateInt, string month1, string month2, string month3, decimal interest1, decimal interest2, decimal interest3, int updatedUserId);

        MNMDTO00008 SelectByAccountNoAndLoanNo(string accountNo, string loanNo, string sourceBr);      //ASDA

        IList<MNMDTO00008> SelectByLoanNo(string loanNo,string sourceBr);
    }
}