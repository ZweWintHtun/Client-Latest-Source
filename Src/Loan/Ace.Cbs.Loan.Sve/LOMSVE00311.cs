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
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Core.DataModel;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00311 : BaseService, ILOMSVE00311
    {
        #region Constructor
        //Comment by HMW at 03-Jan-2020
        //LOMSVE00311()
        //{
        //    budget = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
        //}
        #endregion

        #region Properties

        public ICXSVE00002 CodeGenerator { get; set; }

        private ICXDAO00006 accountDAO;
        public ICXDAO00006 AccountDAO
        {
            get { return this.accountDAO; }
            set { this.accountDAO = value; }
        }

        private ILOMDAO00311 personalLoanDAO;
        public ILOMDAO00311 PersonalLoanDAO
        {
            get { return this.personalLoanDAO; }
            set { this.personalLoanDAO = value; }
        }

        private ILOMDAO00312 personalLoanDetailDAO;
        public ILOMDAO00312 PersonalLoanDetailDAO
        {
            get { return this.personalLoanDetailDAO; }
            set { this.personalLoanDetailDAO = value; }
        }

        private ILOMDAO00313 pl_GuanDAO;
        public ILOMDAO00313 PL_GuanDAO
        {
            get { return this.pl_GuanDAO; }
            set { this.pl_GuanDAO = value; }
        }

        private IPFMDAO00028 cledgerDAO;
        public IPFMDAO00028 CledgerDAO
        {
            get { return this.cledgerDAO; }
            set { this.cledgerDAO = value; }
        }

        private ILOMDAO00012 penalFeeDAO;
        public ILOMDAO00012 PenalFeeDAO
        {
            get { return this.penalFeeDAO; }
            set { this.penalFeeDAO = value; }
        }

        private IPFMDAO00056 sys001DAO;
        public IPFMDAO00056 Sys001DAO
        {
            get { return this.sys001DAO; }
            set { this.sys001DAO = value; }
        }

        //public string budget { get; set; }
        public string plno { get; set; }
        public string acctno { get; set; }
        public string acsign { get; set; }
        public string currency { get; set; }
        public string sourceBr { get; set; }        

        string loanNo, eno;

        #endregion

        #region Logical Methods

        #region Save Methods

        [Transaction(TransactionPropagation.Required)]
        public string Save_PersonalLoans(LOMDTO00313 personal_GuaranteeDto, LOMDTO00311 loanDto, IList<LOMDTO00012> penalFeeList, string sourceBranch)
        {
            try
            {
                sourceBr = loanDto.SourceBr.Trim();
                sourceBranch = loanDto.SourceBr.Trim();
                acsign = loanDto.ACSign;
                //plno = loanDto.PLNo;
                //string AcnoName = "";

                #region ***Save***

                if (loanDto.status.Contains("save"))
                {
                    DateTime nextSettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), sourceBr, true });

                    loanNo = this.CodeGenerator.GetGenerateCode("PersonalLoanNo", "PersonalLoanNo", 1, sourceBranch, new object[] { sourceBranch });
                    //eno = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, 1, loanDto.SourceBr, new object[] { nextSettlementDate.ToString("dd"), nextSettlementDate.ToString("MM"), nextSettlementDate.ToString("yy") });
                    eno = "";

                    loanDto.PLNo = loanNo.ToString();
                    personal_GuaranteeDto.PLNo = loanNo.ToString();

                    //this.personalLoanDAO.Save(this.GetPersonalLoanORM(loanDto));
                    //this.pl_GuanDAO.Save(this.GetPersonal_GuaranteeORM(personal_GuaranteeDto));

                    int PaymentFreq =Convert.ToInt16(loanDto.RepaymentPeriod);
                    int PaymentDuration = Convert.ToInt16(loanDto.RepaymentDuration);
                    int NoOfTerms =  PaymentDuration / PaymentFreq;
                    decimal SAmt = Convert.ToDecimal(loanDto.SAmt);
                    decimal RemainingCapital = Convert.ToDecimal(loanDto.SAmt);

                    //string PLNo,string AcctNo,int NoOfTerms,decimal SanAmt,decimal IntRate,decimal DocumentFee,
                    //int PaymentDuration,string PaymentOptionId,string UserNo,string SourceBr,string Cur,int CreatedUserId,
                    //string ENo,DateTime SDate,string BType,DateTime ExpireDate,string Assessor,string Lawer,decimal MonthlyIncome,
                    //bool isSCharge,decimal SCharges,bool isLateFee,string CompanyName,string Name,string Nrc,string Phone)

                    //ploanDto.PLNo, ploanDto.ACNo, ploanDto.BType, ploanDto.SDate,ploanDto.SAmt, ploanDto.ExpireDate, ploanDto.IntRate,
                    // ploanDto.UserNo,ploanDto.Assessor, ploanDto.Lawer, ploanDto.MonthlyIncome,
                    // ploanDto.DocFee, ploanDto.isSCharge, ploanDto.isLateFee;
                    //ploanDto.BalStatus, ploanDto.UId, ploanDto.SourceBr, ploanDto.Cur,ploanDto.CreatedDate, ploanDto.CreatedUserId; 

                    //ploanDto.FirstSAmt, ploanDto.Vouchered,ploanDto.ACSign,ploanDto.BalStatus,

                    LOMDTO00311 result =  this.personalLoanDAO.AddPLRegTermAndVouUpdate(loanDto.PLNo, loanDto.ACNo, NoOfTerms, SAmt, Convert.ToDecimal(loanDto.IntRate), Convert.ToDecimal(loanDto.DocFee),
                        PaymentDuration, PaymentFreq.ToString(), loanDto.UserNo, loanDto.SourceBr, loanDto.Cur, loanDto.CreatedUserId, eno,Convert.ToDateTime(loanDto.SDate),
                        loanDto.BType, Convert.ToDateTime(loanDto.ExpireDate), loanDto.Assessor, loanDto.Lawer, Convert.ToDecimal(loanDto.MonthlyIncome), loanDto.MonthlyRepayDate, loanDto.ProductType, loanDto.CompanyName, Convert.ToBoolean(loanDto.isSCharge),
                        Convert.ToDecimal(loanDto.SCharges), Convert.ToBoolean(loanDto.isLateFee),
                        personal_GuaranteeDto.COMPANYNAME,personal_GuaranteeDto.NAME,personal_GuaranteeDto.NRC,personal_GuaranteeDto.PHONE,Convert.ToDecimal(loanDto.NYIntRate),loanDto.GPeriod);//Updated by HWKO (02-Oct-2017)

                    if (result.RetMsg != "0")
                    {
                        this.ServiceResult.ErrorOccurred = true;
                    }
                    //for (int i = 1; i <= NoOfTerms; i++)
                    //{
                    //    LOMDTO00312 plDetail = new LOMDTO00312();
                    //    plDetail.PLNO = loanNo;
                    //    plDetail.TermNo = i;
                    //    plDetail.InstallmentAmount = ((SAmt * (loanDto.IntRate / 100)) + SAmt) / PaymentDuration;
                    //    plDetail.RemainingCapital = RemainingCapital = RemainingCapital - plDetail.InstallmentAmount;
                    //    plDetail.InterestRate = loanDto.IntRate;
                    //    plDetail.InterestAmount = (RemainingCapital * (loanDto.IntRate / 100)) / PaymentDuration;
                    //    plDetail.Acctno = loanDto.ACNo;
                    //    plDetail.UserNo = loanDto.UserNo;
                    //    plDetail.SourceBr = loanDto.SourceBr;
                    //    plDetail.Cur = loanDto.Cur;
                    //    plDetail.CreatedDate = DateTime.Now;
                    //    plDetail.CreatedUserId = loanDto.CreatedUserId;

                    //    this.personalLoanDetailDAO.Save(this.GetPersonalLoanDetailORM(plDetail));
                    //}

                    

                    if (!this.CledgerDAO.UpdateLoansCountForLoan(sourceBranch, loanDto.ACNo, loanDto.CreatedUserId, loanDto.CreatedDate))
                        this.ServiceResult.ErrorOccurred = true;

                    //if (loanDto.isLateFee && penalFeeList.Count > 0)
                    //{
                    //    foreach (LOMDTO00012 penalFeeDto in penalFeeList)
                    //    {
                    //        penalFeeDto.Lno = loanNo;
                    //        this.PenalFeeDAO.Save(this.GetPenalFeeORM(penalFeeDto));
                    //    }
                    //}
                }

                #endregion
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90000";  //Saving Error.
            }
            return loanNo;
        }

        #endregion

        #region Select Methods
        //Added by ZMS
        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00072> IsValidForLoanAcctnoForHPRepaymentListing(string acctno)
        {
            IList<PFMDTO00072> AccountInfoList = new List<PFMDTO00072>();
            try
            {
                // Select Current Account Info , loan acctno must be current acctno...
                AccountInfoList = this.AccountDAO.GetCurrentAccountInfoByAccountNumber_ForClosedACAndUnClosed(acctno);
                if (AccountInfoList.Count > 0)
                {
                    //Close Account Checking
                    if (AccountInfoList[0].CloseDate.ToShortDateString() != "01/01/0001" && String.IsNullOrEmpty(AccountInfoList[0].CloseDate.ToShortDateString()))
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "MV00044";//Account No has been closed.
                    }

                    //Link Account Checking
                    int count = this.AccountDAO.GetLinkAccountCountByCurrentAccountNo(acctno);
                    if (count > 0)
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "MV00056"; //This Account {0} is already Link Account.
                    }

                    //Legal Case Checking
                    //int legalcaseCount = this.personalLoanDAO.GetLegalCaseFromPersonalLoansByAccountNo(acctno);
                    //if (legalcaseCount > 0)
                    //{
                    //    this.ServiceResult.ErrorOccurred = true;
                    //    this.ServiceResult.MessageCode = "MV90069"; // This AccountNo. ( {0} ) is in Legal Case ! 
                    //}
                }
                else
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV00046"; //	Invalid Account No.
                }

                return AccountInfoList;
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV00058";// Invalid Current Account No.
            }

            return AccountInfoList;
        }


        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00072> IsValidForLoanAcctno(string acctno)
        {
            IList<PFMDTO00072> AccountInfoList = new List<PFMDTO00072>();
            try
            {
                // Select Current Account Info , loan acctno must be current acctno...
                AccountInfoList = this.AccountDAO.GetCurrentAccountInfoByAccountNumber(acctno);
                if (AccountInfoList.Count > 0)
                {
                    //Close Account Checking
                    if (AccountInfoList[0].CloseDate.ToShortDateString() != "01/01/0001" && String.IsNullOrEmpty(AccountInfoList[0].CloseDate.ToShortDateString()))
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "MV00044";//Account No has been closed.
                    }

                    //Link Account Checking
                    int count = this.AccountDAO.GetLinkAccountCountByCurrentAccountNo(acctno);
                    if (count > 0)
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "MV00056"; //This Account {0} is already Link Account.
                    }

                    //Legal Case Checking
                    //int legalcaseCount = this.personalLoanDAO.GetLegalCaseFromPersonalLoansByAccountNo(acctno);
                    //if (legalcaseCount > 0)
                    //{
                    //    this.ServiceResult.ErrorOccurred = true;
                    //    this.ServiceResult.MessageCode = "MV90069"; // This AccountNo. ( {0} ) is in Legal Case ! 
                    //}
                }
                else
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV00046"; //	Invalid Account No.
                }

                return AccountInfoList;
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV00058";// Invalid Current Account No.
            }

            return AccountInfoList;
        }

        //Added by ZMS
        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00072> IsValidForLoanAcctnoForPLRepaymentListing(string acctno)
        {
            IList<PFMDTO00072> AccountInfoList = new List<PFMDTO00072>();
            try
            {
                // Select Current Account Info , loan acctno must be current acctno...
                AccountInfoList = this.AccountDAO.GetCurrentAccountInfoByAccountNumber_ForClosedACAndUnClosed(acctno);
                if (AccountInfoList.Count > 0)
                {
                    //Close Account Checking
                    if (AccountInfoList[0].CloseDate.ToShortDateString() != "01/01/0001" && String.IsNullOrEmpty(AccountInfoList[0].CloseDate.ToShortDateString()))
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "MV00044";//Account No has been closed.
                    }

                    //Link Account Checking
                    int count = this.AccountDAO.GetLinkAccountCountByCurrentAccountNo(acctno);
                    if (count > 0)
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "MV00056"; //This Account {0} is already Link Account.
                    }

                    //Legal Case Checking
                    //int legalcaseCount = this.personalLoanDAO.GetLegalCaseFromPersonalLoansByAccountNo(acctno);
                    //if (legalcaseCount > 0)
                    //{
                    //    this.ServiceResult.ErrorOccurred = true;
                    //    this.ServiceResult.MessageCode = "MV90069"; // This AccountNo. ( {0} ) is in Legal Case ! 
                    //}
                }
                else
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV00046"; //	Invalid Account No.
                }

                return AccountInfoList;
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV00058";// Invalid Current Account No.
            }

            return AccountInfoList;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00028> IsValidForLoanAcctnoForPLContractPrinting(string acctno ,string sourceBranchCode)
        {
            //commented by ZMS for Pristine requirement 8.11.2018
            //IList<PFMDTO00072> AccountInfoList = new List<PFMDTO00072>();

            IList<PFMDTO00028> AccountInfoList = new List<PFMDTO00028>();
            try
            {
                // Select Current Account Info , loan acctno must be current acctno...
                //AccountInfoList = this.AccountDAO.GetCurrentAccountInfoByAccountNumber(acctno);
                AccountInfoList = this.CledgerDAO.SelectAccountInfoFromCledgerForPLContractPrinting(acctno, sourceBranchCode);
                if (AccountInfoList.Count > 0)
                {
                    //commented by ZMS for Pristine requirement 8.11.2018
                    //Close Account Checking
                    //if (AccountInfoList[0].CloseDate.ToShortDateString() != "01/01/0001" && String.IsNullOrEmpty(AccountInfoList[0].CloseDate.ToShortDateString()))
                    //{
                    //    this.ServiceResult.ErrorOccurred = true;
                    //    this.ServiceResult.MessageCode = "MV00044";//Account No has been closed.
                    //}

                    //Link Account Checking
                    int count = this.AccountDAO.GetLinkAccountCountByCurrentAccountNo(acctno);
                    if (count > 0)
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "MV00056"; //This Account {0} is already Link Account.
                    }

                    //Legal Case Checking
                    //int legalcaseCount = this.personalLoanDAO.GetLegalCaseFromPersonalLoansByAccountNo(acctno);
                    //if (legalcaseCount > 0)
                    //{
                    //    this.ServiceResult.ErrorOccurred = true;
                    //    this.ServiceResult.MessageCode = "MV90069"; // This AccountNo. ( {0} ) is in Legal Case ! 
                    //}
                }
                else
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV00046"; //	Invalid Account No.
                }

                return AccountInfoList;
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV00058";// Invalid Current Account No.
            }

            return AccountInfoList;
        }

        [Transaction(TransactionPropagation.Required)]
        public LOMDTO00311 SelectPersonalLoanInfoByLnoAndSourceBr(string lno, string sourcebr)
        {
            LOMDTO00311 ploanDto = new LOMDTO00311();
            try 
            {
                ploanDto = this.PersonalLoanDAO.GetPersonalLoansByLnoAndSourceBr(lno, sourcebr);
                if (ploanDto == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV90055"; //Invalid Loan No.
                }
                else if (ploanDto.CloseDate != null && !Convert.ToDateTime(ploanDto.CloseDate).ToString("dd/MM/yyyy").Contains("01/01/0001"))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV90057"; //Loans No. Already Closed!
                }
                else
                {
                    try
                    {
                        ploanDto.PL_GuanDto = this.PL_GuanDAO.SelectPL_GuanInfoByLoanNoAndSourceBr(lno, sourcebr);
                        if (ploanDto.PL_GuanDto == null)
                            throw new Exception();
                    }
                    catch (Exception ex)
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "MV90055"; //Invalid Loan No.
                    }
                }
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90055"; //Invalid Loan No.
            }
            return ploanDto;
        }
        #endregion

        public string PLMonthlyAutoPaymentProc(string sourceBr, int createdUserId, string userName, IList<DataVersionChangedValueDTO> dvcvList)
        {
            DateTime lastSettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("LastSettlementDate"), sourceBr, true });
            DateTime transactionDate;
            if (lastSettlementDate.Date == DateTime.Now.Date)
            {
                transactionDate = DateTime.Now; //For Current Date Transaction
            }
            else
            {
                string lastSDate = lastSettlementDate.ToString("yyyy-MM-dd") + " " + "23:59:05.000"; // To update SQLite data
                transactionDate = DateTime.Parse(lastSDate);//For Back Date Transaction
            }

            try
            {
                //Comment & Modified by HMW at (06-08-2019) : Generate ENO at Script side to prevent "Voucher No Loss Issue" in every already run (or) no need to run case.
                //string Eno = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, 1, sourceBr, new object[] { lastSettlementDate.ToString("dd"), lastSettlementDate.ToString("MM"), lastSettlementDate.ToString("yy") });

                string retMsg = this.personalLoanDAO.PLMonthlyAutoPaymentProc(sourceBr, createdUserId, userName);
                if (retMsg == "0")
                {
                    //this.sys001DAO.UpdateDateDailyPosting("PLMonthly_AutoPay", DateTime.Now, sourceBr, createdUserId);
                    this.ServiceResult.ErrorOccurred = false;
                    //DateTime settlementDate = DateTime.Now;
                    this.sys001DAO.UpdateDateDailyPosting("PLMonthly_AutoPay", transactionDate, sourceBr, createdUserId);

                    PFMDTO00056 InterestDateDTO = Sys001DAO.SelectSys001Info(sourceBr, "PLMonthly_AutoPay");
                    SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, createdUserId, InterestDateDTO.Id.ToString());
                    Dictionary<string, object> updateColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "Status", "Y" }, { "SysDate", transactionDate } };
                    Dictionary<string, object> whereColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "BranchCode", sourceBr }, { "Name", "PLMonthly_AutoPay" }, { "Active", true } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00056", updateColumnsandValuesForLoansInterestCalculation, whereColumnsandValuesForLoansInterestCalculation));

                    this.ServiceResult.MessageCode = CXMessage.MI90115;//Personal Loan Auto Payment Process is successfully finished.
                }
                else if (retMsg == "1")
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV90182;//Please Run PL Late Fees Auto Voucher Process Firstly!
                }
                else if (retMsg == "-1")
                {
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = CXMessage.MV90154;//No need to run auto pay process in this date!
                }
                else if (retMsg == "-2")
                {
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = CXMessage.MV90161;//Already Run Personal Loan Auto Payment Process!
                }
                else //retMsg=='-3' //Updated by HWKO (29-Aug-2017)
                {
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = CXMessage.MV90162;//No Records to run personal loans Monthly Auto Payment Process!

                    //DateTime settlementDate = DateTime.Now;
                    this.sys001DAO.UpdateDateDailyPosting("PLMonthly_AutoPay", transactionDate, sourceBr, createdUserId);

                    PFMDTO00056 InterestDateDTO = Sys001DAO.SelectSys001Info(sourceBr, "PLMonthly_AutoPay");
                    SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, createdUserId, InterestDateDTO.Id.ToString());
                    Dictionary<string, object> updateColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "Status", "Y" }, { "SysDate", transactionDate } };
                    Dictionary<string, object> whereColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "BranchCode", sourceBr }, { "Name", "PLMonthly_AutoPay" }, { "Active", true } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00056", updateColumnsandValuesForLoansInterestCalculation, whereColumnsandValuesForLoansInterestCalculation));
                }
                return retMsg;
            }
            catch (Exception ex)
            {
                //DateTime settlementDate = DateTime.Now;
                this.sys001DAO.UpdateDateDailyPosting("PLMonthly_AutoPay", lastSettlementDate, sourceBr, createdUserId);

                PFMDTO00056 InterestDateDTO = Sys001DAO.SelectSys001Info(sourceBr, "PLMonthly_AutoPay");
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, createdUserId, InterestDateDTO.Id.ToString());
                Dictionary<string, object> updateColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "Status", "Y" }, { "SysDate", transactionDate } };
                Dictionary<string, object> whereColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "BranchCode", sourceBr }, { "Name", "PLMonthly_AutoPay" }, { "Active", true } };
                CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00056", updateColumnsandValuesForLoansInterestCalculation, whereColumnsandValuesForLoansInterestCalculation));

                throw;
            }
        }

        public string PLLateFeesCalculationProcess(string sourceBr, int createdUserId, string userName, IList<DataVersionChangedValueDTO> dvcvList)
        {
            try
            {
                DateTime nextSettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("LastSettlementDate"), sourceBr, true });
                DateTime plLateFeesRunDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), sourceBr, true });

                string Eno = this.CodeGenerator.GetGenerateCode("PLRegisterVoucher", string.Empty, 1, sourceBr, new object[] { nextSettlementDate.ToString("dd"), nextSettlementDate.ToString("MM"), nextSettlementDate.ToString("yy") });

                string retMsg = this.personalLoanDAO.PLLateFeesCalculationProcess(sourceBr, createdUserId, userName);
                if (retMsg == "0")
                {
                    this.sys001DAO.UpdateDateDailyPosting("PLLateFees_AutoRun", nextSettlementDate.AddDays(-1), sourceBr, createdUserId);
                    this.ServiceResult.ErrorOccurred = false;

                    PFMDTO00056 InterestDateDTO = Sys001DAO.SelectSys001Info(sourceBr, "PLLateFees_AutoRun");
                    SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, createdUserId, InterestDateDTO.Id.ToString());
                    Dictionary<string, object> updateColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "Status", "Y"} , { "SysDate", nextSettlementDate.AddDays(-1) } };
                    Dictionary<string, object> whereColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "BranchCode", sourceBr }, { "Name", "PLLateFees_AutoRun" }, { "Active", true } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00056", updateColumnsandValuesForLoansInterestCalculation, whereColumnsandValuesForLoansInterestCalculation));
                    
                    this.ServiceResult.MessageCode = CXMessage.MI90116;//Personal Loan Late Fees Calculation Process is successfully finished!
                }
                else if (retMsg == "1")
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV90182;//Please Run PL Auto Payment Process Firstly!
                }
                else //if retMsg == "-1"
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV90180;//There is no late fees in this date!. 

                    this.sys001DAO.UpdateDateDailyPosting("PLLateFees_AutoRun", plLateFeesRunDate.AddDays(-1), sourceBr, createdUserId);

                    PFMDTO00056 InterestDateDTO = Sys001DAO.SelectSys001Info(sourceBr, "PLLateFees_AutoRun");
                    SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, createdUserId, InterestDateDTO.Id.ToString());
                    Dictionary<string, object> updateColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "Status", "Y" }, { "SysDate", plLateFeesRunDate.AddDays(-1) } };
                    Dictionary<string, object> whereColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "BranchCode", sourceBr }, { "Name", "PLLateFees_AutoRun" }, { "Active", true } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00056", updateColumnsandValuesForLoansInterestCalculation, whereColumnsandValuesForLoansInterestCalculation));
                    
                }
                return retMsg;
            }
            catch (Exception ex)
            {
                //DateTime nextSettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), sourceBr, true });

                //this.sys001DAO.UpdateDateDailyPosting("PLLateFees_AutoRun", nextSettlementDate.AddDays(-1), sourceBr, createdUserId);

                //PFMDTO00056 InterestDateDTO = Sys001DAO.SelectSys001Info(sourceBr, "PLLateFees_AutoRun");
                //SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, createdUserId, InterestDateDTO.Id.ToString());
                //Dictionary<string, object> updateColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "Status", "Y" }, { "SysDate", nextSettlementDate.AddDays(-1) } };
                //Dictionary<string, object> whereColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "BranchCode", sourceBr }, { "Name", "PLLateFees_AutoRun" }, { "Active", true } };
                //CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00056", updateColumnsandValuesForLoansInterestCalculation, whereColumnsandValuesForLoansInterestCalculation));
                    

                throw;
            }
        }

        //Added by HWKO (13-Oct-2017)
        //For Personal Loans Manual Prepayment

        public string CheckPLAccountandStartTerm(string plNo, string sourceBr)
        {
            return this.PersonalLoanDAO.CheckPLAccountandStartTerm(plNo, sourceBr);
        }

        public string Get_PL_PrepaymentInfo_NewLogic(string plNo, int startTerm, int endTerm, string sourceBr)
        {
            return this.PersonalLoanDAO.Get_PL_PrepaymentInfo_NewLogic(plNo, startTerm, endTerm, sourceBr);
        }

        public string PL_Manual_Pre_Payment_Process_NewLogic(string plNo, int startTerm, int endTerm, decimal totalPaidInstallmentAmt, decimal totalPaidPrincipleAmt, decimal totalPaidRentalChgAmt,
                                                    decimal rentalDiscountRate, string eno, string sourceBr, int createdUserId, string userName)
        {
            DateTime lastSettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("LastSettlementDate"), sourceBr, true });
            string Eno = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, 1, sourceBr, new object[] { lastSettlementDate.ToString("dd"), lastSettlementDate.ToString("MM"), lastSettlementDate.ToString("yy") });
            string retMsg = this.PersonalLoanDAO.PL_Manual_Pre_Payment_Process_NewLogic(plNo, startTerm, endTerm, totalPaidInstallmentAmt, totalPaidPrincipleAmt, totalPaidRentalChgAmt, rentalDiscountRate,
                                                                             Eno, sourceBr, createdUserId, userName);
            if (retMsg == "0")
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MI90128;//PL Manual Prepayment Process is successfully finished!.
            }
            else
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MV90159;//InSufficient Balance in Customer Account !
            }
            return retMsg;
        }

        //Endregion

        //Added by HWKO (16-Oct-2017)
        public string PLLateFeesAutoPayVoucherProcess(string eno, string sourceBr, int createdUserId, string userName, IList<DataVersionChangedValueDTO> dvcvList)
        {
            DateTime lastSettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("LastSettlementDate"), sourceBr, true });
            DateTime transactionDate;
            if (lastSettlementDate.Date == DateTime.Now.Date)
            {
                transactionDate = DateTime.Now; //For Current Date Transaction
            }
            else
            {
                string lastSDate = lastSettlementDate.ToString("yyyy-MM-dd") + " " + "23:59:02.000"; // To update SQLite data
                transactionDate = DateTime.Parse(lastSDate);//For Back Date Transaction
            }

            //Comment & Modified by HMW at (31-07-2019) : Generate ENO at Script side to prevent "Voucher No Loss Issue" in every already run (or) no need to run case.
            //eno = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, 1, sourceBr, new object[] { lastSettlementDate.ToString("dd"), lastSettlementDate.ToString("MM"), lastSettlementDate.ToString("yy") });
            //string str = this.PersonalLoanDAO.PLLateFeesAutoPayVoucherProcess(eno, sourceBr, createdUserId, userName);
                        
            string str = this.PersonalLoanDAO.PLLateFeesAutoPayVoucherProcess(sourceBr, createdUserId, userName);
            if (str == "0")
            {
                this.ServiceResult.ErrorOccurred = false;
                PFMDTO00056 InterestDateDTO = sys001DAO.SelectSys001Info(sourceBr, "PLLateFees_AutoPay");
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, createdUserId, InterestDateDTO.Id.ToString());
                //Dictionary<string, object> updateColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "Status", "Y" }, { "SysDate", DateTime.Now } };
                Dictionary<string, object> updateColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "Status", "Y" }, { "SysDate", transactionDate } };
                Dictionary<string, object> whereColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "BranchCode", sourceBr }, { "Name", "PLLateFees_AutoPay" }, { "Active", true } };
                CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00056", updateColumnsandValuesForLoansInterestCalculation, whereColumnsandValuesForLoansInterestCalculation));

                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MI90129;//PL Late Fees Auto Voucher Process is successfully finshed!.
            }
            else if (str == "-2")
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MV90189;//Already Run PL Late Fees Auto Voucher Process!.
            }
            else if (str == "-3")
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.ME00070;//Please check the "System Date" and "Settlement Date" First!
            }
            else //(str == "-1")
            {
                this.ServiceResult.ErrorOccurred = false;
                PFMDTO00056 InterestDateDTO = sys001DAO.SelectSys001Info(sourceBr, "PLLateFees_AutoPay");
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, createdUserId, InterestDateDTO.Id.ToString());
                //Dictionary<string, object> updateColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "Status", "Y" }, { "SysDate", DateTime.Now } };
                Dictionary<string, object> updateColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "Status", "Y" }, { "SysDate", transactionDate } };
                Dictionary<string, object> whereColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "BranchCode", sourceBr }, { "Name", "PLLateFees_AutoPay" }, { "Active", true } };
                CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00056", updateColumnsandValuesForLoansInterestCalculation, whereColumnsandValuesForLoansInterestCalculation));


                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MV90186;//No Data For Late Fees Auto Pay Voucher Process! 
            }
            return str;
        }
        //endregion

        //Added by HWKO (26-Oct-2017)
        public string GetPLNoByACNoAndSourceBr(string acctNo, string sourceBr)
        {
            return this.PersonalLoanDAO.GetPLNoByACNoAndSourceBr(acctNo, sourceBr);
        }
        //End Region

        //Added by HWKO (08-Dec-2017)
        public string GetHPNoByACNoAndSourceBr(string acctNo, string sourceBr)
        {
            return this.PersonalLoanDAO.GetHPNoByACNoAndSourceBr(acctNo, sourceBr);
        }

        //Added by HWKO (14-Dec-2017)
        public string GetBLNoByACNoAndSourceBr(string acctNo, string sourceBr)
        {
            return this.PersonalLoanDAO.GetBLNoByACNoAndSourceBr(acctNo, sourceBr);
        }

        //Added by HWKO (08-Dec-2017)
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00334> GetHPInfoForContractPrinting(LOMDTO00334 dto)
        {
            IList<LOMDTO00334> DataList = new List<LOMDTO00334>();
            DataList = this.PersonalLoanDAO.GetHPInfoForContractPrinting(dto.HPNo, dto.SourceBr);
            return DataList;
        }

        //Added by HWKO (08-Dec-2017)
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00334> GetCustInfoByAcctNo(string acctNo, string sourceBr)
        {
            IList<LOMDTO00334> DataList = new List<LOMDTO00334>();
            DataList = this.PersonalLoanDAO.GetCustInfoByAcctNo(acctNo, sourceBr);
            return DataList;
        }

        //Added by YMP (19-Feb-2019)
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00338> GetCustInfoByAcctNoForBL_LB(string acctNo, string sourceBr)
        {
            IList<LOMDTO00338> DataList = new List<LOMDTO00338>();
            DataList = this.PersonalLoanDAO.GetCustInfoByAcctNoForBL_LB(acctNo, sourceBr);
            return DataList;
        }

        //Added by HWKO (08-Dec-2017)
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00336> GetPLInfoForContractPrinting(LOMDTO00336 dto)
        {
            IList<LOMDTO00336> DataList = new List<LOMDTO00336>();
            DataList = this.PersonalLoanDAO.GetPLInfoForContractPrinting(dto.PLNo, dto.SourceBr);
            return DataList;
        }

        //Added by HWKO (13-Dec-2017)
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00338> GetBLHPInfoForContractPrinting(LOMDTO00338 dto)
        {
            IList<LOMDTO00338> DataList = new List<LOMDTO00338>();
            DataList = this.PersonalLoanDAO.GetBLHPInfoForContractPrinting(dto.Lno, dto.SourceBr);
            return DataList;
        }

        //Added by HWKO (13-Dec-2017)
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00338> GetBLLBInfoForContractPrinting(LOMDTO00338 dto)
        {
            IList<LOMDTO00338> DataList = new List<LOMDTO00338>();
            DataList = this.PersonalLoanDAO.GetBLLBInfoForContractPrinting(dto.Lno, dto.SourceBr);
            return DataList;
        }

        //Added by HWKO (13-Dec-2017)
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00338> GetBLPGInfoForContractPrinting(LOMDTO00338 dto)
        {
            IList<LOMDTO00338> DataList = new List<LOMDTO00338>();
            DataList = this.PersonalLoanDAO.GetBLPGInfoForContractPrinting(dto.Lno, dto.SourceBr);
            return DataList;
        }

        //End Region

        //Added by HWKO (27-Oct-2017) //For Personal Loans Voucher Outstanding Listing
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00311> GetPLVrOutstandingListing(LOMDTO00311 dto)
        {
            IList<LOMDTO00311> DataList = new List<LOMDTO00311>();
            DataList = this.PersonalLoanDAO.GetPLVrOutstandingListing(dto.SourceBr, dto.Cur);
            return DataList;
        }

        //Added by HWKO (07-Nov-2017) //For Business Loans Voucher Outstanding Listing
        [Transaction(TransactionPropagation.Required)]
        public IList<TLMDTO00018> GetBLVrOutstandingListing(TLMDTO00018 dto)
        {
            IList<TLMDTO00018> DataList = new List<TLMDTO00018>();
            DataList = this.PersonalLoanDAO.GetBLVrOutstandingListing(dto.SourceBranchCode, dto.Currency);
            return DataList;
        }

        //Added by HWKO (07-Nov-2017) //For Business Loans Voucher Outstanding Listing
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00311> GetPLLFOutstandingListing(LOMDTO00311 dto)
        {
            IList<LOMDTO00311> DataList = new List<LOMDTO00311>(); 
            DataList = this.PersonalLoanDAO.GetPLLFOutstandingListing(dto.SourceBr, dto.Cur);
            return DataList;
        }

        //Added by AAM (22-May-2018)
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00243> Get_PLInfoRegisterEdit_ByAcctNo(string acctNo, string sourceBr)
        {
            IList<LOMDTO00243> dto = new List<LOMDTO00243>();
            dto = this.PersonalLoanDAO.Get_PLInfoRegisterEdit_ByAcctNo(acctNo, sourceBr);
            if (dto == null || dto.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.ME30012;//Data Not Found.
            }
            return dto;
        }

        public string Save_PLInfoRegisterEdit_ByAcctNo(string acctNo, string sourceBr, string companyName, string guaCompanyName
                                                       , string guaName, string guaNRC, string guaPhone, int createdUserId)
        {
            string str= this.PersonalLoanDAO.Save_PLInfoRegisterEdit_ByAcctNo(acctNo, sourceBr, companyName, guaCompanyName
                                                                         , guaName, guaNRC, guaPhone, createdUserId);
            if (str=="0")
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MI90136;
            }
            return str;
        }

        #endregion

        #region Convert DTO To ORM

        private LOMORM00313 GetPersonal_GuaranteeORM(LOMDTO00313 personal_GuaranteeDto)
        {
            LOMORM00313 personal_GuaranteeOrm = new LOMORM00313();

            personal_GuaranteeOrm.PLNO = loanNo;
            personal_GuaranteeOrm.COMPANYNAME = personal_GuaranteeDto.COMPANYNAME;
            personal_GuaranteeOrm.NAME = personal_GuaranteeDto.NAME;
            personal_GuaranteeOrm.NRC = personal_GuaranteeDto.NRC;
            personal_GuaranteeOrm.PHONE = personal_GuaranteeDto.PHONE;
            personal_GuaranteeOrm.CLOSEDATE = personal_GuaranteeDto.CLOSEDATE;
            personal_GuaranteeOrm.UId = personal_GuaranteeDto.UId;
            personal_GuaranteeOrm.SourceBr = personal_GuaranteeDto.SourceBr;
            personal_GuaranteeOrm.Cur = personal_GuaranteeDto.Cur;
            personal_GuaranteeOrm.Active = personal_GuaranteeDto.Active;
            personal_GuaranteeOrm.CreatedDate = personal_GuaranteeDto.CreatedDate;
            personal_GuaranteeOrm.CreatedUserId = personal_GuaranteeDto.CreatedUserId;

            return personal_GuaranteeOrm;
        }

        private LOMORM00311 GetPersonalLoanORM(LOMDTO00311 ploanDto)
        {
            LOMORM00311 ploanOrm = new LOMORM00311();
            ploanOrm.PLNo = plno = ploanDto.PLNo;
            ploanOrm.ACNo = acctno = ploanDto.ACNo;
            ploanOrm.BType = ploanDto.BType;
            ploanOrm.SDate = Convert.ToDateTime(ploanDto.SDate);
            ploanOrm.SAmt =  Convert.ToDecimal(ploanDto.SAmt);
            ploanOrm.ExpireDate = Convert.ToDateTime(ploanDto.ExpireDate);
            ploanOrm.IntRate =  Convert.ToDecimal(ploanDto.IntRate);
            ploanOrm.FirstSAmt = Convert.ToDecimal(ploanDto.FirstSAmt);
            ploanOrm.LasIntDate= Convert.ToDateTime(ploanDto.LasIntDate);
            ploanOrm.Vouchered =  Convert.ToBoolean(ploanDto.Vouchered);
            ploanOrm.ACSign = acsign = ploanDto.ACSign;
            ploanOrm.UserNo = ploanDto.UserNo;
            ploanOrm.Assessor = ploanDto.Assessor;
            ploanOrm.Lawer = ploanDto.Lawer;
            ploanOrm.MonthlyIncome = ploanDto.MonthlyIncome;
            ploanOrm.DocFee = Convert.ToDecimal(ploanDto.DocFee);
            ploanOrm.LegalCase = Convert.ToBoolean(ploanDto.LegalCase);
            ploanOrm.LegalDate= ploanDto.LegalDate;
            ploanOrm.LegaLawer = ploanDto.LegaLawer;
            ploanOrm.CloseDate   = Convert.ToDateTime(ploanDto.CloseDate);    
            ploanOrm.NPLCase = Convert.ToBoolean(ploanDto.NPLCase);
            ploanOrm.NPLDate= Convert.ToDateTime(ploanDto.NPLDate);
            ploanOrm.LastUserNo= ploanDto.LastUserNo;
            ploanOrm.LastDate= Convert.ToDateTime(ploanDto.LastDate);
            ploanOrm.Partial= Convert.ToBoolean(ploanDto.Partial);
            ploanOrm.VoucherDate= Convert.ToDateTime(ploanDto.VoucherDate);
            ploanOrm.PartialNo= Convert.ToInt16(ploanDto.PartialNo);
            ploanOrm.SCharges= Convert.ToDecimal(ploanDto.SCharges);
            ploanOrm.TodSerial= ploanDto.TodSerial;
            ploanOrm.TodCloseDate=  Convert.ToDateTime(ploanDto.TodCloseDate);
            ploanOrm.Charges_Status = ploanDto.Charges_Status;
            ploanOrm.MarkNPLUser= ploanDto.MarkNPLUser;
            ploanOrm.NPLReleaseUser= ploanDto.NPLReleaseUser;
            ploanOrm.MarkLegalUser= ploanDto.MarkLegalUser;
            ploanOrm.LegalReleaseUser = ploanDto.LegalReleaseUser;
            ploanOrm.isSCharge = Convert.ToBoolean(ploanDto.isSCharge);
            ploanOrm.isLateFee = Convert.ToBoolean(ploanDto.isLateFee);
            ploanOrm.BalStatus = ploanDto.BalStatus;
            ploanOrm.UId = ploanDto.UId;
            ploanOrm.SourceBr = sourceBr = ploanDto.SourceBr;
            ploanOrm.Cur = currency = ploanDto.Cur;
            ploanOrm.CreatedDate = ploanDto.CreatedDate;
            ploanOrm.CreatedUserId = ploanDto.CreatedUserId;            
            
            return ploanOrm;
        }

        private LOMORM00312 GetPersonalLoanDetailORM(LOMDTO00312 plDetailDto)
        {
            LOMORM00312 plDetailOrm = new LOMORM00312();
            plDetailOrm.PLNO = plno = plDetailDto.PLNO;
            plDetailOrm.Acctno = plDetailDto.Acctno;
            plDetailOrm.TermNo = plDetailDto.TermNo;
            plDetailOrm.InstallmentAmount = plDetailDto.InstallmentAmount;
            plDetailOrm.RemainingCapital = plDetailDto.RemainingCapital;
            plDetailOrm.InterestRate = plDetailDto.InterestRate;
            plDetailOrm.InterestAmount = plDetailDto.InterestAmount;
            if (plDetailDto.InterestAmountPerDay == null)
                plDetailOrm.InterestAmountPerDay = 0;
            else
                plDetailOrm.InterestAmountPerDay = plDetailDto.InterestAmountPerDay;
            plDetailOrm.UserNo = plDetailDto.UserNo;
            plDetailOrm.SourceBr = sourceBr = plDetailDto.SourceBr;
            plDetailOrm.Cur = currency = plDetailDto.Cur;
            plDetailOrm.CreatedDate = plDetailDto.CreatedDate;
            plDetailOrm.CreatedUserId = plDetailDto.CreatedUserId;

            return plDetailOrm;
        }

        private LOMORM00012 GetPenalFeeORM(LOMDTO00012 penalFeeDto)
        {
            LOMORM00012 penalFeeOrm = new LOMORM00012();

            //penalFeeOrm.Lno = penalFeeDto.Lno;
            penalFeeOrm.Lno = loanNo;
            penalFeeOrm.StartDay = penalFeeDto.StartDay;
            penalFeeOrm.EndDay = penalFeeDto.EndDay;
            penalFeeOrm.Fee = penalFeeDto.Fee;
            penalFeeOrm.Amount = penalFeeDto.Amount;
            penalFeeOrm.Duration = penalFeeDto.Duration;
            //penalFeeOrm.Status = string.Empty;
            penalFeeOrm.SourceBr = sourceBr;
            penalFeeOrm.CreatedDate = penalFeeDto.CreatedDate;
            penalFeeOrm.CreatedUserId = penalFeeDto.CreatedUserId;

            return penalFeeOrm;
        }

        #endregion

        #region Data Version Update Service
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
        #endregion

    }
}
