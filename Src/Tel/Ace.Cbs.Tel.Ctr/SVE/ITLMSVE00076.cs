//----------------------------------------------------------------------
// <copyright file="ITLMSVE00076.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2014-07-21</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Service;
using Ace.Cbs.Cx.Com.Dto;

namespace Ace.Cbs.Tel.Ctr.Sve
{
  public interface ITLMSVE00076:IBaseService
    {
      IList<TLMDTO00017> GetDrawingCashDepositDenoLists(string registerNo, string branchcode);
      void Save(TLMDTO00015 cashdenoDTO, IList<string> registerNoList);
    }
}
