//----------------------------------------------------------------------
// <copyright file="TLMSVE00003.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>AK</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Core.Utt;
using System.Linq;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Tcm.Ctr.Sve;
//using log4net; //By STP

namespace Ace.Cbs.Tel.Sve
{
    public class TLMSVE00003 : BaseService, ITLMSVE00003
    {
        //private static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName); //By STP
        #region Propertities

        public ICXSVE00002 CodeGenerator { get; set; }
        public ICXSVE00006 CodeChecker { get; set; }
        public ITLMDAO00004 IBLTLFDao { get; set; }
        public ICXSVE00010 SPCommonService { get; set; }
        public IPFMDAO00028 CLedgerDAO { get; set; }
        public ITLMDAO00015 CashDenoDAO { get; set; }
        public IPFMDAO00054 TLFDao { get; set; }
        public ITLMDAO00009 DepoDenoDao { get; set; }
        public PFMDTO00028 CledgerDTO { get; set; }
        public IPFMDAO00029 LinkACDao { get; set; }
        public ILOMDAO00096 hpRegListsDAO { get; set; }
        public IPFMDAO00024 CoaDAO { get; set; }

        string voucherNumber = string.Empty;
        TLMORM00015 CashDenoInfo;
        PFMDTO00029 LinkAcInfo;
        TLMDTO00029 remitBranchDTO;
        TLMDTO00031 zoneDTO;
        TLMORM00004 iblTLFInfo;

        #endregion

        #region Main Methods

        public IList<PFMDTO00001> SelectByAccountNumber(string accountNo,DateTime todaydate)
        {
            IList<PFMDTO00001> customer = null;

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

            ////// Updated by ZMS (12.11.18)for Pristine
            ////// Check ExpiredLoans Account No
            //if (this.CodeChecker.IsExpiredLoansAccount(accountNo, todaydate))
            //{
            //    this.ServiceResult.ErrorOccurred = false;
            //    this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
            //    //return null;
            //    customer[0].ExpiredStatus = true;
            //} 

            //Check FLedger Account
            bool isFAOF = CXServiceWrapper.Instance.Invoke<ICXSVE00006, bool>(x => x.isFAOFAccountNo(accountNo));
            if (isFAOF)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90045"; //Current,Saving,Chart of Account Only.
                return null;
            }
            
                customer = CXServiceWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00001>>(x => x.GetCustomerInfomationByAccountNo(accountNo, false));
                
                //// Updated by ZMS (12.11.18)for Pristine
                //// Check ExpiredLoans Account No
                if (this.CodeChecker.IsExpiredLoansAccount(accountNo, todaydate) && customer != null)
                {
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                    //return null;
                    customer[0].ExpiredStatus = true;
                } 

                if (customer == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00175; // Account Not found.
                }
                else
                {
                    this.CledgerDTO = this.CodeChecker.GetAccountInfoOfCledgerByAccountNo(accountNo);
                    customer[0].BranchCode = CledgerDTO.SourceBranchCode;
                    LinkAcInfo = LinkACDao.SelectLinkAmount(accountNo, accountNo);
                    if (LinkAcInfo == null)
                        customer[0].LinkAmount = 0;
                    else if (LinkAcInfo.MinimumSavingAccountBalance == 0)
                        customer[0].LinkAmount = LinkAcInfo.MinimumCurrentAccountBalance;
                    else if (LinkAcInfo.MinimumCurrentAccountBalance == 0)
                        customer[0].LinkAmount = LinkAcInfo.MinimumSavingAccountBalance;
                }

            return customer;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool DebitInformationCheckingAndLink(TLMDTO00038 transferEntity)
        {
            string messageNo = string.Empty;
            bool isLink = false;

            //if (!transferEntity.ChequeNo.Equals(string.Empty) && this.CodeChecker.IsVaildChequeNoforWithdrawal(transferEntity.AccountNo, transferEntity.ChequeNo, transferEntity.BranchCode))
            //{
            //    this.ServiceResult.ErrorOccurred = true;
            //    this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
            //    return false;
            //}

            //Check Amount
            if (!transferEntity.IsDomesticAccount)
            if (!this.CodeChecker.CheckAmount(transferEntity.AccountNo, transferEntity.Amount + transferEntity.Commissions + transferEntity.CommunicationCharges, true, transferEntity.IsVIP, true, ref isLink, ref messageNo))
            {
                string _m = messageNo;
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = messageNo;
                return false;
            }
            return isLink;
        }

        //Added by HWKO (14-Sep-2017) //For HP Int Prepayment Voucher Entry
        [Transaction(TransactionPropagation.Required)]
        public bool CheckInterestAmountByAcctNo(TLMDTO00038 transferEntity)
        {
            string result = this.hpRegListsDAO.GetTotalIntAmtOfAllTermByAcctNo(transferEntity.AccountNo, transferEntity.BranchCode);
            if (result == "-1") //  There is no hire puchase loan for given account. 
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90185";
                return false;
            }
            if (transferEntity.Amount != Convert.ToDecimal(result))
            {
                return false;
            }
            return true;
        }

