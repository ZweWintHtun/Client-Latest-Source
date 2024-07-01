using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tcm.Ctr.Dao;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Admin.Contracts.Dao;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Tcm.Sve
{
    public class TCMSVE00005 : BaseService , ITCMSVE00005
    {
        #region Properties DAO

        public ICXSVE00002 CodeGenerator { get; set; }
        public IChargeOfAccountDAO CoaDAO { get; set; }
        public ICXSVE00006 CodeChecker { get; set; }
        public IPFMDAO00040 SIDAO { get; set; }
        public ITCMDAO00006 SIaccWitDAO { get; set; }
        public IPFMDAO00054 TLFDAO { get; set; }
        public IPFMDAO00043 PrnDAO { get; set; }
        public IPFMDAO00028 CledgerDAO { get; set; }
        public ITLMDAO00015 CashDenoDAO { get; set; }

        public TCMORM00006 SIAccWitInfo;
        public PFMORM00054 TlfInfo;
        public PFMORM00043 PrnFileInfo;
        PFMDTO00028 cledgerInfo;
        TLMORM00015 CashDenoInfo;
        string VoucherNo;
        #endregion

        #region Main Methods

        public PFMDTO00016 SelectByAccountNumber(string accountNo,string sourceBranch,DateTime todaydate)
        {
            IList<PFMDTO00016> saofEntities = null;
            PFMDTO00040 SIInfo;            
            //Checking different branch account no or not
            saofEntities = (List<PFMDTO00016>)CXServiceWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00016>>(x => x.GetSAOFsByAccountNumber(accountNo));

            if (saofEntities == null || saofEntities.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00051;//Invalid Saving Account No.
                return null;
            }
            //else if (saofEntities[0].SourceBranchCode != CurrentUserEntity.BranchCode)
            else if (saofEntities[0].SourceBranchCode != sourceBranch)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00091;//Invalid Account No. for Branch {0}.
                return null;
            }
            // Check saving account no is already closed or not.
            else if (this.CodeChecker.IsClosedAccountForCLedger(accountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return null;
            }

            // Check Freesze Account No
            else if (this.CodeChecker.IsFreezeAccount(accountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return null;
            }

            // Check LegalCase Account No
            else if (this.CodeChecker.HasLegalCaseAccount(accountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return null;
            }

            // Check NPLCase Account No
            else if (this.CodeChecker.HasNPLCaseAccount(accountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return null;
            }

            // Check ExpiredLoans Account No
            else if (this.CodeChecker.IsExpiredLoansAccount(accountNo,todaydate))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return null;
            }
            
            SIInfo = SIDAO.SelectInterestByAccountNo(accountNo);
            if (SIInfo == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MC00001; // Account has no interest.
                return null;
            }
            else if (SIInfo.AccruedInt.Value == 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV20070; // Account has no interest.
                return null;
            }
            else
                saofEntities[0].AccruedInterest = SIInfo.AccruedInt.Value;
            return saofEntities[0];
        }

        [Transaction(TransactionPropagation.Required)]
        public string Withdrawal(PFMDTO00016 entity)
        {
            try
            {
                decimal homeExchageRate = CXCOM00010.Instance.GetExchangeRate(entity.CurrencyCode, "CS");
                string COASetupAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("ACCRUEDINT", entity.SourceBranchCode, entity.CurrencyCode);
                ChargeOfAccountDTO CoaDto = CoaDAO.SelectACode(COASetupAccount, entity.SourceBranchCode);
                if (CoaDto == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV20035; // Account Code not found in file.
                    return null;
                }
                
                DateTime settlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), entity.SourceBranchCode);
                string ButgetYear = CXCOM00010.Instance.GetBudgetYear1("BUDSMTH");
                VoucherNo = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, entity.CreatedUserId, entity.SourceBranchCode, new object[] { settlementDate.Day.ToString().PadLeft(2, '0'), settlementDate.Month.ToString().PadLeft(2, '0'), settlementDate.Year.ToString().Substring(2) });
                cledgerInfo = this.CodeChecker.GetAccountInfoOfCledgerByAccountNo(entity.AccountNo);

                this.SIaccWitDAO.Save(this.GetSavingInterestWithdrawalInfo(entity, ButgetYear));
                this.SIDAO.UpdateAccruedIntTo0ByAccountNo(entity.CreatedUserId, entity.AccountNo);
                //this.CashDenoDAO.Save(this.GetCashDeno(entity, VoucherNo, settlementDate, homeExchageRate));

                TlfInfo = this.GetTransactionLogFile(VoucherNo, COASetupAccount, false, entity.AccruedInterest, entity.AccruedInterest, 0, "", CoaDto.COASetUpAccountName,
                    "Int Withdrawal for :" + entity.AccountNo, entity.CreatedDate, "CDV", "ACCINTCSDR", entity.AccountSign, entity.SourceBranchCode,
                    entity.CurrencyCode, homeExchageRate, "", CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel),
                    entity.CreatedUserId.ToString(), settlementDate);
               
                this.TLFDAO.Save(TlfInfo);

                PrnDAO.Save(this.GetPrintFile(entity.AccountNo, entity.CreatedUserId, entity.AccruedInterest, cledgerInfo.CurrentBal, entity.CurrencyCode, entity.SourceBranchCode, "CHW",entity.CreatedDate));
                this.ServiceResult.ErrorOccurred = false;
            }
            catch(Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME90043; // Unexpected Error Occur.
                throw new Exception(this.ServiceResult.MessageCode);
            }
            return VoucherNo;
        }

        [Transaction(TransactionPropagation.Required)]
        public string Transfer(PFMDTO00016 entity)
        {
            try
            {
                decimal homeExchageRate = CXCOM00010.Instance.GetExchangeRate(entity.CurrencyCode, "TT");
                string COASetupAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("ACCRUEDINT", entity.SourceBranchCode, entity.CurrencyCode);
                ChargeOfAccountDTO CoaDto = CoaDAO.SelectACode(COASetupAccount, entity.SourceBranchCode);
                DateTime settlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), entity.SourceBranchCode);
                string ButgetYear = CXCOM00010.Instance.GetBudgetYear1("BUDSMTH");
                VoucherNo = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, entity.CreatedUserId, entity.SourceBranchCode, new object[] { settlementDate.Day.ToString().PadLeft(2, '0'), settlementDate.Month.ToString().PadLeft(2, '0'), settlementDate.Year.ToString().Substring(2) });
                cledgerInfo = this.CodeChecker.GetAccountInfoOfCledgerByAccountNo(entity.AccountNo);

                this.SIaccWitDAO.Save(this.GetSavingInterestWithdrawalInfo(entity, ButgetYear));
                this.SIDAO.UpdateAccruedIntTo0ByAccountNo(entity.CreatedUserId, entity.AccountNo);

                TlfInfo = this.GetTransactionLogFile(VoucherNo, COASetupAccount, false, entity.AccruedInterest, entity.AccruedInterest, 0, "", CoaDto.COASetUpAccountName,
                    "Int Withdrawal for :" + entity.AccountNo, entity.CreatedDate, "TDV", "ACCINTTRDR", entity.AccountSign, entity.SourceBranchCode, entity.CurrencyCode, homeExchageRate, "", 
                    CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel), entity.CreatedUserId.ToString(), settlementDate);
                this.TLFDAO.Save(TlfInfo);

                TlfInfo = this.GetTransactionLogFile(VoucherNo, entity.AccountNo, false, entity.AccruedInterest, entity.AccruedInterest, 0, "", CoaDto.COASetUpAccountName,
                    "Int Withdrawal for :" + entity.AccountNo, entity.CreatedDate, "TCV", "ACCINTTRCR", entity.AccountSign, entity.SourceBranchCode, entity.CurrencyCode, homeExchageRate, "",
                    CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel), entity.CreatedUserId.ToString(), settlementDate);
                this.TLFDAO.Save(TlfInfo);

                CledgerDAO.UpdateCurrentBalance(entity.AccountNo, cledgerInfo.CurrentBal + entity.AccruedInterest, ++cledgerInfo.TransactionCount, entity.CreatedUserId, entity.CreatedUserId.ToString());

                PrnDAO.Save(this.GetPrintFile(entity.AccountNo, entity.CreatedUserId, entity.AccruedInterest, cledgerInfo.CurrentBal + entity.AccruedInterest, entity.CurrencyCode, entity.SourceBranchCode, "TRCREDIT",entity.CreatedDate));
                this.ServiceResult.ErrorOccurred = false;
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME90043; // Unexpected Error Occur.
                throw new Exception(this.ServiceResult.MessageCode);
            }
            return VoucherNo;
        }

        #endregion

        #region Helper Methods

        private TCMORM00006 GetSavingInterestWithdrawalInfo(PFMDTO00016 entity,string butgetYear)
        {
            SIAccWitInfo = new TCMORM00006();
            SIAccWitInfo.AccountNo = entity.AccountNo;
            SIAccWitInfo.Type = "C";
            SIAccWitInfo.Amount = entity.AccruedInterest;
            SIAccWitInfo.Description = "Saving Interest Withdraw";
            SIAccWitInfo.Budget = butgetYear;
            SIAccWitInfo.SourceBranch = entity.SourceBranchCode;
            SIAccWitInfo.Currency = entity.CurrencyCode;
            SIAccWitInfo.Date_Time = DateTime.Now;
            SIAccWitInfo.UserNo = entity.CreatedUserId.ToString();
            SIAccWitInfo.Active = true;
            SIAccWitInfo.CreatedDate = DateTime.Now;
            SIAccWitInfo.CreatedUserId = entity.CreatedUserId;

            return SIAccWitInfo;
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
            tlf.ReferenceType = referenceType;
            tlf.CreatedUserId = Convert.ToInt32(userNo);

            return tlf;
        }

        private PFMORM00043 GetPrintFile(string accountNo, int userId, decimal creditAmount, decimal currentBalance, string currency, string branchCode,string reference,DateTime date)
        {
            PrnFileInfo = new PFMORM00043();
            PrnFileInfo.AccountNo = accountNo;
            PrnFileInfo.UserNo = userId.ToString();
            PrnFileInfo.Active = true;
            PrnFileInfo.Reference = reference;
            PrnFileInfo.Credit = creditAmount;
            PrnFileInfo.Debit = 0;
            PrnFileInfo.SourceBranchCode = branchCode;
            PrnFileInfo.Balance = currentBalance;
            PrnFileInfo.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
            PrnFileInfo.CreatedDate = date;
            PrnFileInfo.CreatedUserId = userId;
            PrnFileInfo.CurrencyCode = currency;
            PrnFileInfo.DATE_TIME = date;
            return PrnFileInfo;
        }

        private TLMORM00015 GetCashDeno(PFMDTO00016 info, string voucherNo, DateTime nextSettlementDate, decimal homeExchangeRate)
        {
            CashDenoInfo = new TLMORM00015();
            CashDenoInfo.TlfEntryNo = voucherNo;
            CashDenoInfo.Amount = info.AccruedInterest;
            CashDenoInfo.AdjustAmount = info.AdjustAmount;
            CashDenoInfo.CashDate = System.DateTime.Now;
            CashDenoInfo.DenoDetail = info.DenoString;
            CashDenoInfo.DenoRefundDetail = info.RefundString;
            CashDenoInfo.DenoRate = info.DenoRate;
            CashDenoInfo.DenoRefundRate = info.RefundRate;
            CashDenoInfo.Status = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);
            CashDenoInfo.Reverse = false;
            CashDenoInfo.CreatedDate = System.DateTime.Now;
            CashDenoInfo.CreatedUserId = info.CreatedUserId;
            CashDenoInfo.CounterNo = info.CounterNo;
            CashDenoInfo.Currency = info.CurrencyCode;
            CashDenoInfo.AllDenoRate = info.AllDenoRate;
            CashDenoInfo.Rate = homeExchangeRate;
            CashDenoInfo.UserNo = info.CreatedUserId.ToString();
            CashDenoInfo.SettlementDate = nextSettlementDate;

            return CashDenoInfo;
        }

        #endregion

    }
}
