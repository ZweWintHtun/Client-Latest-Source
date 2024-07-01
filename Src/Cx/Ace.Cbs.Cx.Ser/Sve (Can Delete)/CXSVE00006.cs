using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Mnm.Dmd;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Core.Service;

namespace Ace.Cbs.Cx.Ser.Sve
{
    /// <summary>
    /// Code Validation Checker
    /// </summary>
    public class CXSVE00006 : BaseService, ICXSVE00006
    {
        #region Private Variables
        private ICXDAO00003 printDAO;
        private ICXDAO00006 codeCheckerDAO;
        private ICXDAO00010 procedureDAO;
        private ICXDAO00004 tlfDAO;
        private ICXDAO00005 cashDAO;
        private ICXDAO00011 ibltlfDAO;
        private ICXDAO00012 hiscashdenoDAO;
        private ICXDAO00013 frpnDAO;
        #endregion

        #region Properties
        public ICXDAO00003 PrintDAO
        {
            get { return this.printDAO; }
            set { this.printDAO = value; }
        }
        public ICXDAO00006 CodeCheckerDAO 
        {
            get { return this.codeCheckerDAO; }
            set { this.codeCheckerDAO = value; }
        }
        public ICXDAO00010 ProcedureDAO 
        {
            get { return this.procedureDAO; }
            set { this.procedureDAO = value; }
        }
        public ICXDAO00004 TLFDAO
        {
            get { return this.tlfDAO; }
            set { this.tlfDAO = value; }
        }
        public ICXDAO00005 Cashdao
        {
            get { return this.cashDAO; }
            set { this.cashDAO = value; }
        }
        public ICXDAO00011 IBLTLFDAO
        {
            get { return this.ibltlfDAO; }
            set { this.ibltlfDAO = value; }
        }
        public ICXDAO00012 HisCashDAO
        {
            get { return this.hiscashdenoDAO; }
            set { this.hiscashdenoDAO = value; }
        }
        public ICXDAO00013 FPRNDAO
        {
            get { return this.frpnDAO; }
            set { this.frpnDAO = value; }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Check customer id is valid or not.
        /// </summary>
        /// <param name="customerId">Your customer id</param>
        /// <returns>Return true if your customer id is valid, or false</returns>
        public bool IsValidCustomerId(string customerId)
        {
            int count = this.codeCheckerDAO.CustomerSelectCount(customerId);
            return count > 0;
        }

        /// <summary>
        /// Get Customer Data by customer id
        /// </summary>
        /// <param name="customerId">Your customer id</param>
        /// <returns>Return customer data</returns>
        public PFMDTO00001 GetCustomerByCustomerId(string customerId)
        {
            return this.codeCheckerDAO.CustomerSelectByCustomerId(customerId);
        }

        /// <summary>
        /// Check ChequeBookNo is duplicate or not by ChequeNo (StartNo and EndNo)
        /// </summary>
        /// <param name="chequeBookNo">Your cheque book No</param>
        /// <param name="fromNumber">Cheque start No of your cheque book No</param>
        /// <param name="toNumber">Cheque End No of your cheque book No</param>
        /// <returns>Return true if it is duplicate, or false</returns>
        public bool HasDuplicatedChequeBookIssueNo(string chequeBookNo, string fromNumber, string toNumber, string branchCode)
        {
            int count = this.codeCheckerDAO.ChequeSelectCountByBookNoAndSourceBr(chequeBookNo, branchCode);
            if (count > 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00025; // Duplicate Cheque Book No or Cheque No. Please enter New Cheque Book No and Cheque No.
                return true;
            }
            count = this.codeCheckerDAO.ChequeSelectCount(chequeBookNo, fromNumber, toNumber, branchCode);

            if (count > 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00025; // Duplicate Cheque Book No or Cheque No. Please enter New Cheque Book No and Cheque No.
                return true;
            }

            count = this.codeCheckerDAO.UCheckSelectCount(fromNumber, toNumber, branchCode);

            if (count > 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00061; // This cheque no is already used.
                return true;
            }

            count = this.codeCheckerDAO.SCheckSelectCount(chequeBookNo, fromNumber, toNumber, branchCode);

            if (count > 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00060; // This cheque no is already stopped.
                return true;
            }

            return false;
        }

        /// <summary>
        /// Check ChequeBookNo is exist or not by Account No and Cheque Book and ChequeNo (StartNo and EndNo)
        /// </summary>
        /// <param name="accountNumber">Your account No</param>
        /// <param name="chequeBookNo">Your cheque book No</param>
        /// <param name="fromNumber">Cheque start No of your cheque book No</param>
        /// <param name="toNumber">Cheque End No of your cheque book No</param>
        /// <returns>Return true if it is valid, or false</returns>
        public bool IsValidChequeBookIssueNoForStopCheque(string accountNumber, string chequeBookNo, string fromNumber, string toNumber, string branchCode)
        {
            int count = this.codeCheckerDAO.ChequeSelectCount(accountNumber, chequeBookNo, fromNumber, toNumber, branchCode);

            if (count <= 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00064; // Invalid Cheque Book No and Cheque No..
                return false;
            }

            count = this.codeCheckerDAO.UCheckSelectCount(fromNumber, toNumber, branchCode);

            if (count > 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00061; // This cheque no is already used.
                return false;
            }

            count = this.codeCheckerDAO.SCheckSelectCountForStopCheque(chequeBookNo, fromNumber, toNumber, branchCode);

            if (count > 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00060; // This cheque no is already stopped.
                return false;
            }

            return true;
        }

        public bool IsAlreadyPrintedChequeNo(string fromNumber, string toNumber, string branchCode)
        {
            int count = this.codeCheckerDAO.PrintChequeSelectCount(fromNumber, toNumber, branchCode);

            if (count > 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV00069"; // This Cheque No are already printed.
            }

            return count > 0;
        }

        /// <summary>
        /// Check ChequeBookNo is exist or not by Account No and ChequeNo
        /// </summary>
        /// <param name="accountNumber">Your account No</param>
        /// <param name="toNumber">Your Cheque No</param>
        /// <returns>Return true if it is valid, or false</returns>
        public bool IsValidChequeBookIssueNoForAccountClose(string accountNo, string chequeNo, string branchCode)
        {
            int count = this.codeCheckerDAO.ChequeSelectCount(accountNo, chequeNo, branchCode);

            if (count <= 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00059; // Invalid Cheque No.
                return false;
            }

            count = this.codeCheckerDAO.UCheckSelectCount(chequeNo, chequeNo, branchCode);

            if (count > 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00061; // This Cheque No is already used.
                return false;
            }

            count = this.codeCheckerDAO.SCheckSelectCount(chequeNo, branchCode);

            if (count > 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00060; // This Cheque No is already stopped.
                return false;
            }

            return true;
        }

        /// <summary>
        /// Get CAOF list data by account No
        /// </summary>
        /// <param name="accountNumber">Your account No</param>
        /// <returns>Return CAOF list object</returns>
        public IList<PFMDTO00017> GetCAOFsByAccountNumber(string accountNumber)
        {
            return this.codeCheckerDAO.GetCAOFsByAccountNumber(accountNumber);
        }

        /// <summary>
        /// Get SAOF list data by account No
        /// </summary>
        /// <param name="accountNumber">Your account No</param>
        /// <returns>Return SAOF list object</returns>
        public IList<PFMDTO00016> GetSAOFsByAccountNumber(string accountNumber)
        {   
            return this.codeCheckerDAO.GetSAOFsByAccountNumber(accountNumber);
        }

        

        /// <summary>
        /// Get FAOF list data by account No
        /// </summary>
        /// <param name="accountNumber">Your account No</param>
        /// <returns>Return FAOF list object</returns>
        public IList<PFMDTO00021> GetFAOFsByAccountNumber(string accountNumber)
        {
            return this.codeCheckerDAO.GetFAOFsByAccountNumber(accountNumber);
        }

        /// <summary>
        /// Get CAOF list data by account No
        /// </summary>
        /// <param name="accountNumber">Your account No</param>
        /// <returns>Return CAOF list object</returns>
        [Transaction(TransactionPropagation.Required)]
        public PFMDTO00017 GetCAOFByAccountNumberAndSerialOfCustomer(string accountNumber, int serialOfCustomer)
        {
            return this.codeCheckerDAO.GetCAOFByAccountNumber(accountNumber,serialOfCustomer);
        }

        /// <summary>
        /// Get SAOF list data by account No
        /// </summary>
        /// <param name="accountNumber">Your account No</param>
        /// <returns>Return SAOF list object</returns>
        [Transaction(TransactionPropagation.Required)]
        public PFMDTO00016 GetSAOFByAccountNumberAndSerialOfCustomer(string accountNumber, int serialOfCustomer)
        {
            return this.codeCheckerDAO.GetSAOFByAccountNumber(accountNumber,serialOfCustomer);
        }

        /// <summary>
        /// Get FAOF list data by account No
        /// </summary>
        /// <param name="accountNumber">Your account No</param>
        /// <returns>Return FAOF list object</returns>
        public PFMDTO00021 GetFAOFByAccountNumberAndSerialOfCustomer(string accountNumber, int serialOfCustomer)
        {
            return this.codeCheckerDAO.GetFAOFByAccountNumber(accountNumber,serialOfCustomer);
        }

        public PFMDTO00021 GetTopFAOFINfoByAccountNo(string accountNumber)
        {
            return this.codeCheckerDAO.GetTopFAOFINfoByAccountNumber(accountNumber);
        }

        public IList<PFMDTO00072> GetCurrentAccountInfoByAccountNumber(string accountNo)
        {
            return this.codeCheckerDAO.GetCurrentAccountInfoByAccountNumber(accountNo);
        }

        public IList<PFMDTO00072> GetSavingAccountInfoByAccountNumber(string accountNo)
        {
            return this.codeCheckerDAO.GetSavingAccountInfoByAccountNumber(accountNo);
        }

        public bool HasLoanAccount(string accountNo)
        {
            int per_guanCount = this.codeCheckerDAO.GetLoanAccountCountFromPer_GuanByAccountNo(accountNo);
            if (per_guanCount > 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00055;
                return true;
            }

            int cLedgerCount = this.codeCheckerDAO.GetLoanAccountCountFromCLedgerByAccountNo(accountNo);
            if (cLedgerCount > 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00054;
                return true;
            }

            return false;
        }

        public bool HasCurrentAccountInLinkAccount(string currentAccountNo)
        {
            int count = this.codeCheckerDAO.GetLinkAccountCountByCurrentAccountNo(currentAccountNo);
            if (count > 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00056;
            }

            return count > 0;
        }

        public bool HasSavingAccountInLinkAccount(string savingAccountNo)
        {
            int count = this.codeCheckerDAO.GetLinkAccountCountBySavingAccountNo(savingAccountNo);
            if (count > 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00056;
            }

            return count > 0;
        }

        public bool HasInterestAccount(string accountNo)
        {
            int count = this.codeCheckerDAO.GetToAccountNoCountByAccountNo(accountNo);
            if (count > 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00053;
            }

            return count > 0;
        }

        public bool IsFreezeAccount(string accountNo)
        {
            int count = this.codeCheckerDAO.GetFreezeAccountCountByAccountNo(accountNo);
            if (count > 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00057;
            }

            return count > 0;
        }

        public bool IsClosedAccountForCLedger(string accountNo)
        {
            object account = this.codeCheckerDAO.GetClosedAccountByAccountNo(accountNo);
            if (account != null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00044;
            }

            return account != null;
        }

        /// <summary>
        /// Check ChequeBookNo is Vaild or not by ChequeNo  for Withdrawal
        /// </summary>
        /// <param name="chequeBookNo">Your cheque book No</param>
        /// <param name="fromNumber">Cheque start No of your cheque book No</param>
        /// <param name="toNumber">Cheque End No of your cheque book No</param>
        /// <returns>Return true if it is duplicate, or false</returns>
        public bool IsVaildChequeNoforWithdrawal(string accountNo, string chequeNo, string branchCode)
        {
            int count = this.codeCheckerDAO.ChequeSelectCount(accountNo, chequeNo, branchCode);

            if (count == 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00064; // Invalid Cheque Book No and Cheque No.
                return true;
            }

            count = this.codeCheckerDAO.UCheckSelectCount(chequeNo, chequeNo, branchCode);

            if (count > 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00061; // This cheque no is already used.
                return true;
            }

            count = this.codeCheckerDAO.SCheckSelectCount(chequeNo, branchCode);

            if (count > 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00060; // This cheque no is already stopped.
                return true;
            }

            return false;
        }

        /// <summary>
        /// SelectPoByPoNoandBudgetYear 
        /// </summary>
        /// <param name="poNo">Required Parameter</param>
        /// <param name="budgetYear">Optional Parameter</param>
        /// <returns>TLMDTO00016</returns>
        public TLMDTO00016 GetPOByPoNoandBudgetYear(string poNo, string budgetYear)
        {
            if (string.IsNullOrEmpty(poNo) || string.IsNullOrEmpty(budgetYear))
            {
                //throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.  
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME90018; //Invalid Parameter Value.  
                return null;
            }
            else
            {
                TLMDTO00016 poDTO = this.codeCheckerDAO.SelectPOByPoNo(poNo);
                if (poDTO == null)
                {
                    TLMDTO00001 reDTO = this.codeCheckerDAO.SelectREByPoNo(poNo, budgetYear);
                    if (reDTO == null)
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = CXMessage.MV00219; //PO No. not found
                        return null;
                    }
                    else
                    {
                        poDTO.PONo = reDTO.RegisterNo;
                        poDTO.AccountNo = reDTO.AccountNo;
                        poDTO.Budget = reDTO.Budget;
                    }
                  
                }
                else
                {
                    if (poDTO.Budget != budgetYear)
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = CXMessage.MV00104; //Invalid Budget for this P.O.
                        return null;
                    }
                }

                return poDTO;
            }
        }

