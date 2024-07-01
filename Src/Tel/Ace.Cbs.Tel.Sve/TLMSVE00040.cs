//----------------------------------------------------------------------
// <copyright file="TLMSVE00040.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-09-24</CreatedDate>
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
   public class TLMSVE00040:BaseService,ITLMSVE00040
    {
       public ICXDAO00009 ViewDAO { get; set; }

       public IList<TLMDTO00017> GetNRCDrawingEncashRemittanceLists(string typename, DateTime startDate, DateTime endDate,string nrcname)
       {
           IList<TLMDTO00017> DrawingEncashRemittanceDataLists = new List<TLMDTO00017>();

           switch (typename)
           {
               case "Drawing Remittance NRC By Transaction Date": DrawingEncashRemittanceDataLists = this.ViewDAO.SelectNRCForDrawingRemittanceByTransactionDate(startDate, endDate, nrcname);
                   break;

               case "Drawing Remittance NRC By Settlement Date": DrawingEncashRemittanceDataLists = this.ViewDAO.SelectNRCForDrawingRemittanceBySettlementDate(startDate, endDate, nrcname);
                   break;

               case "Drawing Remittance NRC Exactly By Transaction Date": DrawingEncashRemittanceDataLists = this.ViewDAO.SelectNRCExactlyForDrawingRemittanceByTransactionDate(startDate, endDate, nrcname);
                   break;

               case "Drawing Remittance NRC Exactly By Settlement Date": DrawingEncashRemittanceDataLists = this.ViewDAO.SelectNRCExactlyForDrawingRemittanceBySettlementDate(startDate, endDate, nrcname);
                   break;

               case "Drawing Remittance Name By Transaction Date": DrawingEncashRemittanceDataLists = this.ViewDAO.SelectNameForDrawingRemittanceByTransactionDate(startDate, endDate, nrcname);
                   break;

               case "Drawing Remittance Name By Settlement Date": DrawingEncashRemittanceDataLists = this.ViewDAO.SelectNameForDrawingRemittanceBySettlementDate(startDate, endDate, nrcname);
                   break;

               case "Drawing Remittance Name Exactly By Transaction Date": DrawingEncashRemittanceDataLists = this.ViewDAO.SelectNameExactlyForDrawingRemittanceByTransactionDate(startDate, endDate, nrcname);
                   break;

               case "Drawing Remittance Name Exactly By Settlement Date": DrawingEncashRemittanceDataLists = this.ViewDAO.SelectNameExactlyForDrawingRemittanceBySettlementDate(startDate, endDate, nrcname);
                   break;

               case "Encash Remittance NRC By Transaction Date": DrawingEncashRemittanceDataLists = this.ViewDAO.SelectNRCForEncashRemittanceByTransactionDate(startDate, endDate, nrcname); ;
                   break;

               case "Encash Remittance NRC By Settlement Date": DrawingEncashRemittanceDataLists = this.ViewDAO.SelectNRCForEncashRemittanceBySettlementDate(startDate, endDate, nrcname);
                   break;

               case "Encash Remittance NRC Exactly By Transaction Date": DrawingEncashRemittanceDataLists = this.ViewDAO.SelectNRCExactlyForEncashRemittanceByTransactionDate(startDate, endDate, nrcname);
                   break;

               case "Encash Remittance NRC Exactly By Settlement Date": DrawingEncashRemittanceDataLists = this.ViewDAO.SelectNRCExactlyForEncashRemittanceBySettlementDate(startDate, endDate, nrcname);
                   break;

               case "Encash Remittance Name By Transaction Date": DrawingEncashRemittanceDataLists = this.ViewDAO.SelectNameForEncashRemittanceByTransactionDate(startDate, endDate, nrcname);
                   break;

               case "Encash Remittance Name By Settlement Date": DrawingEncashRemittanceDataLists = this.ViewDAO.SelectNameForEncashRemittanceBySettlementDate(startDate, endDate, nrcname);
                   break;

               case "Encash Remittance Name Exactly By Transaction Date": DrawingEncashRemittanceDataLists = this.ViewDAO.SelectNameExactlyForEncashRemittanceByTransactionDate(startDate, endDate, nrcname);
                   break;

               case "Encash Remittance Name Exactly By Settlement Date": DrawingEncashRemittanceDataLists = this.ViewDAO.SelectNameExactlyForEncashRemittanceBySettlementDate(startDate, endDate, nrcname);
                   break;


           }
           return DrawingEncashRemittanceDataLists;

       }
    }
}
