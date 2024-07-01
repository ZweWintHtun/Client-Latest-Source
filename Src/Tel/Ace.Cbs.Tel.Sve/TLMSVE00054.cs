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
using Ace.Cbs.Cx.Ser.Dao;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;

namespace Ace.Cbs.Tel.Sve
{
  public  class TLMSVE00054 : BaseService, ITLMSVE00054
    {
        #region DAO
        public ICXDAO00009 ViewDAO { get; set; }
        #endregion  
      
       [Transaction(TransactionPropagation.Required)]
        public IList<TLMDTO00058> SelectSavingDayBook(DateTime requireDate, int createdUserId, string acsign, string currencyCode, string sourceBr, string workStation, bool issettlmedate)
        {
            PFMDTO00042 check = new PFMDTO00042();
            CXDTO00006 parameter = new CXDTO00006();
            parameter.ACSign = acsign;
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

            if(!issettlmedate)
            {
            IList<TLMDTO00058> dayBookDTOlist = this.ViewDAO.SelectDayBookSavings(workStation, currencyCode, requireDate);
                return dayBookDTOlist;
           }
           else
            {
                IList<TLMDTO00058> dayBookDTOlist = this.ViewDAO.SelectDayBookSavingsBySettlementDate(workStation, currencyCode, requireDate);
                return dayBookDTOlist;
            }
        }

       [Transaction(TransactionPropagation.Required)]
       public IList<TLMDTO00058> SelectSavingReversalDayBook(DateTime requireDate, int createdUserId, string acsign, string currencyCode, string sourceBr, string workStation, bool issettlmedate)
        {
            PFMDTO00042 check = new PFMDTO00042();
            CXDTO00006 parameter = new CXDTO00006();
            parameter.ACSign = acsign;
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
                IList<TLMDTO00058> dayBookDTOlist = this.ViewDAO.SelectDayBookSavingsReversal(workStation, currencyCode, requireDate);
                return dayBookDTOlist;
            }
            else
            {
                IList<TLMDTO00058> dayBookDTOlist = this.ViewDAO.SelectDayBookSavingsReversalBySettlemtntDate(workStation, currencyCode, requireDate);
                return dayBookDTOlist; 
            }
        }

       [Transaction(TransactionPropagation.Required)]
       public IList<TLMDTO00058> SelectFixedDayBook(DateTime requireDate, int createdUserId, string acsign, string currencyCode, string sourceBr, string workStation, bool issettlmedate)
        {
            PFMDTO00042 check = new PFMDTO00042();
            CXDTO00006 parameter = new CXDTO00006();
            parameter.ACSign = acsign;
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
            
           if(!issettlmedate)
            {
            IList<TLMDTO00058> dayBookDTOlist = this.ViewDAO.SelectDayFixed(workStation, currencyCode, requireDate);
                return dayBookDTOlist;
            }
           else
           {
               IList<TLMDTO00058> dayBookDTOlist = this.ViewDAO.SelectDayFixedBySettlementDate(workStation, currencyCode, requireDate);
               return dayBookDTOlist;
           }
        }

       [Transaction(TransactionPropagation.Required)]
       public IList<TLMDTO00058> SelectFixedReversalDayBook(DateTime requireDate, int createdUserId, string acsign, string currencyCode, string sourceBr, string workStation, bool issettlmedate)
        {
            PFMDTO00042 check = new PFMDTO00042();
            CXDTO00006 parameter = new CXDTO00006();
            parameter.ACSign = acsign;
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
                IList<TLMDTO00058> dayBookDTOlist = this.ViewDAO.SelectDayFixedReversal(workStation, currencyCode, requireDate);
                return dayBookDTOlist;
            }
            else
            {
                IList<TLMDTO00058> dayBookDTOlist = this.ViewDAO.SelectDayFixedReversalBySettlementDate(workStation, currencyCode, requireDate);
                return dayBookDTOlist; 
            }
        }
    }
}
