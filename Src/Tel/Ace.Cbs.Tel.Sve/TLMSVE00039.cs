//----------------------------------------------------------------------
// <copyright file="TLMSVE00039.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-09-23</CreatedDate>
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
   public class TLMSVE00039:BaseService,ITLMSVE00039
    {
       public ICXDAO00009 ViewDAO { get; set; }

        public IList<TLMDTO00017> GetAmountDrawingEncashRemittanceBranchLists(string typename, DateTime startDate, DateTime endDate,decimal startamount,decimal endamount,string sourceBr)
        {
            IList<TLMDTO00017> DrawingEncashRemittanceDataLists = new List<TLMDTO00017>();

            switch(typename)
            {
                //case "Drawing Remittance Listing By Transaction Date": DrawingEncashRemittanceDataLists = this.ViewDAO.SelectAmountForDrawingRemittanceByTransactionDate(startDate, endDate, startamount, endamount );
                case "Drawing Remittance Listing By Transaction Date": DrawingEncashRemittanceDataLists = this.ViewDAO.SelectAmountForDrawingRemittanceByTransactionDate(startDate, endDate, startamount, endamount,sourceBr); //edited by ASDA (bug-185)
                      break;

                //case "Drawing Remittance Listing By Settlement Date": DrawingEncashRemittanceDataLists = this.ViewDAO.SelectAmountForDrawingRemittanceBySettlementDate(startDate, endDate, startamount, endamount);
                case "Drawing Remittance Listing By Settlement Date": DrawingEncashRemittanceDataLists = this.ViewDAO.SelectAmountForDrawingRemittanceBySettlementDate(startDate, endDate, startamount, endamount,sourceBr); //edited by ASDA (bug_185)
                      break;

                case "Encash Remittance Listing By Transaction Date": DrawingEncashRemittanceDataLists = this.ViewDAO.SelectAmountForEncashRemittanceByTransactionDate(startDate, endDate, startamount, endamount, sourceBr);
                      break;

                case "Encash Remittance Listing By Settlement Date": DrawingEncashRemittanceDataLists = this.ViewDAO.SelectAmountForEncashRemittanceBySettlementDate(startDate, endDate, startamount, endamount, sourceBr);
                      break;

            }
            return DrawingEncashRemittanceDataLists;           

        }
    }
}
