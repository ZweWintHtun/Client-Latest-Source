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
    public interface IMNMSVE00091 : IBaseService
    {       
        IList<MNMDTO00010> SelectTrialBalanceDetail(string Branchno,string BranchnoforBudgetYear, string Currency, int Month,bool ishome);
        IList<MNMDTO00010> SelectTriDetailForBackDate(string currency, string branchCode, DateTime selectedDate);//Added by HWKO (03-Sep-2017)
    }
}
