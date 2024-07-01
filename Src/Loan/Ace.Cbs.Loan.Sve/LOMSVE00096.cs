using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Cx.Com.Utt;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00096 : BaseService, ILOMSVE00096
    {
        public LOMDTO00200 dto;
        public IList<LOMDTO00216> dtoHP;
        public IList<LOMDTO00217> dtoPL;
        //public ILOMDAO00096 termDAO;// { get; set; }
        //public ILOMDAO00096 TermDAO
        //{
        //    get { return this.termDAO; }
        //    set { this.termDAO = value; }
        //}
        public ICXSVE00002 CodeGenerator { get; set; }
        public ICXSVE00006 CodeChecker { get; set; }
        public ICXSVE00006 GetAccountInfomation { get; set; }

        private ILOMDAO00096 hpRegListsDAO;
        public ILOMDAO00096 HpRegListsDAO
        {
            get { return this.hpRegListsDAO; }
            set { this.hpRegListsDAO = value; }
        }

        private IPFMDAO00056 sys001DAO;
        public IPFMDAO00056 Sys001DAO
        {
            get { return this.sys001DAO; }
            set { this.sys001DAO = value; }
        }

        public IList<LOMDTO00096> GetAllHPRegisterLists(string sourceBr, string cur, DateTime startDate, DateTime endDate, string stockGroup)
        {
            return this.hpRegListsDAO.GetAllHPRegisterLists(sourceBr, cur, startDate, endDate, stockGroup);
        }

        public IList<LOMDTO00100> GetHPPaymentSchedule(string sourceBr, string cur, string month, string year)
        {
            return this.hpRegListsDAO.GetHPPaymentSchedule(sourceBr, cur, month, year);
        }

        public LOMDTO00200 HPManualRepayment(string hpNo, int startTerm, int endTerm, decimal totalRepayAmt, string eno, string sourceBr, int createdUserId, string userName)
        {
            string Eno = this.CodeGenerator.GetGenerateCode(CXCOM00009.HPRegisterVoucher, CXCOM00009.HirePurchaseVoucher, 1, sourceBr, new object[] { DateTime.Now.ToString("dd"), DateTime.Now.ToString("MM"), DateTime.Now.ToString("yy") });
            dto = this.hpRegListsDAO.HPManualRepayment(hpNo, startTerm, endTerm, totalRepayAmt, Eno, sourceBr, createdUserId, userName);
            if (dto.retMsg == "0" || dto.retMsg == "1")
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MI90111;
            }
            else if (dto.retMsg == "-1" || dto.retMsg == "-2")
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MV90159;
            }
            else
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MV00135;
            }
            return dto;
        }

        public string HPManualRepayment_CheckPaidOrUnpaid(string hpNo, int startTerm, int endTerm, string sourceBr, int createdUserId, string userName)
        {
            string retMsg = this.hpRegListsDAO.HPManualRepayment_CheckPaidorUnpaid(hpNo, startTerm, endTerm, sourceBr, createdUserId, userName);
            if (retMsg == "0")
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MV90157;
            }
            return retMsg;
        }

        public string GetRepayAmountPerTerm(string hpno, string sourceBr)
        {
            string repayAmt = this.hpRegListsDAO.GetRepayAmountPerTerm(hpno, sourceBr);
            return repayAmt;
        }

        public string GetRepayAmountSTermToETerm(string hpno, int startTerm, int endTerm, string sourceBr)
        {
            string repayTotalAmt = this.hpRegListsDAO.GetRepayAmountSTermToETerm(hpno, startTerm, endTerm, sourceBr);
            return repayTotalAmt;
        }

        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId, string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            PFMORM00056 Sys001ORM = new PFMORM00056();

            //Require Data
            clientDataVersionDTO.ORMObjectName = Sys001ORM;
            clientDataVersionDTO.DataIdValue = dataValueId;
            clientDataVersionDTO.CreatedUserId = createdUserId;

            //ChangedDataContents
            IList<ChangeDataContent> cdclist = new List<ChangeDataContent>();
            foreach (DataVersionChangedValueDTO dvcvdto in dvcvList)
            {
                ChangeDataContent cdcdto = new ChangeDataContent();
                cdcdto.Property = dvcvdto.OrmPropertyName;
                cdcdto.OldValue = dvcvdto.OrmPreviousValue;
                cdcdto.NewValue = dvcvdto.OrmNewValue;
                cdclist.Add(cdcdto);
            }
            clientDataVersionDTO.ChangeDataContentList = cdclist;
            // CXServiceWrapper.Instance.Invoke<IDataVersionUpdateService, bool>(x => x.SaveOrUpdateClientDataVersion(clientDataVersionDTO, dataAction));
        }

        public string HPMonthlyAutoPaymentProc(string sourceBr, int createdUserId, string userName, IList<DataVersionChangedValueDTO> dvcvList)
        {
            try
            {
                
                DateTime lastSettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("LastSettlementDate"), sourceBr, true });
                DateTime transactionDate;
                if (lastSettlementDate.Date == DateTime.Now.Date) 
                {
                    transactionDate = DateTime.Now; //For Current Date Transaction
                }
                else 
                {
                    string lastSDate = lastSettlementDate.ToString("yyyy-MM-dd") + " " + "23:59:04.000"; // To update SQLite data
                    transactionDate = DateTime.Parse(lastSDate);//For Back Date Transaction
                }

                //Comment & Modified by HMW at (06-08-2019) : Generate ENO at Script side to prevent "Voucher No Loss Issue" in every already run (or) no need to run case.
                //string Eno = this.CodeGenerator.GetGenerateCode(CXCOM00009.NormalVoucher, CXCOM00009.NormalVoucher, 1, sourceBr, new object[] { lastSettlementDate.ToString("dd"), nextSettlementDate.ToString("MM"), nextSettlementDate.ToString("yy") });

                string retMsg = this.hpRegListsDAO.HPMonthlyAutoPaymentProc(sourceBr, createdUserId, userName);
                if (retMsg == "0")
                {
                    this.ServiceResult.ErrorOccurred = false;
                    PFMDTO00056 InterestDateDTO = sys001DAO.SelectSys001Info(sourceBr, "HPMonthly_AutoPay");
                    SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, createdUserId, InterestDateDTO.Id.ToString());
                    //Dictionary<string, object> updateColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "Status", "Y" }, { "SysDate", DateTime.Now } };
                    Dictionary<string, object> updateColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "Status", "Y" }, { "SysDate", transactionDate } };
                    Dictionary<string, object> whereColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "BranchCode", sourceBr }, { "Name", "HPMonthly_AutoPay" }, { "Active", true } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00056", updateColumnsandValuesForLoansInterestCalculation, whereColumnsandValuesForLoansInterestCalculation));

                    this.ServiceResult.MessageCode = CXMessage.MI90112;//HP Monthly Auto Payment Process is finished successfully!
                }
                else if (retMsg == "1")
                {
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = CXMessage.MV90164;//Please Run HP Late Fees Auto Voucher Process Firstly!.
                }
                else if (retMsg == "2")
                {
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = CXMessage.MV90236;//Insufficient Total Late Fees in some account! Please do the Late Fee Exception First!.
                }
                else if (retMsg == "-1")
                {
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = CXMessage.MV90154;//No need to run auto pay process in this date!
                }
                else if (retMsg == "-2")
                {
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = CXMessage.MV90155;//Already Run HP Auto Payment Process!
                }
                else //retMsg=='-3'
                {
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = CXMessage.MV90150;//No Records to run HP Monthly Auto Payment Process!

                    this.sys001DAO.UpdateDateDailyPosting("HPMonthly_AutoPay", transactionDate, sourceBr, createdUserId);

                    PFMDTO00056 InterestDateDTO = sys001DAO.SelectSys001Info(sourceBr, "HPMonthly_AutoPay");
                    SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, createdUserId, InterestDateDTO.Id.ToString());
                    Dictionary<string, object> updateColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "Status", "Y" }, { "SysDate", transactionDate } };
                    Dictionary<string, object> whereColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "BranchCode", sourceBr }, { "Name", "HPMonthly_AutoPay" }, { "Active", true } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00056", updateColumnsandValuesForLoansInterestCalculation, whereColumnsandValuesForLoansInterestCalculation));

                }
                return retMsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<LOMDTO00202> GetHPOverDraftListing(string sourceBr, string cur,DateTime startDate,DateTime endDate)
        {
            return this.hpRegListsDAO.GetHPOverDraftListing(sourceBr, cur,startDate,endDate);
        }

        public IList<LOMDTO00203> GetHPInsufficientListing(string sourceBr, string cur, string month)
        {
            return this.hpRegListsDAO.GetHPInsufficientListing(sourceBr, cur, month);
        }

        public string HPLateFeesCalculationProcess(string sourceBr, int createdUserId, string userName, IList<DataVersionChangedValueDTO> dvcvList)
        {
            try
            {
                DateTime nextSettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("LastSettlementDate"), sourceBr, true });
                string Eno = this.CodeGenerator.GetGenerateCode(CXCOM00009.HPRegisterVoucher, CXCOM00009.HirePurchaseVoucher, 1, sourceBr, new object[] { nextSettlementDate.ToString("dd"), nextSettlementDate.ToString("MM"), nextSettlementDate.ToString("yy") });

                string retMsg = this.hpRegListsDAO.HPLateFeesCalculationProcess(sourceBr, createdUserId, userName);
                if (retMsg == "0")
                {
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = CXMessage.MI90114; //HP Late Fees Calculation Process is successfully finshed!.

                    PFMDTO00056 InterestDateDTO = sys001DAO.SelectSys001Info(sourceBr, "HPLateFees_AutoRun");
                    SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, createdUserId, InterestDateDTO.Id.ToString());
                    Dictionary<string, object> updateColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "Status", "Y" }, { "SysDate", nextSettlementDate.AddDays(-1) } };
                    Dictionary<string, object> whereColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "BranchCode", sourceBr }, { "Name", "HPLateFees_AutoRun" }, { "Active", true } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00056", updateColumnsandValuesForLoansInterestCalculation, whereColumnsandValuesForLoansInterestCalculation));

                }
                else if (retMsg == "1")
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV90164;//Please Run HP Auto Payment Process Firtly!.
                }
                else
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV90180;//There is no late fees in this date!. 

                    PFMDTO00056 InterestDateDTO = sys001DAO.SelectSys001Info(sourceBr, "HPLateFees_AutoRun");
                    SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, createdUserId, InterestDateDTO.Id.ToString());
                    Dictionary<string, object> updateColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "Status", "Y" }, { "SysDate", nextSettlementDate.AddDays(-1) } };
                    Dictionary<string, object> whereColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "BranchCode", sourceBr }, { "Name", "HPLateFees_AutoRun" }, { "Active", true } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00056", updateColumnsandValuesForLoansInterestCalculation, whereColumnsandValuesForLoansInterestCalculation));
                }
                return retMsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<LOMDTO00205> GetPLInfoListing(DateTime startDate, DateTime endDate, string companyName, string sourceBr)
        {
            return this.hpRegListsDAO.GetPLInfoListing(startDate, endDate, companyName, sourceBr);
        }

        public IList<LOMDTO00206> GetBLInterestListing(string month, string year, string sourceBr, int createdUserId)
        {
            return this.hpRegListsDAO.GetBLInterestListing(month, year, sourceBr, createdUserId);
        }

        public IList<LOMDTO00207> GetPersonalLoanNPLCaseListing(DateTime startDate, DateTime endDate, string sourceBr)
        {
            return this.hpRegListsDAO.GetPersonalLoanNPLCaseListing(startDate, endDate, sourceBr);
        }

        public string GetHPLateFeesRepayment_Amount(string hpNo, int startTerm, int endTerm, string sourceBr)
        {
            return this.hpRegListsDAO.GetHPLateFeesRepayment_Amount(hpNo, startTerm, endTerm, sourceBr);
        }

        public string HPAccountExistsOrValid(string hpNo, string sourceBr)
        {
            return this.hpRegListsDAO.HPAccountExistsOrValid(hpNo, sourceBr);
        }

        public string HPLateFeesRepaymentProcess(string hpNo, int startTerm, int endTerm, decimal totalLateFeesAmount, string eno, string sourceBr, int createdUserId, string userName)
        {
            DateTime lastSettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("LastSettlementDate"), sourceBr, true });
            string Eno = this.CodeGenerator.GetGenerateCode(CXCOM00009.HPRegisterVoucher, CXCOM00009.HirePurchaseVoucher, 1, sourceBr, new object[] { lastSettlementDate.ToString("dd"), lastSettlementDate.ToString("MM"), lastSettlementDate.ToString("yy") });
            string retStr = this.hpRegListsDAO.HPLateFeesRepaymentProcess(hpNo, startTerm, endTerm, totalLateFeesAmount, Eno, sourceBr, createdUserId, userName);
            if (retStr == "0")
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MI90117;
            }
            return retStr;
        }

        //public IList<LOMDTO00208> GetHPDailyPositionListing(string stockGroupCode, DateTime startDate, DateTime endDate, string sourceBr)
        public IList<LOMDTO00208> GetHPDailyPositionListing(string stockGroupCode, string sourceBr)
        {
            //return this.hpRegListsDAO.GetHPDailyPositionListing(stockGroupCode,startDate,endDate,sourceBr);
            return this.hpRegListsDAO.GetHPDailyPositionListing(stockGroupCode, sourceBr);
        }

        public IList<LOMDTO00209> GetHPInformationListing(DateTime startDate, DateTime endDate, string stockGroup, string sourceBr)
        {
            return this.hpRegListsDAO.GetHPInformationListing(startDate, endDate, stockGroup, sourceBr);
        }

        public IList<LOMDTO00210> GetHPPaymentListing(DateTime startDate, DateTime endDate, string stockGroup, string cur, string sourceBr)
        {
            return this.hpRegListsDAO.GetHPPaymentListing(startDate, endDate, stockGroup, cur, sourceBr);
        }

        public IList<LOMDTO00211> GetHPRePaymentListing(DateTime startDate, DateTime endDate, string cur, string sourceBr, string stockGroup)
        {
            return this.hpRegListsDAO.GetHPRepaymentListing(startDate, endDate, cur, sourceBr, stockGroup);
        }

        public IList<LOMDTO00212> GetHPInterest_Due_PreListing(DateTime startDate, DateTime endDate, string currency, string sourceBr, string stockGroup, string interestPaidStatus)
        {
            return this.hpRegListsDAO.GetHPInterest_Due_PreListing(startDate, endDate, currency, sourceBr, stockGroup, interestPaidStatus);
        }

        //Updated by HWKO (21-Nov-2017)
        public IList<LOMDTO00213> Get_HP_Repayment_Schedule_Listing(string acctNo, string currency, string sourceBr)
        {
            return this.hpRegListsDAO.Get_HP_Repayment_Schedule_Listing(acctNo, currency, sourceBr);
        }

        public string Get_HP_PrepaymentInfo(string hpNo, string sourceBr)
        {
            return this.hpRegListsDAO.Get_HP_PrepaymentInfo(hpNo, sourceBr);
        }

        public string HP_Manual_Pre_Payment_Process(string hpNo, int startTerm, int endTerm, decimal totalPaidPrepayAmt, decimal totalPaidRentalChgAmt,
                                                    decimal rentalDiscountRate, string eno, string sourceBr, int createdUserId, string userName)
        {
            DateTime nextSettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), sourceBr, true });
            string Eno = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, 1, sourceBr, new object[] { nextSettlementDate.ToString("dd"), nextSettlementDate.ToString("MM"), nextSettlementDate.ToString("yy") });
            string retMsg = this.hpRegListsDAO.HP_Manual_Pre_Payment_Process(hpNo, startTerm, endTerm, totalPaidPrepayAmt, totalPaidRentalChgAmt,
                                                                             rentalDiscountRate, eno, sourceBr, createdUserId, userName);
            if (retMsg == "0")
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MI90111;//HP Manual Prepayment Process is successfully finished!.
            }
            else
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MV90159;//InSufficient Balance in Customer Account !
            }
            return retMsg;
        }

        //Added at (22_Sep_2017)
        public string HP_Manual_Pre_Payment_Process_NewLogic(string hpNo, int startTerm, int endTerm, decimal totalPaidInstallmentAmt, decimal totalPaidPrincipleAmt, decimal totalPaidRentalChgAmt,
                                                    decimal rentalDiscountRate, string sourceBr, int createdUserId, string userName)
        {
            DateTime lastSettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("LastSettlementDate"), sourceBr, true });
            //string Eno = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, 1, sourceBr, new object[] { lastSettlementDate.ToString("dd"), lastSettlementDate.ToString("MM"), lastSettlementDate.ToString("yy") });
            string retMsg = this.hpRegListsDAO.HP_Manual_Pre_Payment_Process_NewLogic(hpNo, startTerm, endTerm, totalPaidInstallmentAmt, totalPaidPrincipleAmt, totalPaidRentalChgAmt, rentalDiscountRate,
                                                                             sourceBr, createdUserId, userName);
            if (retMsg == "0")
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MI90111;//HP Manual Prepayment Process is successfully finished!.
            }
            else
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MV90159;//InSufficient Balance in Customer Account !
            }
            return retMsg;
        }

        public string Get_HP_PrepaymentInfo_NewLogic(string hpNo, int startTerm, int endTerm, string sourceBr)
        {
            return this.hpRegListsDAO.Get_HP_PrepaymentInfo_NewLogic(hpNo, startTerm, endTerm, sourceBr);
        }

        public string CheckHPAccountandStartTerm(string hpNo, string sourceBr)
        {
            return this.hpRegListsDAO.CheckHPAccountandStartTerm(hpNo, sourceBr);
        }

        //Added 29-09-2017
        public string HPLateFeesAutoPayVoucherProcess(string eno, string sourceBr, int createdUserId, string userName, IList<DataVersionChangedValueDTO> dvcvList)
        {
            DateTime lastSettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("LastSettlementDate"), sourceBr, true });
            DateTime transactionDate;
            if (lastSettlementDate.Date == DateTime.Now.Date)
            {
                transactionDate = DateTime.Now; //For Current Date Transaction
            }
            else
            {
                string lastSDate = lastSettlementDate.ToString("yyyy-MM-dd") + " " + "23:59:01.000"; // To update SQLite data
                transactionDate = DateTime.Parse(lastSDate);//For Back Date Transaction
            }

            //Comment & Modified by HMW at (26-07-2019) : Generate ENO at Script side to prevent "Voucher No Loss Issue" in every already run (or) no need to run case.
            //eno = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, 1, sourceBr, new object[] { lastSettlementDate.ToString("dd"), lastSettlementDate.ToString("MM"), lastSettlementDate.ToString("yy") });
            //string str = this.hpRegListsDAO.HPLateFeesAutoPayVoucherProcess(eno, sourceBr, createdUserId, userName);
                        
            string str = this.hpRegListsDAO.HPLateFeesAutoPayVoucherProcess(sourceBr, createdUserId, userName);
            if (str == "0" || str == "1")
            {
                this.ServiceResult.ErrorOccurred = false;
                PFMDTO00056 InterestDateDTO = sys001DAO.SelectSys001Info(sourceBr, "HPLateFees_AutoPay");
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, createdUserId, InterestDateDTO.Id.ToString());
                //Dictionary<string, object> updateColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "Status", "Y" }, { "SysDate", DateTime.Now } };
                Dictionary<string, object> updateColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "Status", "Y" }, { "SysDate", transactionDate } };
                Dictionary<string, object> whereColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "BranchCode", sourceBr }, { "Name", "HPLateFees_AutoPay" }, { "Active", true } };
                CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00056", updateColumnsandValuesForLoansInterestCalculation, whereColumnsandValuesForLoansInterestCalculation));

                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MI90127;//HP Late Fees Auto Voucher Process is successfully finshed!.
            }
            else if (str == "-2")
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MV90188;//Already Run HP Late Fees Auto Voucher Process!.
            }
            else if (str == "-3")
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.ME00070;//Please check the "System Date" and "Settlement Date" First!
            }
            else //(str == "-1")
            {
                this.ServiceResult.ErrorOccurred = false;
                PFMDTO00056 InterestDateDTO = sys001DAO.SelectSys001Info(sourceBr, "HPLateFees_AutoPay");
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, createdUserId, InterestDateDTO.Id.ToString());
                //Dictionary<string, object> updateColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "Status", "Y" }, { "SysDate", DateTime.Now } };
                Dictionary<string, object> updateColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "Status", "Y" }, { "SysDate", transactionDate } };
                Dictionary<string, object> whereColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "BranchCode", sourceBr }, { "Name", "HPLateFees_AutoPay" }, { "Active", true } };
                CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00056", updateColumnsandValuesForLoansInterestCalculation, whereColumnsandValuesForLoansInterestCalculation));

                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MV90186;//No Data For Late Fees Auto Pay Voucher Process!
            }
            return str;
        }
        //Added By AAM(20-10-2017)
        public IList<LOMDTO00214> HPAbsentHistoryListing(DateTime startDate, DateTime endDate, string acctno, string sourceBr)
        {
            // Modified By AAM (23-Nov-2017)
            IList<LOMDTO00214> hpDTO = new List<LOMDTO00214>();
            hpDTO = this.hpRegListsDAO.HPAbsentHistoryListing(startDate, endDate, acctno, sourceBr);
            if (hpDTO == null || hpDTO.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.ME30012;//Data Not Found.
            }
            return hpDTO;
        }
        //Added By AAM(23-10-2017)
        public IList<LOMDTO00215> PLAbsentHistoryListing(DateTime startDate, DateTime endDate, string acctno, string sourceBr)
        {
            // Modified By AAM (23-Nov-2017)
            IList<LOMDTO00215> plDTO = new List<LOMDTO00215>();
            plDTO = this.hpRegListsDAO.PLAbsentHistoryListing(startDate, endDate, acctno, sourceBr);
            if (plDTO == null || plDTO.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.ME30012;//Data Not Found.
            }
            return plDTO;
        }

        public IList<LOMDTO00216> HPAbsentHistory_Enquiry(string acctno, string sourceBr)
        {
            dtoHP = this.hpRegListsDAO.HPAbsentHistory_Enquiry(acctno, sourceBr);

            if (dtoHP == null || dtoHP.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.ME30012;//Data Not Found.
            }

            else if (dtoHP[0].chkAcctNo == "-1")
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MV00046;//Invalid Account No.
            }
            return dtoHP;
        }

        public IList<LOMDTO00217> PLAbsentHistory_Enquiry(string acctno, string sourceBr)
        {
            dtoPL = this.hpRegListsDAO.PLAbsentHistory_Enquiry(acctno, sourceBr);

            if (dtoPL == null || dtoPL.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.ME30012;//Data Not Found.
            }
            else if (dtoPL[0].chkAcctNo == "-1")
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MV00046;//Invalid Account No.
            }
            return dtoPL;
        }

        public IList<LOMDTO00218> HP_LateFees_Outstanding_Listing(string currency, string sourceBr, DateTime startDate, DateTime endDate
                                                                 , int searchBy)
        {
            // Modified By AAM (23-Nov-2017)
            IList<LOMDTO00218> hpDTO = new List<LOMDTO00218>();
            hpDTO = this.hpRegListsDAO.HP_LateFees_Outstanding_Listing(currency, sourceBr, startDate, endDate, searchBy);
            if (hpDTO == null || hpDTO.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.ME30012;//Data Not Found.
            }
            return hpDTO;
        }

        public IList<LOMDTO00219> BL_LateFees_Outstanding_Listing(string currency, string sourceBr)
        {
            // Modified By AAM (23-Nov-2017)
            IList<LOMDTO00219> blDTO = new List<LOMDTO00219>();
            blDTO = this.hpRegListsDAO.BL_LateFees_Outstanding_Listing(currency, sourceBr);
            if (blDTO == null || blDTO.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.ME30012;//Data Not Found.
            }
            return blDTO;
        }

        //Added By HMW (13-Nov-2019)
        public IList<LOMDTO00219> BL_OD_LateFees_Outstanding_Listing_By_Account(string acctno, string sourceBr)
        {            
            IList<LOMDTO00219> blDTO = new List<LOMDTO00219>();
            blDTO = this.hpRegListsDAO.BL_OD_AND_LateFee_Outstanding_Listing_ByAccount(acctno, sourceBr);
            if (blDTO == null || blDTO.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.ME30012;//Data Not Found.
            }
            return blDTO;
        }

        // Added By AAM (27-Nov-2017)
        public IList<LOMDTO00220> HP_Installment_Listing(string currency, string sourceBr, string stockGroup, string SortType )
        {
            IList<LOMDTO00220> hpDTO = new List<LOMDTO00220>();
            hpDTO = this.hpRegListsDAO.HP_Installment_Listing(currency, sourceBr, stockGroup, SortType);
            if (hpDTO == null || hpDTO.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.ME30012;//Data Not Found.
            }
            return hpDTO;
        }

        // Added By AAM (28-Nov-2017)
        public IList<LOMDTO00221> PL_Installment_Listing(string currency, string sourceBr, string companyName, string SortType)
        {
            IList<LOMDTO00221> plDTO = new List<LOMDTO00221>();
            plDTO = this.hpRegListsDAO.PL_Installment_Listing(currency, sourceBr, companyName, SortType);
            if (plDTO == null || plDTO.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.ME30012;//Data Not Found.
            }
            return plDTO;
        }

        // Added By AAM (29-Nov-2017)
        public IList<LOMDTO00222> BL_Installment_Listing(string currency, string sourceBr, string businessType, string SortType)
        {
            IList<LOMDTO00222> blDTO = new List<LOMDTO00222>();
            blDTO = this.hpRegListsDAO.BL_Installment_Listing(currency, sourceBr, businessType, SortType);
            if (blDTO == null || blDTO.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.ME30012;//Data Not Found.
            }
            return blDTO;
        }

        // Added By AAM (29-Nov-2017)
        public IList<LOMDTO00223> PL_DailyPosition_Listing(string sourceBr, string companyName)
        {
            IList<LOMDTO00223> plDTO = new List<LOMDTO00223>();
            plDTO = this.hpRegListsDAO.PL_DailyPosition_Listing(sourceBr, companyName);
            if (plDTO == null || plDTO.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.ME30012;//Data Not Found.
            }
            return plDTO;
        }

        // Added By AAM (04-Dec-2017)
        public IList<LOMDTO00224> HP_AutoPay_Sufficient_Listing(DateTime startDate, DateTime endDate, string stockGroup, string currency, string sourceBr)
        {
            IList<LOMDTO00224> hpDTO = new List<LOMDTO00224>();
            hpDTO = this.hpRegListsDAO.HP_AutoPay_Sufficient_Listing(startDate, endDate, stockGroup, currency, sourceBr);
            if (hpDTO == null || hpDTO.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.ME30012;//Data Not Found.
            }
            return hpDTO;
        }

        // Added By AAM (05-Dec-2017)
        public IList<LOMDTO00225> PL_AutoPay_Sufficient_Listing(DateTime startDate, DateTime endDate, string companyName, string currency, string sourceBr)
        {
            IList<LOMDTO00225> plDTO = new List<LOMDTO00225>();
            plDTO = this.hpRegListsDAO.PL_AutoPay_Sufficient_Listing(startDate, endDate, companyName, currency, sourceBr);
            if (plDTO == null || plDTO.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.ME30012;//Data Not Found.
            }
            return plDTO;
        }

        // Added By AAM (06-Dec-2017)
        public IList<LOMDTO00226> BL_AutoPay_Sufficient_Listing(DateTime startDate, DateTime endDate, string businessType, string currency, string sourceBr)
        {
            IList<LOMDTO00226> blDTO = new List<LOMDTO00226>();
            blDTO = this.hpRegListsDAO.BL_AutoPay_Sufficient_Listing(startDate, endDate, businessType, currency, sourceBr);
            if (blDTO == null || blDTO.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.ME30012;//Data Not Found.
            }
            return blDTO;
        }

        // Added By AAM (07-Dec-2017)
        public IList<LOMDTO00227> BL_Overdrawn_Listing(DateTime startDate, DateTime endDate, string currency, string sourceBr)
        {
            IList<LOMDTO00227> blDTO = new List<LOMDTO00227>();
            blDTO = this.hpRegListsDAO.BL_Overdrawn_Listing(startDate, endDate, currency, sourceBr);
            if (blDTO == null || blDTO.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.ME30012;//Data Not Found.
            }
            return blDTO;
        }

        // Added By AAM (13-Dec-2017)
        public IList<LOMDTO00228> LOANS_SUMMARY_REPORT_ForBOM(DateTime Date, string currency, string sourceBr)
        {
            IList<LOMDTO00228> dto = new List<LOMDTO00228>();
            dto = this.hpRegListsDAO.LOANS_SUMMARY_REPORT_ForBOM(Date, currency, sourceBr);
            if (dto == null || dto.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.ME30012;//Data Not Found.
            }
            return dto;
        }

        // Added By AAM (15-Dec-2017)
        public IList<LOMDTO00229> LOANS_SUMMARY_REPORT_ForBOM_LiveUnLive(DateTime Date, string currency, string sourceBr)
        {
            IList<LOMDTO00229> dto = new List<LOMDTO00229>();
            dto = this.hpRegListsDAO.LOANS_SUMMARY_REPORT_ForBOM_LiveUnLive(Date, currency, sourceBr);
            if (dto == null || dto.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.ME30012;//Data Not Found.
            }   
            return dto;
        }

        // Added By AAM (26-Dec-2017)
        public IList<LOMDTO00230> HP_TOD_Repayment_Listing(DateTime startDate, DateTime endDate, string currency, string sourceBr)
        {
            IList<LOMDTO00230> dto = new List<LOMDTO00230>();
            dto = this.hpRegListsDAO.HP_TOD_Repayment_Listing(startDate, endDate, currency, sourceBr);
            if (dto == null || dto.Count == 0) 
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.ME30012;//Data Not Found.
            }
            return dto;
        }  

        public IList<LOMDTO00230> PL_TOD_Repayment_Listing(DateTime startDate, DateTime endDate, string currency, string sourceBr)
        {
            IList<LOMDTO00230> dto = new List<LOMDTO00230>();
            dto = this.hpRegListsDAO.PL_TOD_Repayment_Listing(startDate, endDate, currency, sourceBr);
            if (dto == null || dto.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.ME30012;//Data Not Found.
            }
            return dto;
        }

        public IList<LOMDTO00230> BL_TOD_Repayment_Listing(DateTime startDate, DateTime endDate, string currency, string sourceBr)
        {
            IList<LOMDTO00230> dto = new List<LOMDTO00230>();
            dto = this.hpRegListsDAO.BL_TOD_Repayment_Listing(startDate, endDate, currency, sourceBr);
            if (dto == null || dto.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.ME30012;//Data Not Found.
            }
            return dto;
        }

        public IList<LOMDTO00231> HP_AccountClosed_Listing(DateTime startDate, DateTime endDate, string currency, string sourceBr)
        { 
            IList<LOMDTO00231> dto = new List<LOMDTO00231>();
            dto = this.hpRegListsDAO.HP_AccountClosed_Listing(startDate, endDate, currency, sourceBr);
            if (dto == null || dto.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.ME30012;//Data Not Found.
            }
            return dto;
        }

        public IList<LOMDTO00231> PL_AccountClosed_Listing(DateTime startDate, DateTime endDate, string currency, string sourceBr)
        {
            IList<LOMDTO00231> dto = new List<LOMDTO00231>();
            dto = this.hpRegListsDAO.PL_AccountClosed_Listing(startDate, endDate, currency, sourceBr);
            if (dto == null || dto.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.ME30012;//Data Not Found.
            }
            return dto;
        }

        public IList<LOMDTO00231> BL_AccountClosed_Listing(DateTime startDate, DateTime endDate, string currency, string sourceBr)
        {
            IList<LOMDTO00231> dto = new List<LOMDTO00231>();
            dto = this.hpRegListsDAO.BL_AccountClosed_Listing(startDate, endDate, currency, sourceBr);
            if (dto == null || dto.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.ME30012;//Data Not Found.
            }
            return dto;
        }

        public IList<LOMDTO00232> Transfer_Transaction_Listing(string dateOption, DateTime startDate, DateTime endDate, string voucherStatus,
                                                               string requiredType, int reverseStatus, string currency, string sourceBr)
        {
            IList<LOMDTO00232> dto = new List<LOMDTO00232>();
            dto = this.hpRegListsDAO.Transfer_Transaction_Listing(dateOption, startDate, endDate, voucherStatus, requiredType, reverseStatus, currency, sourceBr);
            if (dto == null || dto.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.ME30012;//Data Not Found.
            }
            return dto;
        }

        public string GetDealerBusinessName_For_HPLimitVoucher_Printing(string dealerNo)
        {
            return this.hpRegListsDAO.GetDealerBusinessName_For_HPLimitVoucher_Printing(dealerNo);
        }

        public IList<LOMDTO00234> Get_HP_LimitVou_Lists(string eno)
        {
            return this.hpRegListsDAO.Get_HP_LimitVou_Lists(eno);
        }

        // Added By AAM (15-Jan-2018)
        public IList<LOMDTO00236> Get_BL_LimitVou_Lists(string eno)
        {
            return this.hpRegListsDAO.Get_BL_LimitVou_Lists(eno);
        }

        // Added By AAM (15-Jan-2018)
        public IList<LOMDTO00235> Get_PL_LimitVou_Lists(string eno)
        {
            return this.hpRegListsDAO.Get_PL_LimitVou_Lists(eno);
        }

        // Added By AAM (07-Feb-2018)
        public IList<LOMDTO00237> Get_HP_Information_For_Enquiry(string acctNo, string sourceBr)
        {
            return this.hpRegListsDAO.Get_HP_Information_For_Enquiry(acctNo, sourceBr);
        }

        // Added By AAM (16-Feb-2018)
        public string Get_HPInfo_ByHPNo(string hpNo)
        {
            string str = this.hpRegListsDAO.Get_HPInfo_ByHPNo(hpNo);
            return str;
        }
        // Added By AAM (19-Feb-2018)
        public string HP_Registration_Reversal(string hpNo, string reversalEno, int createdUserId, string sourceBr)
        {
            DateTime nextSettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), sourceBr, true });
            string reversal_Eno = this.CodeGenerator.GetGenerateCode("HPRegReversalID", string.Empty, createdUserId, sourceBr, new object[] { nextSettlementDate.ToString("dd"), nextSettlementDate.ToString("MM"), nextSettlementDate.ToString("yy") });
            return this.hpRegListsDAO.HP_Registration_Reversal(hpNo, reversal_Eno, createdUserId, sourceBr);
        }

        // Added By AAM (21-Feb-2018)
        public IList<LOMDTO00238> Get_COA_Lists(string sourceBr)
        {
            return this.hpRegListsDAO.Get_COA_Lists(sourceBr);
        }

        public string Importing_Deposit_Voucher(string acWithOtherBnk, List<LOMDTO00238> lstImportData, string eno, int createdUserId
                                                , string sourceBr, string narration)
        {
            DateTime nextSettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), sourceBr, true });
            string Eno = this.CodeGenerator.GetGenerateCode(CXCOM00009.NormalVoucher, CXCOM00009.NormalVoucher, 1, sourceBr, new object[] { nextSettlementDate.ToString("dd"), nextSettlementDate.ToString("MM"), nextSettlementDate.ToString("yy") });
            return this.hpRegListsDAO.Importing_Deposit_Voucher(acWithOtherBnk, lstImportData, Eno, createdUserId, sourceBr,narration);
        }
		
		// For Year End Income Voucher, added by AAM (28-Mar-2018)
        public IList<LOMDTO00239> Get_PNL_Zerorization_Income_Info(string sourceBr)
        {
            return this.hpRegListsDAO.Get_PNL_Zerorization_Income_Info(sourceBr);
        }
        public string Get_Info_For_PNL_Zerorization_Income_ByPLAC(string plAC, string sourceBr)
        {
            return this.hpRegListsDAO.Get_Info_For_PNL_Zerorization_Income_ByPLAC(plAC, sourceBr);
        }
        public string PNL_Zerorization_Income_Voucher(string pnlAC, int createdUserId, string sourceBr)
        {            
            /*
            // Comment by HMW at 19-Sept-2019 : It is wrong logic in generating ENO with PC Date)
            string Eno = this.CodeGenerator.GetGenerateCode(CXCOM00009.NormalVoucher, CXCOM00009.NormalVoucher, 1, sourceBr, new object[] { DateTime.Now.ToString("dd"), DateTime.Now.ToString("MM"), DateTime.Now.ToString("yy") });
            return hpRegListsDAO.PNL_Zerorization_Income_Voucher(pnlAC, Eno, createdUserId, sourceBr);
            */

            return hpRegListsDAO.PNL_Zerorization_Income_Voucher(pnlAC, createdUserId, sourceBr);//ENO will generate at script side directly with back date (LastSettlementDate)
        }

        //Added by HMW at 23-Sept-2019
        public string Check_AlreadyZerorizationForIncomeAC(string ProfitAndLossAc)
        {
            return this.hpRegListsDAO.Check_AlreadyZerorizationForIncomeAC(ProfitAndLossAc);
        }

        //Added by HMW at 23-Sept-2019
        public string Check_AlreadyZerorizationForExpenseAC(string ProfitAndLossAc)
        {
            return this.hpRegListsDAO.Check_AlreadyZerorizationForExpenseAC(ProfitAndLossAc);
        }

        // For Year End Expense Voucher, added by AAM (28-Mar-2018)
        public IList<LOMDTO00239> Get_Expn_Zerorization_Expense_Info(string sourceBr)
        {
            return this.hpRegListsDAO.Get_Expn_Zerorization_Expense_Info(sourceBr);
        }

        public string Get_Info_For_Expn_Zerorization_Expense_ByExpnAC(string expnAC, string sourceBr)
        {
            return this.hpRegListsDAO.Get_Info_For_Expn_Zerorization_Expense_ByExpnAC(expnAC, sourceBr);
        }

        public string Expn_Zerorization_Expense_Voucher(string expnAC, int createdUserId, string sourceBr)
        {
            /*
            // Comment by HMW at 19-Sept-2019 : It is wrong logic in generating ENO with PC Date)
            string Eno = this.CodeGenerator.GetGenerateCode(CXCOM00009.NormalVoucher, CXCOM00009.NormalVoucher, 1, sourceBr, new object[] { DateTime.Now.ToString("dd"), DateTime.Now.ToString("MM"), DateTime.Now.ToString("yy") });
            return hpRegListsDAO.Expn_Zerorization_Expense_Voucher(expnAC, Eno, createdUserId, sourceBr);
            */

            return hpRegListsDAO.Expn_Zerorization_Expense_Voucher(expnAC, createdUserId, sourceBr);//ENO will generate at script side directly with back date (LastSettlementDate)
        }
        public string Get_BLInfo_ByBLNo(string blNo)
        {
            string str = this.hpRegListsDAO.Get_BLInfo_ByBLNo(blNo);
            return str;
        }
        // Added By AAM (03-Apr-2018)
        public string BL_Registration_Reversal(string blNo, string formatCode, int createdUserId, string sourceBr)
        {
            return this.hpRegListsDAO.BL_Registration_Reversal(blNo, formatCode, createdUserId, sourceBr);//Modify by HMW at 27-08-2019
        }

        // Personal Loan Manual Prepayment Process,added by AAM (05-Apr-2018)
        public string PL_Manual_Pre_Payment_Process(string plNo, int startTerm, int endTerm, decimal totalPaidInstallAmt
                                                    , decimal totalPaidPrinAmt, decimal totalPaidIntAmt, decimal intDisRate, string sourceBr
                                                    , int createdUserId, string userName, string formatCode
                                                    , int valueCount, string valueStr)
        {
            string retMsg = this.hpRegListsDAO.PL_Manual_Pre_Payment_Process(plNo, startTerm, endTerm, totalPaidInstallAmt
                                                                              , totalPaidPrinAmt, totalPaidIntAmt, intDisRate, sourceBr
                                                                              , createdUserId, userName, formatCode
                                                                              , valueCount, valueStr);
            string[] strResult = retMsg.Split('#');
            string retCode = strResult[0];
            string retDesp = strResult[1];

            if (retCode == "0")
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MI90128;//PL Manual Pre-payment Process is successfully finished!.
            }
            else
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MV90159;//InSufficient Balance in Customer Account !
            }
            return retMsg;
        }

        public string Get_PL_PrepaymentInfo(string plNo, int startTerm, int endTerm, string sourceBr)
        {
            return this.hpRegListsDAO.Get_PL_PrepaymentInfo(plNo, startTerm, endTerm, sourceBr);
        }

        public string CheckPLAccountandStartTerm(string plNo, string sourceBr)
        {
            return this.hpRegListsDAO.CheckPLAccountandStartTerm(plNo, sourceBr);
        }

        public IList<LOMDTO00241> Get_HPList_For_Interest_Prepay_ByDealer(LOMDTO00241 hpListBydealer)
        {
            IList<LOMDTO00241> str = this.hpRegListsDAO.Get_HPList_For_Interest_Prepay_ByDealer(hpListBydealer);
            if (str.Count == 0) return str;

            else if (str[0].DealerCheck == "-1")
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MV90206;//Invalid Dealer Account Number!
            }
            return str;

        }

        public string Dealer_Interest_Prepaid_ForHP(LOMDTO00241 hpListBydealer)
        {
            string retMsg = this.hpRegListsDAO.Dealer_Interest_Prepaid_ForHP(hpListBydealer);

            string[] strResult = retMsg.Split('#');
            string retCode = strResult[0];
            string retDesp = strResult[1];

            if (retCode == "0")
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MI90111;//HP Manual Pre-payment Process is successfully finished!.
            }
            else
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = retDesp;
            }
            return retMsg;
        }

        public IList<LOMDTO00242> HPInterestPrepaidByDealer_Listing(LOMDTO00242 hpIntPrepaidList)
        {
            return this.hpRegListsDAO.HPInterestPrepaidByDealer_Listing(hpIntPrepaidList);
        }

        public string Get_PLInfo_ByPLNo(string plNo)
        {
            string str = this.hpRegListsDAO.Get_PLInfo_ByPLNo(plNo);
            return str;
        }
        // Added By AAM (22-Mar-2018)
        public string PL_Registration_Reversal(string plNo, int createdUserId, string sourceBr, string formatCode
                                                , int valueCount, string valueStr)
        {
            return this.hpRegListsDAO.PL_Registration_Reversal(plNo, createdUserId, sourceBr, formatCode, valueCount, valueStr);
        }

        public IList<LOMDTO00240> Get_TotalInterestAndFirstInstallment(LOMDTO00084 dto)
        {
            return this.hpRegListsDAO.Get_TotalInterestAndFirstInstallment(dto);
        }
        public IList<LOMDTO00244> CheckAccountForAccountClosed(string acctNo,string sourceBr)
        {
            #region 
            IList<LOMDTO00244> lst = this.hpRegListsDAO.CheckAccountForAccountClosed(acctNo, sourceBr);
            if (lst == null || lst.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.ME30012;//Data Not Found.
            }

            if (lst[0].RetCode == "-1")
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MV00046;
            }
            else if (lst[0].RetCode == "-2")
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MV00201;
            }
            else if (lst[0].RetCode == "-3")
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MV00054;
            }
            else if (lst[0].RetCode == "-4")
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MV90205;
            }

            else if (lst[0].RetCode == "-5")
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MV00206;
            }
            else if (lst[0].RetCode == "-6")
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MV00057;
            }
            else if (lst[0].RetCode == "-7")
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MV00056;
            }
            return lst;

            #endregion
            //return this.hpRegListsDAO.CheckAccountForAccountClosed(acctNo, sourceBr);
        }
        
        public IList<LOMDTO00244> GetAccountInfoForAccountClosed(string acctNo, string sourceBr)
        {
            return this.hpRegListsDAO.GetAccountInfoForAccountClosed(acctNo, sourceBr);
        }

        public string Save_AccountClosed(LOMDTO00244 dto)
        {
            return this.hpRegListsDAO.Save_AccountClosed(dto);
        }

        public IList<LOMDTO00244> AccountClosedListing(LOMDTO00244 dto)
        {
            return this.hpRegListsDAO.AccountClosedListing(dto);
        }
        public IList<LOMDTO00245> TransactionListing(LOMDTO00245 dto)
        {
            return this.hpRegListsDAO.TransactionListing(dto);
        }
        
        //Added by YMP for Late Fee Exception (Checker) (17-May-2019)
        public IList<LOMDTO00219> GetLateFeeInfoAllForChecker()
        {
            return this.hpRegListsDAO.GetLateFeeInfoAllForChecker();
        }


        //Added by YMP for Late Fee Exception (15-May-2019)
        public IList<LOMDTO00219> GetLateFeeInfoByACNo(string Acctno, string SourceBr)
        {
            return this.hpRegListsDAO.GetLateFeeInfoByACNo(Acctno,SourceBr);
        }

        //Added by YMP for Late Fee Exception (Maker) (15-May-2019)
        public string SaveLateFeeExceptionInfo(IList<LOMDTO00219> SaveLateFeeExceptionInfo)
        {
            return this.hpRegListsDAO.SaveLateFeeExceptionInfo(SaveLateFeeExceptionInfo);
        }

        //Added by YMP for Late Fee Exception (Checker) (17-May-2019)
        public string UpdateLateFeeExceptionInfo(IList<LOMDTO00219> latefeeinfo, string ApproveReject)
        {
            return this.hpRegListsDAO.UpdateLateFeeExceptionInfo(latefeeinfo,ApproveReject);
        }
    }
}
