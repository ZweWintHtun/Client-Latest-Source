//--------------------------------------------------- Contract ------------------------------------------------//
//----------------------------------------------------------------------
// <copyright file="IMNMDAO00011.cs" company="ACE Data Systems">
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
    /// MNMDAO00011 Interface
    /// </summary>
    public interface IMNMDAO00011 : IDataRepository<MNMORM00011>
    {
        IList<MNMDTO00011> SelectAll(string SourceBranchCode);
        bool UpdateCommit(decimal month, string budget, string SourceBranchCode, int updatedUserId);
        IList<MNMDTO00011> SelectByAccountNo(string accountNo);
        bool UpdateCommitmentFeesForInterestEdit(string loanNo, decimal lastCalculateInt, string month1, string month2, string month3, decimal interest1, decimal interest2, decimal interest3, int updatedUserId);
        IList<MNMDTO00011> SelectByLoansNo(string loanNo, string sourceBr);
    }
}