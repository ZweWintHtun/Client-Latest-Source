//----------------------------------------------------------------------
// <copyright file="Transfer Report" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Khin swe win</CreatedUser>
// <CreatedDate>14/01/2014</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.Core.Service;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using NHibernate;
using Spring.Data.NHibernate.Support;
using Ace.Windows.Admin.DataModel;
using System.Linq;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
using System.Collections.Generic;
using System;

namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00035 : BaseService,IMNMSVE00035
    {
        public ICXSVE00010 DataGenerateService
        { get; set; }
        private ICXDAO00009 viewDAO;
        public ICXDAO00009 ViewDAO
        {
            get { return this.viewDAO; }
            set { this.viewDAO = value; }
        }

        private ICXDAO00010 DataGenerateDAO { get; set; }


        #region "Private Methods"

        private CXDTO00006 GetTranAndSettleDateDTO(PFMDTO00042 TransferScroolDTO)
        {
            CXDTO00006 reportparameters = new CXDTO00006();
            switch (TransferScroolDTO.DateType)
            {
                case "T": reportparameters.BDateType = "T";
                    reportparameters.StartDate = TransferScroolDTO.StartDate;
                    reportparameters.EndDate = TransferScroolDTO.StartDate;
                    reportparameters.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
                    reportparameters.UserNo = TransferScroolDTO.WorkStation;
                    reportparameters.CreatedUserId = TransferScroolDTO.CreatedUserId;

                    break;
                case "S": reportparameters.BDateType = "S";
                    reportparameters.StartDate = TransferScroolDTO.StartDate;
                    reportparameters.EndDate = TransferScroolDTO.StartDate;
                    reportparameters.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
                    reportparameters.UserNo = TransferScroolDTO.WorkStation;
                    reportparameters.CreatedUserId = TransferScroolDTO.CreatedUserId;

                    break;
            }

            return reportparameters;

        }
        #endregion 

        #region insert ReportTlf
        private PFMDTO00042 GetDataTransfetScroll(PFMDTO00042 TransferScrollDTO)
        {
            PFMDTO00042 DataGenerateDTO = new PFMDTO00042();
            CXDTO00006 reportparameters = new CXDTO00006();

            if (TransferScrollDTO.DateType == "T")
            {
                if (TransferScrollDTO.IsAllBranches == true)
                {
                    reportparameters = this.GetTranAndSettleDateDTO(TransferScrollDTO);
                    DataGenerateDTO = this.DataGenerateService.GetReportDataGenerateInSQL(reportparameters);

                }
                else
                {
                    if (!string.IsNullOrEmpty(TransferScrollDTO.SourceBranch))
                    {
                        reportparameters = this.GetTranAndSettleDateDTO(TransferScrollDTO);
                        reportparameters.SpecialCondition = "sourcebr = '" + TransferScrollDTO.SourceBranch + "'";
                        //To Insert Datas to Report_TLF Table
                        DataGenerateDTO = this.DataGenerateService.GetReportDataGenerateInSQL(reportparameters);
                    }
                }
            }
            else if (TransferScrollDTO.DateType == "S")
            {
                if (TransferScrollDTO.IsAllBranches == true)
                {
                    reportparameters = this.GetTranAndSettleDateDTO(TransferScrollDTO);
                    //To Insert Datas to Report_TLF Table
                    DataGenerateDTO = this.DataGenerateService.GetReportDataGenerateInSQL(reportparameters);
                }

                else
                {
                    if (!string.IsNullOrEmpty(TransferScrollDTO.SourceBranch))
                    {
                        reportparameters = this.GetTranAndSettleDateDTO(TransferScrollDTO);
                        reportparameters.SpecialCondition = "sourcebr = '" + TransferScrollDTO.SourceBranch + "'";
                        //To Insert Datas to Report_TLF Table
                        DataGenerateDTO = this.DataGenerateService.GetReportDataGenerateInSQL(reportparameters);
                    }
                }
            }
            return DataGenerateDTO;
        }
        #endregion 

        #region Transaction Report
        public IList<MNMDTO00033> GetReturnTransferData(PFMDTO00042 TransferScrollDTO)
        {
            IList<MNMDTO00033> TrDrCrDataDTOList = new List<MNMDTO00033>();
            IList<PFMDTO00042> TotalbalCashClear = new List<PFMDTO00042>();

            try
            {
                switch (TransferScrollDTO.DateType)
                {
                    case "Transaction Date": TransferScrollDTO.DateType = "T";
                        break;

                    case "Settlement Date": TransferScrollDTO.DateType = "S";
                        break;
                }

                switch (TransferScrollDTO.IsWithReversal)
                {
                    case true: TransferScrollDTO.WithdrawalCount = 1;
                        break;

                    case false: TransferScrollDTO.WithdrawalCount = 0;
                        break;
                }
                PFMDTO00042 reportdata = this.GetDataTransfetScroll(TransferScrollDTO);

                TrDrCrDataDTOList = this.GetCrDrData(TransferScrollDTO);

                //if (TrDrCrDataDTOList.Count > 0)
                //{
                //    TotalbalCashClear = this.GetTotalBalCashClear(TransferScrollDTO, sourcebr);

                //}             

            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MI00039; //No data for Report 
            }
            return TrDrCrDataDTOList;
            
        }
       #endregion 

        #region TR DR CR Data
        public IList<MNMDTO00033> GetCrDrData(PFMDTO00042 TransferScrollDTO)
        {
            PFMDTO00042 rptDto = new PFMDTO00042();
            IList<MNMDTO00033> TrDTOLists = new List<MNMDTO00033>();
            string workstation=TransferScrollDTO.WorkStation;


            if (TransferScrollDTO.IsWithReversal == true)
            {
                if (TransferScrollDTO.DateType == "T")
                {
                    if (TransferScrollDTO.IsAllBranches == true)
                    {
                        if (TransferScrollDTO.IsHomeCurrency == true)
                        {
                            TrDTOLists=ViewDAO.SelectTransferScroll_Home_AllBranches(workstation,TransferScrollDTO.StartDate);
                        }
                        else
                        {
                            TrDTOLists=ViewDAO.SelectTransferScroll_ByCur_AllBranches(workstation,TransferScrollDTO.SourceCur,TransferScrollDTO.StartDate);
                        }
                    }
                    else
                    {
                        if(TransferScrollDTO.IsHomeCurrency==true)
                        {
                            TrDTOLists = ViewDAO.SelectTransferScroll_Home_ByBranch(workstation, TransferScrollDTO.StartDate, TransferScrollDTO.SourceBranch);
                        }
                        else
                        {
                            TrDTOLists = ViewDAO.SelectTransferScroll_ByCur_ByBranch(workstation, TransferScrollDTO.SourceCur, TransferScrollDTO.StartDate, TransferScrollDTO.SourceBranch);
                        }
                    }
                }
                else if(TransferScrollDTO.DateType=="S")
                {
                    if (TransferScrollDTO.IsAllBranches == true)
                    {
                        if (TransferScrollDTO.IsHomeCurrency == true)
                        {
                            TrDTOLists = ViewDAO.SelectTransferScroll_Home_AllBranches(workstation, TransferScrollDTO.StartDate);
                        }
                        else
                        {
                            TrDTOLists = ViewDAO.SelectTransferScroll_ByCur_AllBranches(workstation, TransferScrollDTO.SourceCur, TransferScrollDTO.StartDate);
                        }
                    }
                    else
                    {
                        if (TransferScrollDTO.IsHomeCurrency == true)
                        {
                            TrDTOLists = ViewDAO.SelectTransferScroll_Home_ByBranch(workstation, TransferScrollDTO.StartDate, TransferScrollDTO.SourceBranch);
                        }
                        else
                        {
                            TrDTOLists = ViewDAO.SelectTransferScroll_ByCur_ByBranch(workstation, TransferScrollDTO.SourceCur, TransferScrollDTO.StartDate, TransferScrollDTO.SourceBranch);
                        }
                    }
                }
            }

            else
            {
                if (TransferScrollDTO.DateType == "T")
                {
                    if (TransferScrollDTO.IsAllBranches == true)
                    {
                        if (TransferScrollDTO.IsHomeCurrency == true)
                        {
                            TrDTOLists=ViewDAO.SelectTransferScroll_Home_AllBranches_withoutReverse(workstation,TransferScrollDTO.StartDate);
                        }
                        else
                        {
                            TrDTOLists = ViewDAO.SelectTransferScroll_ByCur_AllBranches_withoutReverse(workstation, TransferScrollDTO.SourceCur, TransferScrollDTO.StartDate);
                        }
                    }
                    else
                    {
                        if(TransferScrollDTO.IsHomeCurrency==true)
                        {
                            TrDTOLists = ViewDAO.SelectTransferScroll_Home_ByBranch_withoutReverse(workstation, TransferScrollDTO.StartDate, TransferScrollDTO.SourceBranch);
                        }
                        else
                        {
                            TrDTOLists = ViewDAO.SelectTransferScroll_ByCur_ByBranch_withoutReverse(workstation, TransferScrollDTO.SourceCur, TransferScrollDTO.StartDate, TransferScrollDTO.SourceBranch);
                        }
                    }
                }
                else if(TransferScrollDTO.DateType=="S")
                {
                    if(TransferScrollDTO.IsAllBranches==true)
                    {
                        if(TransferScrollDTO.IsHomeCurrency==true)
                        {
                           TrDTOLists=ViewDAO.SelectTransferScroll_Home_AllBranches_BySDate_withoutReverse(workstation,TransferScrollDTO.StartDate);
                        }
                        else
                        {
                            TrDTOLists = ViewDAO.SelectTransferScroll_ByCur_AllBranches_BySDate_withoutReverse(workstation, TransferScrollDTO.SourceCur, TransferScrollDTO.StartDate);
                        }
                    }
                    else
                    {
                        if(TransferScrollDTO.IsHomeCurrency==true)
                        {
                            TrDTOLists = ViewDAO.SelectTransferScroll_Home_ByBranch_BySDate_withoutReverse(workstation, TransferScrollDTO.StartDate, TransferScrollDTO.SourceBranch);
                        }
                        else
                        {
                            TrDTOLists = ViewDAO.SelectTransferScroll_ByCur_ByBranch_BySDate_withoutReverse(workstation, TransferScrollDTO.SourceCur, TransferScrollDTO.StartDate, TransferScrollDTO.SourceBranch);
                        }
                    }
                }
            }
            return TrDTOLists;
        }
        #endregion 

        #region Total Balance Cash/Clear

        public PFMDTO00042 GetTotalBalCashClear(PFMDTO00042 TransferScrollDTO)
        {
            PFMDTO00042 TotalCashClear = new PFMDTO00042();
            object result = new object();

            if (TransferScrollDTO.IsWithReversal == true)
            {
                if (TransferScrollDTO.IsAllBranches == false && TransferScrollDTO.IsHomeCurrency == true)
                {
                    if (TransferScrollDTO.DateType == "T")
                    {
                         result= this.DataGenerateDAO.TransferScroll(TransferScrollDTO.SourceBranch,TransferScrollDTO.WorkStation, TransferScrollDTO.StartDate, 1, 'T', "KYT", TransferScrollDTO.ClearingTotal, TransferScrollDTO.TotalCash);
                    }
                    else
                    {
                        result = this.DataGenerateDAO.TransferScroll(TransferScrollDTO.SourceBranch, TransferScrollDTO.WorkStation, TransferScrollDTO.StartDate, 1, 'S', "KYT", TransferScrollDTO.ClearingTotal, TransferScrollDTO.TotalCash);
                    }
                }
                else if (TransferScrollDTO.IsAllBranches == true && TransferScrollDTO.IsHomeCurrency == true)
                {
                    if (TransferScrollDTO.DateType == "T")
                    {
                        result = this.DataGenerateDAO.TransferScroll("", TransferScrollDTO.WorkStation, TransferScrollDTO.StartDate, 1, 'T', "KYT", TransferScrollDTO.ClearingTotal, TransferScrollDTO.TotalCash);
                    }
                    else
                    {
                        result = this.DataGenerateDAO.TransferScroll("", TransferScrollDTO.WorkStation, TransferScrollDTO.StartDate, 1, 'S', "KYT", TransferScrollDTO.ClearingTotal, TransferScrollDTO.TotalCash);
                    }

                }
                else if (TransferScrollDTO.IsAllBranches == false && TransferScrollDTO.IsHomeCurrency == false)
                {
                    if (TransferScrollDTO.DateType == "T")
                    {
                        result = this.DataGenerateDAO.TransferScroll(TransferScrollDTO.SourceBranch, TransferScrollDTO.WorkStation, TransferScrollDTO.StartDate, 1, 'T', TransferScrollDTO.SourceCur, TransferScrollDTO.ClearingTotal, TransferScrollDTO.TotalCash);
                    }
                    else
                    {
                        result = this.DataGenerateDAO.TransferScroll(TransferScrollDTO.SourceBranch, TransferScrollDTO.WorkStation, TransferScrollDTO.StartDate, 1, 'S', TransferScrollDTO.SourceCur, TransferScrollDTO.ClearingTotal, TransferScrollDTO.TotalCash);
                    }
                }
                else if (TransferScrollDTO.IsAllBranches == true && TransferScrollDTO.IsHomeCurrency == false)
                {
                    if (TransferScrollDTO.DateType == "T")
                    {
                        result = this.DataGenerateDAO.TransferScroll("", TransferScrollDTO.WorkStation, TransferScrollDTO.StartDate, 1, 'T', TransferScrollDTO.SourceCur, TransferScrollDTO.ClearingTotal, TransferScrollDTO.TotalCash);
                    }
                    else
                    {
                        result = this.DataGenerateDAO.TransferScroll("", TransferScrollDTO.WorkStation, TransferScrollDTO.StartDate, 1, 'T', TransferScrollDTO.SourceCur, TransferScrollDTO.ClearingTotal, TransferScrollDTO.TotalCash);
                    }
                }

            }
            else
            {

                if (TransferScrollDTO.IsAllBranches == false && TransferScrollDTO.IsHomeCurrency == true)
                {
                    if (TransferScrollDTO.DateType == "T")
                    {
                        result = this.DataGenerateDAO.TransferScroll(TransferScrollDTO.SourceBranch, TransferScrollDTO.WorkStation, TransferScrollDTO.StartDate, 0, 'T', "KYT", TransferScrollDTO.ClearingTotal, TransferScrollDTO.TotalCash);
                    }
                    else
                    {
                        result = this.DataGenerateDAO.TransferScroll(TransferScrollDTO.SourceBranch, TransferScrollDTO.WorkStation, TransferScrollDTO.StartDate, 0, 'S', "KYT", TransferScrollDTO.ClearingTotal, TransferScrollDTO.TotalCash);
                    }
                }
                else if (TransferScrollDTO.IsAllBranches == true && TransferScrollDTO.IsHomeCurrency == true)
                {
                    if (TransferScrollDTO.DateType == "T")
                    {
                        result = this.DataGenerateDAO.TransferScroll("", TransferScrollDTO.WorkStation, TransferScrollDTO.StartDate, 0, 'T', "KYT", TransferScrollDTO.ClearingTotal, TransferScrollDTO.TotalCash);
                    }
                    else
                    {
                        result = this.DataGenerateDAO.TransferScroll("", TransferScrollDTO.WorkStation, TransferScrollDTO.StartDate, 0, 'S', "KYT", TransferScrollDTO.ClearingTotal, TransferScrollDTO.TotalCash);
                    }

                }
                else if (TransferScrollDTO.IsAllBranches == false && TransferScrollDTO.IsHomeCurrency == false)
                {
                    if (TransferScrollDTO.DateType == "T")
                    {
                        result = this.DataGenerateDAO.TransferScroll(TransferScrollDTO.SourceBranch, TransferScrollDTO.WorkStation, TransferScrollDTO.StartDate, 0, 'T', TransferScrollDTO.SourceCur, TransferScrollDTO.ClearingTotal, TransferScrollDTO.TotalCash);
                    }
                    else
                    {
                        result = this.DataGenerateDAO.TransferScroll(TransferScrollDTO.SourceBranch, TransferScrollDTO.WorkStation, TransferScrollDTO.StartDate, 0, 'S', TransferScrollDTO.SourceCur, TransferScrollDTO.ClearingTotal, TransferScrollDTO.TotalCash);
                    }
                }
                else if (TransferScrollDTO.IsAllBranches == true && TransferScrollDTO.IsHomeCurrency == false)
                {
                    if (TransferScrollDTO.DateType == "T")
                    {
                        result = this.DataGenerateDAO.TransferScroll("", TransferScrollDTO.WorkStation, TransferScrollDTO.StartDate, 0, 'T', TransferScrollDTO.SourceCur, TransferScrollDTO.ClearingTotal, TransferScrollDTO.TotalCash);
                    }
                    else
                    {
                        result = this.DataGenerateDAO.TransferScroll("", TransferScrollDTO.WorkStation, TransferScrollDTO.StartDate, 0, 'S', TransferScrollDTO.SourceCur, TransferScrollDTO.ClearingTotal, TransferScrollDTO.TotalCash);
                    }
                }
            }

            object[] resultArr = (object[])result;
            TotalCashClear.ClearingTotal = Convert.ToDecimal(resultArr[0]);
            TotalCashClear.TotalCash = Convert.ToDecimal(resultArr[1]);
            return TotalCashClear;
        }
        #endregion 
    }
}
