//----------------------------------------------------------------------
// <copyright file="TLMSVE00027.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-07-17</CreatedDate>
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
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Windows.Core.Service;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Ace.Windows.CXServer.Utt;
using Spring.Transaction.Interceptor;
using NHibernate.Criterion;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Admin.Contracts.Dao;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;



namespace Ace.Cbs.Tel.Sve
{
   public class TLMSVE00027:BaseService,ITLMSVE00027
   {
       #region "DAO Properties"
       private ICXSVE00010 DataGenerateService { get; set; }
       private ICXSVE00006 CodeChecker { get; set; }
       private ICXDAO00009 ViewDAO { get; set; }
       #endregion

       #region Private Variable
       private const string bDateType = "T";
       private const string specialCondition = "Status='CDW'";
       #endregion

       #region "Method"
       [Transaction(TransactionPropagation.Required)]
       public bool IsInFAOFAccountNoOrInCledgerAcNo(string accountno)
       {           
           bool isValid = true;
           PFMDTO00028 Cledger = this.CodeChecker.GetAccountInfoOfCledgerByAccountNo(accountno);
           if (Cledger != null)
           {
               bool isCloseAccount = this.CodeChecker.IsClosedAccountForCLedger(accountno);
               if (isCloseAccount)
               {
                   this.ServiceResult.ErrorOccurred = true;
                   this.ServiceResult.MessageCode = CXMessage.MV00044;
                   isValid = false;
               }
           }
           else
           {
               PFMDTO00021 FledgerInfo = new PFMDTO00021();
               FledgerInfo = this.CodeChecker.GetTopFAOFINfoByAccountNo(accountno);
               if (FledgerInfo == null)
               {
                   this.ServiceResult.ErrorOccurred = true;
                   this.ServiceResult.MessageCode = CXMessage.MV00046;
                   isValid = false;
               }
           }

           return isValid;
       }
       #endregion

       #region "GetGenerateDataDTO"
       //For Withdrawal.All
        [Transaction(TransactionPropagation.Required)]
       private void GetGenerateDataForAll(DateTime startDate, DateTime endDate, int workStation, int createdUserId, string sourceBr)
       {
           PFMDTO00042 DataGenerateDTO = new PFMDTO00042();
           CXDTO00006 reportparameters = new CXDTO00006();
           reportparameters.StartDate = startDate;
           reportparameters.EndDate = endDate;
           reportparameters.BDateType = bDateType;
           reportparameters.SpecialCondition = specialCondition;
           reportparameters.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
           reportparameters.UserNo = workStation.ToString();
           reportparameters.CreatedUserId = createdUserId;
           reportparameters.SpecialCondition = "SourceBr = " + "'" + sourceBr + "'";
           DataGenerateDTO = this.DataGenerateService.GetReportDataGenerateInSQL(reportparameters);

       }