        /// <summary>
        /// SelectStartNoandEndNobyAccountNo
        /// </summary>
        /// <param name="accountNo">Required Parameter</param>
        /// <returns>IList<PFMDTO00006></returns>

        public IList<PFMDTO00006> GetStartNoandEndNo(string accountNo)
        {
            return this.CodeCheckerDAO.SelectStartNoandEndNobyCurrentAccountNo(accountNo);
        }

        public PFMDTO00028 GetAccountInfoOfCledgerByAccountNo(string accountNo)
        {
            return this.codeCheckerDAO.GetAccountInfoOfCledgerByAccountNo(accountNo);
        }

        public IList<PFMDTO00001> GetCustomerInfomationByCaofOrSaof(string accountNo, string accountType)
        {
            return this.CodeCheckerDAO.GetCustomerInformationBySAOForCAOF(accountNo, accountType);
        }

        public IList<PFMDTO00001> GetCustomerInfomationByAccountNo(string accountNo,bool isPhoto)
        {
            try
            {
                IList<PFMDTO00001> customerList;
                PFMDTO00028 customerLedgerInfo = this.CodeCheckerDAO.GetAccountInfoOfCledgerByAccountNo(accountNo);

                if (customerLedgerInfo == null)
                {
                    return null;
                }
                else if (CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurrentAccountSign) == customerLedgerInfo.AccountSign.Substring(0, 1))
                {
                    customerList = this.CodeCheckerDAO.GetCustomerInformationBySAOForCAOF(accountNo, customerLedgerInfo.AccountSign.Substring(0, 1));
                }
                else if (CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavingAccountSign) == customerLedgerInfo.AccountSign.Substring(0, 1))
                {
                    customerList = this.CodeCheckerDAO.GetCustomerInformationBySAOForCAOF(accountNo, customerLedgerInfo.AccountSign.Substring(0, 1));
                }
                else
                    throw new Exception(CXMessage.MV20054);//Invalid Account Type

