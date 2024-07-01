//----------------------------------------------------------------------
// <copyright file="TCMSVE00034.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>♠ Ye Mann Aung ♠</CreatedUser>
// <CreatedDate>12/12/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Ser.Sve;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Core.Utt;
using Ace.Windows.Admin.DataModel;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Tcm.Sve
{
    /// <summary>
    /// Clearing Paid Cheque Report Service
    /// </summary>
    public class TCMSVE00034 : BaseService, ITCMSVE00034
    {
        #region DAOProperties
        public IPFMDAO00042 ReportTlfDAO { get; set; }
        public ICXSVE00010 DataGenerateService { get; set; }
        #endregion

        #region Print Service Method

        public IList<PFMDTO00042> GetPrintData(DateTime startdate, DateTime enddate , int currentUserId,string workstation , string transactionStatus,string sourceBr)
        {
            PFMDTO00042 spdto = this.GetGenerateDataForAll(startdate, enddate, currentUserId, "T", workstation,(transactionStatus.Equals("Receipt")?string.Empty:transactionStatus),sourceBr);
            if (spdto.Row_Count.Equals(0))
                return new List<PFMDTO00042>();

            IList<PFMDTO00042> printdata = new List<PFMDTO00042>();
            switch (transactionStatus)
            {
                case "Receipt":
                    printdata = this.ReportTlfDAO.GetClearingPaidChequeReport(startdate, enddate, workstation);
                    foreach (PFMDTO00042 item in printdata)
                    {
                        item.StringDateTime = item.DATE_TIME.Value.ToString("yyyy/MM/dd");
                    }
                    break;

                case "POReceipt":
                    printdata = this.ReportTlfDAO.ChequePOReceipt(startdate, enddate, workstation);
                    foreach (PFMDTO00042 item in printdata)
                    {
                        item.ADateString = item.ADate.Value.ToString("yyyy/MM/dd");
                        item.IDateString = item.IDate.Value.ToString("yyyy/MM/dd");
                    }
                    break;
            }
            return printdata;
        }
        #endregion

        #region Helper Methods

        private PFMDTO00042 GetGenerateDataForAll(DateTime startDate, DateTime endDate, int currentUserId, string bdatetype, string workstation, string status, string sourceBr)
        {
            CXDTO00006 reportparameters = new CXDTO00006();
            reportparameters.StartDate = startDate;
            reportparameters.EndDate = endDate;
            reportparameters.TransactionCode = String.IsNullOrEmpty(status) ? status : "PORCL";
            reportparameters.CreatedUserId = currentUserId;
            reportparameters.BDateType = bdatetype;
            reportparameters.UserNo = workstation;
            reportparameters.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
            reportparameters.SpecialCondition = "sourceBr = '" + sourceBr + "'";
            return this.DataGenerateService.GetReportDataGenerateInSQL(reportparameters);
        }

        #endregion
    }
}