        //For Withdrawal.Current
        [Transaction(TransactionPropagation.Required)]
        private void GetGenerateDataForByCurrentAccountType(DateTime startDate, DateTime endDate, int workStation, int createdUserId, string sourceBr)
        {
            PFMDTO00042 DataGenerateDTO = new PFMDTO00042();
            CXDTO00006 reportparameters = new CXDTO00006();
            reportparameters.StartDate = startDate;
            reportparameters.EndDate = endDate;
            reportparameters.BDateType = bDateType;
            reportparameters.SpecialCondition = specialCondition;
            reportparameters.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
            reportparameters.ACSign = "C%";
            reportparameters.UserNo = workStation.ToString();
            reportparameters.CreatedUserId = createdUserId;
            reportparameters.SpecialCondition = "SourceBr = " + "'" + sourceBr + "'";
            DataGenerateDTO = this.DataGenerateService.GetReportDataGenerateInSQL(reportparameters);

        }
       /*Added by ZMS (for Pristine BL/PL/HP/DL AC)*/
        //For Withdrawal.BL
        [Transaction(TransactionPropagation.Required)]
        private void GetGenerateDataForByBusinessLoansAccountType(DateTime startDate, DateTime endDate, int workStation, int createdUserId, string sourceBr)
        {
            PFMDTO00042 DataGenerateDTO = new PFMDTO00042();
            CXDTO00006 reportparameters = new CXDTO00006();
            reportparameters.StartDate = startDate;
            reportparameters.EndDate = endDate;
            reportparameters.BDateType = bDateType;
            reportparameters.SpecialCondition = specialCondition;
            reportparameters.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
            reportparameters.ACSign = "B%";
            reportparameters.UserNo = workStation.ToString();
            reportparameters.CreatedUserId = createdUserId;
            reportparameters.SpecialCondition = "SourceBr = " + "'" + sourceBr + "'";
            DataGenerateDTO = this.DataGenerateService.GetReportDataGenerateInSQL(reportparameters);

        }
        //For Withdrawal.HirePurchase
        [Transaction(TransactionPropagation.Required)]
        private void GetGenerateDataForByHirePurchaseAccountType(DateTime startDate, DateTime endDate, int workStation, int createdUserId, string sourceBr)
        {
            PFMDTO00042 DataGenerateDTO = new PFMDTO00042();
            CXDTO00006 reportparameters = new CXDTO00006();
            reportparameters.StartDate = startDate;
            reportparameters.EndDate = endDate;
            reportparameters.BDateType = bDateType;
            reportparameters.SpecialCondition = specialCondition;
            reportparameters.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
            reportparameters.ACSign = "H%";
            reportparameters.UserNo = workStation.ToString();
            reportparameters.CreatedUserId = createdUserId;
            reportparameters.SpecialCondition = "SourceBr = " + "'" + sourceBr + "'";
            DataGenerateDTO = this.DataGenerateService.GetReportDataGenerateInSQL(reportparameters);

        }
        //For Withdrawal.PersonalLoans
        [Transaction(TransactionPropagation.Required)]
        private void GetGenerateDataForByPersonalLoansAccountType(DateTime startDate, DateTime endDate, int workStation, int createdUserId, string sourceBr)
        {
            PFMDTO00042 DataGenerateDTO = new PFMDTO00042();
            CXDTO00006 reportparameters = new CXDTO00006();
            reportparameters.StartDate = startDate;
            reportparameters.EndDate = endDate;
            reportparameters.BDateType = bDateType;
            reportparameters.SpecialCondition = specialCondition;
            reportparameters.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
            reportparameters.ACSign = "P%";
            reportparameters.UserNo = workStation.ToString();
            reportparameters.CreatedUserId = createdUserId;
            reportparameters.SpecialCondition = "SourceBr = " + "'" + sourceBr + "'";
            DataGenerateDTO = this.DataGenerateService.GetReportDataGenerateInSQL(reportparameters);

        }
        //For Withdrawal.Dealer
        [Transaction(TransactionPropagation.Required)]
        private void GetGenerateDataForByDealerAccountType(DateTime startDate, DateTime endDate, int workStation, int createdUserId, string sourceBr)
        {
            PFMDTO00042 DataGenerateDTO = new PFMDTO00042();
            CXDTO00006 reportparameters = new CXDTO00006();
            reportparameters.StartDate = startDate;
            reportparameters.EndDate = endDate;
            reportparameters.BDateType = bDateType;
            reportparameters.SpecialCondition = specialCondition;
            reportparameters.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
            reportparameters.ACSign = "D%";
            reportparameters.UserNo = workStation.ToString();
            reportparameters.CreatedUserId = createdUserId;
            reportparameters.SpecialCondition = "SourceBr = " + "'" + sourceBr + "'";
            DataGenerateDTO = this.DataGenerateService.GetReportDataGenerateInSQL(reportparameters);
        }
        /*Added by ZMS (for Pristine BL/PL/HP/DL AC)*/

        //For Withdrawal.Saving
        [Transaction(TransactionPropagation.Required)]
        private void GetGenerateDataForBySavingAccountType(DateTime startDate, DateTime endDate, int workStation, int createdUserId, string sourceBr)
        {
            PFMDTO00042 DataGenerateDTO = new PFMDTO00042();
            CXDTO00006 reportparameters = new CXDTO00006();
            reportparameters.StartDate = startDate;
            reportparameters.EndDate = endDate;
            reportparameters.SpecialCondition = specialCondition;
            reportparameters.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
            reportparameters.BDateType = bDateType;
            reportparameters.UserNo = workStation.ToString();
            reportparameters.CreatedUserId = createdUserId;
            reportparameters.ACSign = "S";
            reportparameters.SpecialCondition = "SourceBr = " + "'" + sourceBr + "'";
            DataGenerateDTO = this.DataGenerateService.GetReportDataGenerateInSQL(reportparameters);
        }

        //For Withdrawal.Fix
        [Transaction(TransactionPropagation.Required)]
        private void GetGenerateDataForByFixedAccountType(DateTime startDate, DateTime endDate, int workStation, int createdUserId, string sourceBr)
        {
            PFMDTO00042 DataGenerateDTO = new PFMDTO00042();
            CXDTO00006 reportparameters = new CXDTO00006();
            reportparameters.StartDate = startDate;
            reportparameters.EndDate = endDate;
            reportparameters.BDateType = bDateType;
            reportparameters.UserNo = workStation.ToString();
            reportparameters.CreatedUserId = createdUserId;
            reportparameters.SpecialCondition = specialCondition;
            reportparameters.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
            reportparameters.ACSign = "F";
            reportparameters.SpecialCondition = "SourceBr = " + "'" + sourceBr + "'";
            DataGenerateDTO = this.DataGenerateService.GetReportDataGenerateInSQL(reportparameters);
        }

