using System;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Pfm.Dmd.DTO;

namespace Ace.Cbs.Pfm.Sve
{
    /// <summary>
    /// Service
    /// Current Account - Individual
    /// Current Account - PrivateFirm
    /// Saving Account - Individual
    /// Saving Account - Minor
    /// Fixed Account - Individual
    /// Fixed Account - Minor
    /// </summary>
    public class PFMSVE00001 : BaseService, IPFMSVE00001
    {
        #region Properties
        public ICXSVE00002 CodeGenerator { get; set; }
        public IPFMDAO00028 CledgerDAO { get; set; }
        public IPFMDAO00017 CaofDAO { get; set; }
        public IPFMSVE00013 ChequeService { get; set; }
        public IPFMDAO00033 BalanceDAO { get; set; }
        public IPFMDAO00001 CustomerIdDAO { get; set; }
        public IPFMDAO00040 SavingInterestDAO { get; set; }
        public IPFMDAO00016 SAOFDAO { get; set; }
        public IPFMDAO00021 FAOFDAO { get; set; }
        public IPFMSVE00027 FReceiptService { get; set; }
        public IPFMDAO00023 FLedgerDAO { get; set; }

        private ICXDAO00014 blfDAO;
        public ICXDAO00014 BLFDAO
        {
            get { return this.blfDAO; }
            set { this.blfDAO = value; }
        }

        #endregion

