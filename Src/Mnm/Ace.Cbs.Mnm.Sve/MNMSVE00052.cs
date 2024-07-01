using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Windows.Core.Service;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Mnm.Dmd.DTO;

namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00052 : BaseService,IMNMSVE00052
    {
        #region Properties
        ICXDAO00009 ViewDAO { get; set; }
        IPFMDAO00028 CledgerDAO { get; set; }
        ICXDAO00006 CustomerDAO {get;set;}
        ICXSVE00010 DataGenerateService { get; set; }
        IList<PFMDTO00001> CustomerInfo { get; set; }
        public PFMDTO00001 CommonDto = new PFMDTO00001();      
        #endregion

        #region MainMethod
        public IList<PFMDTO00042> GetReportData(PFMDTO00042 DataDTO,int workStationId,int createdUserId)
        {
            IList<PFMDTO00042> PrintDataList = new List<PFMDTO00042>();
            
            PFMDTO00042 ReportData = GetDataForReportTLF(DataDTO,workStationId,createdUserId);

            return PrintDataList;
        }

        public IList<PFMDTO00001> SelectBankStatementAll_ByAcctNo(string AcctNo, DateTime startPeriod, DateTime endPeriod, string sourceBr, string formName)
        {
            IList<PFMDTO00001> PrintDataList = new List<PFMDTO00001>();
            IList<PFMDTO00042> ReportDataList = new List<PFMDTO00042>();           
           
            //int m_Count = 0;
            decimal mem_Balance = 0;

            #region For Specific
            if (formName == "Current Specific" || formName == "Saving Specific")
            {
                PFMDTO00001 PrintData = new PFMDTO00001();
                mem_Balance = this.GetBalance(AcctNo, startPeriod, endPeriod,sourceBr);               

                ReportDataList = this.ViewDAO.SelectBankStatement_ByAcctNo(AcctNo, startPeriod, endPeriod, sourceBr);
                if (ReportDataList.Count > 0)   // if (PrintDataList.Count > 0)
                {
                    int WithCount = 0;
                    int DepCount = 0;
                    //for Opening Balance ... if OpBalance is 0 then not display
                        PrintData.MonthOpeningBalance = mem_Balance;

                    //'Display Data For Report
                    for (int i = 0; i < ReportDataList.Count; i++)
                    {
                        if (ReportDataList[i].DebitTotal != 0)
                        {
                            mem_Balance = mem_Balance - ReportDataList[i].DebitTotal;
                            WithCount = WithCount + 1;
                        }
                        else
                        {
                            mem_Balance = mem_Balance + ReportDataList[i].CreditTotal;
                            DepCount = DepCount + 1;
                        }
                        PrintData.MinimumBalance = mem_Balance;
                        PrintData.DATE_TIME = ReportDataList[i].TIME;
                        PrintData.Description = ReportDataList[i].Description;
                        PrintData.WithdrawAmount = ReportDataList[i].DebitTotal;
                        PrintData.DepositAmount = ReportDataList[i].CreditTotal;
                    }
                    PrintData.TransactionCount = WithCount;
                    PrintData.LoansCount = DepCount;
                }
                else
                {
                    ServiceResult.ErrorOccurred = true;
                    ServiceResult.MessageCode = "MI00039";
                    return PrintDataList;
                }
                //PFMDTO00028 GetAcSign = CustomerDAO.GetAccountInfoOfCledgerByAccountNoAndSourceBranch(AcctNo, CurrentUserEntity.BranchCode);  //Get AcSign from Cledger
                PFMDTO00028 GetAcSign = CustomerDAO.GetAccountInfoOfCledgerByAccountNoAndSourceBranch(AcctNo, sourceBr); 
                IList<PFMDTO00001> GetCustId = CustomerDAO.GetCustomerInformationBySAOForCAOF(AcctNo, GetAcSign.AccountSign.Substring(0, 1)); //Get CustId
                //PFMDTO00001 GetCustomerInfo = CustomerDAO.GetCustomerInfo(GetCustId[0].CustomerId, CurrentUserEntity.BranchCode);
                PFMDTO00001 GetCustomerInfo = CustomerDAO.GetCustomerInfomation(GetCustId[0].CustomerId);
                if (GetCustomerInfo != null)
                {
                    //Return PrintDataList for report               
                    PrintData.Name = GetCustomerInfo.Name;
                    PrintData.NRC = GetCustomerInfo.NRC;
                    PrintData.Address = GetCustomerInfo.Address;
                    PrintData.TownshipCode = GetCustomerInfo.TownshipCode;
                    PrintData.PhoneNo = GetCustomerInfo.PhoneNo;
                    PrintData.AccountNo = AcctNo;
                    //PrintData.MonthOpeningBalance = mem_Balance;
                    PrintDataList.Add(PrintData);
                }
                else
                {
                    ServiceResult.ErrorOccurred = true;
                    ServiceResult.MessageCode = "MI00039";
                    return PrintDataList;
                }
            }

            #endregion

            #region For All
            else if (formName == "Current All" || formName == "Saving All")
            {
                PrintDataList = this.ViewDAO.SelectBankStatementAll_ByAcctNo(AcctNo, startPeriod, endPeriod, sourceBr);
                if (PrintDataList.Count > 0)
                {
                    PFMDTO00001 PrintData = new PFMDTO00001();
                    mem_Balance = this.GetBalance(AcctNo, startPeriod, endPeriod,sourceBr);
                    if (mem_Balance != 0) //for Opening Balance ... if OpBalance is 0 then not display
                    {
                        PFMDTO00001 OpeningData = new PFMDTO00001();
                        OpeningData.Description = "Opening Balance";
                        OpeningData.WithdrawAmount = 0;
                        OpeningData.DepositAmount = 0;
                        OpeningData.MinimumBalance = mem_Balance;
                        PrintDataList.Add(OpeningData);
                    }

                    //'Display Data For Report
                    for (int i = 0; i < PrintDataList.Count; i++)
                    {
                        if (PrintDataList[i].WithdrawAmount != 0)
                        {
                            mem_Balance = mem_Balance - PrintDataList[i].WithdrawAmount;
                        }
                        else
                        {
                            mem_Balance = mem_Balance + PrintDataList[i].DepositAmount;
                        }
                        PrintDataList[i].MinimumBalance = mem_Balance;      
                    }                
                    //PrintDataList.Add(PrintData);
                }
            }

            #endregion

            return PrintDataList;        
        }

        public PFMDTO00042 GetDataForReportTLF(PFMDTO00042 DataDTO,int workStationId,int createdUserId)
        {
            PFMDTO00042 DataGenerateDTO = new PFMDTO00042();

            CXDTO00006 reportparameters = new CXDTO00006();
            reportparameters.AccountNo = DataDTO.AcctNo;
            if (DataDTO.AccountSign == null || DataDTO.AccountSign == string.Empty)
            {
                reportparameters.ACSign = null;
            }
            else
            {
                reportparameters.ACSign = DataDTO.AccountSign.Substring(0, 1) + "%";
            }
            reportparameters.StartDate = DataDTO.StartDate;
            reportparameters.EndDate = DataDTO.EndDate;
            reportparameters.CreatedUserId = createdUserId;
            reportparameters.WorkStationId = workStationId;
            reportparameters.UserNo = workStationId.ToString();
            //reportparameters.UserNo = createdUserId.ToString();
            reportparameters.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
            reportparameters.BDateType = "T";
            reportparameters.SpecialCondition = "sourceBr = '" + DataDTO.SourceBranch + "'";

            DataGenerateDTO = this.DataGenerateService.GetReportDataGenerateInSQL(reportparameters);
            return DataGenerateDTO;
        }

        public IList<PFMDTO00001> SelectCustomerInfoAll(string sourcebr,string formName)
        {
            if (formName.Contains("Current"))
            {
                CustomerInfo = this.ViewDAO.SelectCurrentAC_All(sourcebr);
            }

            else if (formName.Contains("Saving"))
            {
                CustomerInfo= this.ViewDAO.SelectSavingAC_All(sourcebr);
            }
            return CustomerInfo;
        }

        public string CheckingAccountNo(string accountNo, string branchCode, string formName)
        {
            PFMDTO00028 cledgerAccount = this.CledgerDAO.SelectACSignByAccountNo(accountNo); 

            if (cledgerAccount == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00175;    //Account No Not Found
                return null;
            }
            if (cledgerAccount.CloseDate != null && cledgerAccount.CloseDate.ToString() != "" && cledgerAccount.CloseDate != default(DateTime))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00044;     //Account has been Closed
                return null;
            }                     
            if (cledgerAccount.AccountSign.Substring(0, 1) == "C" && cledgerAccount.AccountSign.Substring(0, 1) != formName.Substring(0, 1))
            {
                this.ServiceResult.MessageCode = CXMessage.MV00046; //Invalid Saving Ac   
                return null;
            }           

            if (cledgerAccount.AccountSign.Substring(0, 1) == "S" && cledgerAccount.AccountSign.Substring(0, 1) != formName.Substring(0, 1))
            {
                this.ServiceResult.MessageCode = CXMessage.MV00046; //Invalid Current Ac 
                return null;
            }
            return cledgerAccount.AccountSign;
        }

        public decimal GetBalance(string AcctNo, DateTime startPeriod, DateTime endPeriod,string sourceBr)
        {
            string month = string.Empty; 
            decimal amt = 0;

            // 'Yearly Closing Modify
            string budYear = CXCOM00010.Instance.GetBudgetYear4(CXCOM00009.BudgetYearCode, startPeriod).ToString();

            if (startPeriod.Month > 3)
            {
                month = Convert.ToString(startPeriod.Month - 3);
            }
            else
            {
                month = Convert.ToString(startPeriod.Month + 9);
            }
            //PFMDTO00033 ObjBalance = this.ViewDAO.SelectBalance_ByAcctNoAndBudYear(month, AcctNo, budYear, CurrentUserEntity.BranchCode); //VW_BAL
            PFMDTO00033 ObjBalance = this.ViewDAO.SelectBalance_ByAcctNoAndBudYear(month, AcctNo, budYear, sourceBr); //VW_BAL
            if (ObjBalance != null)
            {
                switch (month)
                {
                    case "1": decimal M1 = ObjBalance.Month1;
                        amt = M1;
                        break;

                    case "2": decimal M2 = ObjBalance.Month2;
                        amt = M2;
                        break;

                    case "3": decimal M3 = ObjBalance.Month3;
                       amt = M3;
                        break;

                    case "4": decimal M4 = ObjBalance.Month4;
                        amt = M4;
                        break;

                    case "5": decimal M5 = ObjBalance.Month5;
                        amt = M5;
                        break;

                    case "6": decimal M6 = ObjBalance.Month6;
                        amt = M6;
                        break;

                    case "7": decimal M7 = ObjBalance.Month7;
                        amt = M7;
                        break;

                    case "8": decimal M8 = ObjBalance.Month8;
                        amt = M8;
                        break;

                    case "9": decimal M9 = ObjBalance.Month9;
                        amt = M9;
                        break;

                    case "10": decimal M10 = ObjBalance.Month10;
                        amt = M10;
                        break;

                    case "11": decimal M11 = ObjBalance.Month11;
                        amt = M11;
                        break;

                    case "12": decimal M12 = ObjBalance.Month12;
                        amt = M12;
                        break;

                    default:
                        amt = 0;
                        break;
                }                
            }
            else
            {
                amt = 0;
            }
            return amt;      
        }

        #endregion
    }
}
