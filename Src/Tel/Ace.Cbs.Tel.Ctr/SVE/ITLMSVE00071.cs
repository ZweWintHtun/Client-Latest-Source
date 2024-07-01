//----------------------------------------------------------------------
// <copyright file="ITLMSVE00071.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San </CreatedUser>
// <CreatedDate>2013-06-18</CreatedDate>
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
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Ctr.Sve
{
  public  interface ITLMSVE00071 :IBaseService
    {
IList<TLMDTO00009> SelectDenoForMultiTransaction(string currency, string sourcebr, DateTime cashdate, bool isMulti, string counterno);
      IList<object> CashControlReport(string currency, string whereString);
      IList<string> SelectDenoDescriptionByCurrency(string currency);
      IList<CounterInfoDTO> GetCounterInfo(string sourceBr);
      IList<object> CashControlRefundList(string currency, string whereString);
      string GetMaxDate(string date);
      IList<object> CashControlTotalVaultList(string currency, string wherestring);
    }
}
