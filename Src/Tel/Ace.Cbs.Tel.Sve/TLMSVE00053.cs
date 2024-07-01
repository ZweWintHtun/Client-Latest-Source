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
  public  class TLMSVE00053 :BaseService,ITLMSVE00053
    {

        #region DAO
        public ICXDAO00009 ViewDAO { get; set; }
        #endregion        

        [Transaction(TransactionPropagation.Required)]
        public IList<TLMDTO00058> SelectCurrentDayBook(DateTime requireDate, int createdUserId, string acsign, string currencyCode, string sourceBr, string workStation, bool issettlmedate, bool sortByTime)
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
            { parameter.BDateType = "S"; }
            else
            { parameter.BDateType = "T"; }
            parameter.UserNo = workStation;
            check = CXServiceWrapper.Instance.Invoke<ICXSVE00010, PFMDTO00042>(x => x.GetReportDataGenerateInSQL(parameter));
            if (check == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MI00039"; //No Data For Report
                 IList < TLMDTO00058 > dayBookDTOlist = new List<TLMDTO00058>(); 
                 return dayBookDTOlist;
            }

            //if (!issettlmedate)
            //{
            //    IList<TLMDTO00058> dayBookDTOlist = this.ViewDAO.SelectDayBookCurrent(workStation, currencyCode, requireDate);
            //    return dayBookDTOlist;
            //}
            //else
            //{
            //    IList<TLMDTO00058> dayBookDTOlist = this.ViewDAO.SelectDayBookCurrentBySettlementDate(workStation, currencyCode, requireDate);
            //    return dayBookDTOlist;
 
            //}

            //Editted by HWKO (14-Aug-2017)
            if (!issettlmedate)
            {
                IList<TLMDTO00058> dayBookDTOlist = this.ViewDAO.SelectDayBookCurrentAll(workStation, currencyCode, requireDate, acsign, sortByTime);
                return dayBookDTOlist;
            }
            else
            {
                IList<TLMDTO00058> dayBookDTOlist = this.ViewDAO.SelectDayBookCurrentAllBySettlementDate(workStation, currencyCode, requireDate, acsign, sortByTime);
                return dayBookDTOlist;
            }
            //End Region
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<TLMDTO00058> SelectCurrentReversalDayBook(DateTime requireDate, int createdUserId, string acsign, string currencyCode, string sourceBr, string workStation, bool issettlmedate, bool sortByName)
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
            { parameter.BDateType = "S"; }
            else
            { parameter.BDateType = "T"; }
            parameter.UserNo = workStation;
            check = CXServiceWrapper.Instance.Invoke<ICXSVE00010, PFMDTO00042>(x => x.GetReportDataGenerateInSQL(parameter));
            if (check == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MI00039"; //No Data For Report
                IList<TLMDTO00058> dayBookDTOlist = new List<TLMDTO00058>();
                return dayBookDTOlist;
            }

            //if (!issettlmedate)
            //{
            //    IList<TLMDTO00058> dayBookDTOlist = this.ViewDAO.SelectDayBookCurrentReversal(workStation, currencyCode, requireDate);
            //    return dayBookDTOlist;
            //}
            //else
            //{
            //    IList<TLMDTO00058> dayBookDTOlist = this.ViewDAO.SelectDayBookCurrentReversalBySettlementDate(workStation, currencyCode, requireDate);
            //    return dayBookDTOlist;
 
            //}

            //Editted by HWKO (14-Aug-2017)
            if (!issettlmedate)
            {
                IList<TLMDTO00058> dayBookDTOlist = this.ViewDAO.SelectDayBookCurrentAllReversal(workStation, currencyCode, requireDate, acsign, sortByName);
                return dayBookDTOlist;
            }
            else
            {
                IList<TLMDTO00058> dayBookDTOlist = this.ViewDAO.SelectDayBookCurrentAllReversalBySettlementDate(workStation, currencyCode, requireDate, acsign, sortByName);
                return dayBookDTOlist;
            }
            //End Region
        }


        [Transaction(TransactionPropagation.Required)]
        public IList<TLMDTO00058> SelectCurrentHomeDayBook(DateTime requireDate, int createdUserId, string acsign, string currencyCode, string sourceBr, string workStation, bool issettlmedate, bool sortByName)
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
            { parameter.BDateType = "S"; }
            else
            { parameter.BDateType = "T"; }
            parameter.UserNo = workStation;
            check = CXServiceWrapper.Instance.Invoke<ICXSVE00010, PFMDTO00042>(x => x.GetReportDataGenerateInSQL(parameter));
            if (check == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MI00039"; //No Data For Report
                IList<TLMDTO00058> dayBookDTOlist = new List<TLMDTO00058>();
                return dayBookDTOlist;
            }

            #region Old Code // Modify by HWKO (14-Aug-2017)
            //if (!issettlmedate)
            //{
            //    IList<TLMDTO00058> dayBookDTOlist = this.ViewDAO.SelectDayBookCurrentHome(workStation, currencyCode, requireDate);
            //    return dayBookDTOlist;
            //}

            //else
            //{
            //    IList<TLMDTO00058> dayBookDTOlist = this.ViewDAO.SelectDayBookCurrent_HomeBySettlementDate(workStation, currencyCode, requireDate);
            //    return dayBookDTOlist;

            //}
            #endregion

            //Editted by HWKO (14-Aug-2017)
            if (!issettlmedate)
            {
                IList<TLMDTO00058> dayBookDTOlist = this.ViewDAO.SelectCurrentDayBookAllHome(workStation, currencyCode, requireDate,acsign,sortByName);               
                return dayBookDTOlist;
            }

            else
            {
                IList<TLMDTO00058> dayBookDTOlist = this.ViewDAO.SelectDayBookCurrentAll_HomeBySettlementDate(workStation, currencyCode, requireDate, acsign, sortByName);
                return dayBookDTOlist;
 
            }
            //Endregion
        }



        [Transaction(TransactionPropagation.Required)]
        public IList<TLMDTO00058> SelectCurrentHomeReversalDayBook(DateTime requireDate, int createdUserId, string acsign, string currencyCode, string sourceBr, string workStation, bool issettlmedate, bool sortByTime)
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
            { parameter.BDateType = "S"; }
            else
            { parameter.BDateType = "T"; }
            parameter.UserNo = workStation;
            check = CXServiceWrapper.Instance.Invoke<ICXSVE00010, PFMDTO00042>(x => x.GetReportDataGenerateInSQL(parameter));
            if (check == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MI00039"; //No Data For Report
                IList<TLMDTO00058> dayBookDTOlist = new List<TLMDTO00058>();
                return dayBookDTOlist;
            }
            
            //if(!issettlmedate)
            //{
            //IList<TLMDTO00058> dayBookDTOlist = this.ViewDAO.SelectDayBookCurrentHomeReversal(workStation, currencyCode, requireDate);
            //    return dayBookDTOlist;
            //}
            //else 
            //{
            //    IList<TLMDTO00058> dayBookDTOlist = this.ViewDAO.SelectDayBookCurrentHomeReversalBySettlementDate(workStation, currencyCode, requireDate);
            //    return dayBookDTOlist;
            //}

            //Editted by HWKO (14-Aug-2017)
            if (!issettlmedate)
            {
                IList<TLMDTO00058> dayBookDTOlist = this.ViewDAO.SelectDayBookCurrentAllHomeReversal(workStation, currencyCode, requireDate, acsign, sortByTime);
                return dayBookDTOlist;
            }
            else
            {
                IList<TLMDTO00058> dayBookDTOlist = this.ViewDAO.SelectDayBookCurrentAllHomeReversalBySettlementDate(workStation, currencyCode, requireDate, acsign, sortByTime);
                return dayBookDTOlist;
            }
            //Endregion
        }

       
    }
}
