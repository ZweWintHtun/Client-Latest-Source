//----------------------------------------------------------------------
// <copyright file="PFMSVE00011.cs" company="Ace Data Systems">
// Copyright (c) Ace Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Si Thu Phyo</CreatedUser>
// <CreatedDate>11/02/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Admin.Contracts.Dao;


namespace Ace.Cbs.Pfm.Sve
{
    /// <summary>
    /// Saving Account Closing Service
    /// </summary>
    public class PFMSVE00010 : BaseService, IPFMSVE00010
    {
        #region Properties
        public ICXSVE00002 CodeGenerator { get; set; }
        public ICXSVE00006 CodeChecker { get; set; }
        public IPFMDAO00028 CLedgerDAO { get; set; }
        public IPFMDAO00033 BalanceDAO { get; set; }
        public IPFMDAO00001 CustomerDAO { get; set; }
        public IPFMDAO00016 SAOFDAO { get; set; }
        public IPFMDAO00002 CloseBalanceDAO { get; set; }
        public IPFMDAO00040 SIDAO { get; set; }
        public IPFMDAO00043 PRNFileDAO { get; set; }
        public IPFMDAO00054 TLFDao { get; set; }
        public IList<PFMDTO00016> saofEntities { get; set; } //edit by hmw  
        private IChargeOfAccountDAO coaDAO;
        public IChargeOfAccountDAO COADAO
        {
            get
            {
                return this.coaDAO;
            }
            set
            {
                this.coaDAO = value;
            }
        }
        #endregion

        #region Main Methods
        // Call Dao SelectACode Method
        public ChargeOfAccountDTO SelectACode(string aCode, string sourceBranchCode)
        {
            return this.coaDAO.SelectACode(aCode, sourceBranchCode);
        }

