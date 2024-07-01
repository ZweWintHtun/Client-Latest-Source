//----------------------------------------------------------------------
// <copyright file="TLMSVE00038.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-09-19</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;

namespace Ace.Cbs.Tel.Sve
{
  public class TLMSVE00038:BaseService,ITLMSVE00038
    {
      public ICXDAO00009 ViewDAO { get; set; }

      public IList<TLMDTO00017> GetDrawingEncashRemittanceDataAllandByBranchLists(string typename,DateTime startDate,DateTime endDate,string bankNo,string sourceBr)
      {
          IList<TLMDTO00017> DrawingEncashRemittanceDataLists = new List<TLMDTO00017>();
          switch (typename)
          {
              case "Drawing All By Transaction Date": DrawingEncashRemittanceDataLists = this.ViewDAO.SelectDataForDrawingRemittanceAllByTransactionDate(startDate, endDate,sourceBr);
                                         break;

              case "Drawing All By Settlement Date": DrawingEncashRemittanceDataLists = this.ViewDAO.SelectDataForDrawingRemittanceAllBySettlementDate(startDate, endDate,sourceBr);
                                         break;

              case "Drawing By Branch By Transaction Date": DrawingEncashRemittanceDataLists = this.ViewDAO.SelectDataForDrawingRemittanceByBranchByTransactionDate(startDate, endDate, bankNo,sourceBr);
                                         break;

              case "Drawing By Branch By Settlement Date": DrawingEncashRemittanceDataLists = this.ViewDAO.SelectDataForDrawingRemittanceByBranchBySettlementDate(startDate, endDate, bankNo,sourceBr);
                                         break;

              case "Encash All By Transaction Date": DrawingEncashRemittanceDataLists = this.ViewDAO.SelectDataForEncashRemittanceAllByTransactionDate(startDate, endDate,sourceBr);
                                         break;

              case "Encash All By Settlement Date": DrawingEncashRemittanceDataLists = this.ViewDAO.SelectDataForEncashRemittanceAllBySettlementDate(startDate, endDate,sourceBr);
                                         break;

              case "Encash By Branch By Transaction Date": DrawingEncashRemittanceDataLists = this.ViewDAO.SelectDataForEncashRemittanceByBranchByTransactionDate(startDate, endDate, bankNo,sourceBr );
                                         break;

              case "Encash By Branch By Settlement Date": DrawingEncashRemittanceDataLists = this.ViewDAO.SelectDataForEncashRemittanceByBranchBySettlementDate(startDate, endDate, bankNo,sourceBr);
                                         break;

          }
          return DrawingEncashRemittanceDataLists;
      }

    }
}