        [Transaction(TransactionPropagation.Required)]
        public string SaveLocalTransfer(IList<TLMDTO00038> transferCollection)
        {
            //Logger.Info("TLMSVE00003 - SaveLocalTransfer - Sithuphyo");
            string groupNumber = string.Empty;
            string returnNo, messageNo;
            bool isLink;
            transferCollection = this.GetDataforTransfer(transferCollection);

            foreach (TLMDTO00038 transferEntity in transferCollection)
            {
                returnNo = messageNo = string.Empty;
                isLink = false;
                //Check Cheque No
                if (!transferEntity.ChequeNo.Equals(string.Empty) && this.CodeChecker.IsVaildChequeNoforWithdrawal(transferEntity.AccountNo, transferEntity.ChequeNo, transferEntity.BranchCode))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                    return string.Empty;
                }
                //Check Amount
                if (transferEntity.IsDebit && !transferEntity.IsDomesticAccount)
                if (!this.CodeChecker.CheckAmount(transferEntity.AccountNo, transferEntity.Amount + transferEntity.Commissions + transferEntity.CommunicationCharges, true, transferEntity.IsVIP, true, ref isLink, ref messageNo))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = messageNo;
                    return string.Empty;
                }
            }
            //voucherNumber = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, transferCollection[0].UpdatedUserId.Value, transferCollection[0].FromBranchCode, new object[] { transferCollection[0].NextSettlementDate.Value.Day.ToString().PadLeft(2, '0'), transferCollection[0].NextSettlementDate.Value.Month.ToString().PadLeft(2, '0'), transferCollection[0].NextSettlementDate.Value.Year.ToString().Substring(2) });
            //For Multiple Transfer
            //if (transferCollection.Count > 2)   //This comment scope is according to bug list.
            //{
            //    groupNumber = string.IsNullOrEmpty(groupNumber) ? this.CodeGenerator.GetGenerateCode("GroupVoucher", string.Empty, transferCollection[0].UpdatedUserId.Value, transferCollection[0].FromBranchCode, new object[] { transferCollection[0].NextSettlementDate.Value.Day.ToString().PadLeft(2, '0'), transferCollection[0].NextSettlementDate.Value.Month.ToString().PadLeft(2, '0'), transferCollection[0].NextSettlementDate.Value.Year.ToString().Substring(2) }) : groupNumber;                
            //    string[] strEven = { "0", "2", "4", "6", "8" };
            //    for (int i=0 ; i < transferCollection.Count; i++)
            //    {
            //        string strUserId = transferCollection[i].CreatedUserId.ToString();
            //        string strVoucherType = transferCollection[i].VoucherType.Substring(0, 1);
            //        string str = i.ToString();
            //        foreach (string num in strEven)
            //        {
            //            if (str.Substring(str.Length - 1) == num)
            //            {
            //                voucherNumber = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, transferCollection[0].UpdatedUserId.Value, transferCollection[0].FromBranchCode, new object[] { transferCollection[0].NextSettlementDate.Value.Day.ToString().PadLeft(2, '0'), transferCollection[0].NextSettlementDate.Value.Month.ToString().PadLeft(2, '0'), transferCollection[0].NextSettlementDate.Value.Year.ToString().Substring(2) });
            //            }
            //        }
            //        //Save in DepoDeno with SameGroupNo, Different VoucherNo
            //        TLMORM00009 depodeno = new TLMORM00009();
            //        depodeno.GroupNo = groupNumber;
            //        depodeno.Tlf_Eno = voucherNumber;
            //        depodeno.AccountType = transferCollection[i].AccountNo;
            //        depodeno.Amount = transferCollection[i].Amount;
            //        depodeno.Reverse_Status = false;
            //        depodeno.Communicationcharge = transferCollection[i].CommunicationCharges;
            //        depodeno.Income = transferCollection[i].Commissions;
            //        depodeno.SourceBranchCode = transferCollection[i].BranchCode;
            //        depodeno.Currency = transferCollection[i].Currency;
            //        depodeno.CreatedUserId = transferCollection[i].CreatedUserId;
            //        depodeno.CreatedDate = DateTime.Now;
            //        this.DepoDenoDao.Save(depodeno);

            //        //Transfer voucher in Tlf
            //        returnNo = CXServiceWrapper.Instance.Invoke<ICXSVE00010, string>(x => x.UpdateForTransfer(voucherNumber, transferCollection[i].AccountNo, transferCollection[i].Amount, 0, transferCollection[i].ChequeNo, strVoucherType, transferCollection[i].IsAutoLink, transferCollection[i].Narration, strUserId, transferCollection[0].Currency, transferCollection[0].HomeExchangeRate.Value, transferCollection[0].FromBranchCode, transferCollection[0].NextSettlementDate.Value, transferCollection[0].Channel));
            //    }  
            //}
            //a pair of debit ,Credit Voucher
            //else
            //{
                voucherNumber = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, transferCollection[0].UpdatedUserId.Value, transferCollection[0].FromBranchCode, new object[] { transferCollection[0].NextSettlementDate.Value.Day.ToString().PadLeft(2, '0'), transferCollection[0].NextSettlementDate.Value.Month.ToString().PadLeft(2, '0'), transferCollection[0].NextSettlementDate.Value.Year.ToString().Substring(2) });
                foreach (TLMDTO00038 transferEntity in transferCollection)
                {
                    //returnNo = string.Empty;
                    string strUserId = transferEntity.CreatedUserId.ToString();
                    string strVoucherType = transferEntity.VoucherType.Substring(0, 1);
                    //Transfer voucher in Tlf
                    returnNo = CXServiceWrapper.Instance.Invoke<ICXSVE00010, string>(x => x.UpdateForTransfer(voucherNumber, transferEntity.AccountNo, transferEntity.Amount, 0, transferEntity.ChequeNo, strVoucherType, transferEntity.IsAutoLink, transferEntity.Narration, strUserId, transferCollection[0].Currency, transferCollection[0].HomeExchangeRate.Value, transferCollection[0].FromBranchCode, transferCollection[0].NextSettlementDate.Value, transferCollection[0].Channel));
                    if (this.ServiceResult.ErrorOccurred)
                    {
                        this.ServiceResult.MessageCode = returnNo; // Not Allow Saving Debit Transaction for more than one time in a week
                        //return string.Empty;
                        throw new Exception(this.ServiceResult.MessageCode);
                    }
                }
            //}
            //if(!string.IsNullOrEmpty(groupNumber))
            //    return groupNumber; 
            //else
                return voucherNumber;
        }

        [Transaction(TransactionPropagation.Required)]
        public string SaveOnlineTransfer(IList<TLMDTO00038> transferCollection)
        {

                var debit = from value in transferCollection where value.IsDebit == true select value;
                var credit = from value in transferCollection where value.IsCredit == true select value;

                TLMDTO00038 debitTransactionInfo = debit.ToList<TLMDTO00038>()[0];
                TLMDTO00038 creditTransactionInfo = credit.ToList<TLMDTO00038>()[0];
                transferCollection = this.GetDataforTransfer(transferCollection);
                string strUserId = transferCollection[0].CreatedUserId.ToString();
                int takeIncome = debitTransactionInfo.IsIncomeByCash ? 1 : 2;
                string strVIP = debitTransactionInfo.IsVIP == true ? "1" : "0";

                //remitBranchDTO = CXCOM00011.Instance.GetScalarObject<TLMDTO00029>("RemitBrIBL.Server.SelectByBranch", new object[] { debitTransactionInfo.BranchCode, debitTransactionInfo.FromBranchCode, debitTransactionInfo.Currency });
                remitBranchDTO = CXCOM00011.Instance.GetScalarObject<TLMDTO00029>("RemitBrIBL.Server.SelectByBranch", new object[] { creditTransactionInfo.BranchCode, debitTransactionInfo.BranchCode, debitTransactionInfo.Currency });
                zoneDTO = CXCOM00011.Instance.GetScalarObject<TLMDTO00031>("Zone.Server.SelectByBranch", new object[] { debitTransactionInfo.BranchCode, debitTransactionInfo.FromBranchCode });

                //voucherNumber = this.CodeGenerator.GetGenerateCode("IBLVoucher", string.Empty, debitTransactionInfo.UpdatedUserId.Value, CurrentUserEntity.BranchCode, new object[] { debitTransactionInfo.BranchCode });   
                voucherNumber = this.CodeGenerator.GetGenerateCode("IBLVoucher", string.Empty, debitTransactionInfo.UpdatedUserId.Value, debitTransactionInfo.FromBranchCode, new object[] { debitTransactionInfo.FromBranchCode });

                if (debitTransactionInfo.BranchCode == creditTransactionInfo.BranchCode)
                {
                    if (!CXServiceWrapper.Instance.Invoke<ICXSVE00010, bool>(x => x.TransferSameBarnchVoucher(voucherNumber, creditTransactionInfo.AccountNo, debitTransactionInfo.AccountNo, debitTransactionInfo.ChequeNo, strVIP, debitTransactionInfo.Amount, transferCollection[0].Commissions, transferCollection[0].CommunicationCharges,
                        debitTransactionInfo.BranchCode, creditTransactionInfo.BranchCode, transferCollection[0].FromBranchCode, debitTransactionInfo.IsAutoLink, remitBranchDTO.IBSComAccount, remitBranchDTO.TelaxAccount, takeIncome, debitTransactionInfo.Narration, strUserId, transferCollection[0].Currency,
                        transferCollection[0].HomeExchangeRate.Value, creditTransactionInfo.BranchCode, transferCollection[0].NextSettlementDate.Value, transferCollection[0].Channel)))
                        throw new Exception(CXServiceWrapper.Instance.ServiceResult.MessageCode);
                    else
                        goto end;
                    //return null;
                }
                else
                {
                    //Tlf
                    if (!CXServiceWrapper.Instance.Invoke<ICXSVE00010, bool>(x => x.TransferDebitVoucher(voucherNumber, debitTransactionInfo.AccountNo, strVIP, debitTransactionInfo.Amount, debitTransactionInfo.ChequeNo, "TDV", "TRDEBIT", "TRW",
                        debitTransactionInfo.BranchCode, creditTransactionInfo.BranchCode, creditTransactionInfo.AccountNo, debitTransactionInfo.Commissions,
                        debitTransactionInfo.CommunicationCharges, debitTransactionInfo.IsAutoLink, zoneDTO.AccountCode,
                        remitBranchDTO.IBSComAccount, remitBranchDTO.TelaxAccount, takeIncome,debitTransactionInfo.Narration, strUserId, transferCollection[0].Currency, transferCollection[0].HomeExchangeRate.Value, transferCollection[0].FromBranchCode, transferCollection[0].NextSettlementDate.Value, transferCollection[0].Channel)))
                        throw new Exception(CXServiceWrapper.Instance.ServiceResult.MessageCode);
                    //return null;

                    if (!CXServiceWrapper.Instance.Invoke<ICXSVE00010, bool>(x => x.TransferCreditVoucher(voucherNumber, creditTransactionInfo.AccountNo, creditTransactionInfo.Amount, "TCV", "TRCREDIT", "TRD",
                        debitTransactionInfo.BranchCode, creditTransactionInfo.BranchCode, debitTransactionInfo.AccountNo, debitTransactionInfo.IsAutoLink, remitBranchDTO.IBSComAccount, debitTransactionInfo.Narration, strUserId,
                        transferCollection[0].Currency, transferCollection[0].HomeExchangeRate.Value, transferCollection[0].FromBranchCode, transferCollection[0].NextSettlementDate.Value, transferCollection[0].Channel)))
                        throw new Exception(CXServiceWrapper.Instance.ServiceResult.MessageCode);
                    //return null;
                }

                #region save cashdeno
                 if (takeIncome == 1)
                {
                    CashDenoInfo=new  TLMORM00015();
                    CashDenoInfo=this.GetCashDenoSingle(debitTransactionInfo,voucherNumber);
                    CashDenoDAO.Save(CashDenoInfo);
                }
                #endregion 

                #region IBLTLF Transaction For OnlineTransfer
                //REGISTER BRANCH IS DEBIT BRANCH
                if (transferCollection[0].FromBranchCode == debitTransactionInfo.BranchCode)
                {
                    //Debit Transaction in Register Branch(Debit Branch)
                    iblTLFInfo = new TLMORM00004();
                    iblTLFInfo = this.GetIBLTransactionLogFile(voucherNumber, debitTransactionInfo.AccountNo, debitTransactionInfo.Amount, debitTransactionInfo.Commissions, debitTransactionInfo.CommunicationCharges, "TDV", transferCollection[0].FromBranchCode, debitTransactionInfo.BranchCode, creditTransactionInfo.AccountNo, creditTransactionInfo.BranchCode, transferCollection[0].FromBranchCode, debitTransactionInfo.ChequeNo, transferCollection[0].Currency, transferCollection[0].CreatedUserId.ToString(), false, transferCollection[0].IsIncomeByCash);
                    this.IBLTLFDao.Save(iblTLFInfo);

                    //Credit Transaction in Register Branch(Debit Branch)
                    iblTLFInfo = new TLMORM00004();
                    iblTLFInfo = this.GetIBLTransactionLogFile(voucherNumber, creditTransactionInfo.AccountNo, creditTransactionInfo.Amount, 0, 0, "TCV", transferCollection[0].FromBranchCode, creditTransactionInfo.BranchCode, debitTransactionInfo.AccountNo, debitTransactionInfo.BranchCode, transferCollection[0].FromBranchCode, debitTransactionInfo.ChequeNo, transferCollection[0].Currency, transferCollection[0].CreatedUserId.ToString(), false, transferCollection[0].IsIncomeByCash);
                    this.IBLTLFDao.Save(iblTLFInfo);

                    //Credit Transaction in Credit Branch
                    iblTLFInfo = new TLMORM00004();
                    iblTLFInfo = this.GetIBLTransactionLogFile(voucherNumber, creditTransactionInfo.AccountNo, creditTransactionInfo.Amount, 0, 0, "TCV", transferCollection[0].FromBranchCode, creditTransactionInfo.BranchCode, debitTransactionInfo.AccountNo, debitTransactionInfo.BranchCode, creditTransactionInfo.BranchCode, debitTransactionInfo.ChequeNo, transferCollection[0].Currency, transferCollection[0].CreatedUserId.ToString(), true, transferCollection[0].IsIncomeByCash);
                    this.IBLTLFDao.Save(iblTLFInfo);
                }
                //REGISTER BRANCH IS CREDIT BRANCH
                else if (transferCollection[0].FromBranchCode == creditTransactionInfo.BranchCode)
                {
                    //Credit Transaction in Register Branch(Credit Branch)
                    iblTLFInfo = new TLMORM00004();
                    iblTLFInfo = this.GetIBLTransactionLogFile(voucherNumber, creditTransactionInfo.AccountNo, creditTransactionInfo.Amount, 0, 0, "TCV", transferCollection[0].FromBranchCode, creditTransactionInfo.BranchCode, debitTransactionInfo.AccountNo, debitTransactionInfo.BranchCode, transferCollection[0].FromBranchCode, debitTransactionInfo.ChequeNo, transferCollection[0].Currency, transferCollection[0].CreatedUserId.ToString(), false, transferCollection[0].IsIncomeByCash);
                    this.IBLTLFDao.Save(iblTLFInfo);

                    //Debit Transaction in Register Branch(Credit Branch)
                    iblTLFInfo = new TLMORM00004();
                    iblTLFInfo = this.GetIBLTransactionLogFile(voucherNumber, debitTransactionInfo.AccountNo, debitTransactionInfo.Amount, debitTransactionInfo.Commissions, debitTransactionInfo.CommunicationCharges, "TDV", transferCollection[0].FromBranchCode, debitTransactionInfo.BranchCode, creditTransactionInfo.AccountNo, creditTransactionInfo.BranchCode, transferCollection[0].FromBranchCode, debitTransactionInfo.ChequeNo, transferCollection[0].Currency, transferCollection[0].CreatedUserId.ToString(), false, transferCollection[0].IsIncomeByCash);
                    this.IBLTLFDao.Save(iblTLFInfo);

                    //Debit Transaction in Debit Branch
                    iblTLFInfo = new TLMORM00004();
                    iblTLFInfo = this.GetIBLTransactionLogFile(voucherNumber, debitTransactionInfo.AccountNo, debitTransactionInfo.Amount, debitTransactionInfo.Commissions, debitTransactionInfo.CommunicationCharges, "TDV", transferCollection[0].FromBranchCode, debitTransactionInfo.BranchCode, creditTransactionInfo.AccountNo, creditTransactionInfo.BranchCode, debitTransactionInfo.BranchCode, debitTransactionInfo.ChequeNo, transferCollection[0].Currency, transferCollection[0].CreatedUserId.ToString(), true, transferCollection[0].IsIncomeByCash);
                    this.IBLTLFDao.Save(iblTLFInfo);
                }
                //REGISTER BRANCH IS MEDIUM BRANCH
                else
                {
                    //Debit Transaction in Register Branch
                    iblTLFInfo = new TLMORM00004();
                    iblTLFInfo = this.GetIBLTransactionLogFile(voucherNumber, debitTransactionInfo.AccountNo, debitTransactionInfo.Amount, debitTransactionInfo.Commissions, debitTransactionInfo.CommunicationCharges, "TDV", transferCollection[0].FromBranchCode, debitTransactionInfo.BranchCode, creditTransactionInfo.AccountNo, creditTransactionInfo.BranchCode, transferCollection[0].FromBranchCode, debitTransactionInfo.ChequeNo, transferCollection[0].Currency, transferCollection[0].CreatedUserId.ToString(), false, transferCollection[0].IsIncomeByCash);
                    this.IBLTLFDao.Save(iblTLFInfo);

                    //Credit Transaction in Register Branch
                    iblTLFInfo = new TLMORM00004();
                    iblTLFInfo = this.GetIBLTransactionLogFile(voucherNumber, creditTransactionInfo.AccountNo, creditTransactionInfo.Amount, 0, 0, "TCV", transferCollection[0].FromBranchCode, creditTransactionInfo.BranchCode, debitTransactionInfo.AccountNo, debitTransactionInfo.BranchCode, transferCollection[0].FromBranchCode, debitTransactionInfo.ChequeNo, transferCollection[0].Currency, transferCollection[0].CreatedUserId.ToString(), false, transferCollection[0].IsIncomeByCash);
                    this.IBLTLFDao.Save(iblTLFInfo);

                    //Debit Transaction in Debit Branch
                    iblTLFInfo = new TLMORM00004();
                    iblTLFInfo = this.GetIBLTransactionLogFile(voucherNumber, debitTransactionInfo.AccountNo, debitTransactionInfo.Amount, debitTransactionInfo.Commissions, debitTransactionInfo.CommunicationCharges, "TDV", transferCollection[0].FromBranchCode, debitTransactionInfo.BranchCode, creditTransactionInfo.AccountNo, creditTransactionInfo.BranchCode, debitTransactionInfo.BranchCode, debitTransactionInfo.ChequeNo, transferCollection[0].Currency, transferCollection[0].CreatedUserId.ToString(), true, transferCollection[0].IsIncomeByCash);
                    this.IBLTLFDao.Save(iblTLFInfo);

                    //Credit Transaction in Credit Branch
                    iblTLFInfo = new TLMORM00004();
                    iblTLFInfo = this.GetIBLTransactionLogFile(voucherNumber, creditTransactionInfo.AccountNo, creditTransactionInfo.Amount, 0, 0, "TCV", transferCollection[0].FromBranchCode, creditTransactionInfo.BranchCode, debitTransactionInfo.AccountNo, debitTransactionInfo.BranchCode, creditTransactionInfo.BranchCode, debitTransactionInfo.ChequeNo, transferCollection[0].Currency, transferCollection[0].CreatedUserId.ToString(), true, transferCollection[0].IsIncomeByCash);
                    this.IBLTLFDao.Save(iblTLFInfo);
                }
                #endregion
                //SPCommonService.IBL_Voucher(voucherNumber, remitBranchDTO.IBSComAccount, debitTransactionInfo.Amount, string.Empty, string.Empty, "1", string.Empty, string.Empty, debitTransactionInfo.Commissions, debitTransactionInfo.CommunicationCharges, 1,
                //   remitBranchDTO.IBSComAccount, remitBranchDTO.TelaxAccount, transferCollection[0].CreatedUserId.ToString(), transferCollection[0].Currency, transferCollection[0].Currency, transferCollection[0].HomeExchangeRate.Value, transferCollection[0].FromBranchCode, transferCollection[0].NextSettlementDate.Value, transferCollection[0].Channel);
                
                end:
                //if (debitTransactionInfo.Commissions + debitTransactionInfo.CommunicationCharges > 0 && transferCollection[0].IsIncomeByCash)
                //confirm by ma KSWin (17-12/2014)   to save cashdeno 
                if (debitTransactionInfo.Commissions + debitTransactionInfo.CommunicationCharges > 0 && takeIncome==1)   
                    this.CashDenoDAO.Save(this.GetCashDeno(transferCollection[0], string.Empty, voucherNumber));
                
                return voucherNumber;
        }


        //Added by HWKO (15-Sep-2017) //For HP Int Prepayment Voucher Entry
        public ChargeOfAccountDTO GetCOAByAcode(string acode, string sourceBr)
        {
            return this.CoaDAO.SelectByCode(acode, sourceBr);
        }

        //Added by HWKO (14-Sep-2017)
        [Transaction(TransactionPropagation.Required)]
        public string SaveHPIntPrepaymentVoucher(IList<TLMDTO00038> transferCollection)
        {
            string groupNumber = string.Empty;
            string returnNo, messageNo;
            bool isLink;
            transferCollection = this.GetDataforTransfer(transferCollection);

            foreach (TLMDTO00038 transferEntity in transferCollection)
            {
                returnNo = messageNo = string.Empty;
                isLink = false;
                //Check Amount
                if (transferEntity.IsDebit && !transferEntity.IsDomesticAccount)
                {
                    if (!this.CodeChecker.CheckAmount(transferEntity.AccountNo, transferEntity.Amount + transferEntity.Commissions + transferEntity.CommunicationCharges, true, transferEntity.IsVIP, true, ref isLink, ref messageNo))
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = messageNo;
                        return string.Empty;
                    }
                }
            }

            voucherNumber = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, transferCollection[0].UpdatedUserId.Value, transferCollection[0].FromBranchCode, new object[] { transferCollection[0].NextSettlementDate.Value.Day.ToString().PadLeft(2, '0'), transferCollection[0].NextSettlementDate.Value.Month.ToString().PadLeft(2, '0'), transferCollection[0].NextSettlementDate.Value.Year.ToString().Substring(2) });
            foreach (TLMDTO00038 transferEntity in transferCollection)
            {
                if (transferEntity.IsDebit)
                {
                    //returnNo = string.Empty;
                    string strUserId = transferEntity.CreatedUserId.ToString();
                    string strVoucherType = transferEntity.VoucherType.Substring(0, 1);
                    //Transfer voucher in Tlf
                    returnNo = CXServiceWrapper.Instance.Invoke<ICXSVE00010, string>(x => x.UpdateForHPIntPrepaymentVoucher(voucherNumber, transferEntity.AccountNo, transferEntity.Amount, transferEntity.Narration, strUserId, transferCollection[0].Currency, transferCollection[0].FromBranchCode, transferCollection[0].NextSettlementDate.Value, transferCollection[0].Channel));
                    if (this.ServiceResult.ErrorOccurred)
                    {
                        this.ServiceResult.MessageCode = returnNo; // Not Allow Saving Debit Transaction for more than one time in a week
                        //return string.Empty;
                        throw new Exception(this.ServiceResult.MessageCode);
                    }
                }
                else
                {
                    this.hpRegListsDAO.UpdateRentalChargesInTermByAcctNo(transferEntity.AccountNo, transferEntity.BranchCode);
                }
            }
            return voucherNumber;
        }

        //Added By AAM (31_July_2018)
        public IList<PFMDTO00001> SelectByAccountNumber_ForAllowCrTrans(string accountNo, DateTime todaydate)
        {
            IList<PFMDTO00001> customer=null;
            customer = CXServiceWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00001>>(x => x.GetCustomerInfomationByAccountNo(accountNo, false));
            if (this.CodeChecker.IsExpiredLoansAccount_ForAllowCrTrans(accountNo, todaydate))
            {
                customer[0].ExpiredLoansStatus = true;
            }

            return customer;
        }

        #endregion

        #region Helper Methods


        private TLMORM00004 GetIBLTransactionLogFile(string voucherNo, string accountNo, decimal amount, decimal income, decimal communicationCharges, string status, string fromBranch, string toBranch,string relatedAccount,string relatedBranch,string sourceBranch,string cheque, string currencyCode, string userNo,bool inOut,bool isIncomeByCash)
        {
            TLMORM00004 iblTlf = new TLMORM00004();

            iblTlf.Eno = voucherNo;
            iblTlf.Id = IBLTLFDao.SelectMaxId()+1;
            iblTlf.AccountNo = accountNo;
            iblTlf.FromBranch = fromBranch;
            iblTlf.ToBranch = toBranch;
            iblTlf.Amount = amount;
            iblTlf.TranType = status;
            iblTlf.Date_Time = DateTime.Now;
            iblTlf.InOut = inOut;
            iblTlf.Success = true;
            iblTlf.Income = income;
            iblTlf.Communicationcharge = communicationCharges;
            if (income + communicationCharges > 0)
            {
                iblTlf.IncomeType = isIncomeByCash ? 1 : 2;
            }
            else
            {
                iblTlf.IncomeType = 0;
            }
            iblTlf.Cheque = string.IsNullOrEmpty(cheque) ? null : cheque;
            iblTlf.UserNo = userNo;
            iblTlf.Reversal = false;
            iblTlf.RelatedAccount = relatedAccount;
            iblTlf.RelatedBranch = relatedBranch;
            iblTlf.Currency = currencyCode;
            iblTlf.SourceBranchCode = sourceBranch;
            iblTlf.CreatedUserId = Convert.ToInt32(userNo);

            return iblTlf;
        }

        private TLMORM00015 GetCashDeno(TLMDTO00038 info, string groupNo, string voucherNo)
        {
            CashDenoInfo = new TLMORM00015();
            CashDenoInfo.Id = this.CashDenoDAO.SelectMaxId() + 1;
            CashDenoInfo.TlfEntryNo = groupNo == string.Empty ? voucherNo : groupNo;
            //CashDenoInfo.Amount = info.TotalAmount;
            CashDenoInfo.Amount = info.Commissions + info.CommunicationCharges;
            CashDenoInfo.AdjustAmount = info.AdjustAmount;
            //CashDenoInfo.CashDate = System.DateTime.Now;
            CashDenoInfo.CashDate = CashDenoInfo.CashDate;
            CashDenoInfo.DenoDetail = info.DenoString;
            CashDenoInfo.DenoRefundDetail = info.RefundString;
            CashDenoInfo.DenoRate = info.DenoRate;
            CashDenoInfo.DenoRefundRate = info.RefundRate;
            CashDenoInfo.Status = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);
            CashDenoInfo.Reverse = false;
            CashDenoInfo.CreatedDate = System.DateTime.Now;
            CashDenoInfo.CreatedUserId = info.CreatedUserId;
            CashDenoInfo.CounterNo = info.CounterNo;
            CashDenoInfo.Currency = info.Currency;
            CashDenoInfo.AllDenoRate = info.AllDenoRate;
            CashDenoInfo.Rate = info.HomeExchangeRate;
            CashDenoInfo.UserNo = info.CreatedUserId.ToString();
            CashDenoInfo.SettlementDate = info.NextSettlementDate;
            CashDenoInfo.SourceBranchCode = info.FromBranchCode;

            return CashDenoInfo;
        }

        private TLMORM00015 GetCashDenoSingle(TLMDTO00038 info, string voucherNo)
        {
            CashDenoInfo = new TLMORM00015();
            CashDenoInfo.Id = this.CashDenoDAO.SelectMaxId() + 1;
            CashDenoInfo.TlfEntryNo = voucherNo;
            CashDenoInfo.Amount = info.Commissions+info.CommunicationCharges;
            CashDenoInfo.AdjustAmount = info.AdjustAmount;
            CashDenoInfo.Status = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);
            CashDenoInfo.Reverse = false;
            CashDenoInfo.CreatedDate = System.DateTime.Now;
            CashDenoInfo.CreatedUserId = info.CreatedUserId;
            CashDenoInfo.CounterNo = info.CounterNo;
            CashDenoInfo.Currency = info.Currency;
            CashDenoInfo.Rate = info.HomeExchangeRate;
            CashDenoInfo.UserNo = info.CreatedUserId.ToString();
            CashDenoInfo.SettlementDate = info.NextSettlementDate;
            CashDenoInfo.SourceBranchCode = info.FromBranchCode;

            return CashDenoInfo;
        }

        private IList<TLMDTO00038> GetDataforTransfer(IList<TLMDTO00038> transferCollection)
        {           
            var credit = from value in transferCollection where value.IsCredit == true select value;
            
            TLMDTO00038 creditTransactionInfo = credit.ToList<TLMDTO00038>()[0];
            for (int i = 0; i < transferCollection.Count; i++)
            {
                transferCollection[i].ToCurrency = creditTransactionInfo.Currency; 
            }
            foreach (TLMDTO00038 transferEntity in transferCollection)
            {
                transferEntity.HomeExchangeRate = CXCOM00010.Instance.GetExchangeRate(transferEntity.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType));
                transferEntity.AllDenoRate = CXCOM00010.Instance.GetAllDenoRate(transferEntity.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType), transferEntity.ToCurrency);
                //transferEntity.NextSettlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), transferEntity.FromBranchCode);

                //Added by HMW (25-Mar-2019) : For Seperating EOD (2 Times EOD ==> At Current Day EOD, At Tomorrow Morning BOD)
                try
                {
                    for (int j = 0; j < transferCollection.Count; j++)
                    {
                        //Getting Last Settlement Date            
                        string lastSDate = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.LastSettlementDate);
                        PFMDTO00056 sysDTO = CXServiceWrapper.Instance.Invoke<IMNMSVE00004, PFMDTO00056>(x => x.SelectSysDate(lastSDate, transferEntity.FromBranchCode));
                        transferCollection[j].LastSettlementDate = sysDTO.SysDate;
                        string dateOnly = string.Format("{0:yyyy'-'MM'-'dd}", transferCollection[j].LastSettlementDate);
                        transferCollection[j].LastSettlementDate = Convert.ToDateTime(dateOnly + " " + "23:59:00.000"); //Getting the format (2019-03-28 11:59:00.000)
                        DateTime transactionDate = Convert.ToDateTime(dateOnly + " " + "23:59:01.000"); //Getting the format (2019-03-28 11:59:01.000)

                        //Getting System Startup Date
                        TCMDTO00001 startDTO = CXServiceWrapper.Instance.Invoke<ITCMSVE00014, TCMDTO00001>(x => x.SelectStartBySourceBr(transferEntity.FromBranchCode));
                        if (startDTO == null)
                        {
                            this.ServiceResult.ErrorOccurred = true;
                            this.ServiceResult.MessageCode = "ME90047";//System Start Up File has no record.
                            return new List<TLMDTO00038>();
                        }
                        else
                        {
                            if (startDTO.Status == "C")
                            {
                                transferCollection[j].SystemStartupDate = startDTO.Date;
                            }
                        }

                        //Getting Next Settlement Date
                        if ((string.Format("{0:MM/dd/yyyy}", transferCollection[j].SystemStartupDate) == string.Format("{0:MM/dd/yyyy}", transferCollection[j].LastSettlementDate)))
                        {
                            //Case-1 : TXN at Tomorrow BOD 
                            if (string.Format("{0:MM/dd/yyyy}", transferCollection[j].LastSettlementDate) != DateTime.Now.ToString("MM/dd/yyyy"))
                            {
                                transferCollection[j].NextSettlementDate = transferCollection[j].LastSettlementDate;   //2019-03-22 23:59:00.000
                                transferCollection[j].TransactionDate = transactionDate; //Convert.ToDateTime(transferCollection[j].LastSettlementDate);//2019-03-22 23:59:00.000                                
                            }
                            //Case-2 : TXN at Current Day EOD (After Cut Off)
                            else
                            {
                                transferCollection[j].NextSettlementDate = transferCollection[j].LastSettlementDate; //2019-03-22 23:59:00.000
                                transferCollection[j].TransactionDate = DateTime.Now;
                            }
                        }
                        //Case-3 : TXN at Current Day EOD (Before Cut Off)
                        else
                        {
                            transferCollection[j].NextSettlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), transferCollection[j].FromBranchCode);//2019-03-25 17:46:59.077
                            transferCollection[j].TransactionDate = DateTime.Now;
                        }
                    }
                }
                catch (Exception)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00064;
                    return new List<TLMDTO00038>();
                }                
            }
            return transferCollection;
        }

        

        #endregion

    }
}
