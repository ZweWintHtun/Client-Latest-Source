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
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    /// <summary>
    /// Interface Class
    /// Cash Voucher
    /// </summary>
    public interface IMNMSVE00019
    {

        ITLMDAO00001 ReDAO { get; set; }

       // string Save(TLMDTO00043 poIssueEncashmentDTO);
        IList<PFMDTO00054> Save(TLMDTO00043 poIssueEncashmentDTO);
        IList<TLMDTO00001> SelectReInformationByRegisterNo(string registerno, string sourcebr);
     
    }
}