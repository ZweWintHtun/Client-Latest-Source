//----------------------------------------------------------------------
// <copyright file="TCMSVE00027.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ye Mann Aung</CreatedUser>
// <CreatedDate>24/11/2013</CreatedDate>
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
    /// Daily Closing Clearing Report Service
    /// </summary>
    public class TCMSVE00027:BaseService,ITCMSVE00027
    {
        #region Data Properties

        public IPFMDAO00042 ReportTlfDAO { get; set; }
        public ICXSVE00010 DataGenerateService { get; set; }
        public ICXDAO00009 ViewDAO { get; set; }

        #endregion

        #region Helper Methods

        private PFMDTO00042 GetGenerateDataForAll(DateTime startDate, DateTime endDate, int currentUserId, string bdatetype, string type,string workstation,string sourceBr)
        {
            CXDTO00006 reportparameters = new CXDTO00006();
            reportparameters.StartDate = startDate;
            reportparameters.EndDate = endDate;
            reportparameters.CreatedUserId = currentUserId;
            reportparameters.BDateType = bdatetype;
            reportparameters.UserNo = workstation;
            if (type.Equals("Schedule"))
                reportparameters.SpecialCondition = "STATUS='LCD' and sourceBr = '" + sourceBr + "'";
            else if (type.Equals("Abstract"))
                reportparameters.SpecialCondition = "STATUS Like 'L%' and sourceBr = '" + sourceBr + "'";
            else
                reportparameters.SpecialCondition = "sourceBr = '" + sourceBr + "'";
            reportparameters.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
            return this.DataGenerateService.GetReportDataGenerateInSQL(reportparameters);
        }

        #endregion

        #region Main Methods

        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00042> GetScheduleReportData(bool isTransaction, DateTime selectedDate, string workstartion,int currentUserId,string sourceBr,string sourceCur)
        {
            PFMDTO00042 spdto = this.GetGenerateDataForAll(selectedDate, selectedDate, currentUserId, (isTransaction) ? "T" : "S", "Schedule",workstartion,sourceBr);
            if (spdto.Row_Count.Equals(0))
                return new List<PFMDTO00042>();
            return this.ReportTlfDAO.SelectScheduleData(isTransaction, workstartion, selectedDate, sourceCur);
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00042> GetAbstractReportData(bool isTransaction, DateTime selectedDate, string workstartion, int currentUserId, string sourceBr, string sourceCur)
        {
            PFMDTO00042 spdto = this.GetGenerateDataForAll(selectedDate, selectedDate, currentUserId, (isTransaction) ? "T" : "S", "Abstract",workstartion,sourceBr);
            if (spdto.Row_Count.Equals(0))
                return new List<PFMDTO00042>();
            return this.ReportTlfDAO.SelectAbstractData(isTransaction, workstartion, selectedDate, sourceCur);
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<TCMDTO00027> GetScrollData(string workstation, DateTime date_time, string currnecy, bool isTransactionDate, bool isReserval, int currentUserId,string sourceBr)
        {
            PFMDTO00042 spdto = this.GetGenerateDataForAll(date_time, date_time, currentUserId, (isTransactionDate) ? "T" : "S", "Scroll",workstation,sourceBr);
            if (spdto.Row_Count.Equals(0))
                return new List<TCMDTO00027>();
            IList<PFMDTO00042> ScrollDataList_LC = this.ViewDAO.GetScrollData_LC(workstation, date_time, currnecy, isTransactionDate, isReserval);
            IList<PFMDTO00042> ScrollDataList_LD = this.ViewDAO.GetScrollData_LD(workstation, date_time, currnecy, isTransactionDate, isReserval);

            if (ScrollDataList_LC.Count != 0 || ScrollDataList_LD.Count != 0)
            {
                decimal? CreditTotal = 0;
                decimal? DebitTotal = 0;
                foreach (PFMDTO00042 item in ScrollDataList_LD)
                {
                    CreditTotal += item.Debit;
                }

                PFMDTO00042 LDDto = new PFMDTO00042();
                LDDto.Particular = "Clearing House A/C";
                LDDto.Credit = CreditTotal;
                LDDto.Debit = DebitTotal;
                ScrollDataList_LD.Add(LDDto);

                IList<TCMDTO00027> RawList = new List<TCMDTO00027>();
                for (int i = 0; i < ((ScrollDataList_LC.Count >= ScrollDataList_LD.Count) ? ScrollDataList_LC.Count : ScrollDataList_LD.Count); i++)
                {
                    RawList.Add(new TCMDTO00027());
                    if (ScrollDataList_LC.Count != 0 && i < ScrollDataList_LC.Count)
                    {
                        RawList[i].DeliveredParticular = ScrollDataList_LC[i].Particular;
                        RawList[i].DeliveredDebit = ScrollDataList_LC[i].Debit;
                        RawList[i].DeliverCredit = ScrollDataList_LC[i].Credit;
                        RawList[i].DeliverSrNo = (i + 1).ToString();
                    }
                    if (ScrollDataList_LD.Count != 0 && i < ScrollDataList_LD.Count)
                    {
                        RawList[i].ReceiptParticular = ScrollDataList_LD[i].Particular;
                        RawList[i].ReceiptDebit = ScrollDataList_LD[i].Debit;
                        RawList[i].ReceiptCredit = ScrollDataList_LD[i].Credit;
                        RawList[i].ReceiptSrNo = (i + 1).ToString();
                    }
                }
                return RawList;
            }
            else
            {
                return new List<TCMDTO00027>();
            }
        }
        #endregion
    }
}
