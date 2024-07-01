//----------------------------------------------------------------------
// <copyright file="ITLMSVE00016.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Su Su Wai</CreatedUser>
// <CreatedDate>09/06/2013</CreatedDate>
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
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Windows.Core.Service;
namespace Ace.Cbs.Tel.Ctr.Sve
{
    public interface ITLMSVE00016 : IBaseService
    {
        ICXSVE00002 CodeGenerator { get; set; }        
        ITLMDAO00016 PODAO { get; set; }
        IPFMDAO00054 TLFDAO { get; set; }
        ITLMDAO00015 CashDenoDAO { get; set; }
        ITLMDAO00009 DepoDenoDAO { get; set; }

        string Save(IList<TLMDTO00041> poList, string sourceBr);
        string GetBudYear(int service, DateTime reqDate, string sourceBr);//added by HMW to get active Budget from BLF (2019/08/04)
    }
}