                foreach(PFMDTO00001 customerInfo in customerList)
                {
                    if (!isPhoto)
                    {
                        customerInfo.Photo = null;
                        customerInfo.Signature = null;
                    }
                    
                    customerInfo.AccountNo=customerLedgerInfo.AccountNo;
                    customerInfo.CurrentBal=customerLedgerInfo.CurrentBal;
                    customerInfo.OverdraftLimit=customerLedgerInfo.OverdraftLimit;
                    customerInfo.MinimumBalance=customerLedgerInfo.MinimumBalance;
                    customerInfo.OverdraftDate =customerLedgerInfo.OverdraftDate;
                    customerInfo.DayOfBalance =customerLedgerInfo.DayOfBalance;
                    customerInfo.AccountSign =customerLedgerInfo.AccountSign;
                    customerInfo.LoansAccount= customerLedgerInfo.LoansAccount;
                    customerInfo.SourceBranch = customerLedgerInfo.SourceBranchCode;
                    customerInfo.CurrencyCode = customerLedgerInfo.CurrencyCode;
                    customerInfo.SavingInterestRate =customerLedgerInfo.SavingInterestRate;
                    customerInfo.TransactionCount = customerLedgerInfo.TransactionCount;
                    customerInfo.MonthOpeningBalance = customerLedgerInfo.MonthOpeningBalance;
                    customerInfo.CloseDate = customerLedgerInfo.CloseDate;
                    customerInfo.PrintLineNo = customerLedgerInfo.PrintLineNo;
                    customerInfo.TemporaryOverdraftLimit = customerLedgerInfo.TemporaryOverdraftLimit;
                    customerInfo.LoansCount = customerLedgerInfo.LoansCount;

                }
                
