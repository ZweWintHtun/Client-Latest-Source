//----------------------------------------------------------------------
// <copyright file="ITLMSVE00010.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>AK</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Tel.Ctr.Sve
{
    public interface ITLMSVE00010 : IBaseService
    {
        IList<PFMDTO00001> SelectByAccountNumber(string accountNo);
        IList<PFMDTO00054> SaveDepositLocal(IList<TLMDTO00038> DepositCollection, TLMDTO00038 depositInfo);
        IList<PFMDTO00054> SaveDepositOnline(IList<TLMDTO00038> DepositCollection, TLMDTO00038 depositInfo, string sourceBr);
        bool UpdateCleadgerPrintLineNoandDeletePrnFile(string accountNo, int updatedUserId,int lineNo);
    }
}
