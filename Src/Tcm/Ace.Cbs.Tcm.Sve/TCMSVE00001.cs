using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using AutoMapper;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Tcm.Sve
{
    /// <summary>
    /// Fixed Deposit Transfer Service 
    /// </summary>
    public class TCMSVE00001 : BaseService, ITCMSVE00001
    {
        #region Dao Properties

        public ICXSVE00006 CodeChecker { get; set; }
        public IPFMDAO00020 UseChequeDAO { get; set; }
        public ICXSVE00002 CodeGenerator { get; set; }
        public IPFMDAO00028 CLedgerDAO { get; set; }
        public IPFMDAO00054 TLFDAO { get; set; }
        public IPFMDAO00058 FPrnDAO { get; set; }
        public IPFMDAO00043 PrnDAO { get; set; }

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

        private IPFMDAO00023 fledgerDAO;
        public IPFMDAO00023 FledgerDAO
        {
            get
            {
                return this.fledgerDAO;
            }
            set
            {
                this.fledgerDAO = value;
            }
        }

        #endregion

        #region Private Variables

        private int SerialCount = 4;
        private int tlfId = 0;
        IList<PFMDTO00021> faofEntities;
        public PFMORM00054 debitTransactionLog { get; set; }
        public PFMDTO00028 CledgerDTO { get; set; }
        public PFMORM00054 creditTransactionLog { get; set; }
        PFMORM00032 result;
        PFMDTO00028 cledgerInfo;
        PFMORM00020 chequeInfo;
        PFMORM00058 fPrnFileInfo;
        PFMORM00043 PrnFileInfo;
        string voucherNumber;
        DateTime settlementDate;

        #endregion

        #region Public Methods

        public PFMDTO00028 SelectByAccountNumber(string accountNo,string branchCode,DateTime todaydate)
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

            // Check LegalCase Account No
            if (this.CodeChecker.HasLegalCaseAccount(accountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return null;
            }

            // Check NPLCase Account No
            if (this.CodeChecker.HasNPLCaseAccount(accountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return null;
            }

            // Check ExpiredLoans Account No
            if (this.CodeChecker.IsExpiredLoansAccount(accountNo, todaydate))
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
            CledgerDTO.Customer = this.CodeChecker.GetCustomerInfomationByCaofOrSaof(accountNo, CledgerDTO.AccountSign.Substring(0,1))[0];

            return CledgerDTO;
        }

        [Transaction(TransactionPropagation.Required)]
        public string Save(PFMDTO00032 freceiptentity)
        {
            try
            {
                result = Mapper.Map<PFMDTO00032, PFMORM00032>(freceiptentity);
                faofEntities = CXServiceWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00021>>(x => x.GetCustomerInfoandFAOFInfoByAccountNo(freceiptentity.CreditAccountNo));

                if (!this.Cheking(faofEntities, freceiptentity))
                    return null;
                else
                {
                    result.AccountSign = faofEntities[0].AccountSignature;
                    result.CurrencyCode = faofEntities[0].CurrencyCode;
                    result.AccountNo = freceiptentity.CreditAccountNo;
                }

                if (freceiptentity.AutoRenewal == true && (!this.CheckExistAccountNoForCurrentAndSaving(result.ToAccountNo, result.CurrencyCode,result.SourceBranchCode)))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = this.ServiceResult.MessageCode;
                    return null;
                }
                string receiptNo = GenerateReceiptNoByAccountNo(result);
                if (string.IsNullOrEmpty(receiptNo))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00085; // Receipt No for this Account is already reached it's maximum limit.
                    return null;
                }
                else
                {
                    settlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), freceiptentity.SourceBranchCode);
                    voucherNumber = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, freceiptentity.CreatedUserId, freceiptentity.SourceBranchCode, new object[] { settlementDate.Day.ToString().PadLeft(2, '0'), settlementDate.Month.ToString().PadLeft(2, '0'), settlementDate.Year.ToString().Substring(2) });
                    //voucherNumber = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, freceiptentity.CreatedUserId, CurrentUserEntity.BranchCode, new object[] { settlementDate.Day.ToString().PadLeft(2, '0'), settlementDate.Month.ToString().PadLeft(2, '0'), settlementDate.Year.ToString().Substring(2) });
                    cledgerInfo = this.CodeChecker.GetAccountInfoOfCledgerByAccountNo(freceiptentity.AccountNo);

                    result.ReceiptNo = receiptNo;
                    result.FirstReceiptNo = receiptNo;
                    result.Active = true;
                    result.CreatedDate = DateTime.Now;
                    
                    this.freceiptDAO.Save(result);
                    FPrnDAO.Save(this.GetFixedPrintFile(freceiptentity.CreditAccountNo, result.ReceiptNo, freceiptentity.CreatedUserId, freceiptentity.Amount, freceiptentity.CurrencyCode, freceiptentity.SourceBranchCode));

                    this.FledgerDAO.UpdateFBalOfFLedgerForDeposit(freceiptentity.CreditAccountNo, freceiptentity.Amount, freceiptentity.CreatedUserId, DateTime.Now);

                    PrnDAO.Save(this.GetPrintFile(freceiptentity.AccountNo, freceiptentity.CreatedUserId, freceiptentity.Amount, cledgerInfo.CurrentBal, freceiptentity.CurrencyCode, freceiptentity.SourceBranchCode));

                    if(freceiptentity.AccountSign.Substring(0,1)==CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurrentAccountSign))
                        this.UseChequeDAO.Save(this.GetChequeEntity(freceiptentity));

                    if (!this.CLedgerDAO.UpdateCurrentBalance(freceiptentity.AccountNo, cledgerInfo.CurrentBal - freceiptentity.Amount, ++cledgerInfo.TransactionCount, freceiptentity.CreatedUserId, freceiptentity.CreatedUserId.ToString()))
                    {
                        // Update Error
                        throw new Exception(CXMessage.ME90001);
                    }

                      debitTransactionLog = this.GetTransactionLogFile(voucherNumber, freceiptentity.AccountNo, false, freceiptentity.Amount, freceiptentity.Amount, 0, "", "",
                  "" + "Fixed Next Receipt By Transfer", DateTime.Now, "TDV", "TRDEBIT", cledgerInfo.AccountSign, freceiptentity.SourceBranchCode, freceiptentity.CurrencyCode, 1, "", CXCOM00009.Channel, freceiptentity.CreatedUserId.ToString(), settlementDate);
                    this.TLFDAO.Save(debitTransactionLog);

                    creditTransactionLog = this.GetTransactionLogFile(voucherNumber, freceiptentity.CreditAccountNo, false, freceiptentity.Amount, freceiptentity.Amount, 0, "", "",
                "" + "Fixed Next Receipt By Transfer", DateTime.Now, "TCV", "TRCREDIT", faofEntities[0].AccountSignature, freceiptentity.SourceBranchCode, freceiptentity.CurrencyCode, 1, "", CXCOM00009.Channel, freceiptentity.CreatedUserId.ToString(), settlementDate);
                    this.TLFDAO.Save(creditTransactionLog);

                    this.ServiceResult.ErrorOccurred = false;
                }
            }
            catch(Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                if (ex.Message == "ME90001")
                    this.ServiceResult.MessageCode = CXMessage.ME90001;
                else
                    this.ServiceResult.MessageCode = CXMessage.ME90043; // Unexpected Error Occur.
                throw new Exception(this.ServiceResult.MessageCode);
            }

            return result.ReceiptNo;
        }
        

        #endregion

        #region Private Methods

        private bool Cheking(IList<PFMDTO00021> faofEntities, PFMDTO00032 freceiptentity)
        {
            if (this.ServiceResult.ErrorOccurred)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00033; //Invalid Fixed Account No.
                return false;
            }
            else if (faofEntities==null || faofEntities.Count==0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00033; //Invalid Fixed Account No.
                return false;
            }
            else if (faofEntities[0].SourceBranchCode != freceiptentity.SourceBranchCode)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00224; //Invalid Account No {0} for Branch {1}.
                return false;
            }
            else if (faofEntities[0].CurrencyCode != freceiptentity.CurrencyCode)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00086; //Currency of this account should be {0}.
                return false;
            }
            else if (!string.IsNullOrEmpty(freceiptentity.ChequeNo) && this.CodeChecker.IsVaildChequeNoforWithdrawal(freceiptentity.AccountNo, freceiptentity.ChequeNo, freceiptentity.SourceBranchCode))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return false;
            }
            return true;
        }

        private bool DebitInformationCheckingAndLink(PFMDTO00032 entity)
        {
            string messageNo = string.Empty;
            bool isLink = false;

            if (!entity.ChequeNo.Equals(string.Empty) && this.CodeChecker.IsVaildChequeNoforWithdrawal(entity.AccountNo, entity.ChequeNo, entity.SourceBranchCode))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return false;
            }

            //Check Amount
            if (!this.CodeChecker.CheckAmount(entity.AccountNo, entity.Amount, true, false, true, ref isLink, ref messageNo))
            {
                string _m = messageNo;
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = messageNo;
                return false;
            }

            return true;
        }

        private bool CheckExistAccountNoForCurrentAndSaving(string takenAccountNo, string fixedAccountCurrencyCode,string sourceBranch)
        {
            if (String.IsNullOrEmpty(takenAccountNo))
            {
                return true;
            }
            // Check saving account no is already closed or not.
            if (this.CodeChecker.IsClosedAccountForCLedger(takenAccountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return false;
            }

            List<PFMDTO00016> saofEntities = (List<PFMDTO00016>)CXServiceWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00016>>(x => x.GetSAOFsByAccountNumber(takenAccountNo));

            if (saofEntities.Count > 0)
            {
                //if (saofEntities[0].SourceBranchCode != CurrentUserEntity.BranchCode)
                if (saofEntities[0].SourceBranchCode !=sourceBranch)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00224; //Invalid Account No {0} for Branch {1}.
                    return false;
                }

                if (saofEntities[0].CurrencyCode == fixedAccountCurrencyCode)
                    return true;
                else
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00080; //Currency of Fixed Account and Interest Taken Account should be same.
                    return false;
                }
            }
            else
            {
                List<PFMDTO00017> caofEntities = (List<PFMDTO00017>)CXServiceWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00017>>(x => x.GetCAOFsByAccountNumber(takenAccountNo));

                if (caofEntities.Count == 0)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00036; //Invalid Interest Taken Account No
                    return false;
                }

                //else if (caofEntities[0].SourceBranchCode != CurrentUserEntity.BranchCode)
                else if (caofEntities[0].SourceBranchCode != sourceBranch)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00224; //Invalid Account No {0} for Branch {1}.
                    return false;
                }

                if (caofEntities[0].CurrencyCode != fixedAccountCurrencyCode)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00080; //Currency of Fixed Account and Interest Taken Account should be same.
                    return false;
                }
            }
            return true;
        }
        
        private string GenerateReceiptNoByAccountNo(PFMORM00032 fReceiptEntity)
        {
            string receiptNo = string.Empty;

            string prefixCode = GetPrefixCode(Convert.ToInt32(Convert.ToInt32(fReceiptEntity.Duration)));

            if (String.IsNullOrEmpty(fReceiptEntity.AccountNo))
            {
                receiptNo = GetGenerateNumber(prefixCode, 0);
            }

            List<PFMDTO00032> fReceipts = (List<PFMDTO00032>)this.freceiptDAO.GetFixedReceiptByAccountNo(fReceiptEntity.AccountNo, fReceiptEntity.Duration);

            if (fReceipts.Count > 0)
            {
                string generateCode = fReceipts.OrderBy(a => a.ReceiptNo).LastOrDefault<PFMDTO00032>().ReceiptNo;

                int currentSerialNo = Convert.ToInt32(generateCode.Substring(generateCode.Length - SerialCount, SerialCount));

                receiptNo = GetGenerateNumber(prefixCode, currentSerialNo);
            }
            else
            {
                receiptNo = GetGenerateNumber(prefixCode, 0);
            }

            return receiptNo;
        }

        private string GetPrefixCode(int duration)
        {
            string prefixCode = string.Empty;

            if (duration < 1)
            {
                duration *= 4;
                prefixCode = duration.ToString() + 'W';
            }
            else if (duration >= 1 && duration < 12)
            {
                prefixCode = duration.ToString() + 'M';
            }
            else if (duration >= 12)
            {
                duration = duration / 12;
                prefixCode = duration.ToString() + 'Y';
            }

            return prefixCode;
        }

        private string GetGenerateNumber(string prefixCode, int currentSerialNo)
        {
            int serialNo = currentSerialNo + 1;

            string ReceiptNoMaximunValue = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiptNoMaximumValue);

            if (serialNo > Convert.ToInt32(ReceiptNoMaximunValue))
                return null;
            else
                return prefixCode + serialNo.ToString().PadLeft(SerialCount, '0');
        }

        private PFMDTO00023 GetAccountSignAndCurByAccountNo(string accountNo)
        {
            return fledgerDAO.SelectACSignAndCurByAccountNo(accountNo);
        }

        private PFMORM00020 GetChequeEntity(PFMDTO00032 entity)
        {
            chequeInfo = new PFMORM00020();
            chequeInfo.AccountNo = entity.AccountNo;
            chequeInfo.AccountSignature = entity.AccountSign;
            chequeInfo.Active = true;
            chequeInfo.SourceBranchCode = entity.SourceBranchCode;
            chequeInfo.ChequeNo = entity.ChequeNo;
            chequeInfo.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
            chequeInfo.DATE_TIME = DateTime.Now;
            chequeInfo.CreatedDate = DateTime.Now;
            chequeInfo.CreatedUserId = entity.CreatedUserId;

            return chequeInfo;
        }

        private PFMORM00054 GetTransactionLogFile(string voucherNo, string accountNo, bool isSameACodeandAccountNo, decimal amount, decimal netAmount, decimal overdraftAmount, string chequeNo,
           string description, string narration, DateTime date_Time, string status, string transactionCode, string accountSignature, string branchCode, string currencyCode,
           decimal homeRate, string referenceType, string channel, string userNo, DateTime nextSettlementDate)
        {
            PFMORM00054 tlf = new PFMORM00054();
            tlf.Id = this.TLFDAO.SelectMaxId()+1;
            tlf.Eno = voucherNo;

            if (isSameACodeandAccountNo == false && accountSignature.Length > 0)
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
            tlf.ReferenceType = referenceType;

            return tlf;
        }

        private PFMORM00043 GetPrintFile(string accountNo, int userId, decimal debitAmount,decimal currentBalance,string currency, string branchCode)
        {
            PrnFileInfo = new PFMORM00043();
            PrnFileInfo.AccountNo = accountNo;            
            PrnFileInfo.Active = true;
            PrnFileInfo.Credit = 0;
            PrnFileInfo.Debit = debitAmount;
            PrnFileInfo.Reference = "TRW";
            PrnFileInfo.SourceBranchCode = branchCode;
            PrnFileInfo.Balance = currentBalance - debitAmount;
            PrnFileInfo.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
            PrnFileInfo.CreatedDate = DateTime.Now;
            PrnFileInfo.CreatedUserId = userId;
            PrnFileInfo.CurrencyCode = currency;

            return PrnFileInfo;
        }

        private PFMORM00058 GetFixedPrintFile(string accountNo, string receiptNo, int userId, decimal creditAmount, string currency, string branchCode)
        {
            fPrnFileInfo = new PFMORM00058();
            fPrnFileInfo.AccountNo = accountNo;
            fPrnFileInfo.AccessDate = DateTime.Now;
            fPrnFileInfo.AccessUser = userId.ToString();
            fPrnFileInfo.Reference = receiptNo;
            fPrnFileInfo.Active = true;
            fPrnFileInfo.Credit = creditAmount;
            fPrnFileInfo.Debit = 0;
            fPrnFileInfo.Balance = creditAmount + this.CodeChecker.GetAccountInfoOfFledgerByAccountNo(accountNo).FixedBalance;
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