                return customerList;
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME00021;
                return null;
            }
        }

        public IList<PFMDTO00001> GetCustomerInfomationByAccountNoAndSourceBranchCode(string accountNo, bool isPhoto , string branchcode)
        {
            try
            {
                IList<PFMDTO00001> customerList;
                PFMDTO00028 customerLedgerInfo = this.CodeCheckerDAO.GetAccountInfoOfCledgerByAccountNoAndSourceBranch(accountNo,branchcode);

                if (customerLedgerInfo == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV00046";
                    return null;
                }
                else if (CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurrentAccountSign) == customerLedgerInfo.AccountSign.Substring(0, 1))
                {
                    customerList = this.CodeCheckerDAO.GetCustomerInformationBySAOForCAOF(accountNo, customerLedgerInfo.AccountSign.Substring(0, 1));
                }
                else if (CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavingAccountSign) == customerLedgerInfo.AccountSign.Substring(0, 1))
                {
                    customerList = this.CodeCheckerDAO.GetCustomerInformationBySAOForCAOF(accountNo, customerLedgerInfo.AccountSign.Substring(0, 1));
                }
                else
                    throw new Exception(CXMessage.MV20054);//Invalid Account Type

                foreach (PFMDTO00001 customerInfo in customerList)
                {
                    if (!isPhoto)
                    {
                        customerInfo.Photo = null;
                        customerInfo.Signature = null;
                    }

                    customerInfo.AccountNo = customerLedgerInfo.AccountNo;
                    customerInfo.CurrentBal = customerLedgerInfo.CurrentBal;
                    customerInfo.OverdraftLimit = customerLedgerInfo.OverdraftLimit;
                    customerInfo.MinimumBalance = customerLedgerInfo.MinimumBalance;
                    customerInfo.OverdraftDate = customerLedgerInfo.OverdraftDate;
                    customerInfo.DayOfBalance = customerLedgerInfo.DayOfBalance;
                    customerInfo.AccountSign = customerLedgerInfo.AccountSign;
                    customerInfo.LoansAccount = customerLedgerInfo.LoansAccount;
                    customerInfo.SourceBranch = customerLedgerInfo.SourceBranchCode;
                    customerInfo.CurrencyCode = customerLedgerInfo.CurrencyCode;
                    customerInfo.SavingInterestRate = customerLedgerInfo.SavingInterestRate;
                    customerInfo.TransactionCount = customerLedgerInfo.TransactionCount;
                    customerInfo.MonthOpeningBalance = customerLedgerInfo.MonthOpeningBalance;
                    customerInfo.CloseDate = customerLedgerInfo.CloseDate;
                    customerInfo.PrintLineNo = customerLedgerInfo.PrintLineNo;
                    customerInfo.TemporaryOverdraftLimit = customerLedgerInfo.TemporaryOverdraftLimit;
                    customerInfo.LoansCount = customerLedgerInfo.LoansCount;

                }

                return customerList;
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME00021;
                return null;
            }
        }

        public string GetLinkAccountNo(string accountNo, string accountType)
        {
            PFMDTO00029 dto = this.codeCheckerDAO.GetLinkAccountCountByAccountNo(accountNo, accountType);
            if (dto != null)
                return (accountType.Substring(0, accountType.Length - 1).Equals("S") ? dto.SavingAccountNo : dto.CurrentAccountNo);
            else
                return string.Empty;
        }

        public bool HasLegalCaseAccount(string accountNo)
        {
            int count = this.codeCheckerDAO.GetLegalCaseFromLoansByAccountNo(accountNo);
            if (count > 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00053;
            }

            return count > 0;
        }

        public bool HasNPLCaseAccount(string accountNo)
        {
            int count = this.codeCheckerDAO.GetNPLCaseFromLoansByAccountNo(accountNo);
            if (count > 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00053;
            }

            return count > 0;
        }

        public bool IsExpiredLoansAccount(string accountNo)
        {
            int count = this.codeCheckerDAO.GetExpiredLoansFromLoansByAccountNo(accountNo);
            if (count > 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00053;
            }

            return count > 0;
        }

        public PFMDTO00028 SelectCurrentAndMinimumBalanceByAccountNo(string accountNo)
        {
            PFMDTO00028 cledgerDTO = this.codeCheckerDAO.GetCurrentBalanceByAccountNo(accountNo); // Minimum balance and current balance will contain.             
            if (cledgerDTO != null)
            {
                return cledgerDTO;
            }
            else
            {
                throw new Exception(CXMessage.ME00054);//AccountNo not found in Cledger Table.
            }
        }

        public PFMDTO00028 SelectCurrentBalanceByAccountNo(string accountNo)
        {
            PFMDTO00028 cledgerDTO = this.codeCheckerDAO.GetCurrentBalanceByAccountNo(accountNo); // Minimum balance and current balance will contain.             
            if (cledgerDTO == null)
            {
                throw new Exception(CXMessage.ME00054);//AccountNo not found in Cledger Table.               
            }
            else
            {
                return cledgerDTO;
            }
        }
      

        public string SelectTopCurrencyCodeByAccountNo(string accountNo)
        {
            string currencycode = this.codeCheckerDAO.SelectTopCurrencyCodeByAccountNo(accountNo);
            return currencycode;
        }
        /// <summary>
        /// FAOF Account No?
        /// Return it is FAOF Account No,return true or false.
        /// </summary>
        /// <param name="accountno"></param>
        /// <returns>bool</returns>
        public bool isFAOFAccountNo(string accountno)
        {
            bool isfaof;
            PFMDTO00021 FledgerInfo= this.GetTopFAOFINfoByAccountNo(accountno);
            return isfaof = (FledgerInfo != null) ? true : false;
        }

        /// <summary>
        /// Account No Text is Checked.
        /// </summary>
        /// <param name="accountno">Your required Account No.</param>        
        /// <returns>Return true if it is in FAOF Or Cledger Table, or false.</returns>
        public bool IsInFAOFAccountNoOrInCledgerAcNo(string accountno)
        {
            bool isValid = true;
            PFMDTO00028 Cledger = this.GetAccountInfoOfCledgerByAccountNo(accountno);
            if (Cledger != null)
            {
                bool isCloseAccount = this.IsClosedAccountForCLedger(accountno);
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
                FledgerInfo = this.GetTopFAOFINfoByAccountNo(accountno);
                if (FledgerInfo == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00046;
                    isValid = false;
                }
            }

            return isValid;
        }

        public bool CheckAmount(string accountNo,decimal amount,bool isMinBalCheck, bool isVIP,bool isDebit,ref bool isLink, ref string messageCode)
        {
            isLink = false;
            messageCode = string.Empty;
            decimal globalAmount = 0, minimumBalance = 0, debitTotalAmount = 0, customerBalance = 0 ,expiredAmount =0 ,linkMinBal =0;
            PFMDTO00028 cledgerDTO;
            TLMDTO00018 loansDTO;
            PFMDTO00041 setupDTO = new PFMDTO00041();
            PFMDTO00029 linkAcDTO=new PFMDTO00029();
            CXDTO00004 parameterDTO;
            CXDTO00008 returnDTO;
            PFMDTO00057 newSetupDTOforAmount, newSetupDTOforDivider;

            cledgerDTO = this.CodeCheckerDAO.GetAccountInfoOfCledgerByAccountNo(accountNo);
            setupDTO = this.CodeCheckerDAO.SelectMinBal(cledgerDTO.CurrencyCode, cledgerDTO.SourceBranchCode);

            if (cledgerDTO.AccountSign.Substring(0, 1) == CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurrentAccountSign))
            {
                globalAmount = setupDTO.CurrentMinimumBalance;
                newSetupDTOforAmount = this.CodeCheckerDAO.SelectByVariable("CATRANAMT");
                newSetupDTOforDivider = this.CodeCheckerDAO.SelectByVariable("CADIVIDER");
            }
            else if (cledgerDTO.AccountSign.Substring(0, 1) == CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavingAccountSign))
            {
                globalAmount = setupDTO.SavingMinimumBalance;
                newSetupDTOforAmount = this.CodeCheckerDAO.SelectByVariable("SATRANAMT");
                newSetupDTOforDivider = this.CodeCheckerDAO.SelectByVariable("SADIVIDER");
            }
            else
            {
                messageCode = CXMessage.MV20054; // Invalid Account Type.
                return false;
            }
            //Convert.ToInt32(newSetupDTOforAmount.Value) % Convert.ToInt32(newSetupDTOforDivider.Value) == 0 &&
            if (Convert.ToInt32(newSetupDTOforAmount.Value) <= amount)
            {
                switch (isDebit)
                {
                    case false:
                        return true;
                    case true:
                        if (cledgerDTO.LoansAccount > 0)
                        {
                            loansDTO = this.codeCheckerDAO.SelectSAmountByAccountNo(accountNo);
                            expiredAmount = loansDTO.SAmount.Value == 0 ? 0 : loansDTO.SAmount.Value;
                        }
                        if (isMinBalCheck)
                            minimumBalance = cledgerDTO.MinimumBalance > 0 ? cledgerDTO.MinimumBalance : globalAmount;

                        debitTotalAmount = minimumBalance + amount;
                        customerBalance = cledgerDTO.CurrentBal - expiredAmount;

                        if (cledgerDTO.AccountSign.Substring(0, 1) == CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavingAccountSign) && !isVIP)
                        {
                            string strReturn = this.ProcedureDAO.IsCheckSavingDate(accountNo, 1);
                            if (strReturn == "1019")
                            {
                                this.ServiceResult.ErrorOccurred = true;
                                this.ServiceResult.MessageCode = messageCode = CXMessage.MV00135;
                                return false;
                            }
                            
                        }
                        if (debitTotalAmount > customerBalance)
                        {
                            linkAcDTO = this.CodeCheckerDAO.LinkAcSelectLinkAmount(accountNo);
                            if (linkAcDTO == null) linkAcDTO = new PFMDTO00029();
                        }
                        else
                            return true;

                        if ((linkAcDTO.MinimumSavingAccountBalance == 0 && linkAcDTO.MinimumCurrentAccountBalance == 0) || (linkAcDTO.MinimumSavingAccountBalance == null && linkAcDTO.MinimumCurrentAccountBalance == null))
                        {
                            customerBalance = (cledgerDTO.CurrentBal + cledgerDTO.OverdraftLimit) - expiredAmount;
                            if (customerBalance >= debitTotalAmount)
                                return true;
                            else
                            {
                                messageCode = CXMessage.MV00109; // Insufficient Balance.
                                return false;
                            }
                        }
                        else
                        {
                            isLink = true;
                            linkMinBal = linkAcDTO.MinimumSavingAccountBalance == 0 ? linkAcDTO.MinimumCurrentAccountBalance : linkAcDTO.MinimumSavingAccountBalance;
                            debitTotalAmount = minimumBalance + amount + linkMinBal;
                            if (customerBalance >= debitTotalAmount)
                                return true;
                            else
                            {
                                parameterDTO=new CXDTO00004();
                                parameterDTO.AccountNo=accountNo;
                                parameterDTO.ACSign=cledgerDTO.AccountSign;
                                parameterDTO.Amount=amount;
                                parameterDTO.IsVIP=isVIP;
                                parameterDTO.MinBalCheck=1;
                                returnDTO=this.ProcedureDAO.SP_ATL_AMOUNTCHECKING_CHECK_SAVAC_DATE(parameterDTO);

                                if (returnDTO.ReturnValue.Trim() == "3")
                                {
                                    messageCode = CXMessage.MV00109; // Insufficient Balance.
                                    return false;
                                }
                                else if (returnDTO.ReturnValue.Trim() == "1019")
                                {
                                    messageCode = CXMessage.MV00135; // Not Allow Saving One Time.
                                    return false;
                                }
                                else
                                    return true;
                            }
                        }
                }
            }
            else
            {
                messageCode = CXMessage.MV00037;
                return false;
            }
            
            return true;
        }

        public IList<PFMDTO00021> GetCustomerInfoandFAOFInfoByAccountNo(string accountNo)
        {
            try
            {
                IList<PFMDTO00021> FAOFDTOList = new List<PFMDTO00021>();
                PFMDTO00021 FAOF = new PFMDTO00021();
                FAOF = this.codeCheckerDAO.GetTopFAOFINfoByAccountNumber(accountNo);

                if (FAOF.AccountSignature == "FC" || FAOF.AccountSignature == "FJ")
                {
                    IList<PFMDTO00001> CustDTOList;
                    CustDTOList = this.codeCheckerDAO.SelectCustomerInformationByFAOF(accountNo);
                    for (int i = 0; i < CustDTOList.Count; i++)
                    {                        
                            PFMDTO00021 faofDTO = new PFMDTO00021();
                            faofDTO.CustomerId = CustDTOList[i].CustomerId;
                            faofDTO.Name = CustDTOList[i].Name;
                            faofDTO.AccountSignature = CustDTOList[i].AccountSign;
                            faofDTO.Township_Code = CustDTOList[i].TownshipDesp;
                            faofDTO.City_Code = CustDTOList[i].CityCode;
                            faofDTO.NRC = CustDTOList[i].NRC;
                            faofDTO.Address = CustDTOList[i].Address;
                            faofDTO.Phone = CustDTOList[i].PhoneNo;
                            FAOFDTOList.Add(faofDTO);
                    }
                   
                }
                else
                {
                    FAOFDTOList.Add(FAOF);
                }
                ServiceResult.ErrorOccurred = false;
                return FAOFDTOList;
            }
            catch
            {
                ServiceResult.ErrorOccurred = true;
                ServiceResult.MessageCode = CXMessage.MV00033; // Invalid Fixed Account
                return null;
            }
        }
    
        public PFMDTO00023 GetAccountInfoOfFledgerByAccountNo(string accountNo)
        {
            return this.codeCheckerDAO.GetAccountInfoOfFledgerByAccountNo(accountNo);
        }

        /// <summary>
        /// ReversalProcess
        /// </summary>
        /// <param name="ENO">Required Parameter</param>
        /// <param name="ReversalENO">Required Parameter</param>
        /// <param name="GroupNo">Required Parameter</param> 
        /// <param name="BranchCode">Required Parameter</param>
        /// <param name="Date">Required Parameter</param>
        /// <param name="ActiveBranch">Required Parameter</param>
        /// <returns>bool</returns>
        /// Created By KKT
        /// UPdated By NLH
        [Transaction(TransactionPropagation.Required)]
        public void ReversalProcess(string ENO, string ReversalENO, string GroupNo, string BranchCode, DateTime Date, string ActiveBranch, int UpdatedUserID, TLMDTO00015 casndenodto, string Trancode, bool IsCbalChanges)
        {
            #region validation
            if (string.IsNullOrEmpty(ENO))
            {
                throw new Exception("ME90018");//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(ReversalENO))
            {
                throw new Exception("ME90018");//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(BranchCode))
            {
                throw new Exception("ME90018");//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(Date.ToString()))
            {
                throw new Exception("ME90018");//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(ActiveBranch))
            {
                throw new Exception("ME90018");//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(UpdatedUserID.ToString()))
            {
                throw new Exception("ME90018");//Invalid Parameter Value.
            }
            //if (casndenodto == null || string.IsNullOrEmpty(casndenodto.AccountType.ToString()))
            //{
            //    throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            //}
            if (Date.Date != System.DateTime.Now.Date)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME30002";
                return;//Not Allow Back Date Transaction
            }
            #endregion
            #region validate Entry No
            IList<PFMDTO00054> ListTLFdto;
            PFMDTO00028 cledgerDTO;
            PFMDTO00023 fledgerDTO;            
            IList<TLMDTO00004> ListIBLTLFDTO;
            //Select TLF By ENO, ActiveBranch, Date
            ListTLFdto = this.CodeCheckerDAO.SelectTLFByENOBranchCodeDate(ENO, BranchCode, Date, Trancode);
            //Check List TLF DTO count is Less than Equal 0 or not 
            if (ListTLFdto.Count <= 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV00213"; //Entry No Not Found
                return;
            }
            else
            {
                //Check the top of tlf object,these are already issue or not
                if (!string.IsNullOrEmpty(ListTLFdto[0].OrgnEno))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME30003"; //Already Reverse Voucher
                    return;
                }
            }
            #endregion
            #region reversal TLF
            foreach (PFMDTO00054 tlfdto in ListTLFdto)
            {
                /////Insert Into TLF
                TLMDTO00005 reversaltrancodedto=this.CodeCheckerDAO.SelectByTranCode(this.CodeCheckerDAO.SelectByTranCode(tlfdto.TransactionCode).RVReference);
                #region Convert ORGTLFDTO to Reversal TLF DTO
                PFMORM00054 ReversalTlfORM = new PFMORM00054();

                ReversalTlfORM.Id = this.TLFDAO.SelectMaxId() + 1;
                ReversalTlfORM.Eno = ReversalENO;
                ReversalTlfORM.OrgnEno = ENO;
                ReversalTlfORM.OrgnTransactionCode = tlfdto.TransactionCode;
                ReversalTlfORM.OrgnPaymentOrderNo = tlfdto.PaymentOrderNo;
                ReversalTlfORM.OrgnDRegister = tlfdto.DRegisterNo;
                ReversalTlfORM.OrgnERegister = tlfdto.ERegisterNo;
                ReversalTlfORM.OrgnLgNo = tlfdto.LgNo;
                ReversalTlfORM.OrgnLNo = tlfdto.Lno;
                ReversalTlfORM.OrgnCheque = tlfdto.Cheque;

                ReversalTlfORM.AccountNo = tlfdto.AccountNo;
                ReversalTlfORM.Amount = tlfdto.Amount;
                ReversalTlfORM.Acode = tlfdto.Acode;
                ReversalTlfORM.HomeAmount = tlfdto.HomeAmount;
                ReversalTlfORM.HomeAmt = tlfdto.HomeAmt;
                ReversalTlfORM.HomeOAmt = tlfdto.HomeOAmt;
                ReversalTlfORM.LocalAmount = tlfdto.LocalAmount;
                ReversalTlfORM.LocalAmt = tlfdto.LocalAmt;
                ReversalTlfORM.LocalOAmt = tlfdto.LocalOAmt;
                ReversalTlfORM.SourceCurrency = tlfdto.SourceCurrency;
                ReversalTlfORM.CurrencyCode = tlfdto.CurrencyCode;
                ReversalTlfORM.Cheque = tlfdto.Cheque;
                ReversalTlfORM.PaymentOrderNo = tlfdto.PaymentOrderNo;
                ReversalTlfORM.DRegisterNo = tlfdto.DRegisterNo;
                ReversalTlfORM.ERegisterNo = tlfdto.ERegisterNo;
                ReversalTlfORM.LgNo = tlfdto.LgNo;
                ReversalTlfORM.Lno = tlfdto.Lno;
                ReversalTlfORM.Description = tlfdto.Description;
                //Reversal TranType DTO Description
                ReversalTlfORM.Narration = reversaltrancodedto.Description;
                ReversalTlfORM.DateTime = tlfdto.DateTime;
                //Reversal TranType DTO Transaction Status
                ReversalTlfORM.Status = reversaltrancodedto.Status;
                //Reversal TranType DTO Transaction Code
                ReversalTlfORM.TransactionCode = reversaltrancodedto.TransactionCode;
                ReversalTlfORM.AccountSign = tlfdto.AccountSign;
                ReversalTlfORM.DOMBankPost = tlfdto.DOMBankPost;
                ReversalTlfORM.CLRPostStatus = tlfdto.CLRPostStatus;
                ReversalTlfORM.UserNo = UpdatedUserID.ToString();
                ReversalTlfORM.ContraENo = tlfdto.ContraENo;
                ReversalTlfORM.ContraLNo = tlfdto.ContraLNo;
                //ReversalTLFORM.ContraDateTime = tlfdto.ContraDateTime;
                ReversalTlfORM.OtherBank = tlfdto.OtherBank;
                ReversalTlfORM.DeliverReturn = tlfdto.DeliverReturn;
                ReversalTlfORM.ReceiptNo = tlfdto.ReceiptNo;
                ReversalTlfORM.OtherBankChq = tlfdto.OtherBankChq;
                ReversalTlfORM.CheckTime = tlfdto.DateTime;
                ReversalTlfORM.OtherBankAcctNo = tlfdto.OtherBankAcctNo;
                ReversalTlfORM.SettlementDate = tlfdto.SettlementDate;
                ReversalTlfORM.CustomerId = tlfdto.CustomerId;
                ReversalTlfORM.GChequeNo = tlfdto.GChequeNo;
                ReversalTlfORM.SourceBranchCode = tlfdto.SourceBranchCode;
                ReversalTlfORM.Rate = tlfdto.Rate;
                ReversalTlfORM.Active = true;
                ReversalTlfORM.Channel = tlfdto.Channel;
                ReversalTlfORM.ReferenceVoucherNo = tlfdto.ReferenceVoucherNo;
                ReversalTlfORM.ReferenceType = tlfdto.ReferenceType;

                ReversalTlfORM.CreatedUserId = UpdatedUserID;
                ReversalTlfORM.CreatedDate = DateTime.Now;
                #endregion
                //Insert TLF
                this.tlfDAO.Save(ReversalTlfORM);

                //update Original TLF 
                this.CodeCheckerDAO.UpdateTLFOrgnENOOrgnTranCodeByENO(ReversalENO, reversaltrancodedto.TransactionCode, ENO, BranchCode, UpdatedUserID, DateTime.Now);
                
                //Select CLdger By Account No
                cledgerDTO = this.CodeCheckerDAO.GetAccountInfoOfCledgerByAccountNo(tlfdto.AccountNo);
                if (cledgerDTO!=null && string.IsNullOrEmpty(cledgerDTO.AccountNo))
                {
                    //Select Fledger by Account No
                    fledgerDTO = this.CodeCheckerDAO.GetAccountInfoOfFledgerByAccountNo(tlfdto.AccountNo);
                    if (fledgerDTO !=null && !string.IsNullOrEmpty(fledgerDTO.AccountNo))
                    {
                        if (tlfdto.Status.Substring(1, 1) == "C")
                        {
                            if (fledgerDTO.FixedBalance - tlfdto.Amount >= 0)
                            {
                                //Update FLedger
                                this.CodeCheckerDAO.UpdateFLedgerByAccountNo(tlfdto.AccountNo);
                                //Update FReceipt
                                this.CodeCheckerDAO.UpdateFReceiptByAccountNoRNO(tlfdto.AccountNo, tlfdto.ReceiptNo, fledgerDTO.FixedBalance - tlfdto.Amount, UpdatedUserID);
                                //FPRN File Common Module
                                PFMORM00058 FPRNORM = new PFMORM00058();
                                FPRNORM.AccountNo = tlfdto.AccountNo;
                                FPRNORM.Balance = fledgerDTO.FixedBalance;
                                FPRNORM.Reference = reversaltrancodedto.PBReference;
                                if (reversaltrancodedto.Status[1] == 'C')
                                {
                                    FPRNORM.Debit = 0;
                                    FPRNORM.Credit = tlfdto.Amount;
                                }
                                else
                                {
                                    FPRNORM.Debit = tlfdto.Amount;
                                    FPRNORM.Credit = 0;
                                }
                                //FPRNORM.PrintLineNo= cledgerDTO.PrintLineNo;
                                FPRNORM.CurrencyId = tlfdto.CurrencyCode;
                                FPRNORM.SourceBr = BranchCode;
                                FPRNORM.AccessDate = System.DateTime.Now;
                                FPRNORM.CreatedDate = System.DateTime.Now;
                                FPRNORM.CreatedUserId = UpdatedUserID;
                                FPRNORM.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
                                //FPRNORM.UserNo

                                this.FPRNDAO.Save(FPRNORM);
                            }
                            else
                            {
                                throw new Exception(CXMessage.MV00109);//Insufficient amount
                            }
                        }
                        else
                        {
                            //Update FLedger
                            this.CodeCheckerDAO.UpdateFLedgerByAccountNo(tlfdto.AccountNo);
                            //Update FReceipt
                            this.CodeCheckerDAO.UpdateFReceiptByAccountNoRNO(tlfdto.AccountNo, tlfdto.ReceiptNo, fledgerDTO.FixedBalance + tlfdto.Amount, UpdatedUserID);
                            /////FPRN File Common Module
                            PFMORM00058 FPRNORM = new PFMORM00058();
                            FPRNORM.AccountNo = tlfdto.AccountNo;
                            FPRNORM.Balance = fledgerDTO.FixedBalance;
                            FPRNORM.Reference = reversaltrancodedto.PBReference;
                            if (reversaltrancodedto.Status[1] == 'C')
                            {
                                FPRNORM.Debit = 0;
                                FPRNORM.Credit = tlfdto.Amount;
                            }
                            else
                            {
                                FPRNORM.Debit = tlfdto.Amount;
                                FPRNORM.Credit = 0;
                            }
                            //FPRNORM.PrintLineNo= cledgerDTO.PrintLineNo;
                            FPRNORM.CurrencyId = tlfdto.CurrencyCode;
                            FPRNORM.SourceBr = BranchCode;
                            FPRNORM.AccessDate = System.DateTime.Now;
                            FPRNORM.CreatedDate = System.DateTime.Now;
                            FPRNORM.CreatedUserId = UpdatedUserID;
                            FPRNORM.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
                            //FPRNORM.UserNo

                            this.FPRNDAO.Save(FPRNORM);
                        }
                    }
                }
                else if (cledgerDTO!=null && !string.IsNullOrEmpty(cledgerDTO.AccountNo))
                {
                    //Check Credit or Debit
                    if (tlfdto.Status.Substring(1, 1) == "C")
                    {
                        if (IsCbalChanges)
                        {
                            if (cledgerDTO.CurrentBal - (cledgerDTO.MinimumBalance + tlfdto.Amount) >= 0)
                            {
                                //Update Cledger
                                this.CodeCheckerDAO.UpdateCurrentBalance(tlfdto.AccountNo, cledgerDTO.CurrentBal - tlfdto.Amount, ++cledgerDTO.TransactionCount, UpdatedUserID, UpdatedUserID.ToString());
                            }
                            else
                            {
                                throw new Exception("MV00109");//Insufficient amount
                            }
                        }
                    }
                    else
                    {
                        if (IsCbalChanges)
                        {
                            //Update Cledger
                            this.CodeCheckerDAO.UpdateCurrentBalance(tlfdto.AccountNo, cledgerDTO.CurrentBal + tlfdto.Amount, ++cledgerDTO.TransactionCount, UpdatedUserID, UpdatedUserID.ToString());
                        }
                    }
                }

                //Check AC Type or (Maybe Common Module)
                //Check Account Type Current or Saving .Contains("C".ToUpper()))
                if (!string.IsNullOrEmpty(tlfdto.AccountSign))
                {
                    if (tlfdto.AccountSign[0] == 'C')
                    {
                        //Check UCheque Exist or Not
                        if (this.CodeCheckerDAO.CheckUchequeByAccountNoChequeNo(tlfdto.AccountNo, tlfdto.Cheque, BranchCode))
                        {
                            //Delete UCheque
                            this.CodeCheckerDAO.DeletefromUCheckbyChequeNoAccountNo(tlfdto.AccountNo, tlfdto.Cheque, BranchCode, UpdatedUserID);
                        }
                    }
                    //Check Account Type Current or Saving ("S".ToUpper()))
                    else if (tlfdto.AccountSign[0] == 'S')
                    {
                        //PRN File Common Module
                        PFMORM00043 PRNFileORM = new PFMORM00043();
                        PRNFileORM.AccountNo = tlfdto.AccountNo;
                        PRNFileORM.Balance = cledgerDTO.CurrentBal + cledgerDTO.OverdraftLimit;
                        PRNFileORM.Reference = reversaltrancodedto.PBReference;
                        if (reversaltrancodedto.Status[1] == 'C')
                        {
                            PRNFileORM.Debit = 0;
                            PRNFileORM.Credit = tlfdto.Amount;
                        }
                        else
                        {
                            PRNFileORM.Debit = tlfdto.Amount;
                            PRNFileORM.Credit = 0;
                        }
                        //PRNFileORM.PrintLineNo= cledgerDTO.PrintLineNo;
                        PRNFileORM.CurrencyCode = tlfdto.SourceCurrency;
                        PRNFileORM.SourceBranchCode = BranchCode;
                        PRNFileORM.DATE_TIME = System.DateTime.Now;
                        PRNFileORM.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
                        //PRNFileORM.UserNo

                        this.PrintDAO.PRNFile_Save(PRNFileORM);
                    }
                }
            }
            #endregion
            #region reversal IBLTLF,DepoDeno,CashDeno
            //Check BranchCode
            if (ActiveBranch == BranchCode)
            {

                //Deno Edit
                //Check CashDeno is Single or Multiple if null or empty == single
                if (string.IsNullOrEmpty(GroupNo))
                {
                    //Update CashDeno
                    this.CodeCheckerDAO.UpdateCashDenoByENO(ENO, ReversalENO, BranchCode, UpdatedUserID);
                }
                else
                {
                    //Select Original Cash Deno for Payment or Receipt 
                    TLMDTO00015 Orgncashdenodto = this.CodeCheckerDAO.SelectCashDenoByGroupNo(GroupNo, BranchCode);
                    //Check Orgncashdenodto is null or empty
                    if (Orgncashdenodto != null && !string.IsNullOrEmpty(Orgncashdenodto.TlfEntryNo))
                    {
                        //if (Orgncashdenodto.Status == "R")
                        //{
                            //Update DepoDeno Reverse =1
                            this.CodeCheckerDAO.UpdateDepoDenoByTLF_EnoGropuNoSourceBr(ENO, GroupNo, BranchCode, UpdatedUserID);

                            //Update Cash Deno by Reverse =true and DEnoEntyNo=Reversal ENO
                            this.CodeCheckerDAO.UpdateCashDenoByENO(GroupNo, ReversalENO, BranchCode, UpdatedUserID);

                            if (this.CodeCheckerDAO.SelectDepoDenoChargesAmountByEntryNo(GroupNo).Count > 0)
                            {
                                if (casndenodto != null)
                                {
                                    //Insert Cash Deno
                                    #region Convert CashDeno DTO to CashDeno ORM
                                    TLMORM00015 CashDenoORM = new TLMORM00015();
                                    CashDenoORM.TlfEntryNo = GroupNo;
                                    CashDenoORM.DenoEntryNo = null;
                                    CashDenoORM.AccountType = casndenodto.AccountType;
                                    CashDenoORM.Amount = casndenodto.Amount;
                                    CashDenoORM.AdjustAmount = casndenodto.AdjustAmount;
                                    CashDenoORM.CashDate = DateTime.Now;
                                    CashDenoORM.DenoDetail = casndenodto.DenoDetail;
                                    CashDenoORM.DenoRate = casndenodto.DenoRate;
                                    CashDenoORM.DenoRefundDetail = casndenodto.DenoRefundDetail;
                                    CashDenoORM.DenoRefundRate = casndenodto.DenoRefundRate;
                                    CashDenoORM.UserNo = Convert.ToString(casndenodto.CreatedUserId);
                                    CashDenoORM.CounterNo = casndenodto.CounterNo;
                                    CashDenoORM.Status = Orgncashdenodto.Status;
                                    CashDenoORM.SourceBranchCode = casndenodto.SourceBranchCode;
                                    CashDenoORM.Currency = casndenodto.Currency;
                                    CashDenoORM.Reverse = false;
                                    CashDenoORM.Rate = Orgncashdenodto.Rate;
                                    CashDenoORM.Active = true;
                                    CashDenoORM.CreatedUserId = casndenodto.CreatedUserId;
                                    CashDenoORM.CreatedDate = DateTime.Now;
                                    CashDenoORM.SettlementDate = Orgncashdenodto.SettlementDate;
                                    #endregion Convert CashDeno DTO to CashDeno ORM
                                    //Save Cash Deno
                                    this.Cashdao.Save(CashDenoORM);
                                }
                            }
                        #region Payment
                        //}
                        //else if (Orgncashdenodto.Status == "P")
                        //{
                        //    if (this.CodeCheckerDAO.SelectDepoDenoSumAmountByGroupNo(ENO, GroupNo, BranchCode) > 0)
                        //    {
                        //        //Update Cash Deno
                        //        this.CodeCheckerDAO.UpdateCashDenoByENO(GroupNo, ReversalENO, BranchCode, UpdatedUserID);

                        //        //Update DepoDeno active =0 and Reverse =1
                        //        this.CodeCheckerDAO.DeleteDepoDenoByTlf_EnoGroupNo(ENO, GroupNo, BranchCode, UpdatedUserID);

                        //        //Insert Cash Deno
                        //        #region Convert CashDeno DTO to CashDeno ORM
                        //        TLMORM00015 CashDenoORM = new TLMORM00015();
                        //        CashDenoORM.TlfEntryNo = GroupNo;
                        //        CashDenoORM.DenoEntryNo = null;
                        //        CashDenoORM.AccountType = casndenodto.AccountType;
                        //        CashDenoORM.Amount = casndenodto.Amount;
                        //        CashDenoORM.AdjustAmount = casndenodto.AdjustAmount;
                        //        CashDenoORM.CashDate = DateTime.Now;
                        //        CashDenoORM.DenoDetail = casndenodto.DenoDetail;
                        //        CashDenoORM.DenoRate = casndenodto.DenoRate;
                        //        CashDenoORM.DenoRefundDetail = casndenodto.DenoRefundDetail;
                        //        CashDenoORM.DenoRefundRate = casndenodto.DenoRefundRate;
                        //        CashDenoORM.UserNo = Convert.ToString(casndenodto.CreatedUserId);
                        //        CashDenoORM.CounterNo = casndenodto.CounterNo;
                        //        CashDenoORM.Status = Orgncashdenodto.Status;
                        //        CashDenoORM.SourceBranchCode = casndenodto.SourceBranchCode;
                        //        CashDenoORM.Currency = casndenodto.Currency;
                        //        CashDenoORM.Reverse = false;
                        //        CashDenoORM.Rate = Orgncashdenodto.Rate;
                        //        CashDenoORM.Active = true;
                        //        CashDenoORM.CreatedUserId = casndenodto.CreatedUserId;
                        //        CashDenoORM.CreatedDate = DateTime.Now;
                        //        #endregion Convert CashDeno DTO to CashDeno ORM
                        //        //Save Cash Deno
                        //        this.Cashdao.Save(CashDenoORM);
                        //    }
                        //    else
                        //    {
                        //        ////Insert Into His Cash Deno
                        //        #region Convert CashDeno DTO  to His Cash Deno DTO
                        //        //MNMORM00004 HisCashDenoORM = new MNMORM00004();
                        //        //HisCashDenoORM.AccountType = casndenodto.AccountType;
                        //        //HisCashDenoORM.Amount = casndenodto.Amount;
                        //        //HisCashDenoORM.AdjustmentAmount = Convert.ToDecimal(casndenodto.AdjustAmount);
                        //        //HisCashDenoORM.CashDate = DateTime.Now;
                        //        //HisCashDenoORM.DenoDetail = casndenodto.DenoDetail;
                        //        //HisCashDenoORM.DenoRate = casndenodto.DenoRate;
                        //        //HisCashDenoORM.DenoRefundDetail = casndenodto.DenoRefundDetail;
                        //        //HisCashDenoORM.DenoRefundRate = casndenodto.DenoRefundRate;
                        //        //HisCashDenoORM.UserNo = Convert.ToString(casndenodto.CreatedUserId);
                        //        //HisCashDenoORM.CounterNo = casndenodto.CounterNo;
                        //        //HisCashDenoORM.Status = casndenodto.Status;
                        //        //HisCashDenoORM.SourceBranchCode = casndenodto.SourceBranchCode;
                        //        //HisCashDenoORM.Currency = casndenodto.Currency;
                        //        //HisCashDenoORM.Active = true;
                        //        //HisCashDenoORM.CreatedUserId = casndenodto.CreatedUserId;
                        //        //HisCashDenoORM.CreatedDate = DateTime.Now;
                        //        #endregion Convert CashDeno DTO  to His Cash Deno DTO
                        //        ////Insert Into HisCashDeno Table
                        //        //this.HisCashDAO.Save(HisCashDenoORM);

                        //        //Delete Cash Deno active =0
                        //        this.CodeCheckerDAO.DeleteCashDenoByTLF_enoSourceBrReverse(ENO, BranchCode, UpdatedUserID);

                        //        //Delete DepoDeno active =0
                        //        this.CodeCheckerDAO.DeleteDepoDenoByTlf_EnoGroupNo(ENO, GroupNo, BranchCode, UpdatedUserID);
                        //    }
                        //}
                        #endregion
                    }
                }
            }
            //Select List<IBLTLF> by ENO and Branch Code
            ListIBLTLFDTO = this.CodeCheckerDAO.SelectIBLTLFs(ENO, BranchCode);
            if (ListIBLTLFDTO.Count > 0)
            {
                foreach (TLMDTO00004 ibltlfdto in ListIBLTLFDTO)
                {
                    //Insert IBLTLF
                    #region Convert IBLTLF DTO To IBLTLF ORM
                    TLMORM00004 IBLTLFORM = new TLMORM00004();
                    IBLTLFORM.AccountNo = ibltlfdto.AccountNo;
                    IBLTLFORM.Active = ibltlfdto.Active;
                    IBLTLFORM.Amount = ibltlfdto.Amount;
                    IBLTLFORM.Cheque = ibltlfdto.Cheque;
                    IBLTLFORM.Communicationcharge = ibltlfdto.Communicationcharge;
                    IBLTLFORM.CreatedDate = System.DateTime.Now;
                    IBLTLFORM.CreatedUserId = UpdatedUserID;
                    IBLTLFORM.Currency = ibltlfdto.Currency;
                    IBLTLFORM.Date_Time = System.DateTime.Now;
                    IBLTLFORM.Eno = ReversalENO;
                    IBLTLFORM.FromBranch = ibltlfdto.FromBranch;
                    IBLTLFORM.Income = ibltlfdto.Income;
                    IBLTLFORM.IncomeType = ibltlfdto.IncomeType;
                    IBLTLFORM.InOut = ibltlfdto.InOut;
                    IBLTLFORM.RelatedAccount = ibltlfdto.RelatedAccount;
                    IBLTLFORM.RelatedBranch = ibltlfdto.RelatedBranch;
                    IBLTLFORM.Reversal = true;
                    IBLTLFORM.SourceBranchCode = BranchCode;
                    IBLTLFORM.Success = ibltlfdto.Success;
                    IBLTLFORM.ToBranch = ibltlfdto.ToBranch;
                    IBLTLFORM.TranType = (ibltlfdto.TranType.Substring(1, 1) == "C") ? "RD" + ibltlfdto.TranType.Substring(2, 1) : "RC" + ibltlfdto.TranType.Substring(2, 1);
                    IBLTLFORM.UniqueId = ibltlfdto.UniqueId;
                    IBLTLFORM.UserNo = ibltlfdto.UserNo;
                    
                    IList<TLMDTO00004> IBLMax = codeCheckerDAO.SelectMaxIBLTLFID();

                    IBLTLFORM.Id = IBLMax==null? 1 : IBLMax[0].Id +1;
                    #endregion Convert IBLTLF DTO To IBLTLF ORM
                    //Insert Into IBL TLF 
                    this.IBLTLFDAO.Save(IBLTLFORM);
                    //Update IBLTLF
                    this.CodeCheckerDAO.UpdateReversalIBLTLFByENo(ENO, BranchCode, UpdatedUserID);
                }
            }
            #endregion
            //Reversal END
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00028> SelectCustomerAccountData(string custid , string status , ref int count)
        {
            return this.CodeCheckerDAO.GetCustomerAccountData(custid, status, ref count);
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00021> SelectFLedgerByCustomerId(string custid, ref int count)
        {
            return this.CodeCheckerDAO.GetFLedgerByCustomerId(custid, ref count);
        }

        [Transaction(TransactionPropagation.Required)]
        public int SelectLoanCountByCustomerId(string custid)
        {
            return this.CodeCheckerDAO.GetLoanCountByCustomerId(custid);
        }

        [Transaction(TransactionPropagation.Required)]
        public PFMDTO00001 SelectCustomerAccountCount(string custid)
        {
            return this.CodeCheckerDAO.GetCustomerAccountCount(custid);
        }

        [Transaction(TransactionPropagation.Required)]
        public TLMDTO00018 SelectLoanGuarantee(string acctno)
        {
            return this.CodeCheckerDAO.GetLoanGuarantee(acctno);
        }
        #endregion

        /// <summary>
        /// Select Top Information by Current AccountNo,Saving Account No or FAOF Account No.
        /// If it returns Name , NRC, Address and Township Code.
        /// If u wish other information,u just add fields of DTO. 
        /// </summary>
        /// <param name="acccountNo"></param>
        /// <param name="accountSign"></param>
        /// <returns>CAOF DTO</returns>
        public PFMDTO00017 SelectTopCustomerInformationByAnyAccountNoandAnyAcSign(string acccountNo, string accountSign)
        {
            PFMDTO00017 caofinfoDTO = new PFMDTO00017();
            PFMDTO00016 saofinfoDTO=new PFMDTO00016();
            PFMDTO00021 faofinfoDTO=new PFMDTO00021();
            try
            {
                switch (accountSign.Substring(0, 1))
                {
                    case "C": caofinfoDTO = this.codeCheckerDAO.GetTopCAOFInfoByAccountNumber(acccountNo);
                        break;
                    case "S": saofinfoDTO = this.codeCheckerDAO.GetTopSAOFInfoByAccountNumber(acccountNo);
                        caofinfoDTO.Name = saofinfoDTO.Name;
                        caofinfoDTO.NRC = saofinfoDTO.NRC;
                        caofinfoDTO.Address = saofinfoDTO.Address;
                        caofinfoDTO.Township_Code = saofinfoDTO.Township_Code;
                        break;
                    case "F": faofinfoDTO = this.codeCheckerDAO.GetTopFAOFINfoByAccountNumber(acccountNo);
                        caofinfoDTO.Name = faofinfoDTO.Name;
                        caofinfoDTO.NRC = faofinfoDTO.NRC;
                        caofinfoDTO.Address = faofinfoDTO.Address;
                        caofinfoDTO.Township_Code = faofinfoDTO.Township_Code;
                        break;
                    default:
                        caofinfoDTO.Name = string.Empty;
                        break;
                }                
            }
            catch
            {
                ServiceResult.ErrorOccurred = true;
                ServiceResult.MessageCode = CXMessage.MV00046;
            }
            return caofinfoDTO;
        }

        public bool CheckUserNameandPassword(string user, string password)
        {
            if (!CodeCheckerDAO.CheckUserNameandPassword(user, password))
            {
                ServiceResult.MessageCode = "MV30025";
                return false;
            }
            return true;
        }
    }
}
