//----------------------------------------------------------------------
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>HM</CreatedUser>
// <CreatedDate>12/01/2014</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Mnm.Ctr;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00092 : IBaseService
    {
        IList<MNMDTO00010> SelectTrialBalanceGroup(string Branchno, string Currency, int Month, int ishome);
        IList<MNMDTO00010> SelectTriGroupForBackDate(string currency, string branchCode, DateTime selectedDate);//Added by HWKO (31-Aug-2017)
    }
}
