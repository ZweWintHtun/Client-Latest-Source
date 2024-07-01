//----------------------------------------------------------------------
// <copyright file="ITLMSVE00020.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>7.6.2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Service;
using Ace.Cbs.Cx.Com.Dto;

namespace Ace.Cbs.Tel.Ctr.Sve
{
  public interface ITLMSVE00020
    {
      IList<TLMDTO00001> GetEncashRemittanceData(string sourceBr);
      IList<TLMDTO00001> GetEncashRemittanceDataCashType(string sourceBr);
      string SaveRemittanceEncashProcess(TLMDTO00039 rawEncashData, string parameter, CXDTO00001 dtostring);
      TLMDTO00001 GetRegisterNo(string po);
    }
}
