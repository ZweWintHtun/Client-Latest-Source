//----------------------------------------------------------------------
// <copyright file="TLMSVE00014.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Pfm.Dao;
using Ace.Cbs.Cx.Ser.Sve;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Windows.Core.Utt;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dto;

namespace Ace.Cbs.Tel.Sve
{
    /// <summary>
    /// Withdraw Service
    /// </summary>
    public class TLMSVE00014 : BaseService, ITLMSVE00014
    {
        #region DAO Properties
        public ICXSVE00006 CodeChecker { get; set; }
        public IPFMDAO00001 CustomerIdDAO { get; set; }
        public IPFMDAO00002 CloseBalanceDAO { get; set; }
        public IPFMDAO00028 CledgerDAO { get; set; }
        public IPFMDAO00029 LinkACDAO { get; set; }
        public ICXSVE00002 CodeGenerator { get; set; }
        public ICXSVE00010 DataGenerate { get; set; }
        public ITLMDAO00004 IBLTLFDAO { get; set; }
        public ITLMDAO00009 DepoDenoDAO { get; set; }
        public ITLMDAO00015 CashDenoDAO { get; set; }
        public ICXSVE00003 PrintingDAO { get; set; }
        public IPFMDAO00054 TLFDao { get; set; }   

        PFMDTO00002 CloseBalanceInfo;
        TLMORM00015 cashDeno;
        TLMORM00004 iblTlf;
        string voucherNo { get; set; }
      
        #endregion

        #region Main  Method

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateCleadgerPrintLineNoandDeletePrnFile(string accountNo, int updatedUserId,int lineNo)
        {
            try
            {
                this.CledgerDAO.UpdatePrnLineNoByAccountNo(accountNo, updatedUserId,lineNo);
                this.PrintingDAO.DeletePrnFileByAccountNo(accountNo);
                this.ServiceResult.ErrorOccurred = false;
                return true;
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME90001;
                return false;
            }

        }

        public IList<PFMDTO00001> GetAccountInfoByAccountNo(string accountNo, bool vipCustomer, string branchCode, DateTime todaydate)
        {
            IList<PFMDTO00001> customerLists = new List<PFMDTO00001>();
            try
            {
                #region Check Close Account
                if (this.CodeChecker.IsClosedAccountForCLedger(accountNo))
                {
                    CloseBalanceInfo = this.CloseBalanceDAO.SelectDataForLastWithdrawal(accountNo, branchCode);

                    if (CloseBalanceInfo == null)
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                        return customerLists;
                    }
                }
                #endregion

                #region  Check Freesze Account No
                if (this.CodeChecker.IsFreezeAccount(accountNo))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                    return customerLists;
                }
                #endregion

                #region Check Legal Case Account
                if (this.CodeChecker.HasLegalCaseAccount(accountNo))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                    return customerLists;
                }
                #endregion

