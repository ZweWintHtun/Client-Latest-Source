using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tcm.Ctr.Dao;
using Ace.Windows.Admin.Contracts.Dao;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Tcm.Sve
{
    public class TCMSVE00006 : BaseService,ITCMSVE00006
    {
        #region Dao Properties

        public IChargeOfAccountDAO CoaDAO { get; set; }
        public ICXSVE00006 CodeChecker { get; set; }
        public ITLMDAO00019 FixIntWithDAO { get; set; }
        public ICXSVE00002 CodeGenerator { get; set; }
        public IPFMDAO00028 CLedgerDAO { get; set; }
        public IPFMDAO00054 TLFDAO { get; set; }
        public IPFMDAO00058 FPrnDAO { get; set; }
        public IPFMDAO00043 PrnDAO { get; set; }
        public ITLMDAO00015 CashDenoDAO { get; set; }
        private IPFMDAO00032 freceiptDAO;
        public IPFMDAO00032 FReceiptDAO
        {
            get
            {
                return this.freceiptDAO;
            }
            set
            {
                this.freceiptDAO = value;
            }
        }

        #endregion

        #region Private Variables

        IList<PFMDTO00021> faofEntities;
        public PFMORM00054 TlfInfo { get; set; }
        public PFMDTO00028 CledgerDTO { get; set; }
        PFMDTO00032 fReceiptInfo;
        PFMDTO00028 cledgerInfo;
        TLMORM00015 CashDenoInfo;
        TLMORM00019 FixIntWithInfo;
        PFMORM00058 fPrnFileInfo;
        PFMORM00043 PrnFileInfo;
        string voucherNumber;

        #endregion
        
        #region Public Methods

        public PFMDTO00028 SelectByCreditAccountNumber(string accountNo, string branchCode)
        {
            // Check saving account no is already closed or not.
            if (this.CodeChecker.IsClosedAccountForCLedger(accountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return null;
            }

            // Check Freesze Account No
            if (this.CodeChecker.IsFreezeAccount(accountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return null;
            }
            
            this.CledgerDTO = this.CodeChecker.GetAccountInfoOfCledgerByAccountNo(accountNo);

            // Check Cledger
            if (this.CledgerDTO == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00175; // Account No Not Found
                return null;
            }
            else if (this.CledgerDTO.SourceBranchCode != branchCode)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00224; // Invalid Account No {0} for Branch {1}.
                return null;
            }
            CledgerDTO.Customer = this.CodeChecker.GetCustomerInfomationByCaofOrSaof(accountNo, CledgerDTO.AccountSign.Substring(0, 1))[0];

            return CledgerDTO;
        }

        public PFMDTO00021 SeletByDebitAccountNumber(string accountNo, string branchCode)
        {
            faofEntities = this.CodeChecker.GetFAOFsByAccountNumber(accountNo);
            // Check Cledger
            if (this.faofEntities == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00033; // Invalid Fixed Account No
                return null;
            }
            else if (this.faofEntities.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00033; //Invalid Fixed Account No
                return null;
            }
            else if (this.faofEntities[0].SourceBranchCode != branchCode)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00224; // Invalid Account No {0} for Branch {1}.
                return null;
            }

            PFMDTO00032 fReceiptInfo=this.FReceiptDAO.GetAccruedInterestByAccountNo(accountNo);

            if (fReceiptInfo == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV20070; // Account has no Interest.
                return null;
            }
            else if (fReceiptInfo.AccuredInterest == 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV20070; // Account has no Interest.
                return null;
            }

            faofEntities[0].AccuredInterest = fReceiptInfo.AccuredInterest;
            PFMDTO00001 customerInfo = this.CodeChecker.GetCustomerByCustomerId(faofEntities.Count > 1 ? (string.IsNullOrEmpty(faofEntities[0].CustomerId) ? faofEntities[1].CustomerId : faofEntities[0].CustomerId) : faofEntities[0].CustomerId);
            
            if (customerInfo == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00019; // Customer not found.
                return null;
            }

            faofEntities[0].Name = customerInfo.Name;
            faofEntities[0].NRC = customerInfo.NRC;

            return faofEntities[0];
        }

        [Transaction(TransactionPropagation.Required)]
        public string Withdrawl(PFMDTO00032 freceiptEntity)
        {
            try
            {
                decimal homeExchageRate = CXCOM00010.Instance.GetExchangeRate(freceiptEntity.CurrencyCode, "CS");
                string COASetupAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("FACCRUINT", freceiptEntity.SourceBranchCode, freceiptEntity.CurrencyCode);
                ChargeOfAccountDTO CoaDto = CoaDAO.SelectACode(COASetupAccount, freceiptEntity.SourceBranchCode);
                DateTime settlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), freceiptEntity.SourceBranchCode);
                string ButgetYear = CXCOM00010.Instance.GetBudgetYear1("BUDSMTH");
                voucherNumber = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, freceiptEntity.CreatedUserId, freceiptEntity.SourceBranchCode, new object[] { settlementDate.Day.ToString().PadLeft(2, '0'), settlementDate.Month.ToString().PadLeft(2, '0'), settlementDate.Year.ToString().Substring(2) });

                this.FixIntWithDAO.Save(this.GetInterestWithdrawalInfo(freceiptEntity, ButgetYear, settlementDate));
                this.FReceiptDAO.UpdateFreceiptInterestWithdraw(freceiptEntity);

                TlfInfo = this.GetTransactionLogFile(voucherNumber, COASetupAccount, false, freceiptEntity.AccuredInterest, freceiptEntity.AccuredInterest, 0, "", CoaDto.COASetUpAccountName,
                    "Accrued Int Withdraw for FD: " + freceiptEntity.AccountNo, freceiptEntity.CreatedDate, "CDV", "CSDEBIT", freceiptEntity.AccountSign, freceiptEntity.SourceBranchCode,
                    freceiptEntity.CurrencyCode, homeExchageRate, string.Empty, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel), freceiptEntity.CreatedUserId.ToString(), settlementDate);
                this.TLFDAO.Save(TlfInfo);

               // this.CashDenoDAO.Save(this.GetCashDeno(freceiptEntity,voucherNumber,settlementDate,homeExchageRate,denoInfo));
                
                this.ServiceResult.ErrorOccurred = false;
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME90043; // Unexpected Error Occur.
                throw new Exception(this.ServiceResult.MessageCode);
            }
            return voucherNumber;
        }

        [Transaction(TransactionPropagation.Required)]
        public string Transfer(PFMDTO00032 freceiptEntity, PFMDTO00028 saofEntity)
        {
            try
            {
                decimal homeExchageRate = CXCOM00010.Instance.GetExchangeRate(freceiptEntity.CurrencyCode, "TT");
                string COASetupAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("FACCRUINT", freceiptEntity.SourceBranchCode, freceiptEntity.CurrencyCode);
                ChargeOfAccountDTO CoaDto = CoaDAO.SelectACode(COASetupAccount, freceiptEntity.SourceBranchCode);
                DateTime settlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), freceiptEntity.SourceBranchCode);
                string ButgetYear = CXCOM00010.Instance.GetBudgetYear1("BUDSMTH");
                voucherNumber = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, freceiptEntity.CreatedUserId, freceiptEntity.SourceBranchCode, new object[] { settlementDate.Day.ToString().PadLeft(2, '0'), settlementDate.Month.ToString().PadLeft(2, '0'), settlementDate.Year.ToString().Substring(2) });
                
                this.FixIntWithDAO.Save(this.GetInterestWithdrawalInfo(freceiptEntity, ButgetYear, settlementDate));
                this.FReceiptDAO.UpdateFreceiptInterestWithdraw(freceiptEntity);

                TlfInfo = this.GetTransactionLogFile(voucherNumber, COASetupAccount, false, freceiptEntity.AccuredInterest, freceiptEntity.AccuredInterest, 0, "", CoaDto.COASetUpAccountName,
                    "Accrued Int Withdrawal for: " + freceiptEntity.CreditAccountNo, freceiptEntity.CreatedDate, "TDV", "TRDEBIT", freceiptEntity.AccountSign, freceiptEntity.SourceBranchCode, freceiptEntity.CurrencyCode, homeExchageRate, string.Empty, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel), freceiptEntity.CreatedUserId.ToString(), settlementDate);
                this.TLFDAO.Save(TlfInfo);

                TlfInfo = this.GetTransactionLogFile(voucherNumber, freceiptEntity.AccountNo, false, freceiptEntity.AccuredInterest, freceiptEntity.AccuredInterest, 0, "", CoaDto.COASetUpAccountName,
                    "Accrued Int Withdrawal for: " + freceiptEntity.CreditAccountNo, freceiptEntity.CreatedDate, "TCV", "TRCREDIT", saofEntity.AccountSign, freceiptEntity.SourceBranchCode, freceiptEntity.CurrencyCode, homeExchageRate, string.Empty, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel), freceiptEntity.CreatedUserId.ToString(), settlementDate);
                this.TLFDAO.Save(TlfInfo);

                cledgerInfo = this.CodeChecker.GetAccountInfoOfCledgerByAccountNo(freceiptEntity.CreditAccountNo);
                CLedgerDAO.UpdateCurrentBalance(freceiptEntity.CreditAccountNo, cledgerInfo.CurrentBal + freceiptEntity.AccuredInterest, ++cledgerInfo.TransactionCount, freceiptEntity.CreatedUserId, freceiptEntity.CreatedUserId.ToString());

                fReceiptInfo = this.FReceiptDAO.GetFirstReceiptNoByAccountNo(freceiptEntity.AccountNo);

                PrnDAO.Save(this.GetPrintFile(freceiptEntity.CreditAccountNo, freceiptEntity.CreatedUserId, freceiptEntity.AccuredInterest, cledgerInfo.CurrentBal + freceiptEntity.AccuredInterest, freceiptEntity.CurrencyCode, freceiptEntity.SourceBranchCode, "INT"));
                FPrnDAO.Save(this.GetFixedPrintFile(freceiptEntity.AccountNo, fReceiptInfo.ReceiptNo, freceiptEntity.CreatedUserId, freceiptEntity.AccuredInterest, freceiptEntity.CurrencyCode, freceiptEntity.SourceBranchCode));                
                
                this.ServiceResult.ErrorOccurred = false;
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME90043; // Unexpected Error Occur.
                throw new Exception(this.ServiceResult.MessageCode);
            }
            return voucherNumber;
        }

        #endregion

        #region Helper Methods

        private TLMORM00019 GetInterestWithdrawalInfo(PFMDTO00032 entity, string butgetYear,DateTime settlementDate)
        {
            FixIntWithInfo = new TLMORM00019();
            FixIntWithInfo.AccountNo = entity.AccountNo;
            FixIntWithInfo.Amount = entity.AccuredInterest;
            FixIntWithInfo.Budget = butgetYear;
            FixIntWithInfo.SourceBranchCode = entity.SourceBranchCode;
            FixIntWithInfo.Currency = entity.CurrencyCode;
            FixIntWithInfo.Date_Time = DateTime.Now;
            FixIntWithInfo.UserNo = entity.CreatedUserId.ToString();
            FixIntWithInfo.Active = true;
            FixIntWithInfo.CreatedDate = DateTime.Now;
            FixIntWithInfo.CreatedUserId = entity.CreatedUserId;
            FixIntWithInfo.SettlementDate = settlementDate;

            return FixIntWithInfo;
        }

        private PFMORM00054 GetTransactionLogFile(string voucherNo, string accountNo, bool isSameACodeandAccountNo, decimal amount, decimal netAmount, decimal overdraftAmount, string chequeNo,
          string description, string narration, DateTime date_Time, string status, string transactionCode, string accountSignature, string branchCode, string currencyCode,
          decimal homeRate, string referenceType, string channel, string userNo, DateTime nextSettlementDate)
        {
            PFMORM00054 tlf = new PFMORM00054();
            tlf.Id = this.TLFDAO.SelectMaxId() + 1;
            tlf.Eno = voucherNo;

            if (isSameACodeandAccountNo == false && accountSignature.Length > 0 && accountNo.Length > 6)
            {
                switch (accountSignature[0])
                {
                    case 'C':
                        tlf.Acode = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurControl), branchCode, currencyCode);
                        break;

                    case 'S':
                        tlf.Acode = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavControl), branchCode, currencyCode);
                        break;

                    case 'L':
                        tlf.Acode = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CalControl), branchCode, currencyCode);
                        break;

                    case 'F':
                        tlf.Acode = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixControl), branchCode, currencyCode);
                        break;
                }
            }
            else
            {
                tlf.Acode = accountNo;
            }

            tlf.AccountNo = accountNo;

            tlf.SettlementDate = nextSettlementDate;
            tlf.Amount = amount;
            tlf.HomeAmount = amount * homeRate;
            tlf.HomeAmt = netAmount * homeRate;
            tlf.HomeOAmt = overdraftAmount * homeRate;
            tlf.LocalAmount = amount;
            tlf.LocalAmt = netAmount;
            tlf.LocalOAmt = overdraftAmount;
            tlf.Description = description;
            tlf.Narration = narration;
            tlf.Cheque = chequeNo;
            tlf.DateTime = date_Time;
            tlf.Status = status;
            tlf.TransactionCode = transactionCode;
            tlf.AccountSign = accountSignature;
            tlf.UserNo = userNo;
            tlf.SourceCurrency = currencyCode;
            tlf.Rate = homeRate;
            tlf.SourceBranchCode = branchCode;
            tlf.Channel = channel;
            tlf.ReferenceType = referenceType == string.Empty ? null : referenceType;
            tlf.CreatedUserId = Convert.ToInt32(userNo);
            return tlf;
        }

        private PFMORM00043 GetPrintFile(string accountNo, int userId, decimal creditAmount, decimal currentBalance, string currency, string branchCode, string reference)
        {
            PrnFileInfo = new PFMORM00043();
            PrnFileInfo.AccountNo = accountNo;
            PrnFileInfo.UserNo = userId.ToString();
            PrnFileInfo.Active = true;
            PrnFileInfo.Reference = reference;
            PrnFileInfo.Credit = creditAmount;
            PrnFileInfo.Debit = 0;
            PrnFileInfo.SourceBranchCode = branchCode;
            PrnFileInfo.Balance = currentBalance + creditAmount;
            PrnFileInfo.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
            PrnFileInfo.CreatedDate = DateTime.Now;
            PrnFileInfo.CreatedUserId = userId;
            PrnFileInfo.CurrencyCode = currency;

            return PrnFileInfo;
        }

        private TLMORM00015 GetCashDeno(PFMDTO00032 info, string voucherNo, DateTime nextSettlementDate, decimal homeExchangeRate, CXDTO00001 denoInfo)
        {
            CashDenoInfo = new TLMORM00015();
            CashDenoInfo.TlfEntryNo = voucherNo;
            CashDenoInfo.Amount = info.AccuredInterest;
            CashDenoInfo.AdjustAmount = denoInfo.AdjustAmount;
            CashDenoInfo.CashDate = System.DateTime.Now;
            CashDenoInfo.DenoDetail = denoInfo.DenoString;
            CashDenoInfo.DenoRefundDetail = denoInfo.RefundString;
            CashDenoInfo.DenoRate = denoInfo.DenoRateString;
            CashDenoInfo.DenoRefundRate = denoInfo.RefundRateString;
            CashDenoInfo.Status = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);
            CashDenoInfo.Reverse = false;
            CashDenoInfo.CreatedDate = System.DateTime.Now;
            CashDenoInfo.CreatedUserId = info.CreatedUserId;
            CashDenoInfo.CounterNo = denoInfo.CounterNo;
            CashDenoInfo.Currency = info.CurrencyCode;
            CashDenoInfo.AllDenoRate = denoInfo.DenoRateString;
            CashDenoInfo.Rate = homeExchangeRate;
            CashDenoInfo.UserNo = info.CreatedUserId.ToString();
            CashDenoInfo.SettlementDate = nextSettlementDate;

            return CashDenoInfo;
        }

        private PFMORM00058 GetFixedPrintFile(string accountNo, string receiptNo, int userId, decimal debitAmount, string currency, string branchCode)
        {
            fPrnFileInfo = new PFMORM00058();
            fPrnFileInfo.AccountNo = accountNo;
            fPrnFileInfo.AccessDate = DateTime.Now;
            fPrnFileInfo.AccessUser = userId.ToString();
            fPrnFileInfo.Reference = receiptNo;
            fPrnFileInfo.Active = true;
            fPrnFileInfo.Credit = 0;
            fPrnFileInfo.Debit = debitAmount;
            fPrnFileInfo.Balance = 0;
            fPrnFileInfo.SourceBr = branchCode;
            fPrnFileInfo.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
            fPrnFileInfo.CreatedDate = DateTime.Now;
            fPrnFileInfo.CreatedUserId = userId;
            fPrnFileInfo.CurrencyId = currency;

            return fPrnFileInfo;
        }

        #endregion

    }
}
