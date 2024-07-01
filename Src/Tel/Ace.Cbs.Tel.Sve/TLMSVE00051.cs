//----------------------------------------------------------------------
// <copyright file="TLMSVE00051.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo</CreatedUser>
// <CreatedDate>2013-09-05</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
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
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Pfm.Dmd.DTO;

namespace Ace.Cbs.Tel.Sve
{
    public class TLMSVE00051 : BaseService, ITLMSVE00051
    {
        private ICXSVE00010 DataGenerateService { get; set; }
        private ICXDAO00009 ViewDAO { get; set; }
        private IPFMDAO00001 CustomerDAO { get; set; }
        private ICXSVE00006 CodeChecker { get; set; }
        private string accountNo { get; set; }
        DateTime firstdate { get; set; }
        Nullable<decimal> closingbalance;
        IList<PFMDTO00042> BankStatementListingsDTOList = new List<PFMDTO00042>();
        private int tempCount;

        private ICXDAO00014 BLFDAO { get; set; }

        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00042> GetGenerateDataForBankStatementDTOReportList(DateTime startDate, DateTime endDate, string accountno, bool isAllCustomers, string accountType, string budgetMonth, string budgetYear, int createdUserId, string sourceBr, bool withReversal, string workStation)
        {
            //Added By ZMS For Budget End Flexible 2018/09/21
            string Return = String.Empty; 
            //budgetMonth = "M" + BLFDAO.GetBudget_Month_Year_Quarter(3, startDate, sourceBr, "M"); // For 2018/09/17 => 6;
            //budgetYear = BLFDAO.GetBudget_Month_Year_Quarter(2, startDate, sourceBr, "M"); // For 2018/09/17 => 2018/2018;
            IList<PFMDTO00079> budDto = CustomerDAO.GetBLFInfoByStartDate(startDate,sourceBr);
            budgetMonth ="M" + budDto[0].MByDate;
            budgetYear = budDto[0].BUDGET_INFO;

            ////
            IList<PFMDTO00042> BankStatementListingDTOList = new List<PFMDTO00042>();

            PFMDTO00042 DataGenerateDTO = new PFMDTO00042();
            PFMDTO00001 CustomerDTO = new PFMDTO00001();
            //string workStation=Convert.ToString(CurrentUserEntity.WorkStationId);

            string firstdates = startDate.Year.ToString() + "/" + startDate.Month.ToString() + "/" + "01";
            firstdate = Convert.ToDateTime(firstdates);
            if (isAllCustomers == false && accountType == "CS")
            {

                CXDTO00006 reportparameters = new CXDTO00006();

                reportparameters.BDateType = "T";

                reportparameters.EndDate = endDate;
                //reportparameters.SpecialCondition = "Status='CDW'";
                reportparameters.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
                reportparameters.AccountNo = accountno;
                reportparameters.UserNo = workStation;
                reportparameters.CreatedUserId = createdUserId;
                //reportparameters.CreatedUserId = CurrentUserEntity.CurrentUserID;

                reportparameters.StartDate = firstdate;
                reportparameters.SpecialCondition = "SourceBr = " + "'" + sourceBr + "'";
                //To Insert Datas to Report_TLF Table
                DataGenerateDTO = this.DataGenerateService.GetReportDataGenerateInSQL(reportparameters);

            }
            else if (isAllCustomers == false && accountType == "F")
            {
                CXDTO00006 reportparameters = new CXDTO00006();

                reportparameters.BDateType = "T";

                reportparameters.EndDate = endDate;
                //reportparameters.SpecialCondition = "Status='CDW'";
                reportparameters.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
                reportparameters.AccountNo = accountno;
                reportparameters.UserNo = workStation;
                reportparameters.CreatedUserId = createdUserId;
                //reportparameters.CreatedUserId = CurrentUserEntity.CurrentUserID;

                reportparameters.StartDate = firstdate;
                reportparameters.SpecialCondition = "SourceBr = " + "'" + sourceBr + "'";
                //To Insert Datas to Report_TLF Table
                DataGenerateDTO = this.DataGenerateService.GetReportDataGenerateInSQL(reportparameters);
            }

            //To Get Budget Year and Budget Month from VW_BANK
            DataGenerateDTO = this.GetSumMonth(budgetMonth, budgetYear, accountno);
            decimal balanc = DataGenerateDTO.HomeAmt.Value;
            DataGenerateDTO.Description = "Opening Balance";
            DataGenerateDTO.CheckTime = startDate.ToString("dd/MM/yyyy");
            DataGenerateDTO.Amount = null;

            decimal? tranLeadingAmt=0; 

            //To Get Withdraw Amount And Deposit Amount From VW.BANK_STATEMENT BY DATE
            if (startDate.Day > 1)   //opening balance 
            {
                BankStatementListingDTOList = (isAllCustomers == false && accountType == "CS") ? this.ViewDAO.SelectWithdrawAmountAndDepositAmountBankStatementForCS(workStation, accountno, firstdate, startDate.AddDays(-1)) : this.ViewDAO.SelectWithdrawAmountAndDepositAmountBankStatementForFixed(workStation, accountno, firstdate, startDate.AddDays(-1));

                tranLeadingAmt = (from dto in BankStatementListingDTOList
                                  select dto.HomeAmount-dto.Amount).Sum();
                DataGenerateDTO.HomeAmt += tranLeadingAmt;

                #region
                //if (BankStatementListingDTOList.Count > 0)
                //{
                //    for (int i = 0; i < BankStatementListingDTOList.Count; i++)
                //    {
                //        //if (BankStatementListingDTOList[i].Amount > 0)
                //        //{
                //        //    DataGenerateDTO.Amount = BankStatementListingDTOList[i].Amount;
                //        //    DataGenerateDTO.HomeAmount = BankStatementListingDTOList[i].HomeAmount;
                //        //    DataGenerateDTO.HomeAmt -= BankStatementListingDTOList[i].Amount;
                //        //    //closingbalance = balanc - DataGenerateDTO.HomeAmt;
                //        //    closingbalance = DataGenerateDTO.HomeAmt - balanc; // Modified By AAM(17-Nov-2017)
                //        //}

                //        //else
                //        //{
                //        //    DataGenerateDTO.Amount = BankStatementListingDTOList[i].Amount;
                //        //    DataGenerateDTO.HomeAmount = BankStatementListingDTOList[i].HomeAmount;
                //        //    DataGenerateDTO.HomeAmt += BankStatementListingDTOList[i].HomeAmount;
                //        //    closingbalance = balanc + DataGenerateDTO.HomeAmt;
                            
                //        //}
                //    }
                //    DataGenerateDTO.AcctNo = accountno;
                //    DataGenerateDTO.CheckTime = startDate.ToString("dd/MM/yyyy");
                //    DataGenerateDTO.Amount = 0;
                //    DataGenerateDTO.HomeAmount = 0;

                //    BankStatementListingsDTOList.Add(DataGenerateDTO);
                //}
                //else
                //{
                //    DataGenerateDTO.AcctNo = accountNo;
                //    DataGenerateDTO.CheckTime = startDate.ToString("dd/MM/yyyy");
                //    BankStatementListingsDTOList.Add(DataGenerateDTO);
                //}
                #endregion
            }
            #region
            //else
            //{

            //    DataGenerateDTO.AcctNo = accountno;
            //    DataGenerateDTO.CheckTime = startDate.ToString("dd/MM/yyyy");
            //    DataGenerateDTO.Amount = 0;
            //    DataGenerateDTO.HomeAmount = 0;
            //    DataGenerateDTO.HomeAmt = balanc;
            //    BankStatementListingsDTOList.Add(DataGenerateDTO);
            //}
            #endregion

            //BankStatementListingDTOList = (isAllCustomers == false && accountType == "CS") ? this.ViewDAO.SelectDatasFromBankStatementForCS(CurrentUserEntity.WorkStationId.ToString(), accountno, startDate, endDate) : this.ViewDAO.SelectDatasFromBankStatementForFixed(CurrentUserEntity.WorkStationId.ToString(), accountno, startDate, endDate);
            BankStatementListingDTOList = (isAllCustomers == false && accountType == "CS") ? this.ViewDAO.SelectDatasFromBankStatementForCS(workStation, accountno, startDate, endDate, withReversal) : this.ViewDAO.SelectDatasFromBankStatementForFixed(workStation, accountno, startDate, endDate);
            BankStatementListingDTOList.Insert(0, DataGenerateDTO); // Modified By AAM(20-Nov-2017)
            decimal closingBalance = DataGenerateDTO.HomeAmt.Value;

            for (int i = 1; i < BankStatementListingDTOList.Count; i++)
            {
                if (BankStatementListingDTOList[i].Cheque == null)
                {
                    BankStatementListingDTOList[i].Description = (BankStatementListingDTOList[i].Description == null) ? string.Empty : BankStatementListingDTOList[i].Description;
                }
                else
                {
                    BankStatementListingDTOList[i].Description = (BankStatementListingDTOList[i].Description == null) ? string.Empty : BankStatementListingDTOList[i].Description;
                    if (BankStatementListingDTOList[i].Cheque != BankStatementListingDTOList[i].Description.PadRight(8))
                    {
                        BankStatementListingDTOList[i].Description = BankStatementListingDTOList[i].Description == null ? string.Empty : BankStatementListingDTOList[i].Description + "," + BankStatementListingDTOList[i].Cheque;
                    }
                    else
                    {
                        BankStatementListingDTOList[i].Description = BankStatementListingDTOList[i].Description == null ? string.Empty : BankStatementListingDTOList[i].Description;
                    }
                }// Changing Description Field.

                //var brforeclosing = closingBalance;
                closingBalance += (BankStatementListingDTOList[i].HomeAmount.Value - BankStatementListingDTOList[i].Amount.Value);
                BankStatementListingDTOList[i].HomeAmt = closingBalance;

                //For Show Minus Condition in Balance
                //if (closingBalance != 0 && BankStatementListingDTOList[i].Amount.Value != 0)
                //{
                //    if (brforeclosing < BankStatementListingDTOList[i].Amount.Value)
                //    {
                //        if (closingBalance.ToString().Contains("-"))
                //        {
                //            BankStatementListingDTOList[i].strHomeAmt = closingBalance.ToString();
                //        }
                //        else
                //        {

                //            BankStatementListingDTOList[i].strHomeAmt = "-" + closingBalance.ToString();
                //        }
                //    }
                //    else
                //    {
                //        BankStatementListingDTOList[i].strHomeAmt = closingBalance.ToString();
                //    }
                    
                //}
                //else
                //{
                //    BankStatementListingDTOList[i].strHomeAmt = closingBalance.ToString();
                //}
                BankStatementListingDTOList[i].CheckTime =Convert.ToDateTime(BankStatementListingDTOList[i].CheckTime).ToString("dd/MM/yyyy");
            }

            #region
            //if (BankStatementListingDTOList.Count > 0) //(BankStatementListingDTOList.Count > 0)
            //{
            //    for (int i = 0; i < BankStatementListingDTOList.Count; i++)
            //    {
            //        PFMDTO00042 AmountsDTO = new PFMDTO00042();

            //        if (BankStatementListingDTOList[i].Cheque == null)
            //        {
            //            BankStatementListingDTOList[i].Description = (BankStatementListingDTOList[i].Description == null) ? string.Empty : BankStatementListingDTOList[i].Description;
            //        }
            //        else
            //        {
            //            BankStatementListingDTOList[i].Description = (BankStatementListingDTOList[i].Description == null) ? string.Empty : BankStatementListingDTOList[i].Description;
            //            if (BankStatementListingDTOList[i].Cheque != BankStatementListingDTOList[i].Description.PadRight(8))
            //            {
            //                BankStatementListingDTOList[i].Description = BankStatementListingDTOList[i].Description == null ? string.Empty : BankStatementListingDTOList[i].Description + "," + BankStatementListingDTOList[i].Cheque;
            //            }
            //            else
            //            {
            //                BankStatementListingDTOList[i].Description = BankStatementListingDTOList[i].Description == null ? string.Empty : BankStatementListingDTOList[i].Description;
            //            }
            //        }

            //        //-----------
            //        if (BankStatementListingDTOList[i].Amount > 0)
            //        {
            //            closingbalance = (closingbalance == null) ? 0 : closingbalance;
            //            closingbalance -= BankStatementListingDTOList[i].Amount;
            //        }

            //        else
            //        {
            //            closingbalance = (closingbalance == null) ? 0 : closingbalance;
            //            closingbalance += BankStatementListingDTOList[i].HomeAmount;
            //        }

            //        DateTime chktime = Convert.ToDateTime(BankStatementListingDTOList[i].CheckTime);

            //        AmountsDTO.CheckTime = chktime.ToString("dd/MM/yyyy");
            //        AmountsDTO.AcctNo = BankStatementListingDTOList[i].AcctNo;
            //        AmountsDTO.Cheque = BankStatementListingDTOList[i].Cheque;
            //        AmountsDTO.Description = BankStatementListingDTOList[i].Description;
            //        AmountsDTO.Amount = BankStatementListingDTOList[i].Amount;
            //        AmountsDTO.HomeAmount = BankStatementListingDTOList[i].HomeAmount;
            //        AmountsDTO.HomeAmt = closingbalance;

            //        BankStatementListingsDTOList.Add(AmountsDTO);
            //        accountno = AmountsDTO.AcctNo;

            //    }

            //}
            #endregion

            PFMDTO00042 DataGeneratesDTO = new PFMDTO00042();
            DataGeneratesDTO.Description = "Closing Balance";
            DataGeneratesDTO.CheckTime = endDate.ToString("dd/MM/yyyy");

            DataGeneratesDTO.AcctNo = accountno;
            DataGenerateDTO.Amount = DataGenerateDTO.Amount == 0 ? 0 : DataGenerateDTO.Amount;
            DataGeneratesDTO.HomeAmt = closingBalance;
            if (isAllCustomers == false && accountType == "CS")
            {
                CustomerDTO = this.GetCustomerInfoDatas(accountno,accountType);
                DataGeneratesDTO.AcctNo = accountno;
                DataGeneratesDTO.Narration = CustomerDTO.Name;
                DataGeneratesDTO.LGNo = CustomerDTO.NRC;
                DataGeneratesDTO.DomBankPost = CustomerDTO.Address;
                DataGeneratesDTO.RefType = CustomerDTO.TownshipDesp;
                DataGeneratesDTO.RefVNo = CustomerDTO.PhoneNo;
            }
            else if (accountType != "CS")
            {
                CustomerDTO = this.GetCustomerInfoDatas(accountno, accountType);
                DataGeneratesDTO.AcctNo = accountno;
                DataGeneratesDTO.Narration = CustomerDTO.Name;
                DataGeneratesDTO.LGNo = CustomerDTO.NRC;
                DataGeneratesDTO.DomBankPost = CustomerDTO.Address;
                DataGeneratesDTO.RefType = CustomerDTO.TownshipDesp;
                DataGeneratesDTO.RefVNo = CustomerDTO.PhoneNo;
            }
            var withdraw = (from wdraw in BankStatementListingDTOList
                            where wdraw.Amount != 0 && wdraw.Description != "Opening Balance"
                            select wdraw.Amount).ToList();
            DataGeneratesDTO.WithdrawalCount = withdraw.Count;
            var deposit = (from dpsit in BankStatementListingDTOList
                           where dpsit.HomeAmount != 0 && dpsit.Description != "Opening Balance"
                           select dpsit.HomeAmount).ToList();
            DataGeneratesDTO.DepositCount = deposit.Count;
            BankStatementListingDTOList.Add(DataGeneratesDTO);

            return BankStatementListingDTOList;
        }

