using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.Core.Service;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Pfm.Sve
{
    /// <summary>
    /// Current Account - Company
    /// Current Account - Partnership
    /// Current Account - Association
    /// Saving Account - Company / Organization
    /// Fixed Account - Company / Organization
    /// Service
    /// </summary>
    public class PFMSVE00002 : BaseService, IPFMSVE00002
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
        #endregion

        #region Main Method
        [Transaction(TransactionPropagation.Required)]
        public string SaveCompany(PFMDTO00050 companyDTO)
        {
            string accountCode = string.Empty;

            string accountType = companyDTO.AccountType;
            string subAccountType = companyDTO.SubAccountType;

            companyDTO.AccountType = CXCOM00010.Instance.GetSymbolByAccountType(accountType);
            companyDTO.SubAccountType = CXCOM00010.Instance.GetSymbolByAccountTypeAndSubAccountType(accountType, subAccountType);
            companyDTO.AccountSignature = CXCOM00010.Instance.GetAccountSignature(accountType, subAccountType);

            switch (companyDTO.TransactionStatus)
            {
                case "Current.Company":
                    // Prepare Data
                    PFMORM00028 cc_cledger = this.GetCLedger(companyDTO);
                    IList<PFMORM00017> cc_caofs = this.GetCAOFs(companyDTO);
                    PFMDTO00006 cc_cheque = this.GetCheque(companyDTO);
                    PFMORM00033 cc_balance = this.GetBalance(companyDTO);

                    // Save with transaction
                    accountCode = this.Save_CurrentAccount_Company(cc_cledger, cc_caofs, cc_cheque, cc_balance, companyDTO);

                    break;

                case "Current.Partnership":
                    // Prepare Data
                    PFMORM00028 cp_cledger = this.GetCLedger(companyDTO);
                    IList<PFMORM00017> cp_caofs = this.GetCAOFs(companyDTO);
                    PFMDTO00006 cp_cheque = this.GetCheque(companyDTO);
                    PFMORM00033 cp_balance = this.GetBalance(companyDTO);

                    // Save with transaction
                    accountCode = this.Save_CurrentAccount_PartnerShip(cp_cledger, cp_caofs, cp_cheque, cp_balance, companyDTO);

                    break;

                case "Current.Association":
                    // Prepare Data
                    PFMORM00028 ca_cledger = this.GetCLedger(companyDTO);
                    IList<PFMORM00017> ca_caofs = this.GetCAOFs(companyDTO);
                    PFMDTO00006 ca_cheque = this.GetCheque(companyDTO);
                    PFMORM00033 ca_balance = this.GetBalance(companyDTO);

                    // Save with transaction
                    accountCode = this.Save_CurrentAccount_Association(ca_cledger, ca_caofs, ca_cheque, ca_balance, companyDTO);

                    break;

                case "Saving.Company":
                    // Prepare Data
                    PFMORM00028 so_cledger = this.GetCLedger(companyDTO);
                    IList<PFMORM00016> so_saof = this.GetSAOFs(companyDTO);
                    PFMORM00040 so_si = this.GetSavingInterest(companyDTO);
                    PFMORM00033 so_balance = this.GetBalance(companyDTO);

                    // Save with transaction
                    accountCode = this.Save_SavingAccount_Organization(so_cledger, so_si, so_saof, so_balance, companyDTO);

                    break;

                case "Fixed.Company":
                    // Prepare Data
                    PFMORM00023 fc_fledger = this.GetFLedger(companyDTO);
                    IList<PFMORM00021> fc_faof = this.GetFAOFs(companyDTO);
                    PFMORM00033 fc_balance = this.GetBalance(companyDTO);

                    // Save with transaction
                    accountCode = this.Save_FixedAccount_Company(fc_fledger, fc_faof, companyDTO.FReceipt, fc_balance, companyDTO);

                    break;

                //Added By HWKO (22-Jun-2017)
                case "BusinessLoan.Company":
                    // Prepare Data
                    PFMORM00028 bc_cledger = this.GetCLedger(companyDTO);
                    IList<PFMORM00017> bc_caofs = this.GetCAOFs(companyDTO);
                    PFMDTO00006 bc_cheque = this.GetCheque(companyDTO);
                    PFMORM00033 bc_balance = this.GetBalance(companyDTO);

                    // Save with transaction
                    accountCode = this.Save_CurrentAccount_Company(bc_cledger, bc_caofs, bc_cheque, bc_balance, companyDTO);

                    break;

                //Added By HWKO (22-Jun-2017)
                case "HirePurchaseLoan.Company":
                    // Prepare Data
                    PFMORM00028 hc_cledger = this.GetCLedger(companyDTO);
                    IList<PFMORM00017> hc_caofs = this.GetCAOFs(companyDTO);
                    PFMDTO00006 hc_cheque = this.GetCheque(companyDTO);
                    PFMORM00033 hc_balance = this.GetBalance(companyDTO);

                    // Save with transaction
                    accountCode = this.Save_CurrentAccount_Company(hc_cledger, hc_caofs, hc_cheque, hc_balance, companyDTO);

                    break;

                //Added By HWKO (22-Jun-2017)
                case "PersonalLoan.Company":
                    // Prepare Data
                    PFMORM00028 pc_cledger = this.GetCLedger(companyDTO);
                    IList<PFMORM00017> pc_caofs = this.GetCAOFs(companyDTO);
                    PFMDTO00006 pc_cheque = this.GetCheque(companyDTO);
                    PFMORM00033 pc_balance = this.GetBalance(companyDTO);

                    // Save with transaction
                    accountCode = this.Save_CurrentAccount_Company(pc_cledger, pc_caofs, pc_cheque, pc_balance, companyDTO);

                    break;

                //Added By HWKO (04-Aug-2017)
                case "Dealer.Company":
                    // Prepare Data
                    PFMORM00028 dc_cledger = this.GetCLedger(companyDTO);
                    IList<PFMORM00017> dc_caofs = this.GetCAOFs(companyDTO);
                    PFMDTO00006 dc_cheque = this.GetCheque(companyDTO);
                    PFMORM00033 dc_balance = this.GetBalance(companyDTO);

                    // Save with transaction
                    accountCode = this.Save_CurrentAccount_Company(dc_cledger, dc_caofs, dc_cheque, dc_balance, companyDTO);

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
        private string Save_CurrentAccount_Company(PFMORM00028 cledger, IList<PFMORM00017> caofs, PFMDTO00006 cheque, PFMORM00033 balance, PFMDTO00050 companyEntity)
        {
            string accountNoFormatCode = this.CodeGenerator.GetAccountNoFormatCode(companyEntity.TransactionStatus, companyEntity.CurrencyCode);           
            string accountCode = this.CodeGenerator.GetGenerateCode(accountNoFormatCode, CXCOM00009.AccountNoCheckDigitFormula, companyEntity.CreatedUserId, companyEntity.BranchCode, new object[] { companyEntity.BranchCode, companyEntity.CurrencySymbol, companyEntity.AccountType, companyEntity.SubAccountType });

            cledger.AccountNo = accountCode;
            this.CledgerDAO.Save(cledger);

            foreach (PFMORM00017 caof in caofs)
            {
                caof.CledgerAccountNo = accountCode;
                this.CaofDAO.Save(caof);

                this.CustomerIdDAO.UpdateOpenAccount(caof.CustomerID, companyEntity.CreatedUserId);
            }

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

            balance.AccountNo = accountCode;
            this.BalanceDAO.Save(balance);

            return accountCode;
        }

        [Transaction(TransactionPropagation.Required)]
        private string Save_CurrentAccount_PartnerShip(PFMORM00028 cledger, IList<PFMORM00017> caofs, PFMDTO00006 cheque, PFMORM00033 balance, PFMDTO00050 companyEntity)
        {
            string accountNoFormatCode = this.CodeGenerator.GetAccountNoFormatCode(companyEntity.TransactionStatus, companyEntity.CurrencyCode);            
            string accountCode = this.CodeGenerator.GetGenerateCode(accountNoFormatCode, CXCOM00009.AccountNoCheckDigitFormula, companyEntity.CreatedUserId, companyEntity.BranchCode, new object[] { companyEntity.BranchCode, companyEntity.CurrencySymbol, companyEntity.AccountType, companyEntity.SubAccountType });

            cledger.AccountNo = accountCode;
            this.CledgerDAO.Save(cledger);

            foreach (PFMORM00017 caof in caofs)
            {
                caof.CledgerAccountNo = accountCode;
                this.CaofDAO.Save(caof);

                this.CustomerIdDAO.UpdateOpenAccount(caof.CustomerID, companyEntity.CreatedUserId);
            }

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

            balance.AccountNo = accountCode;
            this.BalanceDAO.Save(balance);

            return accountCode;
        }

        [Transaction(TransactionPropagation.Required)]
        private string Save_CurrentAccount_Association(PFMORM00028 cledger, IList<PFMORM00017> caofs, PFMDTO00006 cheque, PFMORM00033 balance, PFMDTO00050 companyEntity)
        {
            string accountNoFormatCode = this.CodeGenerator.GetAccountNoFormatCode(companyEntity.TransactionStatus, companyEntity.CurrencyCode);            
            string accountCode = this.CodeGenerator.GetGenerateCode(accountNoFormatCode, CXCOM00009.AccountNoCheckDigitFormula, companyEntity.CreatedUserId, companyEntity.BranchCode, new object[] { companyEntity.BranchCode, companyEntity.CurrencySymbol, companyEntity.AccountType, companyEntity.SubAccountType });

            cledger.AccountNo = accountCode;
            this.CledgerDAO.Save(cledger);

            foreach (PFMORM00017 caof in caofs)
            {
                caof.CledgerAccountNo = accountCode;
                this.CaofDAO.Save(caof);
                this.CustomerIdDAO.UpdateOpenAccount(caof.CustomerID, companyEntity.CreatedUserId);
            }

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

            balance.AccountNo = accountCode;
            this.BalanceDAO.Save(balance);

            return accountCode;
        }

        [Transaction(TransactionPropagation.Required)]
        private string Save_SavingAccount_Organization(PFMORM00028 cledger, PFMORM00040 si, IList<PFMORM00016> saofs, PFMORM00033 balance, PFMDTO00050 companyEntity)
        {
            string accountNoFormatCode = this.CodeGenerator.GetAccountNoFormatCode(companyEntity.TransactionStatus, companyEntity.CurrencyCode);            
            string accountCode = this.CodeGenerator.GetGenerateCode(accountNoFormatCode, CXCOM00009.AccountNoCheckDigitFormula, companyEntity.CreatedUserId, companyEntity.BranchCode, new object[] { companyEntity.BranchCode, companyEntity.CurrencySymbol, companyEntity.AccountType, companyEntity.SubAccountType });

            cledger.AccountNo = accountCode;
            this.CledgerDAO.Save(cledger);

            foreach (PFMORM00016 saof in saofs)
            {
                saof.CledgerAccountNo = accountCode;
                this.SAOFDAO.Save(saof);

                this.CustomerIdDAO.UpdateOpenAccount(saof.Customer_Id, companyEntity.CreatedUserId);
            }

            si.AccountNo = accountCode;
            this.SavingInterestDAO.Save(si);

            balance.AccountNo = accountCode;
            this.BalanceDAO.Save(balance);

            return accountCode;
        }

        [Transaction(TransactionPropagation.Required)]
        private string Save_FixedAccount_Company(PFMORM00023 fledger, IList<PFMORM00021> faofs, PFMDTO00032 freceipt, PFMORM00033 balance, PFMDTO00050 companyEntity)
        {
            string accountNoFormatCode = this.CodeGenerator.GetAccountNoFormatCode(companyEntity.TransactionStatus, companyEntity.CurrencyCode);            
            string accountCode = this.CodeGenerator.GetGenerateCode(accountNoFormatCode, CXCOM00009.AccountNoCheckDigitFormula, companyEntity.CreatedUserId, companyEntity.BranchCode, new object[] { companyEntity.BranchCode, companyEntity.CurrencySymbol, companyEntity.AccountType, companyEntity.SubAccountType });

            fledger.AccountNo = accountCode;
            this.FLedgerDAO.Save(fledger);

            foreach (PFMORM00021 faof in faofs)
            {
                faof.FledgerAccountNo = accountCode;
                this.FAOFDAO.Save(faof);
                this.CustomerIdDAO.UpdateOpenAccount(faof.CustomerId, companyEntity.CreatedUserId);
            }

            freceipt.AccountNo = accountCode;
            freceipt.AccountSign = companyEntity.AccountSignature;
            freceipt.SourceBranchCode = companyEntity.BranchCode;
            freceipt.CurrencyCode = companyEntity.CurrencyCode;
            
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
            balance.Budget = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode); 
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
            savingInterest.Budget = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode); 
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

            PFMORM00016 companyInfo = new PFMORM00016();
            companyInfo.Name = entity.NameOfFirm;
            companyInfo.PhoneNo = entity.Phone;
            companyInfo.Fax = entity.Fax;
            companyInfo.Address = entity.Address;
            companyInfo.Email = entity.Email;
            companyInfo.NoOfPersonSign = entity.NoOfPersonSign;
            companyInfo.AccountSign = entity.AccountSignature;
            companyInfo.OPENDATE = DateTime.Now;
            companyInfo.USERNO = entity.CreatedUserId.ToString();
            companyInfo.Township_Code = entity.TownshipCode;
            companyInfo.State_Code = entity.StateCode;
            companyInfo.City_Code = entity.CityCode;
            companyInfo.SourceBranchCode = entity.BranchCode;
            companyInfo.CurrencyCode = entity.CurrencyCode;

            if (companyInfo.Name != string.Empty)
                companyInfo.SerialofCustomer = 0;
            companyInfo.Active = true;
            companyInfo.CreatedUserId = entity.CreatedUserId;
            companyInfo.CreatedDate = DateTime.Now;

            saofs.Add(companyInfo);

            for (int i = 1; i <= entity.CustomerIds.Count; i++)
            {
                PFMORM00016 saof = new PFMORM00016();

                saof.NoOfPersonSign = entity.NoOfPersonSign;
                saof.AccountSign = entity.AccountSignature;
                saof.OPENDATE = DateTime.Now;
                saof.USERNO = entity.CreatedUserId.ToString();
                saof.Customer_Id = entity.CustomerIds[i-1];
                saof.SerialofCustomer = i;
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

            PFMORM00017 companyInfo = new PFMORM00017();
            companyInfo.Name = entity.NameOfFirm;
            companyInfo.PhoneNo = entity.Phone;
            companyInfo.Fax = entity.Fax;
            companyInfo.Address = entity.Address;
            companyInfo.Email = entity.Email;
            companyInfo.NoOfPersonSign = entity.NoOfPersonSign;
            companyInfo.AccountSign = entity.AccountSignature;
            companyInfo.OPENDATE = DateTime.Now;
            companyInfo.USERNO = entity.CreatedUserId.ToString();
            companyInfo.Township_Code = entity.TownshipCode;
            companyInfo.State_Code = entity.StateCode;
            companyInfo.City_Code = entity.CityCode;
            companyInfo.Business = entity.Business;
            companyInfo.SourceBranchCode = entity.BranchCode;
            companyInfo.CurrencyCode = entity.CurrencyCode;

            //Added by HWKO (15-Aug-2017)
            companyInfo.CpnyRegNo = entity.CpnyRegNo;
            companyInfo.CpnyRegDate = entity.CpnyRegDate;
            companyInfo.CpnyRegExpDate = entity.CpnyRegExpDate;
            //End Region

            if (companyInfo.Name != string.Empty)
                companyInfo.SerialofCustomer = 0;
            companyInfo.Active = true;
            companyInfo.CreatedUserId = entity.CreatedUserId;
            companyInfo.CreatedDate = DateTime.Now;

            caofs.Add(companyInfo);

            for (int i = 1; i <= entity.CustomerIds.Count; i++)
            {
                PFMORM00017 caof = new PFMORM00017();

                caof.NoOfPersonSign = entity.NoOfPersonSign;
                caof.AccountSign = entity.AccountSignature;
                caof.OPENDATE = DateTime.Now;
                caof.USERNO = entity.CreatedUserId.ToString();
                caof.CustomerID = entity.CustomerIds[i-1];
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

            PFMORM00021 companyInfo = new PFMORM00021();
            companyInfo.Name = entity.NameOfFirm;
            companyInfo.Phone = entity.Phone;
            companyInfo.Fax = entity.Fax;
            companyInfo.Address = entity.Address;
            companyInfo.Email = entity.Email;
            companyInfo.LastReceiptNo = entity.FReceipt.ReceiptNo;  // Receipt No. for Firm
            companyInfo.NoOfPersonSign = entity.NoOfPersonSign;
            companyInfo.AccountSignature = entity.AccountSignature;
            companyInfo.OpenDate = DateTime.Now;
            companyInfo.UserNo = entity.CreatedUserId.ToString();
            companyInfo.Township_Code = entity.TownshipCode;
            companyInfo.State_Code = entity.StateCode;
            companyInfo.City_Code = entity.CityCode;
            companyInfo.SourceBranchCode = entity.BranchCode;
            companyInfo.CurrencyCode = entity.CurrencyCode;
            companyInfo.Active = true;
            companyInfo.CreatedUserId = entity.CreatedUserId;
            companyInfo.CreatedDate = DateTime.Now;

            faofs.Add(companyInfo);

            for (int i = 1; i <= entity.CustomerIds.Count; i++)
            {
                PFMORM00021 faof = new PFMORM00021();

                faof.NoOfPersonSign = entity.NoOfPersonSign;
                faof.AccountSignature = companyInfo.AccountSignature;
                faof.OpenDate = DateTime.Now;
                faof.UserNo = entity.CreatedUserId.ToString();
                faof.CustomerId = entity.CustomerIds[i-1];
                faof.SerialOfCustomer = i;
                faof.SourceBranchCode = entity.BranchCode;
                faof.CurrencyCode = entity.CurrencyCode;
                faof.Active = true;
                faof.CreatedUserId = entity.CreatedUserId;
                faof.CreatedDate = DateTime.Now;

                faof.LastReceiptNo = entity.FReceipt.ReceiptNo; //Receipt No. for Each Customer
                
                faofs.Add(faof);
            }

            return faofs;
        }

        #endregion
    }
}