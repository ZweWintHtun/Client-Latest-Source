//----------------------------------------------------------------------
// <copyright file="ITLMSVE00014.cs" company="ACE Data Systems">
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
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Dto;

namespace Ace.Cbs.Tel.Ctr.Sve
{
    public interface ITLMSVE00014 : IBaseService
    {

        IList<PFMDTO00001> GetAccountInfoByAccountNo(string accountNo, bool vipCustomer, string branchCode, DateTime todaydate);
        IList<PFMDTO00054> SaveWithdrawLocal(IList<TLMDTO00047> withdrawList);
        IList<PFMDTO00054> SaveWithdrawOnline(IList<TLMDTO00047> withdrawList, string sourceBr);
       // TLMDTO00047 CommonDataToSave(IList<TLMDTO00047> WithdrawList);
        CXDTO00009 AmountChecking(TLMDTO00047 withdrawEntity);
        bool DebitInformationCheckingAndLink(TLMDTO00047 withdrawalEntity);
        bool CheckingChequeNo(string accountNo, string chequeNo, string branch);    //Added by ASDA 
        bool UpdateCleadgerPrintLineNoandDeletePrnFile(string accountNo, int updatedUserId,int printlineNo);
    }
}
