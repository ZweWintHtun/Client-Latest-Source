//----------------------------------------------------------------------
// <copyright file="ITLMSVE00003.cs" company="ACE Data Systems">
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
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Ctr.Sve
{
    public interface ITLMSVE00003 : IBaseService
    {
        IList<PFMDTO00001> SelectByAccountNumber(string accountNo,DateTime todaydate);
        bool DebitInformationCheckingAndLink(TLMDTO00038 transferEntity);
        string SaveLocalTransfer(IList<TLMDTO00038> transferCollection);
        string SaveOnlineTransfer(IList<TLMDTO00038> transferCollection);
        bool CheckInterestAmountByAcctNo(TLMDTO00038 transferEntity);//Added by HWKO (14-Sep-2017) //For HP Int Prepayment Voucher Entry
        string SaveHPIntPrepaymentVoucher(IList<TLMDTO00038> transferCollection);//Added by HWKO (14-Sep-2017) //For HP Int Prepayment Voucher Entry
        ChargeOfAccountDTO GetCOAByAcode(string acode, string sourceBr);//Added by HWKO (14-Sep-2017) //For HP Int Prepayment Voucher Entry
        IList<PFMDTO00001> SelectByAccountNumber_ForAllowCrTrans(string accountNo, DateTime todaydate);
    }
}