        public PFMDTO00042 GetSumMonth(string budgetmonthcalculate, string budgetYear, string accountNo)
        {
            IList<PFMDTO00042> BankStatementListingDTOList = new List<PFMDTO00042>();
            PFMDTO00042 BankStatementListingDTO = new PFMDTO00042();

            Nullable<decimal> SumMonths = this.SumMonthByAccountNoandBudget(budgetmonthcalculate, budgetYear, accountNo);

            BankStatementListingDTO.HomeAmt = Convert.ToDecimal(SumMonths);

            return BankStatementListingDTO;
        }

        private Nullable<decimal> SumMonthByAccountNoandBudget(string budgetMonth, string budgetYear, string accountNo)
        {
            Nullable<decimal> summonth = null;

            switch (budgetMonth)
            {
                case "M1": summonth = this.ViewDAO.SelectSumM1Data(accountNo, budgetYear);
                    break;

                case "M2": summonth = this.ViewDAO.SelectSumM2Data(accountNo, budgetYear);
                    break;

                case "M3": summonth = this.ViewDAO.SelectSumM3Data(accountNo, budgetYear);
                    break;

                case "M4": summonth = this.ViewDAO.SelectSumM4Data(accountNo, budgetYear);
                    break;

                case "M5": summonth = this.ViewDAO.SelectSumM5Data(accountNo, budgetYear);
                    break;

                case "M6": summonth = this.ViewDAO.SelectSumM6Data(accountNo, budgetYear);
                    break;

                case "M7": summonth = this.ViewDAO.SelectSumM7Data(accountNo, budgetYear);
                    break;

                case "M8": summonth = this.ViewDAO.SelectSumM8Data(accountNo, budgetYear);
                    break;

                case "M9": summonth = this.ViewDAO.SelectSumM9Data(accountNo, budgetYear);
                    break;

                case "M10": summonth = this.ViewDAO.SelectSumM10Data(accountNo, budgetYear);
                    break;

                case "M11": summonth = this.ViewDAO.SelectSumM11Data(accountNo, budgetYear);
                    break;

                case "M12": summonth = this.ViewDAO.SelectSumM12Data(accountNo, budgetYear);

                    break;

            }
            return summonth;
        }

