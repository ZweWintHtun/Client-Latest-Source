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
using AutoMapper;
using Ace.Windows.CXServer.Utt;

namespace Ace.Cbs.Pfm.Sve
{
    /// <summary>
    /// Current Account Closing Service.
    /// </summary>
    public class PFMSVE00011 : BaseService, IPFMSVE00011
    {
        #region Properties
        public ICXSVE00002 CodeGenerator { get; set; }
        public ICXSVE00006 CodeChecker { get; set; }
        public IPFMDAO00028 CLedgerDAO { get; set; }
        public IPFMDAO00020 UCheckDAO { get; set; }
        public IPFMDAO00033 BalanceDAO { get; set; }
        public IPFMDAO00001 CustomerDAO { get; set; }
        public IPFMDAO00017 CAOFDAO { get; set; }
        public IPFMDAO00006 ChequeDAO { get; set; }
        public IPFMDAO00002 CloseBalanceDAO { get; set; }
        public IPFMDAO00054 TLFDAO { get; set; }
        public IList<PFMDTO00017> caofEntities {get;set;} //edit by hmw   
        public bool flag = false;
        #endregion        

        #region Main Methods
        public IList<PFMDTO00072> GetCurrentAccountInfo(string accountNo,string sourceBranchCode)
        {
            // Check saving account no is already closed or not.
            if (this.CodeChecker.IsClosedAccountForCLedger(accountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return null;
            }

            //Checking different branch account no or not (by hmw)
            //caofEntities = (List<PFMDTO00017>)CXServiceWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00017>>(x => x.GetCAOFsByAccountNumber(accountNo));
            caofEntities = CXServiceWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00017>>(x => x.GetCAOFsByAccountNumber(accountNo));

            if (caofEntities == null || caofEntities.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00058;//Invalid Current Account No.
                return null;
            }
            
            else if (caofEntities[0].SourceBranchCode != sourceBranchCode)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00091;//Invalid Account No. for Branch {0}.
                return null;
            }            

            // Check Freesze Account No
            else if (this.CodeChecker.IsFreezeAccount(accountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return null;
            }

            // Check Interest Account No in FReceipt
            else if (this.CodeChecker.HasInterestAccount(accountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return null;
            }

            // Check Loan Account No
            else if (this.CodeChecker.HasLoanAccount(accountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return null;
            }

            // Check Link Account No
            else if (this.CodeChecker.HasCurrentAccountInLinkAccount(accountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return null;
            }

            //Check cheque information
            IList<PFMDTO00006> chequeList = this.ChequeDAO.SelectByChequeBookNoByAccountNo(accountNo);
            if (chequeList.Count == 0)
            {
                this.ServiceResult.MessageCode = "NoCheque";
            }

            // Get CAOF by accountNo (For CustomerId)
            //return this.CodeChecker.GetCurrentAccountInfoByAccountNumber(accountNo);
            return this.CodeChecker.GetCurrentAccountInfoByAccountNumber_ForClosedACAndUnClosed(accountNo);//Updated by ZMS(16.11.18) for Pristine requirement [ can get close ac info ]
        }

        [Transaction(TransactionPropagation.Required)]
        public void SaveCurrentAccountClose(PFMDTO00072 accountClose)
        {

            try
            {//add by hmw (for different checking)
                caofEntities = CXServiceWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00017>>(x => x.GetCAOFsByAccountNumber(accountClose.AccountNo));

                if (caofEntities == null || caofEntities.Count == 0)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00058;//Invalid Current Account No.
                    return;
                }

                if (caofEntities[0].SourceBranchCode != accountClose.BranchCode)
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

                // Check Cheque No
                if (accountClose.HasCheque && this.CodeChecker.IsValidChequeBookIssueNoForAccountClose(accountClose.AccountNo, accountClose.ChequeNo, accountClose.BranchCode) == false)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                    return;
                }

                // Charges is greater than 0, save TLF table
                if (accountClose.Charges != 0)
                {
                    //string voucherNumber = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, accountClose.UpdatedUserId.Value, CurrentUserEntity.BranchCode, new object[] { accountClose.NextSettlementDate.Value.Day.ToString().PadLeft(2, '0'), accountClose.NextSettlementDate.Value.Month.ToString().PadLeft(2, '0'), accountClose.NextSettlementDate.Value.Year.ToString().Substring(2) });
                    string voucherNumber = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, accountClose.UpdatedUserId.Value, accountClose.BranchCode, new object[] { accountClose.NextSettlementDate.Value.Day.ToString().PadLeft(2, '0'), accountClose.NextSettlementDate.Value.Month.ToString().PadLeft(2, '0'), accountClose.NextSettlementDate.Value.Year.ToString().Substring(2) });
                    flag = true;
                    PFMORM00054 debitTransactionLog = this.GetTransactionLogFile(accountClose, voucherNumber, "By Transfer", "TCV", "TRCREDIT");
                    this.TLFDAO.Save(debitTransactionLog);
                    flag = false;
                    PFMORM00054 creditTransactionLog = this.GetTransactionLogFile(accountClose, voucherNumber, "To Transfer", "TDV", "TRDEBIT");
                    this.TLFDAO.Save(creditTransactionLog);
                }

                // Update CLedger => CloseDate and MinBal
                accountClose.CurrentBalance = accountClose.CurrentBalance - accountClose.Charges;
                if (this.CLedgerDAO.UpdateForClosing(accountClose.AccountNo, accountClose.CloseDate, accountClose.CurrentBalance, 0, accountClose.UpdatedUserId.Value) == false)
                {
                    // Update Error
                    throw new Exception(CXMessage.ME90001);
                }

                if (accountClose.HasCheque == true)
                {
                    // Save UCheck
                    PFMORM00020 ucheck = this.GetUCheck(accountClose);
                    this.UCheckDAO.Save(ucheck);
                }

                // Update Bal => CloseDate
                if (this.BalanceDAO.UpdateCloseDate(accountClose.AccountNo, accountClose.CloseDate, accountClose.UpdatedUserId.Value) == false)
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
                if (this.CAOFDAO.UpdateCloseDate(accountClose.AccountNo, accountClose.CloseDate, accountClose.UpdatedUserId.Value) == false)
                {
                    // Update Error
                    throw new Exception(CXMessage.ME90001);
                }

                // Update Cheque => CloseDate
                if (accountClose.HasCheque && this.ChequeDAO.UpdateCloseDate(accountClose.AccountNo, accountClose.CloseDate, accountClose.UpdatedUserId.Value) == false)
                {
                    // Update Error
                    throw new Exception(CXMessage.ME90001);
                }

                if (Decimal.Equals(accountClose.CurrentBalance, 0))
                {
                    // Save Close Bal
                    PFMORM00002 closeBalance = this.GetCloseBalance(accountClose);
                    this.CloseBalanceDAO.Save(closeBalance);
                }
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;                
            }
        }
        #endregion

        #region Helper Methods
        private PFMORM00020 GetUCheck(PFMDTO00072 accountClose)
        {
            PFMORM00020 ucheck = new PFMORM00020();

            ucheck.AccountNo = accountClose.AccountNo;
            ucheck.AccountSignature = accountClose.AccountSignature;
            ucheck.DATE_TIME = DateTime.Now;
            ucheck.ChequeNo = accountClose.ChequeNo;
            ucheck.USERNO = accountClose.UpdatedUserId.Value.ToString();
            ucheck.SourceBranchCode = accountClose.BranchCode;
            ucheck.CreatedUserId = accountClose.UpdatedUserId.Value;
            ucheck.CreatedDate = DateTime.Now;
            ucheck.Active = true;

            return ucheck;
        }

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

        private PFMORM00054 GetTransactionLogFile(PFMDTO00072 accountClose, string voucherNumber, string narration, string status, string transactionCode)
        {
            PFMORM00054 tlf = new PFMORM00054();

            tlf.Id = this.TLFDAO.SelectMaxId() + 1;
            tlf.Eno = voucherNumber;
            tlf.Cheque = accountClose.ChequeNo;

            if (status == "TCV")
            {
                tlf.AccountNo = accountClose.BankAccountNo;
                tlf.Acode = accountClose.BankAccountNo;
            }
            else if (status == "TDV")
            {
                tlf.AccountNo = accountClose.AccountNo;
                tlf.Acode = accountClose.DebitCOAAccountNo;
                tlf.AccountSign = accountClose.AccountSignature;
            }

            tlf.Amount = accountClose.Charges;
            tlf.HomeAmount = accountClose.Charges * accountClose.HomeExchangeRate;
            tlf.HomeAmt = accountClose.Charges * accountClose.HomeExchangeRate;
            tlf.HomeOAmt = 0;
            tlf.LocalAmount = accountClose.Charges;
            tlf.LocalAmt = accountClose.Charges;
            tlf.LocalOAmt = 0;
            if (flag)
                tlf.Description = "Income for Current A/c Close";
            else 
                tlf.Description = accountClose.CustomerName;
            tlf.Narration = narration;
            tlf.DateTime = DateTime.Now;
            tlf.Status = status;
            tlf.TransactionCode = transactionCode;
            tlf.UserNo = accountClose.UpdatedUserId.Value.ToString();
            tlf.SourceCurrency = accountClose.CurrencyCode;
            tlf.Rate = accountClose.HomeExchangeRate;
            tlf.SourceBranchCode = accountClose.BranchCode;
            tlf.SettlementDate = accountClose.NextSettlementDate;
            tlf.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
            tlf.CreatedUserId = accountClose.UpdatedUserId.Value;
            tlf.Active = true;
            tlf.CurrencyCode = accountClose.CurrencyCode;

            return tlf;
        }
        #endregion
    }
}