using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Tcm.Sve
{
    public class TCMSVE00028 : BaseService,ITCMSVE00028
    {
        #region Properties
        
        public IPFMDAO00042 ReportTlfDAO { get; set; }
        public ICXDAO00010 DatagenerateDAO { get; set; }
        public ICXSVE00010 DataGenerateService { get; set; }
        public IPFMDAO00036 CS99DAO { get; set; }        

        #endregion

        #region Method

        [Transaction(TransactionPropagation.Required)]
        public PFMDTO00042 GetReportData(PFMDTO00042 dataDTO,string workStation)  // Check Data   
        {
            PFMDTO00042 tlfDTO = this.GetDataForReportTLF(dataDTO,workStation);
            decimal creditAmount = 0;
            decimal debitAmount = 0;
            decimal openingBalance = 0;

            //Nullable<decimal> cdTotal = DatagenerateDAO.GetCDTotalByDayBook(dataDTO.StartDate, "C", Environment.MachineName, CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode,dataDTO.SourceCur);  // Check in DayBook_Summary_CDData_SP_ForBranch  
            Nullable<decimal> cdTotal = DatagenerateDAO.GetCDTotalByDayBook(dataDTO.StartDate, "C", workStation,dataDTO.CreatedUserId, dataDTO.SourceBranch, dataDTO.SourceCur);  // Check in DayBook_Summary_CDData_SP_ForBranch  
            if (cdTotal == 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                tlfDTO.ClearingPostStatus = "False";
                return tlfDTO;
            }
            else
            {
                creditAmount = cdTotal == 0 ? 0 : cdTotal.Value;
                //Nullable<decimal> cdTotal1 = DatagenerateDAO.GetCDTotalByDayBook(dataDTO.StartDate, "D", Environment.MachineName, CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode,dataDTO.SourceCur);  // Check in DayBook_Summary_CDData_SP_ForBranch    
                Nullable<decimal> cdTotal1 = DatagenerateDAO.GetCDTotalByDayBook(dataDTO.StartDate, "D", workStation, dataDTO.CreatedUserId,dataDTO.SourceBranch, dataDTO.SourceCur);  // Check in DayBook_Summary_CDData_SP_ForBranch             
                if (cdTotal == 0)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    tlfDTO.ClearingPostStatus = "False";
                    return tlfDTO;
                }
                else
                {
                    debitAmount = cdTotal1 == 0 ? 0 : cdTotal1.Value;
                    if (creditAmount + debitAmount == 0)
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        tlfDTO.ClearingPostStatus = "False";
                        return tlfDTO;
                    }
                    else
                    {
                        DateTime dt = SubtractDays(dataDTO.StartDate, 1);

                        decimal totalBalance = CS99DAO.GetOpeningBalancefromCS99(dt,dataDTO.SourceBranch);  // Check in CS99#00
                        if (totalBalance == 0)
                        {
                            this.ServiceResult.ErrorOccurred = true;                            
                            tlfDTO.ClearingPostStatus = "True";
                            
                            openingBalance = Convert.ToDecimal(totalBalance);
                            PFMDTO00042 reportData = new PFMDTO00042();
                            reportData.ClosingBalance = openingBalance;
                            reportData.Credit = creditAmount;
                            reportData.Debit = debitAmount;
                            reportData.ClearingPostStatus = tlfDTO.ClearingPostStatus;
                            return reportData;
                        }
                        else
                        {
                            //openingBalance = Convert.ToDecimal(totalBalance);
                            PFMDTO00042 reportData = new PFMDTO00042();
                            reportData.ClosingBalance = openingBalance;
                            reportData.Credit = creditAmount;
                            reportData.Debit = debitAmount;
                            return reportData;
                        }
                    }
                }
            }
        }
        public DateTime SubtractDays(DateTime time, int days)
        {
            return time - new TimeSpan(days, 0, 0, 0);
        }
        
        public PFMDTO00042 GetDataForReportTLF(PFMDTO00042 DataDTO,string workStation)
        {
            PFMDTO00042 DataGenerateDTO = new PFMDTO00042();

            CXDTO00006 reportparameters = new CXDTO00006();
            reportparameters.StartDate = DataDTO.StartDate;
            reportparameters.EndDate = DataDTO.StartDate;
            reportparameters.CreatedUserId = DataDTO.CreatedUserId;
            reportparameters.UserNo = workStation;
            reportparameters.CurrencyCode = DataDTO.CurCode;                       
            reportparameters.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
            reportparameters.BDateType = "S";
            reportparameters.SpecialCondition = "sourceBr = '" + DataDTO.SourceBranch + "'"; 

            DataGenerateDTO = this.DataGenerateService.GetReportDataGenerateInSQL(reportparameters);
            return DataGenerateDTO;
        }

        public IList<PFMDTO00042> GetDayBookSummaryReport(DateTime date, string crdr, string workstation, int createduserid, string sourcebr, string sourcecur)
        {
            IList<PFMDTO00042> printDataList = new List<PFMDTO00042>();
            printDataList = DatagenerateDAO.GetDayBookSummaryReport(date, crdr, workstation, createduserid, sourcebr, sourcecur);
            return printDataList;
        }
        #endregion
    }
}
