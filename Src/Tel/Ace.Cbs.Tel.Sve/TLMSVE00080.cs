using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXServer.Utt;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tcm.Ctr.Dao;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Tcm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Mnm.Ctr.Sve;

namespace Ace.Cbs.Tel.Sve
{
    public class TLMSVE00080 : BaseService, ITLMSVE00080
    {
        #region Propertities

        public ICXSVE00002 CodeGenerator { get; set; }
        public ICXSVE00006 CodeChecker { get; set; }
        public ITLMDAO00004 IBLTLFDao { get; set; }
        public IPFMDAO00028 CLedgerDAO { get; set; }
        public ITLMDAO00015 CashDenoDAO { get; set; }
        public IPFMDAO00054 TLFDao { get; set; }
        public ITLMDAO00009 DepoDenoDao { get; set; }
        public PFMDTO00028 CledgerDTO { get; set; }
        public IPFMDAO00043 PrnFileDAO { get; set; }
        public ICXSVE00003 PrintingDAO { get; set; }
        public IPFMDAO00056 SysDAO { get; set; } //Added by HMW (25-Mar-2019) : To perform backdate TXN for Seperating EOD
        public TCMDTO00001 StartDTO { get; set; }//Added by HMW (25-Mar-2019) : To perform backdate TXN for Seperating EOD

        string groupNumber = string.Empty;
        string voucherNumber = string.Empty;
        TLMORM00015 CashDenoInfo;
        TLMORM00009 DepoDenoInfo;
        //PFMORM00043 PrnFileInfo;
        IList<TLMDTO00038> depositList;
        DateTime transactionDate;// Added by HMW (28-Mar-2019)

        #endregion

        #region Main Methods

