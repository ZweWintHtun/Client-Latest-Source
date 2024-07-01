//--------------------------------------------------- Contract ------------------------------------------------//
//----------------------------------------------------------------------
// <copyright file="IMNMDAO00012.cs" company="ACE Data Systems">
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
    /// MNMDAO00012 Interface
    /// </summary>
    public interface IMNMDAO00012 : IDataRepository<MNMORM00012>
    {
        bool CheckExist(string lNO, string aCCTNO, decimal aMOUNT, DateTime dATE_TIME, string cRACCTNO, string uSERNO, string uID, bool isEdit);
        IList<MNMDTO00012> SelectAll();
        MNMDTO00012 SelectByLNO(string lNO);
        IList<MNMDTO00012> SelectLegalIntList(string[] typelist, string loanNo, string branchCode);
        IList<MNMDTO00012> SelectByLoanNo(string loanNo);
    }
}