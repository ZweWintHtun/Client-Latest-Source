using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Pfm.Dmd.DTO;
using Ace.Windows.Core.Service;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Pfm.Sve
{
    /// <summary>
    /// Current Account - Joint
    /// Saving Account - Joint
    /// Fixed Account - Joint
    /// Service
    /// </summary>
    public class PFMSVE00003 : BaseService, IPFMSVE00003
    {
        #region "Properties"
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

        #region "Main Methods"
        [Transaction(TransactionPropagation.Required)]
        public string SaveJoint(PFMDTO00050 jointDTO)
        {
            string accountCode = string.Empty;

            string accountType = jointDTO.AccountType;
            string subAccountType = jointDTO.SubAccountType;

            jointDTO.AccountType = CXCOM00010.Instance.GetSymbolByAccountType(accountType);
            jointDTO.SubAccountType = CXCOM00010.Instance.GetSymbolByAccountTypeAndSubAccountType(accountType, subAccountType);
            jointDTO.AccountSignature = CXCOM00010.Instance.GetAccountSignature(accountType, subAccountType);

            switch (jointDTO.TransactionStatus)
            {
                case "Current.Joint":
                    // Prepare Data
                    PFMORM00028 cc_cledger = this.GetCLedger(jointDTO);
                    IList<PFMORM00017> cc_caofs = this.GetCAOFs(jointDTO);
                    PFMDTO00006 cc_cheque = this.GetCheque(jointDTO);
                    PFMORM00033 cc_balance = this.GetBalance(jointDTO);

                    // Save with transaction
                    accountCode = this.Save_CurrentAccount_Company(cc_cledger, cc_caofs, cc_cheque, cc_balance, jointDTO);

                    break;

                case "Saving.Joint":
                    // Prepare Data
                    PFMORM00028 so_cledger = this.GetCLedger(jointDTO);
                    IList<PFMORM00016> so_saof = this.GetSAOFs(jointDTO);
                    PFMORM00040 so_si = this.GetSavingInterest(jointDTO);
                    PFMORM00033 so_balance = this.GetBalance(jointDTO);

                    // Save with transaction
                    accountCode = this.Save_SavingAccount_Organization(so_cledger, so_si, so_saof, so_balance, jointDTO);

                    break;

                case "Fixed.Joint":
                    // Prepare Data
                    PFMORM00023 fc_fledger = this.GetFLedger(jointDTO);
                    IList<PFMORM00021> fc_faof = this.GetFAOFs(jointDTO);
                    PFMORM00033 fc_balance = this.GetBalance(jointDTO);

                    // Save with transaction
                    accountCode = this.Save_FixedAccount_Company(fc_fledger, fc_faof, jointDTO.FReceipt, fc_balance, jointDTO);

                    break;

                // Added by HWKO (22-Jun-2017)
                case "BusinessLoan.Joint":
                    // Prepare Data
                    PFMORM00028 bj_cledger = this.GetCLedger(jointDTO);
                    IList<PFMORM00017> bj_caofs = this.GetCAOFs(jointDTO);
                    PFMDTO00006 bj_cheque = this.GetCheque(jointDTO);
                    PFMORM00033 bj_balance = this.GetBalance(jointDTO);

                    // Save with transaction
                    accountCode = this.Save_CurrentAccount_Company(bj_cledger, bj_caofs, bj_cheque, bj_balance, jointDTO);

                    break;

                // Added by HWKO (22-Jun-2017)
                case "HirePurchaseLoan.Joint":
                    // Prepare Data
                    PFMORM00028 hj_cledger = this.GetCLedger(jointDTO);
                    IList<PFMORM00017> hj_caofs = this.GetCAOFs(jointDTO);
                    PFMDTO00006 hj_cheque = this.GetCheque(jointDTO);
                    PFMORM00033 hj_balance = this.GetBalance(jointDTO);

                    // Save with transaction
                    accountCode = this.Save_CurrentAccount_Company(hj_cledger, hj_caofs, hj_cheque, hj_balance, jointDTO);

                    break;

                // Added by HWKO (22-Jun-2017)
                case "PersonalLoan.Joint":
                    // Prepare Data
                    PFMORM00028 pj_cledger = this.GetCLedger(jointDTO);
                    IList<PFMORM00017> pj_caofs = this.GetCAOFs(jointDTO);
                    PFMDTO00006 pj_cheque = this.GetCheque(jointDTO);
                    PFMORM00033 pj_balance = this.GetBalance(jointDTO);

                    // Save with transaction
                    accountCode = this.Save_CurrentAccount_Company(pj_cledger, pj_caofs, pj_cheque, pj_balance, jointDTO);

                    break;

                // Added by HWKO (04-Aug-2017)
                case "Dealer.Joint":
                    // Prepare Data
                    PFMORM00028 dj_cledger = this.GetCLedger(jointDTO);
                    IList<PFMORM00017> dj_caofs = this.GetCAOFs(jointDTO);
                    PFMDTO00006 dj_cheque = this.GetCheque(jointDTO);
                    PFMORM00033 dj_balance = this.GetBalance(jointDTO);

                    // Save with transaction
                    accountCode = this.Save_CurrentAccount_Company(dj_cledger, dj_caofs, dj_cheque, dj_balance, jointDTO);

                    break;
            }
            if (string.IsNullOrEmpty(accountCode))
            {
                throw new Exception(this.ServiceResult.MessageCode);
            }
            return accountCode;
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
            //savingInterest.Budget = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
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

        private IList<PFMORM00016> GetSAOFs(PFMDTO00050 entity)
        {
            IList<PFMORM00016> saofs = new List<PFMORM00016>();

            for (int i = 1; i <= entity.CustomerIds.Count; i++)
            {
                PFMORM00016 saof = new PFMORM00016();

                saof.AccountSign = entity.AccountSignature;
                saof.OPENDATE = DateTime.Now;
                saof.USERNO = entity.CreatedUserId.ToString();
                saof.JoinType = entity.JoinType;
                saof.Customer_Id = entity.CustomerIds[i - 1];
                saof.SerialofCustomer = i;
                saof.NoOfPersonSign = entity.NoOfPersonSign;
                saof.SourceBranchCode = entity.BranchCode;
                saof.CurrencyCode = entity.CurrencyCode;
                saof.Active = true;
                saof.CreatedUserId = entity.CreatedUserId;
                saof.CreatedDate = DateTime.Now;

                saofs.Add(saof);
            }

            return saofs;
        }

        private IList<PFMORM00017> GetCAOFs(PFMDTO00050 entity)
        {
            IList<PFMORM00017> caofs = new List<PFMORM00017>();

            for (int i = 1; i <= entity.CustomerIds.Count; i++)
            {
                PFMORM00017 caof = new PFMORM00017();

                caof.NoOfPersonSign = entity.NoOfPersonSign;
                caof.AccountSign = entity.AccountSignature;
                caof.OPENDATE = DateTime.Now;
                caof.USERNO = entity.CreatedUserId.ToString();
                caof.JoinType = entity.JoinType;
                caof.CustomerID = entity.CustomerIds[i - 1];
                caof.SerialofCustomer = i;
                caof.SourceBranchCode = entity.BranchCode;
                caof.CurrencyCode = entity.CurrencyCode;
                caof.Active = true;
                caof.CreatedUserId = entity.CreatedUserId;
                caof.CreatedDate = DateTime.Now;

                caofs.Add(caof);
            }

            return caofs;
        }

        private IList<PFMORM00021> GetFAOFs(PFMDTO00050 entity)
        {
            IList<PFMORM00021> faofs = new List<PFMORM00021>();

            for (int i = 1; i <= entity.CustomerIds.Count; i++)
            {
                PFMORM00021 faof = new PFMORM00021();
                
                faof.AccountSignature = entity.AccountSignature;
                faof.OpenDate = DateTime.Now;
                faof.JoinType = entity.JoinType;
                faof.NoOfPersonSign = entity.NoOfPersonSign;
                faof.UserNo = entity.CreatedUserId.ToString();
                faof.CustomerId = entity.CustomerIds[i - 1];
                faof.SerialOfCustomer = i;
                faof.SourceBranchCode = entity.BranchCode;
                faof.CurrencyCode = entity.CurrencyCode;
                faof.Active = true;
                faof.CreatedUserId = entity.CreatedUserId;
                faof.CreatedDate = DateTime.Now;

                faofs.Add(faof);
            }

            return faofs;
        }

        #endregion

        #region Helper Methods
        [Transaction(TransactionPropagation.Required)]
        private string Save_CurrentAccount_Company(PFMORM00028 cledger, IList<PFMORM00017> caofs, PFMDTO00006 cheque, PFMORM00033 balance, PFMDTO00050 jointEntity)
        {
            string accountNoFormatCode = this.CodeGenerator.GetAccountNoFormatCode(jointEntity.TransactionStatus, jointEntity.CurrencyCode);            
            string accountCode = this.CodeGenerator.GetGenerateCode(accountNoFormatCode, CXCOM00009.AccountNoCheckDigitFormula, jointEntity.CreatedUserId, jointEntity.BranchCode, new object[] { jointEntity.BranchCode, jointEntity.CurrencySymbol, jointEntity.AccountType, jointEntity.SubAccountType });           

            cledger.AccountNo = accountCode;
            this.CledgerDAO.Save(cledger);

            foreach (PFMORM00017 caof in caofs)
            {
                caof.CledgerAccountNo = accountCode;
                this.CaofDAO.Save(caof);

                this.CustomerIdDAO.UpdateOpenAccount(caof.CustomerID, jointEntity.CreatedUserId);
            }

            if (string.IsNullOrEmpty(cheque.ChequeBookNo) == false)
            {
                cheque.AccountNo = accountCode;
                this.ChequeService.Save(cheque);
                if (this.ChequeService.ServiceResult.ErrorOccurred)
                {
                    throw new Exception(this.ChequeService.ServiceResult.MessageCode);
                }
            }           

            balance.AccountNo = accountCode;
            this.BalanceDAO.Save(balance);

            return accountCode;
        }

        [Transaction(TransactionPropagation.Required)]
        private string Save_SavingAccount_Organization(PFMORM00028 cledger, PFMORM00040 si, IList<PFMORM00016> saofs, PFMORM00033 balance, PFMDTO00050 jointEntity)
        {
            string accountNoFormatCode = this.CodeGenerator.GetAccountNoFormatCode(jointEntity.TransactionStatus, jointEntity.CurrencyCode);            
            string accountCode = this.CodeGenerator.GetGenerateCode(accountNoFormatCode, CXCOM00009.AccountNoCheckDigitFormula, jointEntity.CreatedUserId, jointEntity.BranchCode, new object[] { jointEntity.BranchCode, jointEntity.CurrencySymbol, jointEntity.AccountType, jointEntity.SubAccountType });

            cledger.AccountNo = accountCode;
            this.CledgerDAO.Save(cledger);

            foreach (PFMORM00016 saof in saofs)
            {
                saof.CledgerAccountNo = accountCode;
                this.SAOFDAO.Save(saof);

                this.CustomerIdDAO.UpdateOpenAccount(saof.Customer_Id, jointEntity.CreatedUserId);
            }

            si.AccountNo = accountCode;
            this.SavingInterestDAO.Save(si);

            balance.AccountNo = accountCode;
            this.BalanceDAO.Save(balance);

            return accountCode;
        }

        [Transaction(TransactionPropagation.Required)]
        private string Save_FixedAccount_Company(PFMORM00023 fledger, IList<PFMORM00021> faofs, PFMDTO00032 freceipt, PFMORM00033 balance, PFMDTO00050 jointEntity)
        {
            string accountNoFormatCode = this.CodeGenerator.GetAccountNoFormatCode(jointEntity.TransactionStatus, jointEntity.CurrencyCode);            
            string accountCode = this.CodeGenerator.GetGenerateCode(accountNoFormatCode, CXCOM00009.AccountNoCheckDigitFormula, jointEntity.CreatedUserId, jointEntity.BranchCode, new object[] { jointEntity.BranchCode, jointEntity.CurrencySymbol, jointEntity.AccountType, jointEntity.SubAccountType });

            fledger.AccountNo = accountCode;
            this.FLedgerDAO.Save(fledger);

            freceipt.AccountNo = accountCode;
            freceipt.AccountSign = jointEntity.AccountSignature;
            freceipt.SourceBranchCode = jointEntity.BranchCode;
            freceipt.CurrencyCode = jointEntity.CurrencyCode;
            freceipt.UserNo = jointEntity.CreatedUserId.ToString();
            freceipt.RDate = DateTime.Now;
            PFMDTO00032 outputReceipt = this.FReceiptService.Save(freceipt,true);
            if (this.FReceiptService.ServiceResult.ErrorOccurred)
            {
                //throw new Exception(this.FReceiptService.ServiceResult.MessageCode); //comment by hmw
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.FReceiptService.ServiceResult.MessageCode;
                return string.Empty;
            }

            foreach (PFMORM00021 faof in faofs)
            {
                faof.FledgerAccountNo = accountCode;
                faof.LastReceiptNo = outputReceipt.ReceiptNo;
                this.FAOFDAO.Save(faof);
                this.CustomerIdDAO.UpdateOpenAccount(faof.CustomerId, jointEntity.CreatedUserId);
            }            

            balance.AccountNo = accountCode;
            this.BalanceDAO.Save(balance);

            return accountCode;
        }

        //added by ZMS for Pristine the selected customer is black list or not 
        public PFMDTO00080 CheckBlackListCustomerByCustId(string custId, string branchCode)
        {
            PFMDTO00080 res = CaofDAO.CheckBlackListCustomerByCustId(custId, branchCode);
            return res;
        }
        #endregion
    }
}