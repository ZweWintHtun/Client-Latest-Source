//----------------------------------------------------------------------
// <copyright file="IMNMSVE00011.cs" company="ACE Data Systems">
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
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Mnm.Ctr.Dao;
using System.Collections.Generic;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    /// <summary>
    /// Interface Class
    /// Deliver and Receipt Reverse Service
    /// </summary>
    public interface IMNMSVE00011
    {

        IPFMDAO00054 TlfDAO { get; set; }
        ICXDAO00006 CxDAO { get; set; }
        ITLMDAO00040 bcodeDAO { get; set; }
        IPFMDAO00028 CledgerDAO { get; set; }
        IPFMDAO00023 FLedgerDAO { get; set; }
        ICXSVE00002 CodeGenerator { get; set; }
        ICXSVE00006 ReversalTlf { get; set; }

        //IList<TLMDTO00040> GetBCode();
        PFMDTO00054 GetTlfInformation(string eno, string dtype, string ctype, string sourcebr,string status);
        string GetNameByAccount(string acctno);
        string[] Save_DeliverandReceipt(PFMDTO00054 entity);
        void Update(PFMDTO00054 entity);
        void Delete_DeliverEdit(PFMDTO00054 entity);
    }
}