//----------------------------------------------------------------------
// <copyright file="TLMSVE00071.cs" company="ACE Data Systems">
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
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Windows.CXServer.Utt;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Admin.Contracts.Dao;
using Ace.Cbs.Tcm.Ctr.Dao;

namespace Ace.Cbs.Tel.Sve
{
  public class TLMSVE00071 :BaseService,ITLMSVE00071
  {
      #region DAO
      public ITLMDAO00012 DenoDAO { get; set; }
      public ICounterInfoDAO CounterInfoDAO { get; set; }
      public ITCMDAO00009 CashClosingDAO { get; set; }
public ICXDAO00009 CodeCheckerDAO { get; set; }
      #endregion
public IList<TLMDTO00009> SelectDenoForMultiTransaction(string currency, string sourcebr, DateTime cashdate,bool isMulti,string counterno)
      {
          if (!isMulti)
          {
              return this.CodeCheckerDAO.SelectDataForMultiDeno(currency, sourcebr, cashdate);
          }
          else
          {
              return this.CodeCheckerDAO.SelectDataForMultiDenoByCounterNo(currency, sourcebr, cashdate, counterno);
          }

      }

      public IList<object> CashControlReport(string currency, string whereString)
      {
          string orderString = " ORDER BY COUNTERNO, UserName, TLF_ENO, CASHDATE";

          return CXServiceWrapper.Instance.Invoke<ICXSVE00010, IList<object>>(x => x.CashDenominationListing(currency, whereString, orderString));

      }

      public IList<object> CashDenominationListing(string currency, string whereString)
      {
          string orderString = " ORDER BY COUNTERNO, UserName, TLF_ENO, CASHDATE";

          return CXServiceWrapper.Instance.Invoke<ICXSVE00010, IList<object>>(x => x.CashDenominationListing(currency, whereString, orderString));

      }

      public IList<object> CashControlRefundList(string currency, string whereString)
      {
          string orderString = " ORDER BY COUNTERNO, UserName, TLF_ENO, CASHDATE";

          return CXServiceWrapper.Instance.Invoke<ICXSVE00010, IList<object>>(x => x.CashControlRefundList(currency, whereString, orderString));
      }

      public IList<object> CashControlTotalVaultList(string currency, string wherestring)
      {
          string orderString = " ORDER BY COUNTERNO, USERNO, TLF_ENO, CASHDATE";
          return CXServiceWrapper.Instance.Invoke<ICXSVE00010, IList<object>>(x => x.CashControlTotalVaultList(currency, wherestring, orderString));
      }

      public IList<string> SelectDenoDescriptionByCurrency(string currency)
      {
          return this.DenoDAO.SelectDescriptionByCurrrency(currency);
      }

      public IList<CounterInfoDTO> GetCounterInfo(string sourceBr)
      {
          return this.CounterInfoDAO.SelectBySourceBranchCode(sourceBr);
      }

      public string GetMaxDate(string date)
      {
          System.Nullable<DateTime> datetime = this.CashClosingDAO.SelectMaximunDateForCashControl(date);
          if(datetime.HasValue)
          {
          return datetime.Value.ToString("yyyy/MM/dd");
          }
          else{return string.Empty;}
      }

      //public IList<Windows.Admin.DataModel.CounterInfoDTO> GetCounterInfo(string sourceBr)
      //{
      //    throw new NotImplementedException();
      //}
  }

}
