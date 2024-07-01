//----------------------------------------------------------------------
// <copyright file="ITLMSVE00035.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-08-01</CreatedDate>
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
    public interface ITLMSVE00035 : IBaseService
    {
        PFMDTO00036 GetSelectTopCS99(DateTime datetime, string currency,string sourcebr);
       // PFMDTO00042 GetReturnBalanceAndRCTLData(PFMDTO00042 BankCashScrollDTO);
        //IList<PFMDTO00042> GetReportDataForBankCashScroll(PFMDTO00042 BankCashScrollDTO);
        IList<PFMDTO00042> GetReturnBalanceAndRCTLData(PFMDTO00042 BankCashScrollDTO);
        PFMDTO00036 GetSelectTopCS99WithoutCurrency(DateTime datetime, string sourcebr);     
    }
}
