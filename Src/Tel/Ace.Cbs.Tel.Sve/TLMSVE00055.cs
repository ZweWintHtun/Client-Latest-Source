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
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Tel.Sve
{
   public class TLMSVE00055 : BaseService, ITLMSVE00055
    { 
       #region DAO
        public ICXDAO00009 ViewDAO { get; set; }
        #endregion  

        #region old
        [Transaction(TransactionPropagation.Required)]
        public IList<TLMDTO00058> SelectDomesticDayBook(DateTime requireDate, int createdUserId, string currencyCode, string sourceBr, string workStation, bool issettlmedate, bool sortByTime)
        {
            PFMDTO00042 check = new PFMDTO00042();
            CXDTO00006 parameter = new CXDTO00006();
            //parameter.ACode = acode;
            if (string.IsNullOrEmpty(sourceBr))
            {
                parameter.SpecialCondition = "SourceCur = " + "'" + currencyCode + "'";
            }
            else
            {
                parameter.SpecialCondition = "SourceCur = " + "'" + currencyCode + "'" + " and " + "SourceBr = " + "'" + sourceBr + "'";
            }
            parameter.StartDate = requireDate;
            parameter.EndDate = requireDate;
            parameter.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
            parameter.CreatedUserId = createdUserId;
            if (issettlmedate)
            {
                parameter.BDateType = "S";
            }
            else
            {
                parameter.BDateType = "T";
            }
            parameter.UserNo = workStation;
            check = CXServiceWrapper.Instance.Invoke<ICXSVE00010, PFMDTO00042>(x => x.GetReportDataGenerateInSQL(parameter));
            if (check == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MI00039"; //No Data For Report
                IList<TLMDTO00058> dayBookDTOlist = new List<TLMDTO00058>();
                return dayBookDTOlist;
            }

            if (!issettlmedate)
            {
                IList<TLMDTO00058> dayBookDTOlist = this.ViewDAO.SelectDayBookDomestic(workStation, currencyCode, requireDate, sortByTime);
                return dayBookDTOlist;
            }
            else
            {
                IList<TLMDTO00058> dayBookDTOlist = this.ViewDAO.SelectDayBookDomesticBySettlementDate(workStation, currencyCode, requireDate, sortByTime);
                return dayBookDTOlist;

            }
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<TLMDTO00058> SelectDomesticReversalDayBook(DateTime requireDate, int createdUserId, string currencyCode, string sourceBr, string workStation, bool issettlmedate, bool sortByName)
        {
            PFMDTO00042 check = new PFMDTO00042();
            CXDTO00006 parameter = new CXDTO00006();
            //parameter.ACSign = acsign;
            //parameter.ACode = acode;
            if (string.IsNullOrEmpty(sourceBr))
            {
                parameter.SpecialCondition = "SourceCur = " + "'" + currencyCode + "'";
            }
            else
            {
                parameter.SpecialCondition = "SourceCur = " + "'" + currencyCode + "'" + " and " + "SourceBr = " + "'" + sourceBr + "'";
            }
            parameter.StartDate = requireDate;
            parameter.EndDate = requireDate;
            parameter.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
            parameter.CreatedUserId = createdUserId;
            if (issettlmedate)
            {
                parameter.BDateType = "S";
            }
            else
            {
                parameter.BDateType = "T";
            }
            parameter.UserNo = workStation;
            check = CXServiceWrapper.Instance.Invoke<ICXSVE00010, PFMDTO00042>(x => x.GetReportDataGenerateInSQL(parameter));
            if (check == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MI00039"; //No Data For Report
                IList<TLMDTO00058> dayBookDTOlist = new List<TLMDTO00058>();
                return dayBookDTOlist; ;
            }

            if (!issettlmedate)
            {
                IList<TLMDTO00058> dayBookDTOlist = this.ViewDAO.SelectDayBookDomesticReversal(workStation, currencyCode, requireDate, sortByName);

                return dayBookDTOlist;
            }
            else
            {
                IList<TLMDTO00058> dayBookDTOlist = this.ViewDAO.SelectDayBookDomesticReversalBySettlementDate(workStation, currencyCode, requireDate, sortByName);
                return dayBookDTOlist;
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<TLMDTO00058> SelectDomesticHomeDayBook(DateTime requireDate, int createdUserId, string currencyCode, string sourceBr, string workStation, bool issettlmedate, bool sortByName)
        {
            PFMDTO00042 check = new PFMDTO00042();
            CXDTO00006 parameter = new CXDTO00006();
            //parameter.ACSign = acsign;
            //parameter.ACode = acode;
            if (string.IsNullOrEmpty(sourceBr))
            {
                parameter.SpecialCondition = "SourceCur = " + "'" + currencyCode + "'";
            }
            else
            {
                parameter.SpecialCondition = "SourceCur = " + "'" + currencyCode + "'" + " and " + "SourceBr = " + "'" + sourceBr + "'";
            }
            parameter.StartDate = requireDate;
            parameter.EndDate = requireDate;
            parameter.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
            parameter.CreatedUserId = createdUserId;
            if (issettlmedate)
            {
                parameter.BDateType = "S";
            }
            else
            {
                parameter.BDateType = "T";
            }
            parameter.UserNo = workStation;
            check = CXServiceWrapper.Instance.Invoke<ICXSVE00010, PFMDTO00042>(x => x.GetReportDataGenerateInSQL(parameter));
            if (check == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MI00039"; //No Data For Report
                IList<TLMDTO00058> dayBookDTOlist = new List<TLMDTO00058>();
                return dayBookDTOlist;
            }

            if (!issettlmedate)
            {
                IList<TLMDTO00058> dayBookDTOlist = this.ViewDAO.SelectDayBookDomesticHome(workStation, currencyCode, requireDate, sortByName);
                return dayBookDTOlist;
            }
            else
            {
                IList<TLMDTO00058> dayBookDTOlist = this.ViewDAO.SelectDayBookDomesticHomeBySettlementDate(workStation, currencyCode, requireDate, sortByName);
                return dayBookDTOlist;
            }

        }

        [Transaction(TransactionPropagation.Required)]
        public IList<TLMDTO00058> SelectDomesticHomeReversalDayBook(DateTime requireDate, int createdUserId, string currencyCode, string sourceBr, string workStation, bool issettlmedate, bool sortByTime)
        {
            PFMDTO00042 check = new PFMDTO00042();
            CXDTO00006 parameter = new CXDTO00006();
            //parameter.ACSign = acsign;
            //parameter.ACode = acode;
            if (string.IsNullOrEmpty(sourceBr))
            {
                parameter.SpecialCondition = "SourceCur = " + "'" + currencyCode + "'";
            }
            else
            {
                parameter.SpecialCondition = "SourceCur = " + "'" + currencyCode + "'" + " and " + "SourceBr = " + "'" + sourceBr + "'";
            }
            parameter.StartDate = requireDate;
            parameter.EndDate = requireDate;
            parameter.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
            parameter.CreatedUserId = createdUserId;
            if (issettlmedate)
            {
                parameter.BDateType = "S";
            }
            else
            {
                parameter.BDateType = "T";
            }
            parameter.UserNo = workStation;
            check = CXServiceWrapper.Instance.Invoke<ICXSVE00010, PFMDTO00042>(x => x.GetReportDataGenerateInSQL(parameter));
            if (check == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MI00039"; //No Data For Report
                IList<TLMDTO00058> dayBookDTOlist = new List<TLMDTO00058>();
                return dayBookDTOlist; ;
            }
            if (!issettlmedate)
            {
                IList<TLMDTO00058> dayBookDTOlist = this.ViewDAO.SelectDayBookDomesticHomeReversal(workStation, currencyCode, requireDate, sortByTime);
                return dayBookDTOlist;
            }
            else
            {
                IList<TLMDTO00058> dayBookDTOlist = this.ViewDAO.SelectDayBookDomesticHomeReversalBySettlementDate(workStation, currencyCode, requireDate, sortByTime);
                return dayBookDTOlist;
            }

            //Endregion
        }
        #endregion       
    }
}
