//----------------------------------------------------------------------
// <copyright file="ITCMSVE00002.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
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

namespace Ace.Cbs.Tcm.Ctr.Sve
{
    /// <summary>
    /// PO Refund By Transfer Service Controller
    /// </summary>
    public interface ITCMSVE00002 : IBaseService
    {
        TLMDTO00016 CheckPOAndBudget(string pono, string budgetyear,string sourceBr);
        IList<PFMDTO00001> CheckCusomer(string accountno, string sourceBr);
        string Save(TLMDTO00016 po);
        IList<PFMDTO00043> GetPrint(string accountno);
        bool UpdateAndDeleteByAccountNo(string accountNo, IList<PFMDTO00043> prnFileList, int ledgerPrintLineNo, int updatedUserId);
        PFMDTO00028 GetAccountBalance(string account);

        string GetBudYear(int service, DateTime reqDate, string sourceBr);//added by ZMS to get active Budget from BLF (2018/09/21)
    }
}
