//----------------------------------------------------------------------
// <copyright file="TCMSVE00037.cs" company="Ace Data Systems">
// Copyright (c) Ace Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>HM</CreatedUser>
// <CreatedDate>11/02/2014</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using AutoMapper;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Tcm.Sve
{
    /// <summary>
    /// Clearing Receipt Reversal Service 
    /// </summary>
   public class TCMSVE00037 : BaseService, ITCMSVE00037
   {
       #region DAO

       private ICXSVE00010 DataGenerateService { get; set; }
       private ICXDAO00009 ViewDAO { get; set; }

       #endregion

       #region Properties

       public string trancode { get; set; }
      
       #endregion

       #region Methods
          
       [Transaction(TransactionPropagation.Required)]
       public IList<PFMDTO00042> GetClearingReceiptReverseService(DateTime startDate, DateTime endDate,string userNo,int createdUserId,string sourceBr)
       {
           this.DataGenerateInSQL(startDate, endDate, userNo, createdUserId, sourceBr);  //insert into Report_Tlf
           IList<PFMDTO00042> ReportDTOList = this.ViewDAO.SelectClearingReceiptReversalListingReports(startDate, endDate, userNo);
           return ReportDTOList;
       }

       [Transaction(TransactionPropagation.Required)]
       private void DataGenerateInSQL(DateTime startDate, DateTime endDate,string workStation,int createdUserId,string sourceBr)
       {
           PFMDTO00042 DataGenerateDTO = new PFMDTO00042();
           CXDTO00006 reportparameters = new CXDTO00006();
           reportparameters.StartDate = startDate;
           reportparameters.EndDate = endDate;
           reportparameters.BDateType = "T";
           reportparameters.SpecialCondition = "Status='LCD' and (TranCode ='RCLRECE' or TranCode='RPORCL') and sourceBr = '"+sourceBr+"'";
           reportparameters.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
           reportparameters.UserNo = workStation;
           reportparameters.CreatedUserId = createdUserId;
           //reportparameters.UserNo = CurrentUserEntity.WorkStationId.ToString();
           //reportparameters.CreatedUserId = CurrentUserEntity.CurrentUserID;
           DataGenerateDTO = this.DataGenerateService.GetReportDataGenerateInSQL(reportparameters);
       }


       #endregion
   }
}