        #region Main Method
        [Transaction(TransactionPropagation.Required)]
        public string SaveIndividual(PFMDTO00050 individualDTO)
        {
            string accountCode = string.Empty;
            string accountType = individualDTO.AccountType;
            string subAccountType = individualDTO.SubAccountType;

            individualDTO.AccountType = CXCOM00010.Instance.GetSymbolByAccountType(accountType);
            individualDTO.SubAccountType = CXCOM00010.Instance.GetSymbolByAccountTypeAndSubAccountType(accountType, subAccountType);
            individualDTO.AccountSignature = CXCOM00010.Instance.GetAccountSignature(accountType, subAccountType);

            switch (individualDTO.TransactionStatus)
            {
                case "Current.Individual":
                    // Prepare Data
                    PFMORM00028 cc_cledger = this.GetCLedger(individualDTO);
                    PFMORM00017 cc_caofs = this.GetCAOF(individualDTO);
                    PFMDTO00006 cc_cheque = this.GetCheque(individualDTO);
                    PFMORM00033 cc_balance = this.GetBalance(individualDTO);

                    // Save with transaction
                    accountCode = this.Save_CurrentAccount_Individual(cc_cledger, cc_caofs, cc_cheque, cc_balance, individualDTO);

                    break;

                case "Current.PrivateFirm":
                    // Prepare Data
                    PFMORM00028 cp_cledger = this.GetCLedger(individualDTO);
                    PFMORM00017 cp_caofs = this.GetCAOF(individualDTO);
                    PFMDTO00006 cp_cheque = this.GetCheque(individualDTO);
                    PFMORM00033 cp_balance = this.GetBalance(individualDTO);

                    // Save with transaction
                    accountCode = this.Save_CurrentAccount_PrivateFirm(cp_cledger, cp_caofs, cp_cheque, cp_balance, individualDTO);

                    break;

                case "Saving.Individual":
                    // Prepare Data
                    PFMORM00028 si_cledger = this.GetCLedger(individualDTO);
                    PFMORM00040 si_si = this.GetSavingInterest(individualDTO);
                    PFMORM00016 si_saof = this.GetSAOF(individualDTO);
                    PFMORM00033 si_balance = this.GetBalance(individualDTO);

                    // Save with transaction
                    accountCode = this.Save_SavingAccount_Individual(si_cledger, si_si, si_saof, si_balance, individualDTO);

                    break;

                case "Saving.Minor":
                    // Prepare Data
                    PFMORM00028 sm_cledger = this.GetCLedger(individualDTO);
                    PFMORM00040 sm_si = this.GetSavingInterest(individualDTO);
                    PFMORM00016 sm_saof = this.GetSAOF(individualDTO);
                    PFMORM00033 sm_balance = this.GetBalance(individualDTO);

                    // Save with transaction
                    accountCode = this.Save_SavingAccount_Minor(sm_cledger, sm_si, sm_saof, sm_balance, individualDTO);

                    break;

                case "Fixed.Individual":
                    // Prepare Data
                    PFMORM00023 fi_fledger = this.GetFLedger(individualDTO);
                    PFMORM00021 fi_faof = this.GetFAOF(individualDTO);
                    PFMORM00033 fi_balance = this.GetBalance(individualDTO);

                    // Save with transaction
                    accountCode = this.Save_FixedAccount_Individual(fi_fledger, fi_faof, individualDTO.FReceipt, fi_balance, individualDTO);

                    break;

                case "Fixed.Minor":
                    // Prepare Data
                    PFMORM00023 fm_fledger = this.GetFLedger(individualDTO);
                    PFMORM00021 fm_faof = this.GetFAOF(individualDTO);
                    PFMORM00033 fm_balance = this.GetBalance(individualDTO);

                    // Save with transaction
                    accountCode = this.Save_FixedAccount_Minor(fm_fledger, fm_faof, individualDTO.FReceipt, fm_balance, individualDTO);


                    break;

                // Added by HWKO (22-Jun-2017)
                case "BusinessLoan.Individual":
                    // Prepare Data
                    PFMORM00028 bi_cledger = this.GetCLedger(individualDTO);
                    PFMORM00017 bi_caofs = this.GetCAOF(individualDTO);
                    PFMDTO00006 bi_cheque = this.GetCheque(individualDTO);
                    PFMORM00033 bi_balance = this.GetBalance(individualDTO);

                    // Save with transaction
                    accountCode = this.Save_CurrentAccount_Individual(bi_cledger, bi_caofs, bi_cheque, bi_balance, individualDTO);

                    break;

                // Added by HWKO (22-Jun-2017)
                case "HirePurchaseLoan.Individual":
                    // Prepare Data
                    PFMORM00028 hi_cledger = this.GetCLedger(individualDTO);
                    PFMORM00017 hi_caofs = this.GetCAOF(individualDTO);
                    PFMDTO00006 hi_cheque = this.GetCheque(individualDTO);
                    PFMORM00033 hi_balance = this.GetBalance(individualDTO);

                    // Save with transaction
                    accountCode = this.Save_CurrentAccount_Individual(hi_cledger, hi_caofs, hi_cheque, hi_balance, individualDTO);

                    break;

                // Added by HWKO (22-Jun-2017)
                case "PersonalLoan.Individual":
                    // Prepare Data
                    PFMORM00028 pi_cledger = this.GetCLedger(individualDTO);
                    PFMORM00017 pi_caofs = this.GetCAOF(individualDTO);
                    PFMDTO00006 pi_cheque = this.GetCheque(individualDTO);
                    PFMORM00033 pi_balance = this.GetBalance(individualDTO);

                    // Save with transaction
                    accountCode = this.Save_CurrentAccount_Individual(pi_cledger, pi_caofs, pi_cheque, pi_balance, individualDTO);

                    break;

                // Added by HWKO (08-Aug-2017)
                case "Dealer.Individual":
                    // Prepare Data
                    PFMORM00028 di_cledger = this.GetCLedger(individualDTO);
                    PFMORM00017 di_caofs = this.GetCAOF(individualDTO);
                    PFMDTO00006 di_cheque = this.GetCheque(individualDTO);
                    PFMORM00033 di_balance = this.GetBalance(individualDTO);

                    // Save with transaction
                    accountCode = this.Save_CurrentAccount_Individual(di_cledger, di_caofs, di_cheque, di_balance, individualDTO);

                    break;
            }

            if (string.IsNullOrEmpty(accountCode))
            {
                throw new Exception(this.ServiceResult.MessageCode);
            }
            return accountCode;
        }
        #endregion