        //For Withdrawal.Counter
        [Transaction(TransactionPropagation.Required)]
        private void GetGenerateDataForByCounterNo(DateTime startDate, DateTime endDate, int workstationId, int createdUserId, string sourceBr)
        {
            PFMDTO00042 DataGenerateDTO = new PFMDTO00042();
            CXDTO00006 reportparameters = new CXDTO00006();
            reportparameters.StartDate = startDate;
            reportparameters.EndDate = endDate;
            reportparameters.SpecialCondition = specialCondition;
            reportparameters.BDateType = bDateType;
            reportparameters.CreatedUserId = createdUserId;
            //reportparameters.UserNo = userno;
            reportparameters.UserNo = workstationId.ToString();
            reportparameters.CreatedUserId = createdUserId;
            reportparameters.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
            reportparameters.SpecialCondition = "SourceBr = " + "'" + sourceBr + "'";
            DataGenerateDTO = this.DataGenerateService.GetReportDataGenerateInSQL(reportparameters);
        }

        //For Withdrawal.AccountNo
        [Transaction(TransactionPropagation.Required)]
        private void GetGenerateDataForByAccountNo(DateTime startDate, DateTime endDate, string accountNo, int createdUserId, string sourceBr, int workStation)
        {
            PFMDTO00042 DataGenerateDTO = new PFMDTO00042();
            CXDTO00006 reportparameters = new CXDTO00006();
            reportparameters.StartDate = startDate;
            reportparameters.EndDate = endDate;
            reportparameters.SpecialCondition = specialCondition;
            reportparameters.BDateType = bDateType;
            reportparameters.UserNo = workStation.ToString();
            reportparameters.CreatedUserId = createdUserId;
            reportparameters.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
            reportparameters.AccountNo = accountNo;
            reportparameters.SpecialCondition = "SourceBr = " + "'" + sourceBr + "'";
            DataGenerateDTO = this.DataGenerateService.GetReportDataGenerateInSQL(reportparameters);
        }



       #endregion

       #region "GetListing"
        public IList<PFMDTO00042> GetWithdrawalListingList(DateTime startDate, DateTime endDate, string sourcebranchCode, int workStation, int createdUserId)
        {
            IList<PFMDTO00042> DataGenerateDTOList = new List<PFMDTO00042>();
            this.GetGenerateDataForAll(startDate, endDate, workStation, createdUserId, sourcebranchCode);
            DataGenerateDTOList = this.ViewDAO.SelectWithdrawalListingAllReport(startDate, endDate, sourcebranchCode, workStation);
            int i = 0;
            for (; i < DataGenerateDTOList.Count; )
            {
                DataGenerateDTOList[i].Time = DataGenerateDTOList[i].DATE_TIME.Value.ToLongTimeString().Substring(0, 8);
                DataGenerateDTOList[i].CheckTime = DataGenerateDTOList[i].DATE_TIME.Value.ToString("dd/MM/yyyy").Substring(0, 10);
                //DataGenerateDTOList[i].UserNo = this.ViewDAO.SelectUserNamebyUserId(createdUserId).UserName;// Update By ZMS ( to form user name )
                DataGenerateDTOList[i].CurCode = DataGenerateDTOList[i].SourceCur;
                i++;
            }
            return DataGenerateDTOList;
        }

