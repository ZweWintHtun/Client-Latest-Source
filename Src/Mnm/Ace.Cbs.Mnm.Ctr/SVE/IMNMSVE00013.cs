//----------------------------------------------------------------------
// <copyright file="IMNMSVE00013.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>11/04/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using System.Collections.Generic;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    /// <summary>
    /// Saving Interest Withdraw Reversal Service Interface
    /// </summary>
    public interface IMNMSVE00013
    {
        IList<PFMDTO00054> SelectSavingInterestWithdrawReversalByEntryNo(string entryno, string sourcebr);
        string Save(IList<PFMDTO00054> tlfdto,bool isCash);
        IList<PFMDTO00043> GetPrint(string accountno);
    }
}