        #region Helper Methods
        [Transaction(TransactionPropagation.Required)]
        public string Save_CurrentAccount_Individual(PFMORM00028 cledger, PFMORM00017 caof, PFMDTO00006 cheque, PFMORM00033 balance, PFMDTO00050 individualDTO)
        {
            string accountNoFormatCode = this.CodeGenerator.GetAccountNoFormatCode(individualDTO.TransactionStatus, individualDTO.CurrencyCode);            
            string accountCode = this.CodeGenerator.GetGenerateCode(accountNoFormatCode, CXCOM00009.AccountNoCheckDigitFormula, individualDTO.CreatedUserId, individualDTO.BranchCode, new object[] { individualDTO.BranchCode, individualDTO.CurrencySymbol, individualDTO.AccountType, individualDTO.SubAccountType });
            
            cledger.AccountNo = accountCode;
            this.CledgerDAO.Save(cledger);

            caof.CledgerAccountNo = accountCode;
            this.CaofDAO.Save(caof);

            if (string.IsNullOrEmpty(cheque.ChequeBookNo) == false)
            {
                cheque.AccountNo = accountCode;
                this.ChequeService.Save(cheque);
                if (this.ChequeService.ServiceResult.ErrorOccurred)
                {
                    //throw new Exception(this.ChequeService.ServiceResult.MessageCode);
                    this.ServiceResult.ErrorOccurred = true; //modify
                    this.ServiceResult.MessageCode = this.ChequeService.ServiceResult.MessageCode;
                    return string.Empty;
                }
            }           

            this.CustomerIdDAO.UpdateOpenAccount(caof.CustomerID, individualDTO.CreatedUserId);

            balance.AccountNo = accountCode;
            this.BalanceDAO.Save(balance);

            return accountCode;
        }

        [Transaction()]
        private string Save_CurrentAccount_PrivateFirm(PFMORM00028 cledger, PFMORM00017 caof, PFMDTO00006 cheque, PFMORM00033 balance, PFMDTO00050 individualDTO)
        {
            string accountNoFormatCode = this.CodeGenerator.GetAccountNoFormatCode(individualDTO.TransactionStatus, individualDTO.CurrencyCode);
            //string accountCode = this.CodeGenerator.GetGenerateCode(accountNoFormatCode, CXCOM00009.AccountNoCheckDigitFormula, individualDTO.CreatedUserId, CurrentUserEntity.BranchCode, new object[] { individualDTO.BranchCode, individualDTO.CurrencySymbol, individualDTO.AccountType, individualDTO.SubAccountType });
            string accountCode = this.CodeGenerator.GetGenerateCode(accountNoFormatCode, CXCOM00009.AccountNoCheckDigitFormula, individualDTO.CreatedUserId, individualDTO.BranchCode, new object[] { individualDTO.BranchCode, individualDTO.CurrencySymbol, individualDTO.AccountType, individualDTO.SubAccountType });

            cledger.AccountNo = accountCode;
            this.CledgerDAO.Save(cledger);

            caof.CledgerAccountNo = accountCode;
            this.CaofDAO.Save(caof);

            if (string.IsNullOrEmpty(cheque.ChequeBookNo) == false)
            {
                cheque.AccountNo = accountCode;
                this.ChequeService.Save(cheque);
                if (this.ChequeService.ServiceResult.ErrorOccurred)
                {
                    //throw new Exception(this.ChequeService.ServiceResult.MessageCode);                    
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = this.ChequeService.ServiceResult.MessageCode;
                    return string.Empty;
                }
            }

            this.CustomerIdDAO.UpdateOpenAccount(caof.CustomerID, individualDTO.CreatedUserId);

            balance.AccountNo = accountCode;
            this.BalanceDAO.Save(balance);

            return accountCode;
        }

