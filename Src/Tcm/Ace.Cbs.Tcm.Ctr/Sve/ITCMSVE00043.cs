//----------------------------------------------------------------------
// <copyright file="ITLMSVE00043.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-11-06</CreatedDate>
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

namespace Ace.Cbs.Tcm.Ctr.Sve
{
   public interface ITCMSVE00043:IBaseService
    {
       IList<PFMDTO00054> GetClearingPostingTLFList(string sourcebranchCode);
       bool ClearingPosting(IList<PFMDTO00054> TLFDTOList, int createduserId,DateTime createdDate);
    }
}
