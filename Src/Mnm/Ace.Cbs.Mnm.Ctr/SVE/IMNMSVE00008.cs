//----------------------------------------------------------------------
// <copyright file="IMNMSVE00008.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KTRHMS</CreatedUser>
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
    /// Interface Class
    /// Cash Voucher
    /// </summary>
    public interface IMNMSVE00008 
    {
        ICXSVE00002 CodeGenerator { get; set; }
        IPFMDAO00054 TlfDAO { get; set; }
        ITLMDAO00004 ibltlfDAO { get; set; }
        ICXSVE00006 ReversalSVE { get; set; }

        IList<PFMDTO00054> SelectTlfInfoByEntryNoandDateTime(string eno, string dtranCode, string ctranCode, string sourcebr);
        string Save_CashVoucher(PFMDTO00054 entity);
    }
}