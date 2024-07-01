//----------------------------------------------------------------------
// <copyright file="ITLMSVE00006.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Su Su Wai</CreatedUser>
// <CreatedDate>01/08/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Cx.Com.Ctr;

namespace Ace.Cbs.Tel.Ctr.Sve
{
    /// <summary>
    /// Entry -> Clearing -> Delivered Entry & Entry -> Clearing -> Receipt Entry Service Interface
    /// </summary>
    public interface ITLMSVE00006
    {
        ICXSVE00002 CodeGenerator { get; set; }
        ICXSVE00006 CodeChecker { get; set; }
        IPFMDAO00054 TLFDAO { get; set; }
        IPFMDAO00028 CledgerDAO { get; set; }
        IPFMDAO00056 Sys001DAO { get; set; }
        IPFMDAO00020 UCheckDAO { get; set; }

        string Save(TLMDTO00053 entity);
        PFMDTO00001 GetCustomerByAccountNumber(string accountNo, string transactionStatus);
        CXDTO00009 DebitInformationChecking(TLMDTO00053 receiptEntity);
    }
}