        [Transaction()]
        private string Save_SavingAccount_Individual(PFMORM00028 cledger, PFMORM00040 si, PFMORM00016 saof, PFMORM00033 balance, PFMDTO00050 individualDTO)
        {
            string accountNoFormatCode = this.CodeGenerator.GetAccountNoFormatCode(individualDTO.TransactionStatus, individualDTO.CurrencyCode);
            //string accountCode = this.CodeGenerator.GetGenerateCode(accountNoFormatCode, CXCOM00009.AccountNoCheckDigitFormula, individualDTO.CreatedUserId, CurrentUserEntity.BranchCode, new object[] { individualDTO.BranchCode, individualDTO.CurrencySymbol, individualDTO.AccountType, individualDTO.SubAccountType });
            string accountCode = this.CodeGenerator.GetGenerateCode(accountNoFormatCode, CXCOM00009.AccountNoCheckDigitFormula, individualDTO.CreatedUserId, individualDTO.BranchCode, new object[] { individualDTO.BranchCode, individualDTO.CurrencySymbol, individualDTO.AccountType, individualDTO.SubAccountType });
            cledger.AccountNo = accountCode;
            this.CledgerDAO.Save(cledger);

            saof.CledgerAccountNo = accountCode;
            this.SAOFDAO.Save(saof);

            this.CustomerIdDAO.UpdateOpenAccount(saof.Customer_Id, individualDTO.CreatedUserId);

            si.AccountNo = accountCode;
            this.SavingInterestDAO.Save(si);

            balance.AccountNo = accountCode;
            this.BalanceDAO.Save(balance);

            return accountCode;
        }

        [Transaction()]
        private string Save_SavingAccount_Minor(PFMORM00028 cledger, PFMORM00040 si, PFMORM00016 saof, PFMORM00033 balance, PFMDTO00050 individualDTO)
        {
            string accountNoFormatCode = this.CodeGenerator.GetAccountNoFormatCode(individualDTO.TransactionStatus, individualDTO.CurrencyCode);
            //string accountCode = this.CodeGenerator.GetGenerateCode(accountNoFormatCode, CXCOM00009.AccountNoCheckDigitFormula, individualDTO.CreatedUserId, CurrentUserEntity.BranchCode, new object[] { individualDTO.BranchCode, individualDTO.CurrencySymbol, individualDTO.AccountType, individualDTO.SubAccountType });
            string accountCode = this.CodeGenerator.GetGenerateCode(accountNoFormatCode, CXCOM00009.AccountNoCheckDigitFormula, individualDTO.CreatedUserId, individualDTO.BranchCode, new object[] { individualDTO.BranchCode, individualDTO.CurrencySymbol, individualDTO.AccountType, individualDTO.SubAccountType });

            cledger.AccountNo = accountCode;
            this.CledgerDAO.Save(cledger);

            saof.CledgerAccountNo = accountCode;
            this.SAOFDAO.Save(saof);

            this.CustomerIdDAO.UpdateOpenAccount(saof.Customer_Id, individualDTO.CreatedUserId);

            si.AccountNo = accountCode;
            this.SavingInterestDAO.Save(si);

            balance.AccountNo = accountCode;
            this.BalanceDAO.Save(balance);

            return accountCode;
        }

