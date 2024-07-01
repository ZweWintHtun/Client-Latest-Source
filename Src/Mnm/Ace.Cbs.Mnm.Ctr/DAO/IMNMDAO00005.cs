//--------------------------------------------------- Contract ------------------------------------------------//
//----------------------------------------------------------------------
// <copyright file="IMNMDAO00005.cs" company="ACE Data Systems">
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

namespace Ace.Cbs.Mnm.Ctr.Dao
{
    /// <summary>
    /// MNMDAO00005 Interface
    /// </summary>
    public interface IMNMDAO00005 : IDataRepository<MNMORM00005>
    {
        string GetCoaSetupAccountNo(string accountName, string branchCode, string currencyCode);
        IList<MNMDTO00005> SelectAll(string SourceBranchCode);
        bool UpdateTOD_SCHARGED(decimal tod_month, string budget,string SourceBranchCode, int updatedUserId);
        IList<MNMDTO00005> SelectByAccountNo(string accountNo);
        bool UpdateTOD_SChargeForInterestEdit(string accountNo, decimal lastCalculateInt, string month1, string month2, string month3, decimal interest1, decimal interest2, decimal interest3, int updatedUserId);
        IList<MNMDTO00005> SelectByLoanNo(string loanNo, string accountNo, string sourceBr);
        string SaveUpdateHistoryOfCCOA(string dcode);//Added by HWKO (28-Aug-2017) //Updated by HWKO (11-Oct-2017)
    
    }

}