//----------------------------------------------------------------------
// <copyright file="TCMSVE00033.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.CXServer.Utt;
using Ace.Cbs.Cx.Com.Ctr;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Tcm.Sve
{
    public class TCMSVE00033 : BaseService, ITCMSVE00033
    {

        #region DAO 
        public IPFMDAO00042 ReportTLFDAO { get; set; }
        public ICXDAO00009 ViewDAO { get; set; }

        #endregion

        #region Helper Method
        [Transaction(TransactionPropagation.Required)]
        private void InsertReportTLF(string sourcebr,int createduserid,DateTime startdate,DateTime enddate,string workstation,string status)
        {
            PFMDTO00042 DataGenerateDTO = new PFMDTO00042();
            CXDTO00006 reportparametersdto = new CXDTO00006();
            reportparametersdto.StartDate = startdate;
            reportparametersdto.EndDate = enddate;
            reportparametersdto.CreatedUserId = createduserid;
            reportparametersdto.UserNo = workstation;
            reportparametersdto.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
            reportparametersdto.BDateType = "T";
            reportparametersdto.SpecialCondition = "sourceBr = '" + sourcebr + "'" + " and " + "Status = '" + status + "'";
            try
            { CXServiceWrapper.Instance.Invoke<ICXSVE00010, PFMDTO00042>(x => x.GetReportDataGenerateInSQL(reportparametersdto)); }

            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MI00039; 
            }        
 
        }

        private IList<PFMDTO00042> SelectReportTLFBySourceBr(DateTime startdate,DateTime enddate,string sourcebr, string workstation)
        {
            IList <PFMDTO00042>  reportlist = this.ReportTLFDAO.SelectDeliveredChequeBySourceBrAndWorkstation(startdate, enddate, sourcebr, workstation);
            if (reportlist.Count > 0)
            {
                return reportlist;
            }
            else
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MI00039;
                return reportlist;
            }
        }

        public IList<PFMDTO00042> SelectDeliveredCheque(string sourcebr, int createduserid, DateTime startdate, DateTime enddate, string workstation,string status)
        {
            this.InsertReportTLF(sourcebr, createduserid, startdate, enddate, workstation,status);
            IList<PFMDTO00042> reporttlfs = this.SelectReportTLFBySourceBr(startdate, enddate, sourcebr, workstation); 
            foreach(PFMDTO00042 item in reporttlfs)
            {
                IList<MNMDTO00040> names = this.GetCustomerName(item.AcctNo);
                if (names.Count>0)
                {
                    item.Name = names[0].Name;
                }
                if(names.Count>1 && string.IsNullOrEmpty(names[0].Name))
                {
                    item.Name = names[1].Name;
                }
            }
            return reporttlfs;
        }

        public IList<MNMDTO00040> GetCustomerName(string acctno)
        {
            IList<MNMDTO00040> names = this.ViewDAO.SelectNameByAccountNo(acctno);
            return names;
        }
        #endregion

        #region Main Method    

        public IList<PFMDTO00042> SelectNotYetPostedDeliveredCheque(string sourcebr, int createduserid, DateTime startdate, DateTime enddate, string workstation)
        {
            IList<PFMDTO00042> reporttlfs = this.SelectDeliveredCheque(sourcebr,createduserid,startdate,enddate,workstation,"LCD");
            
            var notyetpostedreports = (from value in reporttlfs
                                           where string.IsNullOrEmpty(value.ClearingPostStatus)
                                           select value).ToList();
                return notyetpostedreports;         
           
        }

        public IList<PFMDTO00042> SelectPostedDeliveredCheque(string sourcebr, int createduserid, DateTime startdate, DateTime enddate, string workstation)
        {
            IList<PFMDTO00042> reporttlfs = this.SelectDeliveredCheque(sourcebr, createduserid, startdate, enddate, workstation,"LCD");
            var postedreports = (from value in reporttlfs
                                       where !string.IsNullOrEmpty(value.ClearingPostStatus)
                                       select value).ToList();
            return postedreports;
           }       

        #endregion

    }
}
