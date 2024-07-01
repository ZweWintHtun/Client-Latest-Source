using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Windows.Core.Presenter;
using Ace.Windows.CXClient;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00046 : AbstractPresenter, IMNMCTL00046
    {
        #region Properties
        IList<PFMDTO00001> ReportDTOList { get; set; }
        string type = null;
        public int WithdrawCount;
        public int DepositCount;
        public decimal? Amount;
        string accountSign = string.Empty;
        public IList<PFMDTO00001> CustDTOList;
        public ICXDAO00009 ViewDAO { get; set; }
        private IMNMVEW00046 view;
        public IMNMVEW00046 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        #endregion

        #region Method

        private void WireTo(IMNMVEW00046 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetEntity());
            }
        }

        public bool Validate_Form()
        {
            return this.ValidateForm(this.GetEntity());
        }                

        public PFMDTO00001 GetEntity()
        {
            PFMDTO00001 entity = new PFMDTO00001();            
            entity.Year = this.view.Year;
            entity.Month = this.view.Month;
            entity.SourceBranch = CurrentUserEntity.BranchCode;

            return entity;
        }        

        public bool Print()
        {
            if (Validate_Form())
            {
                return true;
            }
            return false;
        }
                    
        public void ViewReport(IList<PFMDTO00001> AccountList, string formname)
        {          
            //string budget = this.view.Year + "/" + Convert.ToString((this.view.Year + 1));
            //string budgetmonthcalculate = "M" + Convert.ToInt32(CXCOM00010.Instance.GetBudgetYear2(CXCOM00009.BudgetYearCode, DateTime.Now));
            
            if (AccountList.Count > 0)
            {
                string workstation = CurrentUserEntity.WorkStationId.ToString();
                foreach (PFMDTO00001 dto in AccountList)
                {
                    #region oldcode
                    //try
                    //{
                    //    IList<MNMDTO00046> custDTOList = new List<MNMDTO00046>(); 
                    //    MNMDTO00046 ReportDTO = new MNMDTO00046();
                    //    this.WithdrawCount = CXClientWrapper.Instance.Invoke<IMNMSVE00046, int>(x => x.BankSatatementByWithdrawAmount(workstation, dto.AccountNo, this.view.Year, this.view.Month));  //Select Count(WithdrawAmount) from VW_BANK_STATEMENT_ByDate
                    //    this.DepositCount = CXClientWrapper.Instance.Invoke<IMNMSVE00046, int>(x => x.BankSatatementByDepositAmount(workstation, dto.AccountNo, this.view.Year, this.view.Month));    //Select Count(DepositAmount) from VW_BANK_STATEMENT_ByDate
                    //    accountSign = CXClientWrapper.Instance.Invoke<IMNMSVE00046, string>(x => x.SelectAccountSign(dto.AccountNo, CurrentUserEntity.BranchCode));   //Select top 1 ACSIGN From Cledger
                    //    if (accountSign.Substring(0, 1) == "C" && formname.Contains("Current"))
                    //    {
                    //        this.CustDTOList = CXClientWrapper.Instance.Invoke<IMNMSVE00046, IList<PFMDTO00001>>(x => x.SelectCustID(dto.AccountNo, budgetmonthcalculate, budget, "C"));    //'Select TOP 1 CustId from Caof (PFMORM00017.hbm.xml)
                    //        if(CustDTOList == null || CustDTOList.Count <= 0)
                    //            CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);//No transactions to print.
                    //        else this.type = "C";
                    //    }
                    //    else if (accountSign.Substring(0, 1) == "S" && formname.Contains("Saving"))
                    //    {
                    //        this.CustDTOList = CXClientWrapper.Instance.Invoke<IMNMSVE00046, PFMDTO00001>(x => x.SelectCustID(dto.AccountNo, budgetmonthcalculate, budget, "S")); //'Select TOP 1 CustId from Caof (PFMORM00017.hbm.xml)  -- Amount 
                    //        this.type = "S";
                    //    }
                    //    else
                    //    {
                    //        CXUIMessageUtilities.ShowMessageByCode("MV20054"); //Invalid Account Type.
                    //    }

                    //    IList<PFMDTO00042> BankStateDTO = CXClientWrapper.Instance.Invoke<IMNMSVE00046, IList<PFMDTO00042>>(x => x.BankSatatementByAllWithdrawDeposit(workstation, dto.AccountNo, this.view.Year, this.view.Month));  //Select acctno,Date_Time,Description ,WithdrawAmount,DepositAmount,Cheque from VW_BANK_STATEMENT_ByDate                       
                    //    IList<MNMDTO00046> List = new List<MNMDTO00046>();
                    //    decimal mem_Balance = 0;
                    //    mem_Balance = this.GetBalance(CustDTOList[0].AccountNo, this.view.Month, CurrentUserEntity.BranchCode);
                    //    if (CustDTOList.Count > 1)
                    //    {
                    //        foreach (PFMDTO00001 custdto in CustDTOList)
                    //        {
                    //            if (custdto.CustomerId != null)
                    //            {
                    //                //ReportDTO.CustomerId = ReportDTO.CustomerId + "," + custdto.CustomerId;
                    //                ReportDTO.Name = ReportDTO.Name + ", " + custdto.Name;
                    //                ReportDTO.NRC = ReportDTO.NRC + ", " + custdto.NRC;
                    //            }
                    //        }

                    //        ReportDTO.Name = ReportDTO.Name.Remove(0, 2);
                    //        ReportDTO.NRC = ReportDTO.NRC.Remove(0, 2);

                    //        if (CustDTOList[0].CustomerId != null)
                    //        {
                    //            ReportDTO.Address = CustDTOList[0].Address + ",";
                    //            ReportDTO.TownshipCode = CustDTOList[0].TownshipCode + ",";
                    //            ReportDTO.TownshipDesp = CustDTOList[0].CityDesp + ",";
                    //            ReportDTO.CityCode = CustDTOList[0].TownshipDesp + ",";
                    //            ReportDTO.PhoneNo = CustDTOList[0].PhoneNo + ",";
                    //        }
                    //        else
                    //        {
                    //            ReportDTO.Address = CustDTOList[1].Address + ",";
                    //            ReportDTO.TownshipCode = CustDTOList[1].TownshipCode + ",";
                    //            ReportDTO.TownshipDesp = CustDTOList[1].CityDesp + ",";
                    //            ReportDTO.CityCode = CustDTOList[1].TownshipDesp + ",";
                    //            ReportDTO.PhoneNo = CustDTOList[1].PhoneNo + ",";
                    //        }
                    //    }
                    //    else
                    //    {
                    //        ReportDTO.CustomerId = CustDTOList[0].CustomerId + ",";
                    //        ReportDTO.Name = CustDTOList[0].Name + ",";
                    //        ReportDTO.NRC = CustDTOList[0].NRC + ",";
                    //        ReportDTO.Address = CustDTOList[0].Address + ",";
                    //        ReportDTO.TownshipCode = CustDTOList[0].TownshipCode + ",";
                    //        ReportDTO.TownshipDesp = CustDTOList[0].CityDesp + ",";
                    //        ReportDTO.CityCode = CustDTOList[0].TownshipDesp + ",";
                    //        ReportDTO.PhoneNo = CustDTOList[0].PhoneNo + ",";
                    //    }
                    //    ReportDTO.Amount = mem_Balance;
                    //    ReportDTO.AccountNo = CustDTOList[0].AccountNo;
                    //    ReportDTO.WithdrawAmount = 0;
                    //    ReportDTO.DepositAmount = 0;
                    //    if (this.view.Month.ToString().Length == 1)
                    //        ReportDTO.DATE_TIME = "01/" + "0"+ this.view.Month + "/" + this.view.Year;
                    //    else
                    //        ReportDTO.DATE_TIME = "01/" + this.view.Month + "/" + this.view.Year;
                    //    ReportDTO.Description = "Opening Balance";
                    //    ReportDTO.Initial = WithdrawCount.ToString();
                    //    ReportDTO.InitialDesp = DepositCount.ToString();
                    //    custDTOList.Add(ReportDTO);

                    //    decimal balance = Convert.ToDecimal(ReportDTO.Amount);
                    //    if (BankStateDTO.Count > 0)
                    //    {                            
                    //        foreach (PFMDTO00042 pfmdto in BankStateDTO)
                    //        {
                    //            PFMDTO00001 CustomerDTO = new PFMDTO00001();
                    //            MNMDTO00046 rdto = new MNMDTO00046();

                    //            rdto.CustomerId = ReportDTO.CustomerId;
                    //            rdto.Name = ReportDTO.Name;
                    //            rdto.NRC = ReportDTO.NRC;
                    //            rdto.Address = ReportDTO.Address;
                    //            rdto.TownshipCode = ReportDTO.TownshipCode;
                    //            rdto.TownshipDesp = ReportDTO.TownshipDesp;
                    //            rdto.CityCode = ReportDTO.CityCode;
                    //            rdto.PhoneNo = ReportDTO.PhoneNo;                                
                    //            rdto.AccountNo = ReportDTO.AccountNo;                                
                    //            rdto.WithdrawAmount = Convert.ToDecimal(pfmdto.WithdrawalAmount);
                    //            rdto.DepositAmount = Convert.ToDecimal(pfmdto.DepositAmount);
                    //            //modify by ASDA
                    //            if (rdto.WithdrawAmount > 0)
                    //            {
                    //                balance = Convert.ToDecimal(balance - rdto.WithdrawAmount);
                    //            }
                    //            else
                    //            {
                    //                balance = Convert.ToDecimal(balance + rdto.DepositAmount);
                    //            }
                    //            rdto.Amount = balance;
                    //            DateTime dt = Convert.ToDateTime(pfmdto.DATE_TIME);
                    //            rdto.DATE_TIME = dt.ToString("dd/MM/yyyy");
                    //            //
                    //            rdto.Description = pfmdto.Description;
                    //            rdto.Remark = pfmdto.Cheque;
                    //            rdto.Initial = this.WithdrawCount.ToString();
                    //            rdto.InitialDesp = this.DepositCount.ToString();

                    //            custDTOList.Add(rdto);                               
                    //        }

                    //    //    }
                    //        CXUIScreenTransit.Transit("frmMNMRDLC00014.Report", true, new object[] { custDTOList, this.type, this.view.Year, this.view.Month, formname });

                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        CXUIMessageUtilities.ShowMessageByCode(ex.ToString());
                    //    }
                    //}
                    // CXUIScreenTransit.Transit("frmMNMRDLC00014.Report", true, new object[] { custDTOList, this.type, this.view.Year, this.view.Month, formname });
                    #endregion 
                 
                    IList<MNMDTO00046> ReportDataList = new List<MNMDTO00046>();
                    ReportDataList = CXClientWrapper.Instance.Invoke<IMNMSVE00046, IList<MNMDTO00046>>(x => x.BankSatatementByAllWithdrawDeposit(dto.AccountNo,
                        workstation, this.view.Year, this.view.Month, CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred || ReportDataList.Count == 0)
                        CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    else CXUIScreenTransit.Transit("frmMNMRDLC00014.Report", true, new object[] { ReportDataList, this.type, this.view.Year, this.view.Month, formname });
                }
            }
        }

        public decimal GetBalance(string AcctNo, int startPeriod, string sourceBr)
        {
            string month = string.Empty;
            decimal amt = 0;
            int BudgetMonth;

            // 'Yearly Closing Modify
            //string budYear = CXCOM00010.Instance.GetBudgetYear4(CXCOM00009.BudgetYearCode, startPeriod).ToString();
            string budYear = this.view.Year + "/" + Convert.ToString((this.view.Year + 1));
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
            PFMDTO00033 ObjBalance = CXClientWrapper.Instance.Invoke<IMNMSVE00046, PFMDTO00033>(x => x.SelectBalance_ByAcctNoAndBudYear(month, AcctNo, budYear, sourceBr));
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

        #endregion
    }
}