        public IList<PFMDTO00042> GetWithdrawalListingByAccountTypeList(DateTime startDate, DateTime endDate, int workStation, string acSign, string sourceBranch, int createdUserId)
        {
            IList<PFMDTO00042> DataGenerateDTOList = new List<PFMDTO00042>();
            string aSign = acSign.Substring(0, 1);
            switch (aSign)
            {
                case "C": this.GetGenerateDataForByCurrentAccountType(startDate, endDate, workStation, createdUserId, sourceBranch);
                    break;
                case "S": this.GetGenerateDataForBySavingAccountType(startDate, endDate, workStation, createdUserId, sourceBranch);
                    break;
                case "F": this.GetGenerateDataForByFixedAccountType(startDate, endDate, workStation, createdUserId, sourceBranch);
                    break;
                // Updated by ZMS (15/12/2017) For Pristine
                case "B": this.GetGenerateDataForByBusinessLoansAccountType(startDate, endDate, workStation, createdUserId, sourceBranch);
                    break;
                case "H": this.GetGenerateDataForByHirePurchaseAccountType(startDate, endDate, workStation, createdUserId, sourceBranch);
                    break;
                // Updated by ZMS (15/12/2017) For Pristine
                case "P": this.GetGenerateDataForByPersonalLoansAccountType(startDate, endDate, workStation, createdUserId, sourceBranch);
                    break;
                case "D": this.GetGenerateDataForByDealerAccountType(startDate, endDate, workStation, createdUserId, sourceBranch);
                    break;
            }

            DataGenerateDTOList = this.ViewDAO.SelectWithdrawalListingByAccountTypeReport(startDate, endDate, workStation, acSign, sourceBranch);
            for (int i = 0; i < DataGenerateDTOList.Count; i++)
            {
                DataGenerateDTOList[i].Time = DataGenerateDTOList[i].DATE_TIME.Value.ToLongTimeString().Substring(0, 8);
                DataGenerateDTOList[i].CheckTime = DataGenerateDTOList[i].DATE_TIME.Value.ToString("dd/MM/yyyy").Substring(0, 10);
                //DataGenerateDTOList[i].UserNo = this.ViewDAO.SelectUserNamebyUserId(createdUserId).UserName; // Update By ZMS ( to form user name )
                DataGenerateDTOList[i].CurCode = DataGenerateDTOList[i].SourceCur;
            }
            return DataGenerateDTOList;
        }

        public IList<PFMDTO00042> GetWithdrawalListingByCounterNoList(DateTime startDate, DateTime endDate, int workstationId, string username, int createdUserId, string sourceBranch)
        {
            IList<PFMDTO00042> DataGenerateDTOList = new List<PFMDTO00042>();
            if (this.ViewDAO.SelectUserInfobyUseNameForUserNoReport(username,sourceBranch) == null)
            {
                return new List<PFMDTO00042>();
            }
            else
            {
                //int userno = this.ViewDAO.SelectUserInfobyUseNameForUserNoReport(username, sourceBranch).Id;
                this.GetGenerateDataForByCounterNo(startDate, endDate, workstationId, createdUserId, sourceBranch);
                DataGenerateDTOList = this.ViewDAO.SelectWithdrawalListingByCounterNoReport(startDate, endDate, sourceBranch, workstationId, username);
                for (int i = 0; i < DataGenerateDTOList.Count; i++)
                {
                    //DataGenerateDTOList[i].Time = DataGenerateDTOList[i].DATE_TIME.Value.ToLongTimeString().Substring(0, 8); 
                    DataGenerateDTOList[i].Time = DataGenerateDTOList[i].DATE_TIME.Value.ToString("HH:mm:ss");
                    DataGenerateDTOList[i].CheckTime = DataGenerateDTOList[i].DATE_TIME.Value.ToString("dd/MM/yyyy").Substring(0, 10);
                    //DataGenerateDTOList[i].UserNo = this.ViewDAO.SelectUserNamebyUserId(createdUserId).UserName;// Update By ZMS ( to form user name )
                    DataGenerateDTOList[i].CurCode = DataGenerateDTOList[i].SourceCur;
                }
                return DataGenerateDTOList;
            }
        }

        public IList<PFMDTO00042> GetWithdrawalListingByAccountNoList(DateTime startDate, DateTime endDate, string accountNo, int createdUserId, string sourceBranch, int workstation)
        {
            IList<PFMDTO00042> DataGenerateDTOList = new List<PFMDTO00042>();
            this.GetGenerateDataForByAccountNo(startDate, endDate, accountNo, createdUserId, sourceBranch, workstation);
            DataGenerateDTOList = this.ViewDAO.SelectWithdrawalListingByAccountNoReport(startDate, endDate, accountNo, sourceBranch, workstation);
            int i = 0;
            for (; i < DataGenerateDTOList.Count; )
            {
                DataGenerateDTOList[i].Time = DataGenerateDTOList[i].DATE_TIME.Value.ToLongTimeString().Substring(0, 8);
                DataGenerateDTOList[i].CheckTime = DataGenerateDTOList[i].DATE_TIME.Value.ToString("dd/MM/yyyy").Substring(0, 10);
                //int userid = Convert.ToInt16(DataGenerateDTOList[i].UserNo);
                //DataGenerateDTOList[i].UserNo = this.ViewDAO.SelectUserNamebyUserId(userid).UserName;// Update By ZMS ( to form user name )
                DataGenerateDTOList[i].CurCode = DataGenerateDTOList[i].SourceCur;
                i++;
            }
            return DataGenerateDTOList;
        }

        public bool IsValidUserNo(string userno, string sourcebr)
        {
            if (this.ViewDAO.SelectUserInfobyUseNameForUserNoReport(userno, sourcebr) == null)
                return false;
            else
                return true;
        }
       #endregion
    }
}
