using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tcm.Ctr.Sve;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXServer.Utt;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Dao;
//using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Dmd;

namespace Ace.Cbs.Tcm.Sve
{
    public class TCMSVE00063:BaseService,ITCMSVE00063
    {
        #region Constructor
        public TCMSVE00063()
        {

        }

        #endregion

        #region Properties
        public IPFMDAO00054 TLFDao { get; set; }
        public ICXSVE00002 CodeGenerator { get; set; }
        public IPFMDAO00028 CLedgerDAO { get; set; }
        public ITLMDAO00015 CashDenoDAO { get; set; }
        public ITLMDAO00008 Dep_TLFDAO { get; set; }
        TLMORM00015 CashDenoInfo;
        string voucherNumber = string.Empty;
        public PFMDTO00028 cledgerinfo { get; set; }

        public IList<PFMDTO00001> AccountInformationList { get; set; }

        public IList<PFMDTO00001> CustIDList { get; set; }

        private ICXSVE00006 codechecker;
        public ICXSVE00006 CodeChecker
        {
            get { return codechecker; }
            set { codechecker = value; }
        }
        
        #endregion Properties

        public PFMDTO00028 AccountCheck(string AccountNo, string CurrencyCode)
        {
            if (CodeChecker.IsFreezeAccount(AccountNo))
            {                
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00057;  //This Account is already freezed.
                return null;
            }
            cledgerinfo = CodeChecker.GetAccountInfoOfCledgerByAccountNo(AccountNo);
            if (cledgerinfo != null && cledgerinfo.CurrencyCode != CurrencyCode)
            {                
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00086; //Currency of this account should be {0}.
                return null;
            }
            if (cledgerinfo != null && cledgerinfo.CloseDate != null)
            {                
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00201; //Account No {0} has been closed.
                return null;
            }

            //Check FLedger Account
            bool isFAOF = CXServiceWrapper.Instance.Invoke<ICXSVE00006, bool>(x => x.isFAOFAccountNo(AccountNo));
            if (isFAOF)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90045"; //Current,Saving,Chart of Account Only.
                return null;
            }

            CustIDList=CodeChecker.GetCustomerInfomationByAccountNo(AccountNo,false);
            PFMDTO00001 Custid=new PFMDTO00001();
            Custid = CustIDList[0];
            cledgerinfo.Customer = Custid;
            
            return cledgerinfo;
        }

