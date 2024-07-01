//----------------------------------------------------------------------
// <copyright file="TCMSVE00036.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2014-02-06</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Service;
using Spring.Transaction;
using Ace.Windows.CXServer.Utt;
using Spring.Transaction.Interceptor;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Cx.Com.Dmd;
using System.Linq;

namespace Ace.Cbs.Tcm.Sve
{
    /// <summary>
    /// Clearing Delivered Reversal Service
    /// </summary>
   public class TCMSVE00036:BaseService,ITCMSVE00036
   {
       #region "Properties"
       public ICXSVE00010 DataGenerateService { get; set; }
       public ICXDAO00009 ViewDAO { get; set; }
       #endregion

       #region "Methods"
       public IList<PFMDTO00042> GetClearingDeliveredReverseService(DateTime startDate, DateTime endDate, string userNo, int createdUserId,string sourceBranch)
        {
           this.DataGenerateInSQL(startDate, endDate, userNo, createdUserId,sourceBranch);
           //IList<PFMDTO00042> ReportDTOList = this.ViewDAO.SelectClearingDeliveredReversalListingReports(startDate, endDate, userNo,CurrentUserEntity.BranchCode);
           IList<PFMDTO00042> ReportDTOList = this.ViewDAO.SelectClearingDeliveredReversalListingReports(startDate, endDate, userNo, sourceBranch);
           return ReportDTOList;           
        }

       private void DataGenerateInSQL(DateTime startDate, DateTime endDate, string userNo, int createduserId,string sourceBr)
       {
           CXDTO00006 ReportParameters = new CXDTO00006();
           ReportParameters.BDateType = "T";
           ReportParameters.TransactionCode = "RCLDELI";
           ReportParameters.SpecialCondition = "status = 'LDR' and sourceBr = '" + sourceBr + "'";
           ReportParameters.StartDate = startDate;
           ReportParameters.EndDate = endDate;
           ReportParameters.UserNo = userNo;
           ReportParameters.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
           ReportParameters.CreatedUserId = createduserId;
           PFMDTO00042 ReportTLFDTO = this.DataGenerateService.GetReportDataGenerateInSQL(ReportParameters);
       }
       #endregion
   }
}