        public IList<PFMDTO00072> GetSavingAccountInfo(string accountNo,string sourceBranchCode)
        {
            // Check saving account no is already closed or not.
            if (this.CodeChecker.IsClosedAccountForCLedger(accountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return null;
               
            }

            //Checking different branch account no or not (by hmw)
            saofEntities = CXServiceWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00016>>(x => x.GetSAOFsByAccountNumber(accountNo));

            if (saofEntities == null || saofEntities.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00051;//Invalid Saving Account No.
                return null;
                
            }
            
            //if (saofEntities[0].SourceBranchCode != CurrentUserEntity.BranchCode) 
            if (saofEntities[0].SourceBranchCode != sourceBranchCode) 
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00091;//Invalid Account No. for Branch {0}.
                return null;
                
            }  
            

            // Check Freesze Account No
            if (this.CodeChecker.IsFreezeAccount(accountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return null;
             
            }

            // Check Interest Account No in FReceipt
            if (this.CodeChecker.HasInterestAccount(accountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return null;
               
            }

            // Check Loan Account No
            if (this.CodeChecker.HasLoanAccount(accountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return null;
                
            }

            // Check Link Account No
            if (this.CodeChecker.HasSavingAccountInLinkAccount(accountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return null;
                
            }
            
            // Get CAOF by accountNo (For CustomerId)
            return this.CodeChecker.GetSavingAccountInfoByAccountNumber(accountNo);
        }

        public object GetBeforeTaxForCredit(string accountNo)
        {
            string query = string.Empty;

            string quarterType = CXCOM00007.Instance.GetValueByVariable(CXCOM00009.SavingPost);

            int initialMonth = Convert.ToInt32(CXCOM00010.Instance.GetBudgetYear2(CXCOM00009.BudgetYearCode, DateTime.Now));
            int startMonth = 0;
            int endMonth = 0;

            switch (quarterType)
            {
                case "3":
                    if (initialMonth >= 10 && initialMonth <= 12)
                    {
                        startMonth = 10;
                    }
                    else if (initialMonth >= 1 && initialMonth <= 3)
                    {
                        startMonth = 1;
                    }
                    else if (initialMonth >= 4 && initialMonth <= 6)
                    {
                        startMonth = 4;
                    }
                    else if (initialMonth >= 7 && initialMonth <= 9)
                    {
                        startMonth = 7;
                    }
                    break;

                case "6":
                    if (initialMonth >= 7 && initialMonth <= 12)
                    {
                        startMonth = 7;
                    }
                    else if (initialMonth >= 1 && initialMonth <= 6)
                    {
                        startMonth = 1;
                    }
                    break;
            }

            endMonth = initialMonth - 1;

            return this.GetTax(accountNo, startMonth, endMonth);
        }

        public object GetBeforeTaxForDebit(string accountNo, DateTime openDate)
        {
            // Interest
            DateTime now = CXCOM00010.Instance.GetDateOnly(DateTime.Now);
            DateTime month3 = Convert.ToDateTime((now.Year + ((DateTime.Now.Month < 4) ? -1 : 0)).ToString() + "/06/30");
            DateTime month6 = Convert.ToDateTime((now.Year + ((DateTime.Now.Month < 4) ? -1 : 0)).ToString() + "/09/30");
            DateTime month9 = Convert.ToDateTime(now.Year.ToString() + "/12/31");
            DateTime month12 = Convert.ToDateTime(now.Year.ToString() + "/03/31");

            string quarterType = CXCOM00007.Instance.GetValueByVariable(CXCOM00009.SavingPost);
            int budgetMonth = Convert.ToInt32(CXCOM00010.Instance.GetBudgetYear2(CXCOM00009.BudgetYearCode, openDate));
            int startMonth = 0;
            int endMonth = 0;

            switch (quarterType)
            {
                case "3":
                    if (month3 >= openDate && month3 <= now.AddMonths(1))
                    {
                        startMonth = budgetMonth;
                        endMonth = 3;
                    }
                    else if (month6 >= openDate && month6 <= now.AddMonths(1))
                    {
                        startMonth = budgetMonth;
                        endMonth = 6;
                    }
                    else if (month9 >= openDate && month9 <= now.AddMonths(1))
                    {
                        startMonth = budgetMonth;
                        endMonth = 9;
                    }
                    else if (month12 >= openDate && month12 <= now.AddMonths(1))
                    {
                        startMonth = budgetMonth;
                        endMonth = 12;
                    }
                    break;

                case "6":
                    if (month6 >= openDate && month6 <= now.AddMonths(1))
                    {
                        startMonth = budgetMonth;
                        endMonth = 6;
                    }
                    else if (month12 >= openDate && month12 <= now.AddMonths(1))
                    {
                        startMonth = budgetMonth;
                        endMonth = 12;
                    }
                    break;
            }

            return this.GetTax(accountNo, startMonth, endMonth);
        }

        [Transaction(TransactionPropagation.Required)]
        public void SaveSavingAccountClose(PFMDTO00072 accountClose)
        {
            //Checking different branch account no or not (by hmw)
            saofEntities = CXServiceWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00016>>(x => x.GetSAOFsByAccountNumber(accountClose.AccountNo));

            if (saofEntities == null || saofEntities.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00051;//Invalid Current Account No.
                return;
            }

            if (saofEntities[0].SourceBranchCode != accountClose.BranchCode)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00091;//Invalid Account No. for Branch {0}.
                return;
            }            

            // Check saving account no is already closed or not.
            if (this.CodeChecker.IsClosedAccountForCLedger(accountClose.AccountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return;
            }

            // Check Freesze Account No
            if (this.CodeChecker.IsFreezeAccount(accountClose.AccountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return;
            }

            // Check Interest Account No in FReceipt
            if (this.CodeChecker.HasInterestAccount(accountClose.AccountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return;
            }

            // Check Loan Account No
            if (this.CodeChecker.HasLoanAccount(accountClose.AccountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return;
            }

            // Check Link Account No
            if (this.CodeChecker.HasCurrentAccountInLinkAccount(accountClose.AccountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return;
            }

            #region TLF Saving
            PFMORM00054 debitTransactionLog= null;            
            string voucherNumber = this.CodeGenerator.GetGenerateCode("SavingCloseVoucher", string.Empty, accountClose.UpdatedUserId.Value, accountClose.BranchCode, new object[] { accountClose.NextSettlementDate.Value.Day.ToString().PadLeft(2, '0'), accountClose.NextSettlementDate.Value.Month.ToString().PadLeft(2, '0'), accountClose.NextSettlementDate.Value.Year.ToString().Substring(2) });

            if (accountClose.Charges != 0)
            {
                debitTransactionLog = this.GetTransactionLogFile(voucherNumber, accountClose.BankAccountNo, true, accountClose.Charges, accountClose.Charges, 0, "", accountClose.BankAccountDescription,
                    "ACCOUNT CLOSE", DateTime.Now, "TCV", "TRCREDIT", "", accountClose.BranchCode, accountClose.CurrencyCode, accountClose.HomeExchangeRate.Value, "", CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel), accountClose.UpdatedUserId.Value.ToString(), accountClose.NextSettlementDate.Value); //Update by hmw (to get description & channel for tlf)

                //Comment by hmw (because it is the old wrong logic.)
                //if (accountClose.InterestType == "debit") 
                //{
                //    debitTransactionLog.AccountNo = string.Empty;
                //    debitTransactionLog.Acode = string.Empty;
                //    debitTransactionLog.Description = string.Empty;
                //}

                this.TLFDao.Save(debitTransactionLog);
                
                debitTransactionLog = this.GetTransactionLogFile(voucherNumber, accountClose.AccountNo, false, accountClose.Charges, accountClose.Charges, 0, "", accountClose.CustomerName,
                    "ACCOUNT CLOSE", DateTime.Now, "TDV", "TRDEBIT", accountClose.AccountSignature, accountClose.BranchCode, accountClose.CurrencyCode, accountClose.HomeExchangeRate.Value, "", CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel), accountClose.UpdatedUserId.Value.ToString(), accountClose.NextSettlementDate.Value);
                this.TLFDao.Save(debitTransactionLog);
            }

            if (accountClose.CreditAmount1 != 0)
            {
                debitTransactionLog = this.GetTransactionLogFile(voucherNumber, accountClose.CreditAccountNo1, false, accountClose.CreditAmount1, accountClose.CreditAmount1, 0, "", accountClose.CustomerName,
                    "ACCOUNT CLOSE", DateTime.Now, "TCV", "TRCREDIT", accountClose.AccountSignature, accountClose.BranchCode, accountClose.CurrencyCode, accountClose.HomeExchangeRate.Value, "", CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel), accountClose.UpdatedUserId.Value.ToString(), accountClose.NextSettlementDate.Value);
                this.TLFDao.Save(debitTransactionLog);
            }

            if (accountClose.CreditAmount2 != 0)
            {
                debitTransactionLog = this.GetTransactionLogFile(voucherNumber, accountClose.CreditAccountNo2, true, accountClose.CreditAmount2, accountClose.CreditAmount2, 0, "", accountClose.CreditDescription2,
                    "ACCOUNT CLOSE", DateTime.Now, "TCV", "TRCREDIT", string.Empty, accountClose.BranchCode, accountClose.CurrencyCode, accountClose.HomeExchangeRate.Value, "", CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel), accountClose.UpdatedUserId.Value.ToString(), accountClose.NextSettlementDate.Value); //Update by hmw (to get description & channel for tlf)
                this.TLFDao.Save(debitTransactionLog);
            }

            if (accountClose.DebitAmount1 != 0)
            {
                debitTransactionLog = this.GetTransactionLogFile(voucherNumber, accountClose.DebitAccountNo1, true, accountClose.DebitAmount1, accountClose.DebitAmount1, 0, "", accountClose.DebitDescription1,
                    "ACCOUNT CLOSE" + accountClose.AccountNo, DateTime.Now, "TDV", "TRDEBIT", "", accountClose.BranchCode, accountClose.CurrencyCode, accountClose.HomeExchangeRate.Value, "", CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel), accountClose.UpdatedUserId.Value.ToString(), accountClose.NextSettlementDate.Value);
                this.TLFDao.Save(debitTransactionLog);                
            }

            if (accountClose.DebitAmount2 != 0)
            {
                debitTransactionLog = this.GetTransactionLogFile(voucherNumber, accountClose.DebitAccountNo2, true, accountClose.DebitAmount2, accountClose.DebitAmount2, 0, "", "",
                    "ACCOUNT CLOSE", DateTime.Now, "TDV", "TRDEBIT", accountClose.AccountSignature, accountClose.BranchCode, accountClose.CurrencyCode, accountClose.HomeExchangeRate.Value, "", CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel), accountClose.UpdatedUserId.Value.ToString()
                    , accountClose.NextSettlementDate.Value);
                this.TLFDao.Save(debitTransactionLog);
            }
            #endregion

            // Update CLedger => CloseDate and MinBal
            if (this.CLedgerDAO.UpdateForClosing(accountClose.AccountNo, accountClose.CloseDate, accountClose.CurrentBalance, 0, accountClose.UpdatedUserId.Value) == false)
            {
                // Update Error
                throw new Exception(CXMessage.ME90001);
            }

            // Update Bal => CloseDate
            if (this.BalanceDAO.UpdateCloseDate(accountClose.AccountNo, accountClose.CloseDate, accountClose.UpdatedUserId.Value) == false)
            {
                // Update Error
                throw new Exception(CXMessage.ME90001);
            }

            // Update SI => CloseDate
            if (this.SIDAO.UpdateCloseDate(accountClose.AccountNo, accountClose.CloseDate, accountClose.UpdatedUserId.Value) == false)
            {
                // Update Error
                throw new Exception(CXMessage.ME90001);
            }

            // Update CustId => increase CloseAC
            foreach (string customerId in accountClose.CustomerIds)
            {
                if (this.CustomerDAO.UpdateCloseAccount(customerId, accountClose.UpdatedUserId.Value) == false)
                {
                    // Update Error
                    throw new Exception(CXMessage.ME90001);
                }
            }

            // Update CAOF => CloseDate
            if (this.SAOFDAO.UpdateCloseDate(accountClose.AccountNo, accountClose.CloseDate, accountClose.UpdatedUserId.Value) == false)
            {
                // Update Error
                throw new Exception(CXMessage.ME90001);
            }

            if (accountClose.CurrentBalance != 0)
            {
                // Save PRNFile
                PFMORM00043 prnFile = this.GetPRNFile(accountClose);
                this.PRNFileDAO.Save(prnFile);

                // Save Close Bal
                PFMORM00002 closeBalance = this.GetCloseBalance(accountClose);
                this.CloseBalanceDAO.Save(closeBalance);
            }
        }
        #endregion

        #region Helper Methods
        private PFMORM00002 GetCloseBalance(PFMDTO00072 accountClose)
        {
            PFMORM00002 closeBalance = new PFMORM00002();

            closeBalance.AccountNo = accountClose.AccountNo;
            closeBalance.Name = accountClose.CustomerName;
            closeBalance.CloseBalance = accountClose.CurrentBalance;
            closeBalance.CheckNo = accountClose.ChequeNo;
            closeBalance.CloseDate = accountClose.CloseDate;
            closeBalance.SourceBranch = accountClose.BranchCode;
            closeBalance.Cur = accountClose.CurrencyCode;
            closeBalance.AccountSign = accountClose.AccountSignature;
            closeBalance.UserNo = accountClose.UpdatedUserId.Value.ToString();
            closeBalance.CreatedUserId = accountClose.UpdatedUserId.Value;
            closeBalance.CreatedDate = DateTime.Now;
            closeBalance.Active = true;

            return closeBalance;
        }

        private decimal GetTax(string accountNo, int startMonth, int endMonth)
        {
            string query = string.Empty;

            while (startMonth <= endMonth)
            {
                if (startMonth != 0)
                {
                    if (string.IsNullOrEmpty(query))
                    {
                        query += "Month" + (startMonth).ToString();
                    }
                    else
                    {
                        query += ", Month" + (startMonth).ToString();
                    }
                }

                startMonth += 1;
            }

            if (string.IsNullOrEmpty(query))
            {
                return 0;
            }

            object monthlyAmounts = this.SIDAO.GetMonthlyAmount(query, accountNo);
            decimal sumAmount = 0;

            if (monthlyAmounts is object[])
            {
                object[] amounts = (object[])monthlyAmounts;
                foreach (object amount in amounts)
                {
                    sumAmount += Convert.ToDecimal(amount);
                }
            }
            else
            {
                sumAmount = Convert.ToDecimal(monthlyAmounts);
            }

            return sumAmount;
        }

        private PFMORM00043 GetPRNFile(PFMDTO00072 accountClose)
        {
            PFMORM00043 prnFile = new PFMORM00043();

            prnFile.AccountNo = accountClose.AccountNo;
            prnFile.DATE_TIME = DateTime.Now;
            prnFile.Credit = accountClose.TotalInterest;
            prnFile.Balance = accountClose.CurrentBalance;
            prnFile.UserNo = accountClose.UpdatedUserId.Value.ToString();
            prnFile.SourceBranchCode = accountClose.BranchCode;
            prnFile.CurrencyCode = accountClose.CurrencyCode;
            prnFile.CreatedUserId = accountClose.UpdatedUserId.Value;
            prnFile.CreatedDate = DateTime.Now;
            prnFile.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
            prnFile.Reference = "INT";
            prnFile.Active = true;

            return prnFile;
        }

        private PFMORM00054 GetTransactionLogFile(string voucherNo, string accountNo,bool isSameACodeandAccountNo, decimal amount, decimal netAmount, decimal overdraftAmount, string chequeNo, 
            string description, string narration, DateTime date_Time, string status, string transactionCode, string accountSignature, string branchCode, string currencyCode, 
            decimal homeRate, string referenceType, string channel, string userNo, DateTime nextSettlementDate)
        {
            PFMORM00054 tlf = new PFMORM00054();
            tlf.Id = this.TLFDao.SelectMaxId() + 1;
            tlf.Eno = voucherNo;

            if (isSameACodeandAccountNo == false && accountSignature.Length > 0)
            {
                switch (accountSignature[0])
                {
                    case 'C':
                        tlf.Acode = CXCOM00010.Instance.GetCOAAccountNo("CURCONTROL", branchCode, currencyCode);
                        break;

                    case 'S':
                        tlf.Acode = CXCOM00010.Instance.GetCOAAccountNo("SAVCONTROL", branchCode, currencyCode);
                        break;

                    case 'L':
                        tlf.Acode = CXCOM00010.Instance.GetCOAAccountNo("CALCONTROL", branchCode, currencyCode);
                        break;

                    case 'F':
                        tlf.Acode = CXCOM00010.Instance.GetCOAAccountNo("FIXCONTROL", branchCode, currencyCode);
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
            tlf.CurrencyCode = currencyCode;
            tlf.Rate = homeRate;
            tlf.SourceBranchCode = branchCode;
            tlf.Channel = channel;
            tlf.ReferenceType = referenceType;
            tlf.CreatedUserId = Convert.ToInt32(userNo);

            return tlf;
        }
        #endregion
    }
}