        [Transaction(TransactionPropagation.Required)]
        public string Save(IList<TLMDTO00008> Dep_TLFCollection, TLMDTO00038 depositEntity)
        {
            //Nullable<CXDMD00011> accountType;
            if (Dep_TLFCollection.Count<=0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME90018;//Invalid Parameter Value.
            }
            depositEntity.NextSettlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), depositEntity.FromBranchCode);
            PFMORM00054 debitTransactionLog = null;

            voucherNumber = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, depositEntity.CreatedUserId, Dep_TLFCollection[0].SourceBranchCode, new object[] { depositEntity.NextSettlementDate.Value.Day.ToString().PadLeft(2, '0'), depositEntity.NextSettlementDate.Value.Month.ToString().PadLeft(2, '0'), depositEntity.NextSettlementDate.Value.Year.ToString().Substring(2) });

            debitTransactionLog = this.GetTransactionLogFile(voucherNumber, depositEntity.AccountNo, false, depositEntity.Amount, depositEntity.Amount, 0, "", depositEntity.Name,
                   CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.GropuCashDeposit) + depositEntity.Narration, depositEntity.CreatedDate, "CCD", "DEPOSIT", depositEntity.AccountSign, depositEntity.BranchCode, depositEntity.Currency, depositEntity.HomeExchangeRate.Value, "", depositEntity.Channel, depositEntity.UpdatedUserId.Value.ToString(), depositEntity.NextSettlementDate.Value,depositEntity.CreatedUserId);

            if (depositEntity.AccountSign != CXDMD00011.DomesticAccountType.ToString() || depositEntity.AccountNo != CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoType1Length))
            {
                // Update CLedger => CloseDate and MinBal
                PFMDTO00028 cledger = CXServiceWrapper.Instance.Invoke<ICXSVE00006, PFMDTO00028>(x => x.GetAccountInfoOfCledgerByAccountNo(depositEntity.AccountNo));
                if (cledger == null)
                {
                    // Update Error
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME90001;//Invalid Parameter Value.
                    throw new Exception(this.ServiceResult.MessageCode);
                }
                if (this.CLedgerDAO.UpdateCurrentBalance(depositEntity.AccountNo, depositEntity.Amount + cledger.CurrentBal, ++cledger.TransactionCount, depositEntity.UpdatedUserId.Value, depositEntity.UpdatedUserId.ToString()) == false)
                {
                    // Update Error
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME90001;//Invalid Parameter Value.
                    throw new Exception(this.ServiceResult.MessageCode);
                }
            }
            this.TLFDao.Save(debitTransactionLog);
            this.CashDenoDAO.Save(this.GetCashDeno(depositEntity, string.Empty, voucherNumber));

            foreach (TLMDTO00008 dep_TLFEntity in Dep_TLFCollection)
            {
                dep_TLFEntity.ENO = voucherNumber;
                dep_TLFEntity.STATUS = "CCD";
                dep_TLFEntity.UID = Guid.NewGuid().ToString();
                this.Dep_TLFDAO.Save(GetDep_TLFEntity(dep_TLFEntity));  //Save Dep_TLF 
            }
            return voucherNumber;
        }

        #region Helper Methods
        private TLMORM00008 GetDep_TLFEntity(TLMDTO00008 dep_TLFDTOEntity)
        {
            TLMORM00008 Dep_TlfORMEntity = new TLMORM00008();            
            Dep_TlfORMEntity.ENO = dep_TLFDTOEntity.ENO;
            Dep_TlfORMEntity.AccountNo = dep_TLFDTOEntity.AccountNo;
            Dep_TlfORMEntity.NAME = dep_TLFDTOEntity.NAME;
            Dep_TlfORMEntity.DepositCode = dep_TLFDTOEntity.DepositCode;
            Dep_TlfORMEntity.STATUS = dep_TLFDTOEntity.STATUS;
            Dep_TlfORMEntity.DATE_TIME = dep_TLFDTOEntity.DATE_TIME;
            Dep_TlfORMEntity.QUOTANO = dep_TLFDTOEntity.QUOTANO;
            Dep_TlfORMEntity.Quantity = dep_TLFDTOEntity.Quantity;
            Dep_TlfORMEntity.AMOUNT = dep_TLFDTOEntity.AMOUNT;
            Dep_TlfORMEntity.SourceBranchCode = dep_TLFDTOEntity.SourceBranchCode;
            Dep_TlfORMEntity.CurrencyCode = dep_TLFDTOEntity.CurrencyCode;
            Dep_TlfORMEntity.RATE = dep_TLFDTOEntity.RATE;
            Dep_TlfORMEntity.UID = dep_TLFDTOEntity.UID;
            Dep_TlfORMEntity.SETTLEMENTDATE = dep_TLFDTOEntity.SETTLEMENTDATE;
            Dep_TlfORMEntity.Active = dep_TLFDTOEntity.Active;
            Dep_TlfORMEntity.CreatedDate = dep_TLFDTOEntity.CreatedDate;
            Dep_TlfORMEntity.CreatedUserId = dep_TLFDTOEntity.CreatedUserId;
            
            return Dep_TlfORMEntity;
        }

        [Transaction()]
        private PFMORM00054 GetTransactionLogFile(string voucherNo, string accountNo, bool isSameACodeandAccountNo, decimal amount, decimal netAmount, decimal overdraftAmount, string chequeNo,
            string description, string narration, DateTime date_Time, string status, string transactionCode, string accountSignature, string branchCode, string currencyCode,
            decimal homeRate, string referenceType, string channel, string userNo, DateTime nextSettlementDate,int userId)
        {
            PFMORM00054 tlf = new PFMORM00054();

            tlf.Eno = voucherNo;
            if (accountSignature!=null)
            
            {
				 //Nullable<CXDMD00011> accountType;
                //if (CXCLE00012.Instance.IsValidAccountNo(accountNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                //{
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
                //}
            }
            else
            {
                tlf.Acode = accountNo;
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
            tlf.CreatedDate = date_Time;
            tlf.CreatedUserId = userId;
            return tlf;
        }

        private TLMORM00015 GetCashDeno(TLMDTO00038 depositInfo, string groupNo, string voucherNo)
        {
            CashDenoInfo = new TLMORM00015();
            CashDenoInfo.TlfEntryNo = groupNo == string.Empty ? voucherNo : groupNo;
            //if (CXCLE00012.Instance.CheckAccountNoType(depositInfo.AccountNo, CXDMD00011.DomesticAccountType))
            //  CashDenoInfo.AccountType = null;
			//else
                CashDenoInfo.AccountType = depositInfo.AccountNo;

            CashDenoInfo.Amount = depositInfo.Amount;
            CashDenoInfo.AccountType = depositInfo.AccountNo;
            CashDenoInfo.AdjustAmount = depositInfo.AdjustAmount;
            CashDenoInfo.CashDate = System.DateTime.Now;
            CashDenoInfo.DenoDetail = depositInfo.DenoString;
            CashDenoInfo.DenoRefundDetail = depositInfo.RefundString;
            CashDenoInfo.DenoRate = depositInfo.DenoRate;
            CashDenoInfo.DenoRefundRate = depositInfo.RefundRate;
            CashDenoInfo.Status = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);
            CashDenoInfo.Reverse = false;
            CashDenoInfo.CreatedDate = System.DateTime.Now;
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

        #endregion Helper Methods
    }
}
