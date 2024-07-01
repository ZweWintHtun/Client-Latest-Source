//----------------------------------------------------------------------
// <copyright file="MNMSVE00156.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo</CreatedUser>
// <CreatedDate>2015-02-20</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00156 : BaseService, IMNMSVE00156
    {
        #region Private Variable
        private const string type1="Monthly Drawing Remittance Transaction";
        private const string type2 = "Monthly Drawing Remittance Settlement";
        private const string type3="Monthly Encash Remittance Transaction";
        private const string type4="Monthly Encash Remittance Settlement";
        #endregion

        #region Properties
        ICXDAO00009 ViewDAO { get; set; }
        #endregion

        #region Public Methods
        public IList<TLMDTO00017> GetDrawingRemittanceLists(string typename, string sourceBr, string budgetYear)
         {
             try
             {
                 IList<TLMDTO00017> DrawingEncashRemittanceDataLists = new List<TLMDTO00017>();
                 switch (typename)
                 {
                     case type1: DrawingEncashRemittanceDataLists = this.ViewDAO.SelectDrawingRemittanceListByMonthlyClosingByReceiptDate(sourceBr, budgetYear);
                         break;
                     case type2: DrawingEncashRemittanceDataLists = this.ViewDAO.SelectDrawingRemittanceListByMonthlyClosingBySettlementDate(sourceBr, budgetYear);
                         break;
                 }
                 return DrawingEncashRemittanceDataLists;
             }
             catch (Exception ex)
             {

                 throw new Exception(ex.InnerException + ex.Message);
             }
         }

        public IList<TLMDTO00001> GetEncashRemittanceLists(string typename, string sourceBr, string budgetYear)
         {
             try
             {
                 IList<TLMDTO00001> EncashList = new List<TLMDTO00001>();
                 switch (typename)
                 {
                     case type3: EncashList = this.ViewDAO.SelectEncashRemittanceListByMonthlyClosingByIssueDate(sourceBr, budgetYear);
                         break;
                     case type4: EncashList = this.ViewDAO.SelectEncashRemittanceListByMonthlyClosingBySettlementDate(sourceBr, budgetYear);
                         break;
                 }
                 return EncashList;
             }
             catch (Exception ex)
             {
                 
                 throw new Exception (ex.Message+ex.InnerException);
             }
         }
        #endregion                
    }
}