                #region   Check NPL Case Account
                if (this.CodeChecker.HasNPLCaseAccount(accountNo))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                    return customerLists;
                }
                #endregion               

                //Check FLedger Account
                bool isFAOF = CXServiceWrapper.Instance.Invoke<ICXSVE00006, bool>(x => x.isFAOFAccountNo(accountNo));
                if (isFAOF)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV90045"; //Current,Saving,Chart of Account Only.
                    return null;
                }

                #region GetCustomerInfomationByAccountNo
                customerLists = CXServiceWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00001>>(x => x.GetCustomerInfomationByAccountNo(accountNo, false));

                //// Updated by ZMS (12.11.18)for Pristine
                #region Check Is Expire Loan Account
                if (this.CodeChecker.IsExpiredLoansAccount(accountNo, todaydate))
                {
                    this.ServiceResult.ErrorOccurred = false;
                    customerLists[0].ExpiredStatus = true;
                    this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                    return customerLists;
                }
                #endregion

                if (CloseBalanceInfo != null)
                {
                    customerLists[0].CurrentBal = CloseBalanceInfo.CloseBalance;
                    customerLists[0].ChequeNo = CloseBalanceInfo.CheckNo;
                    customerLists[0].IsLastWithdrawal = true;
                }
                else
                    customerLists[0].IsLastWithdrawal = false;

                #endregion
                
                return customerLists;
            }

            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME00054;
                return customerLists;
            }

        }

        [Transaction(TransactionPropagation.Required)]
        public bool DebitInformationCheckingAndLink(TLMDTO00047 withdrawalEntity)
        {
            string messageNo = string.Empty;
            decimal amountforCheck = 0;
            bool isLink = false;
            if (withdrawalEntity.IsIncomeByTransfer)
            {
                amountforCheck = withdrawalEntity.Amount + withdrawalEntity.Commission + withdrawalEntity.CommunicationCharges;
            }
            else
            {
                amountforCheck = withdrawalEntity.Amount;
 
            }

            //comment by ASDA---already done cheque no custom validating(if account is close account's last withdrawl , cheque no already bind so don't need to check)
            //if (!withdrawalEntity.ChequeNo.Equals(string.Empty) && this.CodeChecker.IsVaildChequeNoforWithdrawal(withdrawalEntity.AccountNo, withdrawalEntity.ChequeNo, withdrawalEntity.ToBranch))
            //{
            //    this.ServiceResult.ErrorOccurred = true;
            //    this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
            //    return false;
            //}
            //end comment

            //Check Amount
            if(!withdrawalEntity.IsLastWithdrawal)

                if (!this.CodeChecker.CheckAmount(withdrawalEntity.AccountNo, amountforCheck, true, withdrawalEntity.IsVIP, true, ref isLink, ref messageNo))
                {
                    string _m = messageNo;
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = messageNo;
                    return false;
                }
            return isLink;
        }        

        public TLMDTO00005 GetTranType(string tranCode)
        {
            TLMDTO00005 trantypeDTO = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { tranCode });// WITHDRAW(status)

            if (trantypeDTO == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME00021; // Client Data Not Found.
                return null;
            }
            else
            {
                return trantypeDTO;
            }
        }

        public TLMDTO00031 GetZone(string otherBranch, string sourceBranch)
        {
            TLMDTO00031 zoneDTO = CXCOM00011.Instance.GetScalarObject<TLMDTO00031>("Zone.Server.SelectByBranch", new object[] { otherBranch,sourceBranch });
            if (zoneDTO == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME00021; // Client Data Not Found.
                return null;
            }
            else
            {
                return zoneDTO;
            }
        }

        public TLMDTO00029 GetRemitBrIbl(string otherBranch, string sourceBranch, string currency)
        {
            TLMDTO00029 remitBrILBDTO = CXCOM00011.Instance.GetScalarObject<TLMDTO00029>("RemitBrIBL.Server.SelectByBranch", new object[] {otherBranch,sourceBranch,currency});
            if (remitBrILBDTO == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME00021; // Client Data Not Found.
                return null;
            }
            else
            {
                return remitBrILBDTO;
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public bool HasSavingAccountTransaction(string accountNo, int userid)
        {
            if (this.DataGenerate.HasSavingAccountTransaction(accountNo, userid))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.DataGenerate.ServiceResult.MessageCode;
                return true;
            }
            return false;
        }

        [Transaction()]
        private TLMORM00004 GetIBLTransactionLogFile(string voucherNo, string accountNo, decimal amount, decimal income, decimal communicationCharges, string status, string fromBranchCode, string branchCode, string currencyCode, string userNo, int incomeType, string chequeNo)
        {
            iblTlf = new TLMORM00004();
            iblTlf.Id = IBLTLFDAO.SelectMaxId() + 1;
            iblTlf.Eno = voucherNo;
            iblTlf.AccountNo = accountNo;
            iblTlf.FromBranch = fromBranchCode;
            iblTlf.ToBranch = branchCode;
            iblTlf.Amount = amount;
            iblTlf.TranType = status;
            iblTlf.Date_Time = DateTime.Now;
            iblTlf.InOut = false;
            iblTlf.Success = true;
            iblTlf.Income = income;
            iblTlf.Communicationcharge = communicationCharges;
            iblTlf.IncomeType = Convert.ToInt32(incomeType);
            //iblTlf.Cheque = string.Empty;
            iblTlf.Cheque = chequeNo;  //ASDA
            iblTlf.UserNo = userNo;
            iblTlf.Reversal = false;
            iblTlf.RelatedAccount = string.Empty;
            iblTlf.RelatedBranch = string.Empty;
            iblTlf.Currency = currencyCode;
            //iblTlf.SourceBranchCode = branchCode;
            iblTlf.SourceBranchCode = fromBranchCode;
            iblTlf.CreatedUserId = (!string.IsNullOrEmpty(userNo)) ? int.Parse(userNo) : 0;

            return iblTlf;
        }

        

        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00054> SaveWithdrawOnline(IList<TLMDTO00047> WithdrawList, string sourceBr)
        {
            // Variables
            string groupNumber = string.Empty;
            TLMDTO00005 tranTypeDTO = null;
            TLMDTO00005 transactionTypeDTO = null;
            TLMDTO00031 zoneDTO = null;
            TLMDTO00029 remitBranchDTO = null;
            string status = string.Empty;
            int incomeType = 0;
            IList<PFMDTO00054> TLF_LIST = new List<PFMDTO00054>();
            decimal Rate = decimal.Zero;
            DateTime settlementDate = Convert.ToDateTime(this.GetSettlementDate(WithdrawList[0].SourceBranchCode).ToShortDateString());//Modify by HMW (2019-03-25 00:00:00.000 ==> hh:mm:ss should be zero to fix reversal validation checking)
            // Common Data
          //  TLMDTO00047 withdrawDTO = this.CommonDataToSave(WithdrawList);            

            for (int i = 0; i < WithdrawList.Count; i++)
            {
                voucherNo = this.CodeGenerator.GetGenerateCode("IBLVoucher", string.Empty, WithdrawList[0].UpdatedUserId.Value, WithdrawList[0].SourceBranchCode, new object[] { WithdrawList[0].SourceBranchCode });

                incomeType = Convert.ToInt32(WithdrawList[i].IncomeType);

                zoneDTO = this.GetZone(WithdrawList[i].ToBranch, WithdrawList[i].SourceBranchCode);//PCE002 
                remitBranchDTO = this.GetRemitBrIbl(WithdrawList[i].ToBranch, WithdrawList[i].SourceBranchCode, WithdrawList[i].CurrencyCode);//RE0004,OAN001

                //incomeType=Convert.ToString(WithdrawList[i].IncomeType);
                tranTypeDTO = this.GetTranType(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.WithdrawalCode));//CDW
                string code = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferDebitVoucherCode);//TRDEBIT
                transactionTypeDTO = this.GetTranType(code);//TDV
                status = transactionTypeDTO.Status;
                //replace "sourceBr" instead of "WithdrawList[i].ToBranch"
                if (!CXServiceWrapper.Instance.Invoke<ICXSVE00010, bool>(x => x.IBL_Withdrawal(voucherNo, WithdrawList[i].AccountNo, WithdrawList[i].Amount, WithdrawList[i].IsVIP ? "1" : "0", 1, 1, transactionTypeDTO.Status, transactionTypeDTO.TransactionCode, tranTypeDTO.PBReference, 0,
                 WithdrawList[i].SourceBranchCode, WithdrawList[i].Commission, WithdrawList[i].CommunicationCharges, incomeType, zoneDTO.AccountCode, remitBranchDTO.IBSComAccount, remitBranchDTO.TelaxAccount, WithdrawList[i].UserNo, WithdrawList[i].CurrencyCode,
                 0, WithdrawList[i].ToBranch, settlementDate, WithdrawList[i].Channel, WithdrawList[i].ChequeNo, WithdrawList[i].CreatedUserId)))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXServiceWrapper.Instance.ServiceResult.MessageCode;
                    throw new Exception(this.ServiceResult.MessageCode);
                    //return null;
                }

                string code1 = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashDebitType);//CSDEBIT
                transactionTypeDTO = this.GetTranType(code1);//CDV

                //IBL_Voucher(cash-- tlf save 3 record/transfer-- tlf save 1 record)
                int type = 0;
                if (incomeType == 1)
                { type = 1; }
                else
                { type = 0; }
                if (!CXServiceWrapper.Instance.Invoke<ICXSVE00010, bool>(x => x.IBL_Voucher(voucherNo, zoneDTO.AccountCode, WithdrawList[i].Amount, transactionTypeDTO.Status, transactionTypeDTO.TransactionCode, "1", string.Empty, string.Empty,
                    WithdrawList[i].Commission, WithdrawList[i].CommunicationCharges, type, remitBranchDTO.IBSComAccount, remitBranchDTO.TelaxAccount, WithdrawList[i].UserNo, WithdrawList[i].CurrencyCode, WithdrawList[i].CurrencyCode,
                    0, WithdrawList[i].SourceBranchCode, settlementDate, WithdrawList[i].Channel)))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXServiceWrapper.Instance.ServiceResult.MessageCode;
                    throw new Exception(this.ServiceResult.MessageCode);
                    //return null;
                }
                iblTlf = this.GetIBLTransactionLogFile(voucherNo, WithdrawList[i].AccountNo, WithdrawList[i].Amount, WithdrawList[i].Commission, WithdrawList[i].CommunicationCharges, tranTypeDTO.Status, WithdrawList[i].SourceBranchCode,
                                           WithdrawList[i].ToBranch, WithdrawList[i].CurrencyCode, WithdrawList[i].UserNo, incomeType, WithdrawList[i].ChequeNo);  //edit by ASDA
                this.IBLTLFDAO.Save(iblTlf);

                this.CledgerDAO.UpdateTransactionCount(WithdrawList[i].AccountNo, WithdrawList[i].CreatedUserId);
               
                if (WithdrawList.Count > 1)
                {
                    groupNumber = string.IsNullOrEmpty(groupNumber) ? this.CodeGenerator.GetGenerateCode("GroupVoucher", string.Empty, WithdrawList[0].UpdatedUserId.Value, WithdrawList[0].SourceBranchCode, new object[] { settlementDate.Day.ToString().PadLeft(2, '0'), settlementDate.Month.ToString().PadLeft(2, '0'), settlementDate.Year.ToString().Substring(2) }) : groupNumber;

                    TLMORM00009 depodeno = new TLMORM00009();
                    depodeno.GroupNo = groupNumber;
                    depodeno.Tlf_Eno = voucherNo;
                    depodeno.AccountType = WithdrawList[i].AccountNo;
                    depodeno.Amount = WithdrawList[i].Amount;
                    depodeno.Reverse_Status = false;
                    depodeno.Communicationcharge = WithdrawList[i].CommunicationCharges;
                    depodeno.Income = WithdrawList[i].Commission;
                    depodeno.SourceBranchCode = WithdrawList[i].SourceBranchCode;
                    depodeno.Currency = WithdrawList[i].CurrencyCode;
                    depodeno.CreatedUserId = WithdrawList[i].CreatedUserId;
                    depodeno.CreatedDate = DateTime.Now;
                    this.DepoDenoDAO.Save(depodeno);                    
                }
                Rate = CXCOM00010.Instance.GetExchangeRate(WithdrawList[i].CurrencyCode, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType));
                TLF_LIST.Add(new PFMDTO00054(voucherNo, decimal.Zero, groupNumber, Rate, status));
            }
            if (WithdrawList.Count >= 1)
            {
                // Cash Deno for Payment Amount    
                string acType = (WithdrawList.Count > 1) ? null : WithdrawList[0].AccountNo;
                string eno = (WithdrawList.Count > 1) ? groupNumber : voucherNo;
                cashDeno = this.GetCashDeno(eno, WithdrawList[0].TotalAmount, 0, WithdrawList[0].CreatedUserId, WithdrawList[0].CounterNo, WithdrawList[0].CurrencyCode, settlementDate, WithdrawList[0].SourceBranchCode, true, acType);

                    this.CashDenoDAO.Save(cashDeno);

                    // Cash Deno for Charges Amount     
                    if (WithdrawList[0].TotalCharges > 0)
                    {
                        cashDeno = this.GetCashDeno(eno, WithdrawList[0].TotalCharges, WithdrawList[0].AdjustAmount, WithdrawList[0].CreatedUserId, WithdrawList[0].IncomeCounterNo, WithdrawList[0].CurrencyCode, settlementDate, WithdrawList[0].SourceBranchCode, false, acType);
                        this.CashDenoDAO.Save(cashDeno);
                    }
             }

            //Added by ASDA**
            IList<TLMDTO00009> depoDenoList = new List<TLMDTO00009>();
            IList<PFMDTO00054> tlfList = new List<PFMDTO00054>();
            if (groupNumber != null)
            {
                depoDenoList = DepoDenoDAO.SelectAccountTypesByGroupNo(groupNumber, WithdrawList[0].SourceBranchCode);
            }
            if (depoDenoList != null && depoDenoList.Count > 1)
            {
                foreach (TLMDTO00009 dto in depoDenoList)
                {
                    tlfList = TLFDao.GetTlfInfoForWithdrawEntry(dto.Tlf_Eno, settlementDate);
                    if (tlfList.Count > 0)
                    {
                        foreach (PFMDTO00054 tlfdto in tlfList)
                        {
                            if (tlfdto.AccountNo.Length < 15)
                                TLFDao.UpdateTlfHomeAmt(tlfdto.Id, tlfdto.Amount);
                        }
                    }
                }
            }
            else
            {
                tlfList = TLFDao.GetTlfInfoForWithdrawEntry(voucherNo, settlementDate);
                if (tlfList.Count > 0)
                {
                    foreach (PFMDTO00054 tlfdto in tlfList)
                    {
                        if (tlfdto.AccountNo.Length < 15)
                            TLFDao.UpdateTlfHomeAmt(tlfdto.Id, tlfdto.Amount);
                    }
                }
            }
            
            //End***

            return TLF_LIST;
        }
 
        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00054> SaveWithdrawLocal(IList<TLMDTO00047> WithdrawList)//After NMS Update
        {
            try
            {
                IList<PFMDTO00054> TLF_LIST = new List<PFMDTO00054>();
                string voucherNo = string.Empty;
                string returnString = string.Empty;
                string groupNumber = string.Empty;
                TLMDTO00005 tranTypeDTO = null;
                decimal Rate = decimal.Zero;
                DateTime settlementDate = Convert.ToDateTime(this.GetSettlementDate(WithdrawList[0].SourceBranchCode).ToShortDateString());
            //    TLMDTO00047 withdrawDTO = this.CommonDataToSave(WithdrawList); 
               
                
                for (int i = 0; i < WithdrawList.Count; i++)
                {
                    if (WithdrawList[0].CurrentAccountSign == WithdrawList[0].AccountSing.Substring(0, 1))
                    {
                        bool IsvalidCheque = this.CodeChecker.IsVaildChequeNoforWithdrawal(WithdrawList[i].AccountNo, WithdrawList[i].ChequeNo, WithdrawList[i].SourceBranchCode);
                    }

                    voucherNo = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, WithdrawList[0].UpdatedUserId.Value, WithdrawList[0].SourceBranchCode, new object[] { settlementDate.Day.ToString().PadLeft(2, '0'), settlementDate.Month.ToString().PadLeft(2, '0'), settlementDate.Year.ToString().Substring(2) });
                    this.DataGenerate.AllUpdateForWithdraw(voucherNo, WithdrawList[i].AccountNo, WithdrawList[i].Amount, WithdrawList[i].OverdraftAmount, WithdrawList[i].WithdrawStatus, WithdrawList[i].ChequeNo, WithdrawList[i].UserNo, WithdrawList[i].SourceBranchCode, WithdrawList[i].Channel, settlementDate, WithdrawList[i].IsAutoLink, string.Empty, WithdrawList[i].CreatedUserId, WithdrawList[i].Active);
                    this.CloseBalanceDAO.DeleteForLastWithdrawal(WithdrawList[i].AccountNo);
                    if (WithdrawList.Count > 1)
                    {
                        groupNumber = string.IsNullOrEmpty(groupNumber) ? this.CodeGenerator.GetGenerateCode("GroupVoucher", string.Empty, WithdrawList[0].UpdatedUserId.Value, WithdrawList[0].SourceBranchCode, new object[] { settlementDate.Day.ToString().PadLeft(2, '0'), settlementDate.Month.ToString().PadLeft(2, '0'), settlementDate.Year.ToString().Substring(2) }) : groupNumber;
                        returnString = groupNumber;

                        TLMORM00009 depodeno = new TLMORM00009();
                        depodeno.GroupNo = groupNumber;
                        depodeno.Tlf_Eno = voucherNo;
                        depodeno.AccountType = WithdrawList[i].AccountNo;
                        depodeno.Amount = WithdrawList[i].Amount;
                        depodeno.Reverse_Status = false;
                        depodeno.Communicationcharge = WithdrawList[i].CommunicationCharges;
                        depodeno.Income = WithdrawList[i].Commission;
                        depodeno.SourceBranchCode = WithdrawList[i].SourceBranchCode;
                        depodeno.Currency = WithdrawList[i].CurrencyCode;
                        depodeno.CreatedUserId = WithdrawList[i].CreatedUserId;
                        depodeno.CreatedDate = DateTime.Now;
                        this.DepoDenoDAO.Save(depodeno);                       
                    }
                    else
                    {                        
                        returnString = voucherNo; 
                    }
                    Rate = CXCOM00010.Instance.GetExchangeRate(WithdrawList[i].CurrencyCode, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType)); 
                    tranTypeDTO = this.GetTranType(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.WithdrawalCode));//CDW
                    TLF_LIST.Add(new PFMDTO00054(voucherNo, decimal.Zero, groupNumber, Rate, tranTypeDTO.Status));
                }

                if (WithdrawList.Count > 0)
                {
                    TLMORM00015 cashDeno = new TLMORM00015();                    
                    cashDeno.TlfEntryNo = string.IsNullOrEmpty(groupNumber) ? voucherNo : groupNumber;
                    cashDeno.DenoEntryNo = null;
                    cashDeno.ReceiptNo = string.Empty;
                    cashDeno.Id = this.CashDenoDAO.SelectMaxId() + 1;
                    cashDeno.Amount = WithdrawList[0].TotalAmount;
                    cashDeno.AdjustAmount = WithdrawList[0].AdjustAmount;
                    cashDeno.AccountType = string.IsNullOrEmpty(groupNumber) ? WithdrawList[0].AccountNo : null ; //*if single, actype is customer acctno,otherwise null*
                    //cashDeno.DenoDetail = WithdrawList[0].DenoString;
                    //cashDeno.DenoRefundDetail = WithdrawList[0].DenoRefundString;
                    cashDeno.UserNo = WithdrawList[0].UserNo;
                    cashDeno.CounterNo = WithdrawList[0].CounterNo;
                    cashDeno.Status = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PaymentCashStatus);
                    cashDeno.Reverse = false;
                    cashDeno.SourceBranchCode = WithdrawList[0].SourceBranchCode;
                    cashDeno.Currency = WithdrawList[0].CurrencyCode;
                    //cashDeno.DenoRate = WithdrawList[0].DenoRateString;
                    // cashDeno.DenoRefundRate = WithdrawList[0].DenoRefundRateString;
                    cashDeno.SettlementDate = settlementDate;
                    //cashDeno.AllDenoRate = withdrawDTO.AllDenoRate;
                    //cashDeno.Rate = withdrawDTO.ExchangeRate;
                    cashDeno.CreatedUserId = Convert.ToInt32(WithdrawList[0].UserNo);
                    cashDeno.CreatedDate = DateTime.Now;
                   
                    this.CashDenoDAO.Save(cashDeno);
                }
                
                return TLF_LIST;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        #endregion

        #region Helper Method

        public DateTime GetSettlementDate(string sourceBranchCode)
        {
          return CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), sourceBranchCode); 
        }

       
        //public TLMDTO00047 CommonDataToSave(IList<TLMDTO00047> WithdrawList)
        //{
        //    //Get Exchange Rateity             
        //    TLMDTO00047 withdrawEntity = new TLMDTO00047();
        //    withdrawEntity.ExchangeRate = CXCOM00010.Instance.GetExchangeRate(WithdrawList[0].CurrencyCode, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType));
        //    //Get All Deno Rate
        //    withdrawEntity.AllDenoRate = CXCOM00010.Instance.GetAllDenoRate(WithdrawList[0].CurrencyCode, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType));
        //    //Get NextSettlemet Date
        //    withdrawEntity.SettlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), WithdrawList[0].SourceBranchCode);
        //    return withdrawEntity;
        //}

        private TLMORM00015 GetCashDeno(string entryNo, decimal amount, decimal adjustAmount, int createdUserId, string counterNo, string currency, DateTime settlementDate, string branchCode, bool isPayement, string acType)            
        {
            cashDeno = new TLMORM00015();
            cashDeno.Id = this.CashDenoDAO.SelectMaxId() + 1;
            cashDeno.TlfEntryNo = entryNo;
            cashDeno.Amount = amount;
            cashDeno.AdjustAmount = adjustAmount;
           // cashDeno.CashDate = System.DateTime.Now;
           // cashDeno.DenoDetail = denoString;
           // cashDeno.DenoRefundDetail = refundString;
           // cashDeno.DenoRate = denoRate;
           // cashDeno.DenoRefundRate = refundRate;
            cashDeno.Status = CXCOM00007.Instance.GetValueByKeyName(isPayement?CXCOM00009.PaymentCashStatus:CXCOM00009.ReceiveCashStatus);
            cashDeno.Reverse = false;
            cashDeno.CreatedDate = System.DateTime.Now;
            cashDeno.CreatedUserId = createdUserId;
            cashDeno.CounterNo = counterNo;
            cashDeno.Currency = currency;
          //  cashDeno.AllDenoRate = allDenoRate;
           // cashDeno.Rate = exchangeRate;
            cashDeno.UserNo = Convert.ToString(createdUserId);
            cashDeno.SettlementDate = settlementDate;
            cashDeno.SourceBranchCode = branchCode;
            //cashDeno.AccountType = acType;

            return cashDeno;
        }
        
        public CXDTO00009 AmountChecking(TLMDTO00047 withdrawEntity)
        {
            string messageNo = string.Empty;
            bool isLink = false;

            //Check Amount
            if (!this.CodeChecker.CheckAmount(withdrawEntity.AccountNo, withdrawEntity.Amount, true, withdrawEntity.IsVIP, true, ref isLink, ref messageNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = messageNo;
                return new CXDTO00009(messageNo, isLink);
            }
            return new CXDTO00009(messageNo, isLink);
        }

        public bool CheckingChequeNo(string accountNo, string chequeNo, string branch)  //Added by ASDA
        {
            if (!chequeNo.Equals(string.Empty) && this.CodeChecker.IsVaildChequeNoforWithdrawal(accountNo, chequeNo, branch))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return false;
            }
            return true;
        }

        //public void ConvertToTlfORM(PFMDTO00054 tlfdto)
        //{            
        //    PFMORM00054 tlf = new PFMORM00054();
        //    tlf.Id = tlfdto.Id;
        //    tlf.Eno = tlfdto.Eno;
        //    tlf.AccountNo = tlfdto.AccountNo;            
        //    tlf.SettlementDate = tlfdto.SettlementDate;
        //    tlf.Amount = tlfdto.Amount;            
        //    tlf.HomeAmount = tlfdto.Amount;
        //    tlf.HomeAmt = tlfdto.Amount;
        //    tlf.HomeOAmt = tlfdto.HomeOAmt;
        //    tlf.LocalAmount = tlfdto.LocalAmount;
        //    tlf.LocalAmt = tlfdto.LocalAmt;
        //    tlf.LocalOAmt = tlfdto.LocalOAmt ;
        //    tlf.Description = tlfdto.Description;
        //    tlf.Narration = tlfdto.Narration;
        //    tlf.Cheque = tlfdto.Cheque;
        //    tlf.DateTime = tlfdto.DateTime;
        //    tlf.Status = tlfdto.Status;
        //    tlf.TransactionCode = tlfdto.TransactionCode;
        //    tlf.AccountSign = tlfdto.AccountSign;
        //    tlf.UserNo = tlfdto.UserNo;
        //    tlf.SourceCurrency = tlf.SourceCurrency;
        //    tlf.Rate = tlfdto.Rate;
        //    tlf.SourceBranchCode = tlfdto.SourceBranchCode;
        //    tlf.Channel = tlfdto.Channel;
        //    tlf.ReferenceType = tlfdto.ReferenceType;
        //    tlf.CreatedDate = tlfdto.CreatedDate;
        //    tlf.CreatedUserId = tlfdto.CreatedUserId;
        //    TLFDao.Update(tlf);
        //}

        #endregion

    }
}

