using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.Core.Service;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using NHibernate;
using Spring.Data.NHibernate.Support;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.CXServer.Utt;

namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00046 : BaseService, IMNMSVE00046
    {
        #region DAO
        public ICXDAO00009 ViewDAO { get; set; }
        public IMNMDAO00046 CurrentAllDAO { get; set; }
        public ICXSVE00010 DataGenerateService { get; set; } 
        
        #endregion

        #region Method
        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00001> SelectCurrentAC_AllByMonth(string month, string sourceBr)
        {
            IList<PFMDTO00001> DataList = new List<PFMDTO00001>();

            DataList = ViewDAO.SelectCurrentAC_AllByMonth(month, sourceBr);

            return DataList;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00001> SelectSavingAC_AllByMonth(string month, string sourceBr)
        {
            IList<PFMDTO00001> DataList = new List<PFMDTO00001>();

            DataList = ViewDAO.SelectSavingAC_AllByMonth(month, sourceBr);

            return DataList;
        }

        [Transaction(TransactionPropagation.Required)]
        public int BankSatatementByWithdrawAmount(string workstation, string accountNo, int year, int month)
        {
            IList<PFMDTO00042> DataList = new List<PFMDTO00042>();
            int count;

            DataList = ViewDAO.BankSatatementByWithdrawAmount(workstation, accountNo, year, month);
            if (DataList.Count > 0)
            {
                count = DataList.Count;
            }
            else
            {
                count = 0;
            }
            return count;
        }

        [Transaction(TransactionPropagation.Required)]
        public int BankSatatementByDepositAmount(string workstation, string accountNo, int year, int month)
        {
            IList<PFMDTO00042> DataList = new List<PFMDTO00042>();
            int count;

            DataList = ViewDAO.BankSatatementByDepositAmount(workstation, accountNo, year, month);
            
            if (DataList.Count > 0)
            {
                count = DataList.Count;
            }
            else
            {
                count = 0;
            }
            return count;
        }

        public IList<MNMDTO00046> BankSatatementByAllWithdrawDeposit(string accountNo,  string workstation, int year, int month, int currentUserId,string branchCode)
        {
            IList<MNMDTO00046> ReportDataList = new List<MNMDTO00046>();               
            try
            {
                this.GetReportData(month, year, Convert.ToInt32(workstation), currentUserId); //To insert report_tlf
                string acsign = this.SelectAccountSign(accountNo, branchCode); //To get account signature
                IList<PFMDTO00001> CustInfoDtoList = new List<PFMDTO00001>();
                if (CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurrentAccountSign) == acsign.Substring(0, 1) || CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavingAccountSign) == acsign.Substring(0, 1))
                {
                    //To get Customer Information for Current and Saving Accoounts
                    CustInfoDtoList = CXServiceWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00001>>(x => x.GetCustomerInfomationByAccountNo(accountNo, false));
                }
                else
                {
                    throw new Exception(CXMessage.MV20054);//Invalid Account Type
                }
                    IList<PFMDTO00042> WDDTOList = new List<PFMDTO00042>();
                    WDDTOList = ViewDAO.BankSatatementByAllWithdrawDeposit(workstation, accountNo, year, month);
                    WDDTOList[0].DepositCount = this.BankSatatementByDepositAmount(workstation, accountNo, year, month);
                    WDDTOList[0].WithdrawalCount = this.BankSatatementByDepositAmount(workstation, accountNo, year, month);

                    decimal mem_Balance = 0;
                 
                    MNMDTO00046 ReportDTO = new MNMDTO00046();

                    mem_Balance = this.GetBalance(accountNo , month, branchCode, year);
                    if (CustInfoDtoList.Count > 1)
                    {
                        foreach (PFMDTO00001 custdto in CustInfoDtoList)
                        {
                            if (custdto.CustomerId != null)
                            {
                                //ReportDTO.CustomerId = ReportDTO.CustomerId + "," + custdto.CustomerId;
                                ReportDTO.Name = ReportDTO.Name + ", " + custdto.Name;
                                ReportDTO.NRC = ReportDTO.NRC + ", " + custdto.NRC;
                            }
                        }

                        ReportDTO.Name = ReportDTO.Name.Remove(0, 2);
                        ReportDTO.NRC = ReportDTO.NRC.Remove(0, 2);

                        if (CustInfoDtoList[0].CustomerId != null)
                        {
                            ReportDTO.Address = CustInfoDtoList[0].Address + ",";
                            ReportDTO.TownshipCode = CustInfoDtoList[0].TownshipCode + ",";
                            ReportDTO.TownshipDesp = CustInfoDtoList[0].CityDesp + ",";
                            ReportDTO.CityCode = CustInfoDtoList[0].TownshipDesp;
                            ReportDTO.PhoneNo = CustInfoDtoList[0].PhoneNo ;
                        }
                        else
                        {
                            ReportDTO.Address = CustInfoDtoList[1].Address + ",";
                            ReportDTO.TownshipCode = CustInfoDtoList[1].TownshipCode + ",";
                            ReportDTO.TownshipDesp = CustInfoDtoList[1].CityDesp + ",";
                            ReportDTO.CityCode = CustInfoDtoList[1].TownshipDesp;
                            ReportDTO.PhoneNo = CustInfoDtoList[1].PhoneNo ;
                        }
                    }
                    else if(CustInfoDtoList.Count == 0)
                        throw new Exception(CXMessage.MV00175);// Shows message "Account No. Not Found." when account info are missing....
                    else
                    {
                        ReportDTO.CustomerId = CustInfoDtoList[0].CustomerId ;
                        ReportDTO.Name = CustInfoDtoList[0].Name ;
                        ReportDTO.NRC = CustInfoDtoList[0].NRC ;
                        ReportDTO.Address = CustInfoDtoList[0].Address + ",";
                        ReportDTO.TownshipCode = CustInfoDtoList[0].TownshipCode + ",";
                        ReportDTO.TownshipDesp = CustInfoDtoList[0].CityDesp + ",";
                        ReportDTO.CityCode = CustInfoDtoList[0].TownshipDesp ;
                        ReportDTO.PhoneNo = CustInfoDtoList[0].PhoneNo ;
                    }
                    ReportDTO.Amount = mem_Balance;
                    ReportDTO.AccountNo = CustInfoDtoList[0].AccountNo;
                    ReportDTO.WithdrawAmount = 0;
                    ReportDTO.DepositAmount = 0;
                    if (month.ToString().Length == 1)
                        ReportDTO.DATE_TIME = "01/" + "0" + month + "/" + year;
                    else
                        ReportDTO.DATE_TIME = "01/" + month + "/" + year;
                    ReportDTO.Description = "Opening Balance";
                    ReportDTO.Initial = WDDTOList[0].WithdrawalCount.ToString();
                    ReportDTO.InitialDesp = WDDTOList[0].DepositCount.ToString();
                    ReportDataList.Add(ReportDTO);

                    decimal balance = Convert.ToDecimal(ReportDTO.Amount);
                    if (WDDTOList.Count > 0)
                    {
                        foreach (PFMDTO00042 pfmdto in WDDTOList)
                        {
                            PFMDTO00001 CustomerDTO = new PFMDTO00001();
                            MNMDTO00046 rdto = new MNMDTO00046();

                            rdto.CustomerId = ReportDTO.CustomerId;
                            rdto.Name = ReportDTO.Name;
                            rdto.NRC = ReportDTO.NRC;
                            rdto.Address = ReportDTO.Address;
                            rdto.TownshipCode = ReportDTO.TownshipCode;
                            rdto.TownshipDesp = ReportDTO.TownshipDesp;
                            rdto.CityCode = ReportDTO.CityCode;
                            rdto.StateDesp = ReportDTO.StateDesp;
                            rdto.PhoneNo = ReportDTO.PhoneNo;
                            rdto.AccountNo = ReportDTO.AccountNo;
                            rdto.WithdrawAmount = Convert.ToDecimal(pfmdto.WithdrawalAmount);
                            rdto.DepositAmount = Convert.ToDecimal(pfmdto.DepositAmount);
                            //modify by ASDA
                            if (rdto.WithdrawAmount > 0)
                            {
                                balance = Convert.ToDecimal(balance - rdto.WithdrawAmount);
                            }
                            else
                            {
                                balance = Convert.ToDecimal(balance + rdto.DepositAmount);
                            }
                            rdto.Amount = balance;
                            DateTime dt = Convert.ToDateTime(pfmdto.DATE_TIME);
                            rdto.DATE_TIME = dt.ToString("dd/MM/yyyy");
                            //
                            rdto.Description = pfmdto.Description;
                            rdto.Remark = pfmdto.Cheque;
                            rdto.Initial = WDDTOList[0].WithdrawalCount.ToString();
                            rdto.InitialDesp = WDDTOList[0].DepositCount.ToString();

                            ReportDataList.Add(rdto);
                        }

                    }
              //  } end of foreach

                    return ReportDataList;
            }
            catch (Exception ex)
            {               
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.ToString();                     
            }

            return ReportDataList;
        }       
        
        //public IList<PFMDTO00001> SelectCustID(string accountNo, string budmonth, string budget, string acsign)
        //{
        //    IList<PFMDTO00017> dtolist = new List<PFMDTO00017>();
            
        //    if (acsign == "C")
        //    {
        //        dtolist = CurrentAllDAO.SelectCustID(accountNo);
        //    }
        //    else if (acsign == "S")
        //    {
        //        dtolist = CurrentAllDAO.SelectSCustID(accountNo);
        //    }

        //    IList<PFMDTO00001> custDTOList = new List<PFMDTO00001>();

        //   // custDTOList = this.
        //    foreach (PFMDTO00017 dto in dtolist)
        //    {
        //        PFMDTO00001 custDTO = new PFMDTO00001();
        //        custDTO = this.SelectCustInfoByCustID(dto.CustomerID);

        //        TownshipDTO townshipDTO = new TownshipDTO();
        //        townshipDTO = this.SelectTownshipDesp(custDTO.TownshipCode) ;
        //        custDTO.CityDesp = townshipDTO.Description;

        //        //PFMDTO00033 budgetDTO = new PFMDTO00033();
        //        //budgetDTO = this.SelectBudMonth(budmonth, accountNo, budget);
        //        //if (budgetDTO == null)
        //        //{ 
        //            //custDTO.Amount = 0; 
        //        //}
        //        //else
        //        //{ 
        //            //custDTO.Amount = budgetDTO.Month1; 
        //        //}
        //            custDTO.CustomerId = dto.CustomerID;
        //            custDTO.AccountNo = accountNo;
        //            custDTOList.Add(custDTO);
        //        }
        //    if (custDTOList == null || custDTOList.Count <= 0)
        //    {
        //        this.ServiceResult.ErrorOccurred = true;
        //        this.ServiceResult.MessageCode = "ME30012";    //Data Not Found
        //        return custDTOList;
        //    }

        //    return custDTOList;
        //}

        //public PFMDTO00001 SelectCustInfoByCustID(string custID)
        //{
        //    PFMDTO00001 dto = new PFMDTO00001();
        //    dto = CurrentAllDAO.SelectCustInfoByCustID(custID);
        //    if (dto == null)
        //        return new PFMDTO00001();
        //    return dto;
        //}

        //public TownshipDTO SelectTownshipDesp(string townshipCode)
        //{
        //    TownshipDTO dto = new TownshipDTO();
        //    dto = CurrentAllDAO.SelectTownship(townshipCode);
        //    if (dto == null )
        //    return new TownshipDTO();
        //    return dto;
        //}

        //public PFMDTO00033 SelectBudMonth(string month, string accountNo, string budget)
        //{
        //    PFMDTO00033 dto = new PFMDTO00033();
        //    dto = ViewDAO.VW_BAL_SelectMonth(month, accountNo, budget);  //Select M___ from VW_BAL where AcctNo = '203111000000017' And Budget='2014/2015'
        //    if (dto == null)
        //    return new PFMDTO00033();
        //    return dto;
        //}

        public string SelectAccountSign(string accountNo, string sourceBr)
        {
            PFMDTO00028 dto = new PFMDTO00028();
            dto = CurrentAllDAO.SelectAccountSign(accountNo, sourceBr);
            if (dto == null)
            {
                return null;
            }
            else
            {
                return dto.AccountNo;
            }
        }

        public void GetReportData(int month, int year,int workStationId, int currentUserId)
        {
            PFMDTO00042 ReportTlfData = this.GetDataForReportTLF(month, year,workStationId, currentUserId);
        }

        public PFMDTO00042 GetDataForReportTLF(int month, int year,int workStationId, int currentUserId)
        {
            PFMDTO00042 DataGenerateDTO = new PFMDTO00042();

            CXDTO00006 reportparameters = new CXDTO00006();
            reportparameters.StartDate = Convert.ToDateTime(year + "-" + month + "-01");
            if (year != DateTime.Now.Year)
            {
                int endday = 0;
                    switch (month)
                    {
                        case 1: endday = 31;     //January
                            break;
                        case 2:
                            if (DateTime.IsLeapYear(reportparameters.StartDate.Year))
                                endday = 29;  //February
                            else
                                endday = 28; 
                            break;
                        case 3: endday = 31;   //March
                            break;
                        case 4: endday = 30;  //April
                            break;
                        case 5: endday = 31;   //May
                            break;
                        case 6: endday = 30;  //June
                            break;
                        case 7: endday = 31;  //July
                            break;
                        case 8: endday = 31;  //August
                            break;
                        case 9: endday = 30;  //September
                            break;
                        case 10: endday = 31;  //October
                            break;
                        case 11: endday = 30;  //November
                            break;
                        case 12: endday = 31;  //December                    
                            break;
                    }
                    reportparameters.EndDate = Convert.ToDateTime(year + "-" + month + "-" + endday);
            }
            else
            {
                reportparameters.EndDate = DateTime.Now;                   
            }
            reportparameters.BDateType = "T";
            reportparameters.CreatedUserId = currentUserId;
            reportparameters.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
            reportparameters.WorkStationId = workStationId;
       reportparameters.UserNo = Convert.ToString(workStationId);

            DataGenerateDTO = this.DataGenerateService.GetReportDataGenerateInSQL(reportparameters);
            return DataGenerateDTO;
        }
     
        public decimal GetBalance(string AcctNo, int startPeriod, string sourceBr,int year)
        {
            string month = string.Empty;
            decimal amt = 0;
            int BudgetMonth;

            // 'Yearly Closing Modify
            //string budYear = CXCOM00010.Instance.GetBudgetYear4(CXCOM00009.BudgetYearCode, startPeriod).ToString();
            string budYear = year + "/" + Convert.ToString((year + 1));
            if (startPeriod.ToString().StartsWith(Decimal.Zero.ToString()))
                BudgetMonth = Convert.ToInt16(startPeriod.ToString().Substring(1, 1));
            else
                BudgetMonth = startPeriod;

            if (BudgetMonth > 3)
            {
                month = Convert.ToString(startPeriod - 3);
            }
            else
            {
                month = Convert.ToString(startPeriod + 9);
            }
            //PFMDTO00033 ObjBalance = this.ViewDAO.SelectBalance_ByAcctNoAndBudYear(month, AcctNo, budYear, CurrentUserEntity.BranchCode); //VW_BAL
            PFMDTO00033 ObjBalance = this.SelectBalance_ByAcctNoAndBudYear(month, AcctNo, budYear, sourceBr);
            //PFMDTO00033 ObjBalance = this.ViewDAO.SelectBalance_ByAcctNoAndBudYear(month, AcctNo, budYear, sourceBr); //VW_BAL
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

        public PFMDTO00033 SelectBalance_ByAcctNoAndBudYear(string month, string AcctNo, string budYear, string sourceBr)
        {
            PFMDTO00033 dto = new PFMDTO00033();
            dto = this.ViewDAO.SelectBalance_ByAcctNoAndBudYear(month, AcctNo, budYear, sourceBr);
            //if (dto == null)
            //    return new PFMDTO00033();
            return dto;
        }
      
        #endregion

      
    }
}