        public IList<PFMDTO00001> SelectByAccountNumber(string accountNo)
        {
            IList<PFMDTO00001> customer = null;

            // Check saving account no is already closed or not.
            if (this.CodeChecker.IsClosedAccountForCLedger(accountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return customer;
            }

            // Check Freesze Account No
            if (this.CodeChecker.IsFreezeAccount(accountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return customer;
            }

            customer = CXServiceWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00001>>(x => x.GetCustomerInfomationByAccountNo(accountNo, false));

            if (customer == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00175; // Account Not found.
            }
            else if (customer.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00175; // Account Not found.
            }

            return customer;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00054> SaveDepositLocal(IList<TLMDTO00038> DepositCollection, TLMDTO00038 depositInfo)
        {
            IList<PFMDTO00054> TLF_LIST = new List<PFMDTO00054>();
            depositList = DepositCollection;
            if (!this.CheckAccountList(depositList))
                return null;

            depositInfo = this.GetDataToSave(depositInfo);

            if (DepositCollection.Count > 1)
                groupNumber = this.CodeGenerator.GetGenerateCode("GroupVoucher", string.Empty, depositInfo.UpdatedUserId.Value, depositInfo.FromBranchCode, new object[] { depositInfo.NextSettlementDate.Value.Day.ToString().PadLeft(2, '0'), depositInfo.NextSettlementDate.Value.Month.ToString().PadLeft(2, '0'), depositInfo.NextSettlementDate.Value.Year.ToString().Substring(2) });
            //groupNumber = this.CodeGenerator.GetGenerateCode("GroupVoucher", string.Empty, depositInfo.UpdatedUserId.Value, CurrentUserEntity.BranchCode, new object[] { depositInfo.NextSettlementDate.Value.Day.ToString().PadLeft(2, '0'), depositInfo.NextSettlementDate.Value.Month.ToString().PadLeft(2, '0'), depositInfo.NextSettlementDate.Value.Year.ToString().Substring(2) });

            foreach (TLMDTO00038 depositEntity in DepositCollection)
            {
                PFMORM00054 debitTransactionLog = null;
                //PrnFileInfo = null;

                ////if (DepositCollection.Count > 1)
                ////    voucherNumber = groupNumber;
                ////else
                voucherNumber = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, depositInfo.UpdatedUserId.Value, depositInfo.FromBranchCode, new object[] { depositInfo.NextSettlementDate.Value.Day.ToString().PadLeft(2, '0'), depositInfo.NextSettlementDate.Value.Month.ToString().PadLeft(2, '0'), depositInfo.NextSettlementDate.Value.Year.ToString().Substring(2) });
                //voucherNumber = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, depositInfo.UpdatedUserId.Value, depositInfo.FromBranchCode, new object[] { depositInfo.NextSettlementDate.Value.Day.ToString().PadLeft(2, '0'), depositInfo.NextSettlementDate.Value.Month.ToString().PadLeft(2, '0'), depositInfo.NextSettlementDate.Value.Year.ToString().Substring(2) });
                //voucherNumber = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, depositInfo.UpdatedUserId.Value, CurrentUserEntity.BranchCode, new object[] { depositInfo.NextSettlementDate.Value.Day.ToString().PadLeft(2, '0'), depositInfo.NextSettlementDate.Value.Month.ToString().PadLeft(2, '0'), depositInfo.NextSettlementDate.Value.Year.ToString().Substring(2) });

                depositInfo.HomeExchangeRate = CXCOM00010.Instance.GetExchangeRate(depositEntity.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType));
                debitTransactionLog = this.GetTransactionLogFile(voucherNumber, depositEntity.AccountNo, false, depositEntity.Amount, depositEntity.Amount, 0, "", depositEntity.Name,
               CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NarrationForDeposit) + depositEntity.Narration, transactionDate, "CCD", "DEPOSIT", depositEntity.AccountSign, depositEntity.BranchCode, depositEntity.Currency, depositInfo.HomeExchangeRate.Value, "", depositInfo.Channel, depositInfo.UpdatedUserId.Value.ToString(), depositInfo.NextSettlementDate.Value);
                if (debitTransactionLog == null)
                {
                    // Update Error
                    throw new Exception(CXMessage.MV20035); //Account Code not found in file.
                }
                // Update CLedger => CloseDate and MinBal
                PFMDTO00028 cledger = CXServiceWrapper.Instance.Invoke<ICXSVE00006, PFMDTO00028>(x => x.GetAccountInfoOfCledgerByAccountNo(depositEntity.AccountNo));

                if (this.CLedgerDAO.UpdateCurrentBalance(depositEntity.AccountNo, depositEntity.Amount + cledger.CurrentBal, ++cledger.TransactionCount, depositInfo.UpdatedUserId.Value, depositInfo.UpdatedUserId.ToString()) == false)
                {
                    // Update Error
                    throw new Exception(CXMessage.ME90001);
                }
                //PrnFileInfo = this.GetPRNFile(depositEntity, depositInfo, cledger.CurrentBal);
                //PrnFileInfo.PrintLineNo = cledger.PrintLineNo;
                if (DepositCollection.Count > 1)
                {
                    depositEntity.CreatedUserId = depositInfo.CreatedUserId;
                    this.DepoDenoDao.Save(this.GetDepoDeno(depositEntity, groupNumber, voucherNumber, depositInfo.FromBranchCode));
                }
                else depositInfo.AccountNo = depositEntity.AccountNo;

                this.TLFDao.Save(debitTransactionLog);
                //if (depositEntity.AccountSign.Substring(0, 1) == "S")
                //{
                //    this.PrnFileDAO.Save(PrnFileInfo);
                //}
                TLF_LIST.Add(new PFMDTO00054(voucherNumber, decimal.Zero, groupNumber, depositInfo.HomeExchangeRate.Value, "CCD"));
            }

            this.CashDenoDAO.Save(this.GetCashDeno(depositInfo, groupNumber, voucherNumber));

            return TLF_LIST;
        }      
        #endregion

        #region Helper Methods

        private bool CheckAccountList(IList<TLMDTO00038> depositInforList)
        {
            foreach (TLMDTO00038 info in depositInforList)
            {
                PFMDTO00028 customerLedger = null;

                // Check saving account no is already closed or not.
                if (this.CodeChecker.IsClosedAccountForCLedger(info.AccountNo))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                    ServiceResult.MessageCode += "," + info.AccountNo;
                    return false;
                }
                // Check Freesze Account No
                if (this.CodeChecker.IsFreezeAccount(info.AccountNo))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                    ServiceResult.MessageCode += "," + info.AccountNo;
                    return false;
                }
                customerLedger = this.CodeChecker.GetAccountInfoOfCledgerByAccountNo(info.AccountNo);