        [Transaction()]
        private string Save_FixedAccount_Individual(PFMORM00023 fledger, PFMORM00021 faof, PFMDTO00032 freceipt, PFMORM00033 balance, PFMDTO00050 individualDTO)
        {
            try
            {
                string accountNoFormatCode = this.CodeGenerator.GetAccountNoFormatCode(individualDTO.TransactionStatus, individualDTO.CurrencyCode);
                //string accountCode = this.CodeGenerator.GetGenerateCode(accountNoFormatCode, CXCOM00009.AccountNoCheckDigitFormula, individualDTO.CreatedUserId, CurrentUserEntity.BranchCode, new object[] { individualDTO.BranchCode, individualDTO.CurrencySymbol, individualDTO.AccountType, individualDTO.SubAccountType });
                string accountCode = this.CodeGenerator.GetGenerateCode(accountNoFormatCode, CXCOM00009.AccountNoCheckDigitFormula, individualDTO.CreatedUserId, individualDTO.BranchCode, new object[] { individualDTO.BranchCode, individualDTO.CurrencySymbol, individualDTO.AccountType, individualDTO.SubAccountType });

                fledger.AccountNo = accountCode;
                this.FLedgerDAO.Save(fledger);

                faof.FledgerAccountNo = accountCode;

                //2013/08/15
                faof.LastReceiptNo = freceipt.ReceiptNo;
                //2013/08/15

                this.FAOFDAO.Save(faof);
                this.CustomerIdDAO.UpdateOpenAccount(faof.CustomerId, individualDTO.CreatedUserId);

                freceipt.AccountNo = accountCode;
                freceipt.AccountSign = individualDTO.AccountSignature;
                freceipt.SourceBranchCode = individualDTO.BranchCode;
                freceipt.CurrencyCode = individualDTO.CurrencyCode;
                this.FReceiptService.Save(freceipt, true);
                if (this.FReceiptService.ServiceResult.ErrorOccurred)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = this.FReceiptService.ServiceResult.MessageCode;
                    return string.Empty;
                }
                balance.AccountNo = accountCode;
                this.BalanceDAO.Save(balance);
                return accountCode;
            }
            catch(Exception e)
            {
                if (e.Message == "FReceiptError")
                    throw new Exception();
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90000";
                return string.Empty;
            }
        }

        [Transaction()]
        private string Save_FixedAccount_Minor(PFMORM00023 fledger, PFMORM00021 faof, PFMDTO00032 freceipt, PFMORM00033 balance, PFMDTO00050 individualDTO)
        {
            string accountNoFormatCode = this.CodeGenerator.GetAccountNoFormatCode(individualDTO.TransactionStatus, individualDTO.CurrencyCode);
            //string accountCode = this.CodeGenerator.GetGenerateCode(accountNoFormatCode, CXCOM00009.AccountNoCheckDigitFormula, individualDTO.CreatedUserId, CurrentUserEntity.BranchCode, new object[] { individualDTO.BranchCode, individualDTO.CurrencySymbol, individualDTO.AccountType, individualDTO.SubAccountType });
            string accountCode = this.CodeGenerator.GetGenerateCode(accountNoFormatCode, CXCOM00009.AccountNoCheckDigitFormula, individualDTO.CreatedUserId, individualDTO.BranchCode, new object[] { individualDTO.BranchCode, individualDTO.CurrencySymbol, individualDTO.AccountType, individualDTO.SubAccountType });

            fledger.AccountNo = accountCode;
            faof.LastReceiptNo = freceipt.ReceiptNo;
            this.FLedgerDAO.Save(fledger);

            faof.FledgerAccountNo = accountCode;
            this.FAOFDAO.Save(faof);
            this.CustomerIdDAO.UpdateOpenAccount(faof.CustomerId, individualDTO.CreatedUserId);

            freceipt.AccountNo = accountCode;
            freceipt.AccountSign = individualDTO.AccountSignature;
            freceipt.CurrencyCode = individualDTO.CurrencyCode;
            freceipt.SourceBranchCode = individualDTO.BranchCode;
             this.FReceiptService.Save(freceipt, true);
            if (this.FReceiptService.ServiceResult.ErrorOccurred)
            {
                //throw new Exception(this.FReceiptService.ServiceResult.MessageCode);
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.FReceiptService.ServiceResult.MessageCode;
                return string.Empty;
            }

            balance.AccountNo = accountCode;
            this.BalanceDAO.Save(balance);

            return accountCode;
        }

        //added by ZMS for Pristine => the selected customer is black list or not 
        public PFMDTO00080 CheckBlackListCustomerByCustId(string custId, string branchCode)
        {
            PFMDTO00080 res = CaofDAO.CheckBlackListCustomerByCustId(custId, branchCode);
            return res;
        }
        #endregion

        #region Convert DTO to ORM

