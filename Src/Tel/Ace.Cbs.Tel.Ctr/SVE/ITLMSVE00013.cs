//----------------------------------------------------------------------
// <copyright file="ITLMSVE00013.cs" company="ACE Data Systems">
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

namespace Ace.Cbs.Tel.Ctr.Sve
{
  public  interface ITLMSVE00013 : IBaseService
    {
      IList<PFMDTO00001> GetCustomersByAccountNumber(string accountNo);
      IList<PFMDTO00001> GetCustomerInfoAndWithdrawalReceiptNoByAccountNumber(string accountNo);
      PFMDTO00032 CheckReceiptNoNotDepositedOrAlreadyWithdrawn(string accountNo,string receiptNo,string branch);// add by hmw
      string SaveFixedDepositWithdraw(IList<TLMDTO00041> fixedDepositEntityList);
    }
}
