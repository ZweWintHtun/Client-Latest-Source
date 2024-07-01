//----------------------------------------------------------------------
// <copyright file="ITLMSVE00041.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-08-05</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;

namespace Ace.Cbs.Tel.Ctr.Sve
{
   public interface ITLMSVE00041:IBaseService
    {
       IList<TLMDTO00015> GetCenterTableDepositDTOList(string status, string receiptno, string sourcebr);
       List<TLMDTO00015> SaveDTO(IList<TLMDTO00015> cashdenolist, int userno);
   
       
       
    }
}