        private PFMORM00028 GetCLedger(PFMDTO00050 entity)
        {
            PFMORM00028 cledger = new PFMORM00028();

            cledger.Date_Time = DateTime.Now;
            cledger.AccountSign = entity.AccountSignature;
            cledger.UserNo = entity.CreatedUserId.ToString();
            cledger.SavingInterestRate = entity.SavingInterestRate;
            cledger.SourceBranchCode = entity.BranchCode;
            cledger.CurrencyCode = entity.CurrencyCode;
            cledger.Active = true;
            
            cledger.LastUserNo = Convert.ToString(entity.CreatedUserId);
            cledger.CreatedUserId = entity.CreatedUserId;
            cledger.CreatedDate = DateTime.Now;

            return cledger;
        }

        private PFMDTO00006 GetCheque(PFMDTO00050 entity)
        {
            PFMDTO00006 cheque = new PFMDTO00006();

            cheque.AccountSign = entity.AccountSignature;
            cheque.UserNo = entity.CreatedUserId.ToString();
            cheque.ChequeBookNo = entity.ChequeBookNo;
            cheque.StartNo = entity.ChequeStartNo;
            cheque.EndNo = entity.ChequeEndNo;
            cheque.IssueDate = DateTime.Now;
            cheque.SourceBranchCode = entity.BranchCode;
            cheque.CurrencyCode = entity.CurrencyCode;
            cheque.Active = true;
            cheque.CreatedUserId = entity.CreatedUserId;
            cheque.CreatedDate = DateTime.Now;

            return cheque;
        }

        private PFMORM00033 GetBalance(PFMDTO00050 entity)
        {
            PFMORM00033 balance = new PFMORM00033();

            balance.DATE_TIME = DateTime.Now;
            balance.AccountSign = entity.AccountSignature;
            balance.USERNO = entity.CreatedUserId.ToString();

            //Modified by ZMS for budget end flexible 2018/09/20
            //balance.Budget = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode); 
            string Return = String.Empty;
            balance.Budget = BLFDAO.GetBudget_Month_Year_Quarter(2, DateTime.Now, entity.BranchCode, Return); // For 2018/09/17 => 2018/2018
            
            balance.SourceBranchCode = entity.BranchCode;
            balance.CurrencyCode = entity.CurrencyCode;
            balance.Active = true;
            balance.CreatedUserId = entity.CreatedUserId;
            balance.CreatedDate = DateTime.Now;

            return balance;
        }

        private PFMORM00040 GetSavingInterest(PFMDTO00050 entity)
        {
            PFMORM00040 savingInterest = new PFMORM00040();

            savingInterest.DATE_TIME = DateTime.Now;
            savingInterest.AccountSignature = entity.AccountSignature;
            
            //Modified by ZMS for budget end flexible 2018/09/20
            savingInterest.Budget = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
            string Return = String.Empty;
            savingInterest.Budget = BLFDAO.GetBudget_Month_Year_Quarter(2, DateTime.Now, entity.BranchCode, Return); // For 2018/09/17 => 2018/2018

            savingInterest.SourceBranchCode = entity.BranchCode;
            savingInterest.CurrencyCode = entity.CurrencyCode;
            savingInterest.Active = true;
            savingInterest.CreatedUserId = entity.CreatedUserId;
            savingInterest.CreatedDate = DateTime.Now;

            return savingInterest;
        }

        private PFMORM00023 GetFLedger(PFMDTO00050 entity)
        {
            PFMORM00023 fledger = new PFMORM00023();

            fledger.Date_Time = DateTime.Now;
            fledger.DebitAccountNo = entity.DebitLinkAccount;
            fledger.LinkLimit = entity.DebitLimit;
            fledger.AccountSignature = entity.AccountSignature;
            fledger.UserNo = entity.CreatedUserId.ToString();
            fledger.SourceBranchCode = entity.BranchCode;
            fledger.CurrencyCode = entity.CurrencyCode;
            fledger.Active = true;
            fledger.CreatedUserId = entity.CreatedUserId;
            fledger.CreatedDate = DateTime.Now;

            return fledger;
        }

