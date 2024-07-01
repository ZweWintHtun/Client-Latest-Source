//----------------------------------------------------------------------
// <copyright file="TCMSVE00029.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ye Mann Aung</CreatedUser>
// <CreatedDate>05/12/2013</CreatedDate>
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
    /// OverDraft Report Service
    /// </summary>
    public class TCMSVE00029 : BaseService, ITCMSVE00029
    {
        #region Data Properties

        public IPFMDAO00042 ReportTlfDAO { get; set; }
        public ICXSVE00010 DataGenerateService { get; set; }

        #endregion

        #region Helper Methods

        private PFMDTO00042 GetGenerateDataForAll(DateTime startDate, DateTime endDate, int currentUserId, string bdatetype,string workstation,string sourceBr)
        {
            CXDTO00006 reportparameters = new CXDTO00006();
            reportparameters.StartDate = startDate;
            reportparameters.EndDate = endDate;
            reportparameters.CreatedUserId = currentUserId;
            reportparameters.BDateType = bdatetype;
            reportparameters.UserNo = workstation;
            reportparameters.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
            reportparameters.SpecialCondition = "sourceBr = '" + sourceBr + "'";
            return this.DataGenerateService.GetReportDataGenerateInSQL(reportparameters);
        }

        #endregion

        #region Main Methods

        public IList<PFMDTO00042> GetOverDraftData(DateTime selectedDateTime, string currency, string workstation, bool isReserval, bool isTransaction,int createduserid,string sourceBr)
        {
            PFMDTO00042 spdto = this.GetGenerateDataForAll(selectedDateTime, selectedDateTime, createduserid, (isTransaction) ? "T" : "S", workstation, sourceBr);
            if (spdto.Row_Count < 1)
                return new List<PFMDTO00042>();
            IList <PFMDTO00042> dtolist = this.ReportTlfDAO.SelectOverDraftReportData(selectedDateTime, currency, workstation, isReserval, isTransaction);
            IList<PFMDTO00042> returnlist = new List<PFMDTO00042>();
            foreach (PFMDTO00042 item in dtolist.Where(x => (x.DebitTotal + x.CreditTotal != 0)))
            {
                returnlist.Add(item);
            }
            return returnlist;
        }

        #endregion
    }
}