                if (customerLedger == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00175; // Account Not found.
                    ServiceResult.MessageCode += "," + info.AccountNo;
                    return false;
                }

            }
            return true;
        }

        private TLMDTO00038 GetDataToSave(TLMDTO00038 depositEntity)
        {
            depositEntity.HomeExchangeRate = CXCOM00010.Instance.GetExchangeRate(depositEntity.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType));
            depositEntity.AllDenoRate = CXCOM00010.Instance.GetAllDenoRate(depositEntity.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType), depositEntity.Currency);
            //depositEntity.NextSettlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), depositEntity.FromBranchCode);

            //Added by HMW (25-Mar-2019) : For Seperating EOD
            //Getting Last Settlement Date            
            string lastSDate = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.LastSettlementDate);
            PFMDTO00056 sysDTO = CXServiceWrapper.Instance.Invoke<IMNMSVE00004, PFMDTO00056>(x => x.SelectSysDate(lastSDate, depositEntity.FromBranchCode));
            depositEntity.LastSettlementDate = sysDTO.SysDate;
            string dateOnly = string.Format("{0:yyyy'-'MM'-'dd}", depositEntity.LastSettlementDate);
            depositEntity.LastSettlementDate = Convert.ToDateTime(dateOnly + " " + "23:59:00.000"); //Getting the format (2019-03-28 11:59:00.000)

            //Getting System Startup Date
            TCMDTO00001 startDTO = CXServiceWrapper.Instance.Invoke<ITCMSVE00014, TCMDTO00001>(x => x.SelectStartBySourceBr(depositEntity.FromBranchCode));
            if (startDTO == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90047";//System Start Up File has no record.
                return null;
            }
            else
            {
                if (startDTO.Status == "C")
                {
                    depositEntity.SystemStartupDate = startDTO.Date;
                }
            }

            //Getting Next Settlement Date
            if ((string.Format("{0:MM/dd/yyyy}", depositEntity.SystemStartupDate) == string.Format("{0:MM/dd/yyyy}", depositEntity.LastSettlementDate)))
            {
                //Case-1 : TXN at Tomorrow BOD 
                if (string.Format("{0:MM/dd/yyyy}", depositEntity.LastSettlementDate) != DateTime.Now.ToString("MM/dd/yyyy"))
                {
                    depositEntity.NextSettlementDate = depositEntity.LastSettlementDate;   //2019-03-22 23:59:00.000
                    transactionDate = Convert.ToDateTime(depositEntity.LastSettlementDate);//2019-03-22 23:59:00.000
                }
                //Case-2 : TXN at Current Day EOD (After Cut Off)
                else
                {
                    depositEntity.NextSettlementDate = depositEntity.LastSettlementDate; //2019-03-22 23:59:00.000
                    transactionDate = DateTime.Now;
                }
            }
            //Case-3 : TXN at Current Day EOD (Before Cut Off)
            else
            {
                //depositEntity.NextSettlementDate = Convert.ToDateTime(CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), depositEntity.FromBranchCode).ToShortDateString());//2019-03-25 00:00:00.000 (hh:mm:ss should be zero to fix reversal validation checking)
                
                #region Change_Code             

                DateTime nextSettlemntDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), depositEntity.FromBranchCode);
                depositEntity.NextSettlementDate = Convert.ToDateTime(nextSettlemntDate.ToShortDateString());
                #endregion 

                transactionDate = DateTime.Now;

            }

            try
            {   
                
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME00064;
                return null;
            }

            return depositEntity;
        }

        [Transaction()]
        private PFMORM00054 GetTransactionLogFile(string voucherNo, string accountNo, bool isSameACodeandAccountNo, decimal amount, decimal netAmount, decimal overdraftAmount, string chequeNo,
            string description, string narration, DateTime transactionDate, string status, string transactionCode, string accountSignature, string branchCode, string currencyCode,
            decimal homeRate, string referenceType, string channel, string userNo, DateTime nextSettlementDate)
        {
            PFMORM00054 tlf = new PFMORM00054();

            tlf.Eno = voucherNo;

            if (isSameACodeandAccountNo == false && accountSignature.Length > 0)
            {
                switch (accountSignature[0])
                {
                    case 'B':
                        tlf.Acode = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.BLControl), branchCode, currencyCode);
                        break;
                    case 'P':
                        tlf.Acode = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PLControl), branchCode, currencyCode);
                        break;
                    case 'H':
                        tlf.Acode = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.HPControl), branchCode, currencyCode);
                        break;
                    case 'D':
                        tlf.Acode = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.DLControl), branchCode, currencyCode);
                        break; 
                }
            }
            else
            {
                tlf.Acode = accountNo;
            }

            if (tlf.Acode == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                return null;
            }

            tlf.AccountNo = accountNo;
            tlf.Id = this.TLFDao.SelectMaxId() + 1;
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
            tlf.DateTime = transactionDate;
            tlf.Status = status;
            tlf.TransactionCode = transactionCode;
            tlf.AccountSign = accountSignature;
            tlf.UserNo = userNo;
            tlf.SourceCurrency = currencyCode;
            tlf.Rate = homeRate;
            tlf.SourceBranchCode = branchCode;
            tlf.Channel = channel;
            tlf.ReferenceType = referenceType;
            tlf.CreatedDate = transactionDate;
            tlf.CreatedUserId = Convert.ToInt32(userNo);

            return tlf;
        }

        private TLMORM00015 GetCashDeno(TLMDTO00038 depositInfo, string groupNo, string voucherNo)
        {
            CashDenoInfo = new TLMORM00015();
            CashDenoInfo.Id = this.CashDenoDAO.SelectMaxId() + 1;
            CashDenoInfo.TlfEntryNo = groupNo == string.Empty ? voucherNo : groupNo;
            CashDenoInfo.AccountType = (!string.IsNullOrEmpty(groupNo)) ? string.Empty : depositInfo.AccountNo;
            //CashDenoInfo.AccountType = depositInfo.AccountNo;
            CashDenoInfo.Amount = depositInfo.TotalAmount;
            CashDenoInfo.AdjustAmount = depositInfo.AdjustAmount;
            CashDenoInfo.CashDate = transactionDate;
            CashDenoInfo.DenoDetail = depositInfo.DenoString;
            CashDenoInfo.DenoRefundDetail = depositInfo.RefundString;
            CashDenoInfo.DenoRate = depositInfo.DenoRate;
            CashDenoInfo.DenoRefundRate = depositInfo.RefundRate;
            CashDenoInfo.Status = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);
            CashDenoInfo.Reverse = false;
            CashDenoInfo.CreatedDate = transactionDate;
            CashDenoInfo.CreatedUserId = depositInfo.CreatedUserId;
            CashDenoInfo.CounterNo = depositInfo.CounterNo;
            CashDenoInfo.Currency = depositInfo.Currency;
            CashDenoInfo.AllDenoRate = depositInfo.AllDenoRate;
            CashDenoInfo.Rate = depositInfo.HomeExchangeRate;
            CashDenoInfo.UserNo = depositInfo.CreatedUserId.ToString();
            CashDenoInfo.SettlementDate = depositInfo.NextSettlementDate;
            CashDenoInfo.SourceBranchCode = depositInfo.FromBranchCode;

            return CashDenoInfo;
        }

        private TLMORM00009 GetDepoDeno(TLMDTO00038 depositInfo, string groupNo, string voucherNo, string branchCode)
        {
            DepoDenoInfo = new TLMORM00009();

            DepoDenoInfo.GroupNo = groupNo;
            DepoDenoInfo.Tlf_Eno = voucherNo;
            DepoDenoInfo.AccountType = depositInfo.AccountNo;
            DepoDenoInfo.Amount = depositInfo.Amount;
            DepoDenoInfo.Currency = depositInfo.Currency;
            DepoDenoInfo.Communicationcharge = depositInfo.CommunicationCharges;
            DepoDenoInfo.Income = depositInfo.Commissions;
            DepoDenoInfo.Reverse_Status = false;
            DepoDenoInfo.SourceBranchCode = branchCode;
            // DepoDenoInfo.CreatedUserId = CurrentUserEntity.CurrentUserID;
            DepoDenoInfo.CreatedUserId = depositInfo.CreatedUserId;
            DepoDenoInfo.CreatedDate = transactionDate;

            return DepoDenoInfo;
        }

        //[Transaction(TransactionPropagation.Required)]
        //public IList<PFMDTO00054> SaveDepositOnline(IList<TLMDTO00038> DepositCollection, TLMDTO00038 depositInfo, string sourceBr)
        //{
        //    IList<PFMDTO00054> TLF_LIST = new List<PFMDTO00054>();
        //    depositList = DepositCollection;
        //    if (!this.CheckAccountList(depositList))
        //        return null;

        //    depositInfo = this.GetDataToSave(depositInfo);

        //    if (DepositCollection.Count > 1)
        //    {
        //        groupNumber = this.CodeGenerator.GetGenerateCode("GroupVoucher", string.Empty, depositInfo.UpdatedUserId.Value, depositInfo.FromBranchCode, new object[] { depositInfo.NextSettlementDate.Value.Day.ToString().PadLeft(2, '0'), depositInfo.NextSettlementDate.Value.Month.ToString().PadLeft(2, '0'), depositInfo.NextSettlementDate.Value.Year.ToString().Substring(2) });
        //        //groupNumber = this.CodeGenerator.GetGenerateCode("GroupVoucher", string.Empty, depositInfo.UpdatedUserId.Value, CurrentUserEntity.BranchCode, new object[] { depositInfo.NextSettlementDate.Value.Day.ToString().PadLeft(2, '0'), depositInfo.NextSettlementDate.Value.Month.ToString().PadLeft(2, '0'), depositInfo.NextSettlementDate.Value.Year.ToString().Substring(2) });
        //    }

        //    foreach (TLMDTO00038 depositEntity in DepositCollection)
        //    {
        //        TLMORM00004 iblTransactionLog = null;
        //        string code, referenceCode = string.Empty;
        //        TLMDTO00005 tranTypeDTO = null;
        //        TLMDTO00031 zoneDTO = null;
        //        TLMDTO00029 remitBranchDTO = null;
        //        string strUserId = depositInfo.CreatedUserId.ToString();

        //        voucherNumber = this.CodeGenerator.GetGenerateCode("IBLVoucher", string.Empty, depositInfo.UpdatedUserId.Value, depositInfo.FromBranchCode, new object[] { depositInfo.FromBranchCode });
        //        //voucherNumber = this.CodeGenerator.GetGenerateCode("IBLVoucher", string.Empty, depositInfo.UpdatedUserId.Value, CurrentUserEntity.BranchCode, new object[] { depositInfo.FromBranchCode });

        //        code = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.DepositCode); //CXCOM00009.Deposit
        //        tranTypeDTO = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { "CSCREDIT" });
        //        //zoneDTO = CXCOM00011.Instance.GetScalarObject<TLMDTO00031>("Zone.Server.SelectByBranch", new object[] { (depositInfo.AccountNo), depositInfo.FromBranchCode });
        //        zoneDTO = CXCOM00011.Instance.GetScalarObject<TLMDTO00031>("Zone.Server.SelectByBranch", new object[] { depositEntity.BranchCode, depositInfo.FromBranchCode });
        //        remitBranchDTO = CXCOM00011.Instance.GetScalarObject<TLMDTO00029>("RemitBrIBL.Server.SelectByBranch", new object[] { depositEntity.BranchCode, depositInfo.FromBranchCode, depositInfo.Currency });
        //        //remitBranchDTO = CXCOM00011.Instance.GetScalarObject<TLMDTO00029>("RemitBrIBL.Server.SelectByBranch", new object[] { depositInfo.FromBranchCode, depositInfo.FromBranchCode, depositInfo.Currency });
        //        referenceCode = tranTypeDTO.PBReference;

        //        if (!CXServiceWrapper.Instance.Invoke<ICXSVE00010, bool>(x => x.IBL_Voucher(voucherNumber, zoneDTO.AccountCode, depositEntity.Amount, tranTypeDTO.Status, tranTypeDTO.TransactionCode, "1", string.Empty, string.Empty, depositEntity.Commissions, depositEntity.CommunicationCharges, 1,
        //            remitBranchDTO.IBSComAccount, remitBranchDTO.TelaxAccount, strUserId, depositInfo.Currency, depositInfo.Currency, depositInfo.HomeExchangeRate.Value, depositInfo.FromBranchCode, depositInfo.NextSettlementDate.Value, depositInfo.Channel)))
        //        {
        //            this.ServiceResult.ErrorOccurred = true;
        //            this.ServiceResult.MessageCode = CXServiceWrapper.Instance.ServiceResult.MessageCode;
        //            throw new Exception(this.ServiceResult.MessageCode);
        //            //return null;
        //        }

        //        code = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferCreditVoucherCode);//CXCOM00009.TransferCreditVoucherCode
        //        tranTypeDTO = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { code });
        //        referenceCode = tranTypeDTO.PBReference;
        //        zoneDTO = CXCOM00011.Instance.GetScalarObject<TLMDTO00031>("Zone.Server.SelectByBranch", new object[] { depositEntity.BranchCode, depositInfo.FromBranchCode });
        //        remitBranchDTO = CXCOM00011.Instance.GetScalarObject<TLMDTO00029>("RemitBrIBL.Server.SelectByBranch", new object[] { depositEntity.BranchCode, depositInfo.FromBranchCode, depositInfo.Currency });

        //        depositInfo.HomeExchangeRate = CXCOM00010.Instance.GetExchangeRate(depositEntity.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType));
        //        if (!CXServiceWrapper.Instance.Invoke<ICXSVE00010, bool>(x => x.IBL_Deposit(voucherNumber, depositEntity.AccountNo, depositEntity.Amount, 1, 1, tranTypeDTO.Status, tranTypeDTO.TransactionCode, referenceCode, 0, depositInfo.FromBranchCode, depositEntity.Commissions, depositEntity.CommunicationCharges,
        //            1, zoneDTO.AccountCode, remitBranchDTO.IBSComAccount, remitBranchDTO.TelaxAccount, depositEntity.Narration, strUserId, depositInfo.Currency, depositInfo.HomeExchangeRate.Value, depositEntity.BranchCode, depositInfo.NextSettlementDate.Value, depositInfo.Channel)))
        //        //if (!CXServiceWrapper.Instance.Invoke<ICXSVE00010, bool>(x => x.IBL_Deposit(voucherNumber, depositEntity.AccountNo, depositEntity.Amount, 1, 1, tranTypeDTO.Status, tranTypeDTO.TransactionCode, referenceCode, 0, depositInfo.FromBranchCode, depositEntity.Commissions, depositEntity.CommunicationCharges,
        //        //   1, zoneDTO.AccountCode, remitBranchDTO.IBSComAccount, remitBranchDTO.TelaxAccount, depositEntity.Narration, strUserId, depositInfo.Currency, depositInfo.HomeExchangeRate.Value, depositInfo.FromBranchCode, depositInfo.NextSettlementDate.Value, depositInfo.Channel)))
        //        {
        //            this.ServiceResult.ErrorOccurred = true;
        //            this.ServiceResult.MessageCode = CXServiceWrapper.Instance.ServiceResult.MessageCode;
        //            throw new Exception(this.ServiceResult.MessageCode);
        //            //return null;
        //        }

        //        //iblTransactionLog = this.GetIBLTransactionLogFile(voucherNumber, depositEntity.AccountNo, depositEntity.Amount, depositEntity.Commissions, depositEntity.CommunicationCharges, "CCD", depositInfo.FromBranchCode,
        //        //    depositEntity.BranchCode, depositEntity.Currency, strUserId);

        //        //this.IBLTLFDao.Save(iblTransactionLog);

        //        this.CLedgerDAO.UpdateTransactionCount(depositEntity.AccountNo, Convert.ToInt32(strUserId));

        //        if (DepositCollection.Count > 1)
        //        {
        //            depositEntity.CreatedUserId = depositInfo.CreatedUserId;
        //            this.DepoDenoDao.Save(this.GetDepoDeno(depositEntity, groupNumber, voucherNumber, depositInfo.FromBranchCode));


        //            depositInfo.AccountNo = depositEntity.AccountNo;

        //        }

        //        depositInfo.AccountNo = depositEntity.AccountNo; //Solve for cash deno ACType is blank.
        //        TLF_LIST.Add(new PFMDTO00054(voucherNumber, decimal.Zero, groupNumber, depositInfo.HomeExchangeRate.Value, tranTypeDTO.Status));
        //    }

        //    this.CashDenoDAO.Save(this.GetCashDeno(depositInfo, groupNumber, voucherNumber));

        //    return TLF_LIST;
        //}      


        //private PFMORM00043 GetPRNFile(TLMDTO00038 depositEntity1, TLMDTO00038 depositEntity2, decimal currentBalance)
        //{
        //    PFMORM00043 prnFile = new PFMORM00043();
        //    TLMDTO00005 tranTypeDTO;
        //    string depositCode;

        //    prnFile.AccountNo = depositEntity1.AccountNo;
        //    prnFile.DATE_TIME = DateTime.Now;
        //    prnFile.Credit = depositEntity1.Amount;
        //    prnFile.Balance = depositEntity1.Amount + currentBalance;
        //    prnFile.UserNo = depositEntity2.CreatedUserId.ToString();
        //    prnFile.SourceBranchCode = depositEntity1.BranchCode;
        //    prnFile.CurrencyCode = depositEntity2.Currency;
        //    prnFile.CreatedUserId = depositEntity2.CreatedUserId;
        //    prnFile.CreatedDate = DateTime.Now;
        //    prnFile.Channel = depositEntity2.Channel;
        //    depositCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.DepositCode);
        //    tranTypeDTO = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { depositCode });
        //    prnFile.Reference = tranTypeDTO.PBReference;
        //    prnFile.Active = true;

        //    return prnFile;
        //}

        //[Transaction()]
        //private TLMORM00004 GetIBLTransactionLogFile(string voucherNo, string accountNo, decimal amount, decimal income, decimal communicationCharges, string status, string fromBranchCode, string branchCode, string currencyCode, string userNo)
        //{
        //    TLMORM00004 iblTlf = new TLMORM00004();

        //    iblTlf.Id = IBLTLFDao.SelectMaxId() + 1;
        //    iblTlf.Eno = voucherNo;
        //    iblTlf.AccountNo = accountNo;
        //    iblTlf.FromBranch = fromBranchCode;
        //    iblTlf.ToBranch = branchCode;
        //    iblTlf.Amount = amount;
        //    iblTlf.TranType = status;
        //    iblTlf.Date_Time = DateTime.Now;
        //    iblTlf.InOut = false;
        //    iblTlf.Success = true;
        //    iblTlf.Income = income;
        //    iblTlf.Communicationcharge = communicationCharges;
        //    iblTlf.IncomeType = 1;
        //    iblTlf.Cheque = string.Empty;
        //    iblTlf.UserNo = userNo;
        //    iblTlf.Reversal = false;
        //    iblTlf.RelatedAccount = string.Empty;
        //    iblTlf.RelatedBranch = string.Empty;
        //    iblTlf.Currency = currencyCode;
        //    iblTlf.SourceBranchCode = fromBranchCode;
        //    iblTlf.CreatedUserId = (!string.IsNullOrEmpty(userNo)) ? int.Parse(userNo) : 0;

        //    return iblTlf;
        //}

        //[Transaction(TransactionPropagation.Required)]
        //public bool UpdateCleadgerPrintLineNoandDeletePrnFile(string accountNo, int updatedUserId, int lineNo)
        //{
        //    try
        //    {
        //        this.CLedgerDAO.UpdatePrnLineNoByAccountNo(accountNo, updatedUserId, lineNo);
        //        //this.PrintingDAO.DeletePrnFileByAccountNo(accountNo);
        //        this.ServiceResult.ErrorOccurred = false;
        //        return true;
        //    }
        //    catch
        //    {
        //        this.ServiceResult.ErrorOccurred = true;
        //        this.ServiceResult.MessageCode = CXMessage.ME90001;
        //        return false;
        //    }

        //}
        #endregion
    }
}
