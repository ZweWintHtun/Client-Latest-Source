using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Core.Utt;
using System.Linq;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00029 : BaseService, ILOMSVE00029
    {
        #region Propertities

        public ICXSVE00002 CodeGenerator { get; set; }
        public ICXSVE00006 CodeChecker { get; set; }
        public ICXSVE00010 SPCommonService { get; set; }
        public IPFMDAO00028 CLedgerDAO { get; set; }
        public IPFMDAO00054 TLFDao { get; set; }
        public IPFMDAO00020 UCheckDAO { get; set; }
        public PFMDTO00028 CledgerDTO { get; set; }
        public IPFMDAO00057 NewSeUp { get; set; }
        public IPFMDAO00043 PrnFileDAO { get; set; }
        public PFMORM00054 TlfInfo;
        public IList<PFMDTO00001> customer { get; set; }
        PFMORM00043 PrnFileInfo;
        string voucherNumber = string.Empty;
        
        #endregion

        #region Main Methods

        public IList<PFMDTO00001> SelectByAccountNumber(string accountNo)
        {
            //IList<PFMDTO00001> customer = null;
            customer = null;

            // Check saving account no is already closed or not.
            if (this.CodeChecker.IsClosedAccountForCLedger(accountNo))
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

            //Check FLedger Account
            bool isFAOF = CXServiceWrapper.Instance.Invoke<ICXSVE00006, bool>(x => x.isFAOFAccountNo(accountNo));
            if (isFAOF)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90045"; //Current,Saving,Chart of Account Only.
                return null;
            }

            customer = CXServiceWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00001>>(x => x.GetCustomerInfomationByAccountNo(accountNo, false));

            if (customer == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00175; // Account Not found.
            }
            else
            {
                this.CledgerDTO = this.CodeChecker.GetAccountInfoOfCledgerByAccountNo(accountNo);
                customer[0].BranchCode = CledgerDTO.SourceBranchCode;
            }

            return customer;
        }

        [Transaction(TransactionPropagation.Required)]
        public string SaveSpecialTransfer(IList<TLMDTO00038> transferCollection)
        {
            try
            {
                string groupNumber = string.Empty;
                string returnNo, messageNo;
                transferCollection = this.GetDataforTransfer(transferCollection);

                foreach (TLMDTO00038 transferEntity in transferCollection)
                {
                    returnNo = messageNo = string.Empty;
                    //Check Cheque No
                    if (!transferEntity.ChequeNo.Equals(string.Empty) && this.CodeChecker.IsVaildChequeNoforWithdrawal(transferEntity.AccountNo, transferEntity.ChequeNo, transferEntity.BranchCode))
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                        return string.Empty;
                    }
                    //Check Amount
                    //if (transferEntity.IsDebit && !transferEntity.IsDomesticAccount)
                    //    if (!this.CodeChecker.CheckAmount(transferEntity.AccountNo, transferEntity.Amount + transferEntity.Commissions + transferEntity.CommunicationCharges, true, transferEntity.IsVIP, true, ref isLink, ref messageNo))
                    //    {
                    //        this.ServiceResult.ErrorOccurred = true;
                    //        this.ServiceResult.MessageCode = messageNo;
                    //        return string.Empty;
                    //    }
                }
                voucherNumber = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, transferCollection[0].UpdatedUserId.Value, transferCollection[0].FromBranchCode, new object[] { transferCollection[0].NextSettlementDate.Value.Day.ToString().PadLeft(2, '0'), transferCollection[0].NextSettlementDate.Value.Month.ToString().PadLeft(2, '0'), transferCollection[0].NextSettlementDate.Value.Year.ToString().Substring(2) });
                foreach (TLMDTO00038 transferEntity in transferCollection)
                {
                    PrnFileInfo = null;
                    string strUserId = transferEntity.CreatedUserId.ToString();
                    string strVoucherType = transferEntity.VoucherType.Substring(0, 1);
                    //returnNo = CXServiceWrapper.Instance.Invoke<ICXSVE00010, string>(x => x.UpdateForTransfer(voucherNumber, transferEntity.AccountNo, transferEntity.Amount, 0, transferEntity.ChequeNo, strVoucherType, transferEntity.IsAutoLink, transferEntity.Narration, strUserId, transferCollection[0].Currency, transferCollection[0].HomeExchangeRate.Value, transferCollection[0].FromBranchCode, transferCollection[0].NextSettlementDate.Value, transferCollection[0].Channel));
                    if (strVoucherType == "D")
                    {
                        if (transferEntity.AccountSign.Substring(0, 1) == CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurrentAccountSign))
                        {
                            if (transferEntity.CurrentBal <= 0)
                            {
                                transferEntity.NetAmount = 0;
                                transferEntity.OverdraftAmount = transferEntity.Amount;
                            }
                            else if (Math.Abs(transferEntity.CurrentBal) >= transferEntity.Amount)
                            {
                                transferEntity.OverdraftAmount = 0;
                                transferEntity.NetAmount = transferEntity.Amount;
                            }
                            else if (Math.Abs(transferEntity.CurrentBal) < transferEntity.Amount)
                            {
                                transferEntity.NetAmount = transferEntity.CurrentBal;
                                transferEntity.OverdraftAmount = transferEntity.Amount - transferEntity.CurrentBal;
                            }
                        }
                        TlfInfo = this.GetTransactionLogFile(voucherNumber, transferEntity.AccountNo, false, transferEntity.Amount, transferEntity.NetAmount, transferEntity.OverdraftAmount, transferEntity.ChequeNo, transferEntity.Description,
                            transferEntity.Narration, transferEntity.CreatedDate, "TDV", "TRDEBIT", transferEntity.AccountSign, transferEntity.BranchCode, transferEntity.Currency, transferEntity.HomeExchangeRate, "",
                            CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel), transferEntity.CreatedUserId.ToString(), transferEntity.NextSettlementDate);
                        this.TLFDao.Save(TlfInfo);//Save in TLF
                        #region old update Ledger
                        //if (NewSeUp.UpdateByVariable("RunTrigger", "Disable", transferEntity.CreatedUserId) == false
                        //    && this.CLedgerDAO.UpdateCurrentBalance(transferEntity.AccountNo, transferEntity.CurrentBal - transferEntity.Amount, ++transferEntity.TransactionCount, transferEntity.UpdatedUserId.Value, transferEntity.UpdatedUserId.ToString()) == false)
                        //{
                        //    // Update Error
                        //    throw new Exception(CXMessage.ME90001);
                        //}
                        //if (NewSeUp.UpdateByVariable("RunTrigger", "Enable", transferEntity.CreatedUserId) == false)
                        //{
                        //    // Update Error
                        //    throw new Exception(CXMessage.ME90001);
                        //}
                        //if (transferEntity.AccountSign.Substring(0, 1) == CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurrentAccountSign) &&
                        //    !String.IsNullOrEmpty(transferEntity.ChequeNo))
                        //{
                        //    PFMORM00020 ucheck = this.GetUCheck(transferEntity);
                        //    this.UCheckDAO.Save(ucheck);//Update Use Cheque

                        //}
                        #endregion
                        //End Up
                        #region update Ledger

                        decimal UpdateCbal;
                        UpdateCbal = transferEntity.CurrentBal - transferEntity.Amount;

                        this.NewSeUp.UpdateByVariable("RunTrigger", "Disable", transferEntity.CreatedUserId);
                        this.CLedgerDAO.UpdateCurrentBalance(transferEntity.AccountNo, UpdateCbal, ++transferEntity.TransactionCount, transferEntity.UpdatedUserId.Value, transferEntity.UpdatedUserId.ToString());
                        this.NewSeUp.UpdateByVariable("RunTrigger", "Enable", transferEntity.CreatedUserId);
                        if (transferEntity.AccountSign.Substring(0, 1) == CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurrentAccountSign) &&
                            !String.IsNullOrEmpty(transferEntity.ChequeNo))
                        {
                            PFMORM00020 ucheck = this.GetUCheck(transferEntity);
                            this.UCheckDAO.Save(ucheck);//Update Use Cheque
                        }
                        #endregion
                    }
                    else if (strVoucherType == "C")
                    { 
                        //decimal NetAmount;
                        //decimal OverdraftAmount;
                        PrnFileInfo = this.GetPRNFile(transferEntity);
                        //PrnFileInfo.PrintLineNo = transferEntity.PrintLineNo;//To Find
                        if (transferEntity.IsCurrentAccount)
                        {
                            if (transferEntity.CurrentBal > 0)
                            {
                                transferEntity.NetAmount = transferEntity.Amount;
                                transferEntity.OverdraftAmount = 0;
                            }
                            else if (Math.Abs(transferEntity.CurrentBal) >= transferEntity.Amount)
                            {
                                transferEntity.OverdraftAmount = transferEntity.Amount;
                                transferEntity.NetAmount = 0;
                            }
                            else if (Math.Abs(transferEntity.CurrentBal) < transferEntity.Amount)
                            {
                                transferEntity.OverdraftAmount = Math.Abs(transferEntity.CurrentBal);
                                transferEntity.NetAmount = transferEntity.Amount - Math.Abs(transferEntity.CurrentBal);
                            }
                        }
                        else
                        {
                            transferEntity.NetAmount = transferEntity.Amount;
                            transferEntity.OverdraftAmount = 0;
                        }
                        TlfInfo = this.GetTransactionLogFile(voucherNumber, transferEntity.AccountNo, false, transferEntity.Amount, transferEntity.NetAmount, transferEntity.OverdraftAmount, transferEntity.ChequeNo, transferEntity.Description,
                            transferEntity.Narration, transferEntity.CreatedDate, "TCV", "TRCREDIT", transferEntity.AccountSign, transferEntity.BranchCode, transferEntity.Currency, transferEntity.HomeExchangeRate, "",
                            CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel), transferEntity.CreatedUserId.ToString(), transferEntity.NextSettlementDate);
                        this.TLFDao.Save(TlfInfo);//Save in TLF
                        //Update Cledger
                        if (!transferEntity.IsDomesticAccount)
                        {
                            #region Old Update Ledger
                            //if (NewSeUp.UpdateByVariable("RunTrigger", "Disable", transferEntity.CreatedUserId) == false
                            //    && this.CLedgerDAO.UpdateCurrentBalance(transferEntity.AccountNo, transferEntity.CurrentBal + transferEntity.Amount, ++transferEntity.TransactionCount, transferEntity.UpdatedUserId.Value, transferEntity.UpdatedUserId.ToString()) == false)
                            //{
                            //    // Update Error
                            //    throw new Exception(CXMessage.ME90001);
                            //}
                            //if (NewSeUp.UpdateByVariable("RunTrigger", "Enable", transferEntity.CreatedUserId) == false)
                            //{
                            //    // Update Error
                            //    throw new Exception(CXMessage.ME90001);
                            //}
                            //if (transferEntity.AccountSign.Substring(0, 1) == CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurrentAccountSign) && 
                            //    !String.IsNullOrEmpty(transferEntity.ChequeNo))
                            //{
                            //    PFMORM00020 ucheck = this.GetUCheck(transferEntity);
                            //    this.UCheckDAO.Save(ucheck);//Update Use Cheque
                            //}
                            #endregion
                            #region update Ledger

                            decimal UpdateCbal;
                            UpdateCbal = transferEntity.CurrentBal + transferEntity.Amount;

                            this.NewSeUp.UpdateByVariable("RunTrigger", "Disable", transferEntity.CreatedUserId);
                            this.CLedgerDAO.UpdateCurrentBalance(transferEntity.AccountNo, UpdateCbal, ++transferEntity.TransactionCount, transferEntity.UpdatedUserId.Value, transferEntity.UpdatedUserId.ToString());
                            this.NewSeUp.UpdateByVariable("RunTrigger", "Enable", transferEntity.CreatedUserId);
                            if (!transferEntity.IsDomesticAccount)
                            {
                                if (transferEntity.AccountSign.Substring(0, 1) == CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurrentAccountSign) &&
                                    !String.IsNullOrEmpty(transferEntity.ChequeNo))
                                {
                                    PFMORM00020 ucheck = this.GetUCheck(transferEntity);
                                    this.UCheckDAO.Save(ucheck);//Update Use Cheque
                                }
                                else if (transferEntity.AccountSign.Substring(0, 1) == CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavingAccountSign))
                                {
                                    this.PrnFileDAO.Save(PrnFileInfo);
                                }
                            }
                            #endregion
                        }
                    }
                  
                }
                
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME90043; // Unexpected Error Occur.
                throw new Exception(this.ServiceResult.MessageCode);

            }
            return voucherNumber;
        }

        private IList<TLMDTO00038> GetDataforTransfer(IList<TLMDTO00038> transferCollection)
        {
            //var credit = from value in transferCollection where value.IsCredit == true select value;

            //TLMDTO00038 creditTransactionInfo = credit.ToList<TLMDTO00038>()[0];
            //for (int i = 0; i < transferCollection.Count; i++)
            //{
            //    transferCollection[i].ToCurrency = creditTransactionInfo.Currency;
            //}
            foreach (TLMDTO00038 transferEntity in transferCollection)
            {
                transferEntity.HomeExchangeRate = CXCOM00010.Instance.GetExchangeRate(transferEntity.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType));
                //transferEntity.AllDenoRate = CXCOM00010.Instance.GetAllDenoRate(transferEntity.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType), transferEntity.ToCurrency);
                transferEntity.NextSettlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), transferEntity.FromBranchCode);
            }
            return transferCollection;
        }

        public PFMORM00020 GetUCheck(TLMDTO00038 Transfer)
        {
            PFMORM00020 ucheck = new PFMORM00020();
            ucheck.ChequeNo = Transfer.ChequeNo;
            ucheck.AccountNo = Transfer.AccountNo;
            ucheck.AccountSignature = Transfer.AccountSign;
            ucheck.Channel = "CBS";
            ucheck.DATE_TIME = DateTime.Now;
            ucheck.USERNO = Transfer.CreatedUserId.ToString();
            ucheck.SourceBranchCode = Transfer.BranchCode;
            ucheck.CreatedUserId = Transfer.CreatedUserId;
            ucheck.CreatedDate = Transfer.CreatedDate;
            ucheck.Active = true;

            return ucheck;
        }

        //For Save in TLF
        private PFMORM00054 GetTransactionLogFile(string voucherNo, string accountNo, bool isSameACodeandAccountNo, decimal amount, decimal netAmount, decimal overdraftAmount, string chequeNo,
          string description, string narration, DateTime date_Time, string status, string transactionCode, string accountSignature, string branchCode, string currencyCode,
          Nullable<decimal> homeRate, string referenceType, string channel, string userNo, Nullable<DateTime> nextSettlementDate)
        {
            PFMORM00054 tlf = new PFMORM00054();
            tlf.Id = this.TLFDao.SelectMaxId() + 1;
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
            tlf.SettlementDate = nextSettlementDate;
            tlf.Channel = channel;
            tlf.ReferenceType = referenceType;
            tlf.CreatedUserId = Convert.ToInt32(userNo);

            return tlf;
        }

        //For Save in PrnFile
        private PFMORM00043 GetPRNFile(TLMDTO00038 transferEntity)
        {
            PFMORM00043 prnFile = new PFMORM00043();
            TLMDTO00005 tranTypeDTO;
            string TransactionCode;

            prnFile.AccountNo = transferEntity.AccountNo;
            prnFile.DATE_TIME = DateTime.Now;
            prnFile.Credit = transferEntity.Amount;
            prnFile.Balance = transferEntity.Amount + transferEntity.CurrentBal;
            prnFile.UserNo = transferEntity.CreatedUserId.ToString();
            prnFile.SourceBranchCode = transferEntity.BranchCode;
            prnFile.CurrencyCode = transferEntity.Currency;
            prnFile.CreatedUserId = transferEntity.CreatedUserId;
            prnFile.CreatedDate = DateTime.Now;
            prnFile.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
            TransactionCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferCreditVoucherCode);
            tranTypeDTO = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { TransactionCode });
            prnFile.Reference = tranTypeDTO.PBReference;
            prnFile.Active = true;
            prnFile.PrintLineNo = transferEntity.PrintLineNo;
            return prnFile;
        }
        #endregion
    }
}