        private PFMORM00016 GetSAOF(PFMDTO00050 entity)
        {
            PFMORM00016 individualDTO = new PFMORM00016();
            individualDTO.Name = entity.NameOfFirm;
            individualDTO.Name3 = entity.GuardianshipName;
            individualDTO.DateofBirth = entity.DateOfBirth;
            individualDTO.GuardianshipNRC = entity.GuardianshipNRC;            
            individualDTO.OPENDATE = DateTime.Now;
            individualDTO.Customer_Id = entity.CustomerId;
            individualDTO.AccountSign = entity.AccountSignature;
            if (individualDTO.AccountSign == "SM")   //Added by ASDA
            {
                //int year = individualDTO.DateofBirth.Value.Year + 18;
                //DateTime dt = Convert.ToDateTime(individualDTO.DateofBirth.Value.Day + "-" + individualDTO.DateofBirth.Value.Month + "-" + year);
                //individualDTO.AcceptedDate = dt;
                DateTime dt = Convert.ToDateTime(individualDTO.DateofBirth);
                individualDTO.AcceptedDate = dt.AddYears(18); 
            }
            else
            {
                individualDTO.AcceptedDate = entity.AcceptedDate;
            }      //  End---------------------------     
            individualDTO.NoOfPersonSign = 1;
            individualDTO.SerialofCustomer = 0;
            individualDTO.SourceBranchCode = entity.BranchCode;
            individualDTO.CurrencyCode = entity.CurrencyCode;
            individualDTO.USERNO = entity.CreatedUserId.ToString();  //Added by ASDA
            individualDTO.Active = true;
            individualDTO.CreatedUserId = entity.CreatedUserId;
            individualDTO.CreatedDate = DateTime.Now;

            return individualDTO;
        }

        private PFMORM00017 GetCAOF(PFMDTO00050 entity)
        {
            PFMORM00017 individualDTO = new PFMORM00017();
            individualDTO.Name = entity.NameOfFirm;
            individualDTO.Business = entity.Business;
            individualDTO.AccountSign = entity.AccountSignature;
            individualDTO.OPENDATE = DateTime.Now;
            individualDTO.CustomerID = entity.CustomerId;
            individualDTO.SerialofCustomer = 0;
            individualDTO.NoOfPersonSign = 1;
            //individualDTO.JoinType = "0";
            individualDTO.JoinType = null;
            individualDTO.SourceBranchCode = entity.BranchCode;
            individualDTO.CurrencyCode = entity.CurrencyCode;
            individualDTO.Active = true;
            individualDTO.CreatedUserId = entity.CreatedUserId;
            individualDTO.CreatedDate = DateTime.Now;
            
            return individualDTO;
        }

        private PFMORM00021 GetFAOF(PFMDTO00050 entity)
        {
            PFMORM00021 individualDTO = new PFMORM00021();

            individualDTO.GuardianName = entity.GuardianshipName;
            individualDTO.GuardianNRC = entity.GuardianshipNRC;
            individualDTO.AccountSignature = entity.AccountSignature;
            individualDTO.DateOfBirth = entity.DateOfBirth;
            if (individualDTO.AccountSignature == "FM")   //Added by ASDA
            {   
                DateTime dt = Convert.ToDateTime(individualDTO.DateOfBirth);
                individualDTO.AcceptDate = dt.AddYears(18); 
                
            }
            else
            {
                individualDTO.AcceptDate = entity.AcceptedDate;
            }    //  End---------------------------      
            individualDTO.OpenDate = DateTime.Now;
            individualDTO.CustomerId = entity.CustomerId;
            individualDTO.SourceBranchCode = entity.BranchCode;
            individualDTO.CurrencyCode = entity.CurrencyCode;
            individualDTO.NoOfPersonSign = 1;
            individualDTO.UserNo = entity.CreatedUserId.ToString();
            individualDTO.Active = true;
            individualDTO.CreatedUserId = entity.CreatedUserId;
            individualDTO.CreatedDate = DateTime.Now;

            return individualDTO;
        }

        //DOB,Gname,GuarNrc and ADate fields didn't save in FAOF table. 

        #endregion
    }
}