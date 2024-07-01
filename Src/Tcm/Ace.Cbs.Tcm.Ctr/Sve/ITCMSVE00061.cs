//----------------------------------------------------------------------
// <copyright file="ITLMSVE00061.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-12-11</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Service;


namespace Ace.Cbs.Tcm.Ctr.Sve
{
  public interface ITCMSVE00061:IBaseService
    {
      IList<TLMDTO00001> SelectPOPrintingList(IList<TLMDTO00001> poLists, int currentUserId);
    }
}
