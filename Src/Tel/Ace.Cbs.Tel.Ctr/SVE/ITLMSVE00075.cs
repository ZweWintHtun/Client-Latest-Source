//----------------------------------------------------------------------
// <copyright file="ITLMSVE00075.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2014-07-14</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Cbs.Cx.Com.Dto;

namespace Ace.Cbs.Tel.Ctr.Sve
{
  public interface ITLMSVE00075:IBaseService
    {
      PFMDTO00054 isValidEntryNo(string entryNo, string branchCode);
      void SaveorUpdate(PFMDTO00054 cashDeNoDTO, CXDTO00001 denoString);
    }
}