        //Get Customer Information From Cledger,CAOF,SAOF,FAOF By using AccountNo.
        private PFMDTO00001 GetCustomerInfoDatas(string accountNo,string accType)
        {
            PFMDTO00001 CustomerDTO = new PFMDTO00001();
            PFMDTO00028 ACSignDTO = new PFMDTO00028();
            PFMDTO00023 FACSignDTO = new PFMDTO00023();
            string accountSign = string.Empty;
            string accountType = string.Empty;
            if (accType == "CS")
            {
                ACSignDTO = this.CodeChecker.GetAccountInfoOfCledgerByAccountNo(accountNo);
                accountSign = ACSignDTO.AccountSign.Substring(0, 1);
                accountType = ACSignDTO.AccountSign.Substring(1, 1); 
            }
            else if (accType == "F")
            {
                FACSignDTO = this.CodeChecker.GetAccountInfoOfFledgerByAccountNo(accountNo);
                accountSign = FACSignDTO.AccountSignature.Substring(0, 1);
                accountType = FACSignDTO.AccountSignature.Substring(1, 1);
            }         

            if (accountSign == "C" || accountSign == "B" || accountSign == "H" || accountSign == "P" || accountSign=="D")
            {
                #region Old Code
                //PFMDTO00017 CAOFDTO = new PFMDTO00017();
                //CAOFDTO=this.CodeChecker.GetCAOFsByAccountNumber(accountNo).First();
                //CustomerDTO.CustomerId = CAOFDTO.CustomerID; 
                #endregion

                #region Modify Code By HWKO (17-May-2017)
                IList<PFMDTO00017> CAOFDTO = new List<PFMDTO00017>();
                CAOFDTO = this.CodeChecker.GetCAOFsByAccountNumber(accountNo);
                if (accountType == "I" || accountType == "P")
                {
                    CustomerDTO = this.CustomerDAO.SelectCustomerByCustID(CAOFDTO.First().CustomerID);
                }
                else if (accountType == "J")
                {
   
                    #region Old
                    //CustomerDTO.AccountNo = CAOFDTO.First().CledgerAccountNo;
                    //if (CAOFDTO.Count > 2)
                    //{

                    //}
                    //for (int i = 0; i < CAOFDTO.Count; i++)
                    //{
                    //    PFMDTO00001 tempCustDTO = new PFMDTO00001();
                    //    tempCustDTO = this.CustomerDAO.SelectCustomerByCustID(CAOFDTO[i].CustomerID);
                    //    if (i == 0)
                    //    {
                    //        CustomerDTO.Name = tempCustDTO.Name;
                    //        CustomerDTO.NRC = tempCustDTO.NRC;
                    //    }
                    //    else
                    //    {
                    //        CustomerDTO.Name += tempCustDTO.Name;
                    //        CustomerDTO.NRC += tempCustDTO.NRC;
                    //    }
                    //    if (i < CAOFDTO.Count - 1)
                    //    {
                    //        CustomerDTO.Name += ", ";
                    //        CustomerDTO.NRC += ", ";
                    //    }
                    //}
                    //CustomerDTO.PhoneNo = CAOFDTO.First().PhoneNo;
                    //CustomerDTO.Address = CAOFDTO.First().Address;
                    //CustomerDTO.TownshipDesp = CAOFDTO.First().Township_Code;
                    #endregion

                    //Updated by ZMS (13-06-2018) For Pristine Version  
                    CustomerDTO.AccountNo = CAOFDTO.First().CledgerAccountNo;
                    if (CAOFDTO.Count > 2)
                    {
                        tempCount = 2;
                    }
                    else tempCount = CAOFDTO.Count;
                    for (int i = 0; i < CAOFDTO.Count; i++)
                    {
                        PFMDTO00001 tempCustDTO = new PFMDTO00001();
                        tempCustDTO = this.CustomerDAO.SelectCustomerByCustID(CAOFDTO[i].CustomerID);
                        if (i == 0)
                        {
                            CustomerDTO.Name = tempCustDTO.Name;
                            CustomerDTO.NRC = tempCustDTO.NRC;
                        }
                        else
                        {
                            CustomerDTO.Name += tempCustDTO.Name;
                            CustomerDTO.NRC += tempCustDTO.NRC;
                        }
                        if (i < CAOFDTO.Count - 1)
                        {
                            CustomerDTO.Name += ", ";
                            CustomerDTO.NRC += ", ";
                        }
                    }
                    for (int j = 0; j < tempCount; j++)
                    {
                        PFMDTO00001 tempCustDTO = new PFMDTO00001();
                        tempCustDTO = this.CustomerDAO.SelectCustomerByCustID(CAOFDTO[j].CustomerID);
                        if (j == 0)
                        {
                            CustomerDTO.PhoneNo = String.IsNullOrEmpty(tempCustDTO.PhoneNo)?"-":tempCustDTO.PhoneNo;
                            CustomerDTO.Address = String.IsNullOrEmpty(tempCustDTO.Address) ? "-" : tempCustDTO.Address;
                            CustomerDTO.TownshipDesp = String.IsNullOrEmpty(tempCustDTO.TownshipDesp) ? "-" : tempCustDTO.TownshipDesp;
                        }
                        else
                        {
                            CustomerDTO.PhoneNo += tempCustDTO.PhoneNo;
                            CustomerDTO.Address += tempCustDTO.Address;
                            CustomerDTO.TownshipDesp += tempCustDTO.TownshipDesp;
                        }
                        if (j < tempCount - 1)
                        {
                            CustomerDTO.PhoneNo += "; ";
                            CustomerDTO.Address += "; ";
                            CustomerDTO.TownshipDesp += "; ";
                        }
                    }                   
                    //CustomerDTO.PhoneNo = CAOFDTO.First().PhoneNo;
                    //CustomerDTO.Address = CAOFDTO.First().Address;
                    //CustomerDTO.TownshipDesp = CAOFDTO.First().Township_Code;
                }
                else
                {
                    string tempTCode;
                    CustomerDTO.AccountNo = CAOFDTO.First().CledgerAccountNo;
                    CustomerDTO.Name = CAOFDTO.First().Name;
                    CustomerDTO.NRC = CAOFDTO.First().NRC;
                    CustomerDTO.Address = CAOFDTO.First().Address;
                    CustomerDTO.PhoneNo = CAOFDTO.First().PhoneNo;
                    tempTCode = CAOFDTO.First().Township_Code;

                    TownshipDTO tDesp= new TownshipDTO();
                    tDesp = this.CustomerDAO.SelectTownship(tempTCode);
                    CustomerDTO.TownshipDesp = tDesp.Description;
                }
                #endregion
            }
            else if(accountSign == "S")
            {
                #region Old Code
                //PFMDTO00016 SAOFDTO = new PFMDTO00016();
                //SAOFDTO = this.CodeChecker.GetSAOFsByAccountNumber(accountNo).First();
                //CustomerDTO.CustomerId = SAOFDTO.Customer_Id;
                #endregion

                #region Modify Code By HWKO (17-May-2017)
                IList<PFMDTO00016> SAOFDTO = new List<PFMDTO00016>();
                SAOFDTO = this.CodeChecker.GetSAOFsByAccountNumber(accountNo);
                if (accountType == "I" || accountType == "P")
                {
                    CustomerDTO = this.CustomerDAO.SelectCustomerByCustID(SAOFDTO.First().Customer_Id);
                }
                else if (accountType == "J")
                {
                    CustomerDTO.AccountNo = SAOFDTO.First().CledgerAccountNo;
                    for (int i = 0; i < SAOFDTO.Count; i++)
                    {
                        PFMDTO00001 tempCustDTO = new PFMDTO00001();
                        tempCustDTO = this.CustomerDAO.SelectCustomerByCustID(SAOFDTO[i].Customer_Id);
                        if (i == 0)
                        {
                            CustomerDTO.Name = tempCustDTO.Name;
                            CustomerDTO.NRC = tempCustDTO.NRC;
                        }
                        else
                        {
                            CustomerDTO.Name += tempCustDTO.Name;
                            CustomerDTO.NRC += tempCustDTO.NRC;
                        }
                        if (i < SAOFDTO.Count - 1)
                        {
                            CustomerDTO.Name += ", ";
                            CustomerDTO.NRC += ", ";
                        }
                    }
                    CustomerDTO.PhoneNo = SAOFDTO.First().PhoneNo;
                    CustomerDTO.Address = SAOFDTO.First().Address;
                    CustomerDTO.TownshipDesp = SAOFDTO.First().Township_Code;
                }
                else
                {
                    CustomerDTO.AccountNo = SAOFDTO.First().CledgerAccountNo;
                    CustomerDTO.Name = SAOFDTO.First().Name;
                    CustomerDTO.NRC = SAOFDTO.First().NRC;
                    CustomerDTO.Address = SAOFDTO.First().Address;
                    CustomerDTO.PhoneNo = SAOFDTO.First().PhoneNo;
                    CustomerDTO.TownshipDesp = SAOFDTO.First().Township_Code;
                }
                #endregion
            }
            else if (accountSign == "F")
            {                
                #region Modify Code By HWKO (17-May-2017)
                IList<PFMDTO00021> FAOFDTO = new List<PFMDTO00021>();
                FAOFDTO = this.CodeChecker.GetFAOFsByAccountNumber(accountNo);
                if (accountType == "I" || accountType == "P")
                {
                    CustomerDTO = this.CustomerDAO.SelectCustomerByCustID(FAOFDTO.First().CustomerId);
                }
                else if (accountType == "J")
                {
                    CustomerDTO.AccountNo = FAOFDTO.First().FledgerAccountNo;
                    for (int i = 0; i < FAOFDTO.Count; i++)
                    {
                        PFMDTO00001 tempCustDTO = new PFMDTO00001();
                        tempCustDTO = this.CustomerDAO.SelectCustomerByCustID(FAOFDTO[i].CustomerId);
                        if (i == 0)
                        {
                            CustomerDTO.Name = tempCustDTO.Name;
                            CustomerDTO.NRC = tempCustDTO.NRC;
                        }
                        else
                        {
                            CustomerDTO.Name += tempCustDTO.Name;
                            CustomerDTO.NRC += tempCustDTO.NRC;
                        }
                        if (i < FAOFDTO.Count - 1)
                        {
                            CustomerDTO.Name += ", ";
                            CustomerDTO.NRC += ", ";
                        }
                    }
                    CustomerDTO.PhoneNo = FAOFDTO.First().Phone;
                    CustomerDTO.Address = FAOFDTO.First().Address;
                    CustomerDTO.TownshipDesp = FAOFDTO.First().Township_Code;
                }
                else
                {
                    CustomerDTO.AccountNo = FAOFDTO.First().FledgerAccountNo;
                    CustomerDTO.Name = FAOFDTO.First().Name;
                    CustomerDTO.NRC = FAOFDTO.First().NRC;
                    CustomerDTO.Address = FAOFDTO.First().Address;
                    CustomerDTO.PhoneNo = FAOFDTO.First().Phone;
                    CustomerDTO.TownshipDesp = FAOFDTO.First().Township_Code;
                }
                #endregion
            }

            else if (accountSign == "D")
            {
                #region Modify Code By AAM (20-Nov-2017)
                IList<PFMDTO00017> CAOFDTO = new List<PFMDTO00017>();
                CAOFDTO = this.CodeChecker.GetCAOFsByAccountNumber(accountNo);
                if (accountType == "I" || accountType == "D")
                {
                    CustomerDTO = this.CustomerDAO.SelectCustomerByCustID(CAOFDTO.First().CustomerID);
                }
                else if (accountType == "J")
                {
                    CustomerDTO.AccountNo = CAOFDTO.First().CledgerAccountNo;
                    for (int i = 0; i < CAOFDTO.Count; i++)
                    {
                        PFMDTO00001 tempCustDTO = new PFMDTO00001();
                        tempCustDTO = this.CustomerDAO.SelectCustomerByCustID(CAOFDTO[i].CustomerID);
                        if (i == 0)
                        {
                            CustomerDTO.Name = tempCustDTO.Name;
                            CustomerDTO.NRC = tempCustDTO.NRC;
                        }
                        else
                        {
                            CustomerDTO.Name += tempCustDTO.Name;
                            CustomerDTO.NRC += tempCustDTO.NRC;
                        }
                        if (i < CAOFDTO.Count - 1)
                        {
                            CustomerDTO.Name += ", ";
                            CustomerDTO.NRC += ", ";
                        }
                    }
                    CustomerDTO.PhoneNo = CAOFDTO.First().PhoneNo;
                    CustomerDTO.Address = CAOFDTO.First().Address;
                    CustomerDTO.TownshipDesp = CAOFDTO.First().Township_Code;
                }
                else
                {
                    CustomerDTO.AccountNo = CAOFDTO.First().CledgerAccountNo;
                    CustomerDTO.Name = CAOFDTO.First().Name;
                    CustomerDTO.NRC = CAOFDTO.First().NRC;
                    CustomerDTO.Address = CAOFDTO.First().Address;
                    CustomerDTO.PhoneNo = CAOFDTO.First().PhoneNo;
                    CustomerDTO.TownshipDesp = CAOFDTO.First().Township_Code;
                }
                #endregion
            }
            //CustomerDTO = this.CustomerDAO.SelectCustomerByCustID(CustomerDTO.CustomerId);
            return CustomerDTO;
        }
    }
}
