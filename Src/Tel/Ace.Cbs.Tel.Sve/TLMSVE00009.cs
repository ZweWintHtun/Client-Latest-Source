//----------------------------------------------------------------------
// <copyright file="TLMSVE00009.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Yu Thandar Aung</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser>Hnin Thazin Shwe</UpdatedUser>
// <UpdatedDate>2013-06-27</UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Ser;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Admin.DataModel;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Tel.Sve
{
    /// <summary>
    /// Fixed Deposit DepositEntry Service.
    /// </summary>
    public class TLMSVE00009 : BaseService, ITLMSVE00009
    {
        #region Properties
        public ITLMSVE00013 FixedDeposit { get; set; }
        public IPFMDAO00032 FReceiptDAO { get; set; }
        public ICXSVE00002 CodeGenerator{ get; set; }
        public ITLMDAO00005 TranTypeDAO { get; set; }
        public IPFMDAO00054 TLFDAO { get; set; }
        public ITLMDAO00015 CashDenoDAO { get; set; }
        public IPFMDAO00023 FledgerDAO { get; set; }
        public IPFMDAO00058 FPrnfileDAO { get; set; }

        public string voucherNo = string.Empty;
        public decimal balance { get; set; }
        #endregion

        #region Convert DTO to ORM
        private PFMORM00054 GetTLF(TLMDTO00041 entity)
        {
            PFMORM00054 tlf = new PFMORM00054();
            tlf.AccountNo = entity.AccountNo;            
            tlf.Amount = entity.Amount;
            tlf.AccountSign = entity.AccountSignature;
            tlf.UserNo = Convert.ToString(entity.CreatedUserId);
            tlf.CheckTime = DateTime.Now;
            tlf.DateTime = DateTime.Now;
            tlf.Channel = entity.Channel;
            tlf.ReceiptNo = entity.ReceiptNo;
            tlf.TransactionCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.DepositCode);
            tlf.Narration = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixedCashDeposit);
            tlf.SourceBranchCode = entity.SourceBranchCode;
            tlf.CurrencyCode = entity.CurrencyCode;
            tlf.SourceCurrency = entity.CurrencyCode;
            tlf.HomeOAmt = Convert.ToDecimal(0.00);
            tlf.LocalAmt = entity.Amount;
            tlf.LocalOAmt = Convert.ToDecimal(0.00);
            tlf.LocalAmount =tlf.LocalAmt+tlf.LocalOAmt;
            tlf.Description = entity.Description;
            tlf.Active = true;
            tlf.CreatedUserId = entity.CreatedUserId;
            tlf.CreatedDate = DateTime.Now;
            return tlf;
        }

        private TLMORM00015 GetCashDeno(TLMDTO00041 entity)
        {
            TLMORM00015 cashDeno = new TLMORM00015();
            cashDeno.AccountType = entity.AccountNo;
            cashDeno.ReceiptNo = entity.ReceiptNo;
            cashDeno.Amount = entity.Amount;
            cashDeno.AdjustAmount = entity.AdjustAmount;
            cashDeno.UserNo = Convert.ToString(entity.CreatedUserId);
            cashDeno.Status = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);
            cashDeno.CounterNo = entity.CounterNo;
            cashDeno.SourceBranchCode = entity.SourceBranchCode;
            cashDeno.CashDate = DateTime.Now;
            cashDeno.DenoDetail = entity.DenoDetail;
            cashDeno.DenoRate = entity.DenoRate;
            cashDeno.DenoRefundDetail = entity.DenoRefundDetail;
            cashDeno.DenoRefundRate = entity.DenoRefundRate;
            cashDeno.Currency = entity.CurrencyCode;
            cashDeno.Active = true;
            cashDeno.CreatedUserId = entity.CreatedUserId;
            cashDeno.Reverse = false;
            cashDeno.CreatedDate = DateTime.Now;
            return cashDeno;
        }

        private PFMORM00058 GetFPrnfile(TLMDTO00041 entity)
        {
            PFMORM00058 fPrnfile = new PFMORM00058();
            fPrnfile.AccountNo = entity.AccountNo;
            fPrnfile.Debit = Convert.ToDecimal(0.00);
            fPrnfile.Credit = entity.Amount;
            fPrnfile.Reference = entity.ReceiptNo;
            fPrnfile.SourceBr = entity.SourceBranchCode;
            fPrnfile.AccessDate = DateTime.Now;
            fPrnfile.Channel = entity.Channel;
            fPrnfile.AccessUser = entity.CreatedUserId.ToString();
            fPrnfile.Active = true;
            fPrnfile.CreatedUserId = entity.CreatedUserId;
            fPrnfile.CreatedDate = DateTime.Now;
            return fPrnfile;
        }
        #endregion

        #region Main Methods
        [Transaction(TransactionPropagation.Required)]
        public TLMDTO00005 SaveFixedDeposit(TLMDTO00041 fixedDeposit)
        {
            try
            {
                TLMDTO00005 voucher = new TLMDTO00005();
                PFMORM00054 tlf = this.GetTLF(fixedDeposit);
                TLMORM00015 cashdeno = this.GetCashDeno(fixedDeposit);
                PFMORM00058 fprnfile = this.GetFPrnfile(fixedDeposit);

                voucher = this.Save_FixedDeposit(tlf, cashdeno, fprnfile, fixedDeposit);                
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI00051";//Saving Successful.
                return voucher; 
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.Message;
                throw new Exception(this.ServiceResult.MessageCode);
            }
                       
        }

      

        public IList<PFMDTO00001> GetCustomerInfoandDepositReceiptNoByAccountNo(string accountNo)
        {
            IList<PFMDTO00001> customerInfo = this.FixedDeposit.GetCustomersByAccountNumber(accountNo);
            if (customerInfo.Count > 0)
            {
                customerInfo[0].FreceiptInfo = this.FReceiptDAO.SelectDepositReceiptNoByAccountNo(accountNo);
            }
            return customerInfo;
        }
        #endregion

        #region Helper Methods
        [Transaction(TransactionPropagation.Required)]
        private TLMDTO00005 Save_FixedDeposit(PFMORM00054 tlf, TLMORM00015 cashdeno, PFMORM00058 fprnfile, TLMDTO00041 fixedDeposit)
        {
            //ChargeOfAccountDTO coaDTO = CXCOM00012.Instance.SelectCOAByCoaSetupAccountName(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixControl), fixedDeposit.CurrencyCode, fixedDeposit.SourceBranchCode);
            string acode = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixControl), fixedDeposit.CurrencyCode, fixedDeposit.SourceBranchCode, true });  //edited by ASDA
            
            DateTime sys001 = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), fixedDeposit.SourceBranchCode,true });
            PFMDTO00075 rate = CXCOM00011.Instance.GetScalarObject<PFMDTO00075>("RateInfo.Rate.Select", new object[] { fixedDeposit.CurrencyCode, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType), true,fixedDeposit.CurrencyCode,true });
            //CurrencyDTO currencyDTO = CXCOM00011.Instance.GetScalarObject<CurrencyDTO>("Cur.HomeCur.Select", new object[] { true });

            string day = sys001.Day.ToString().PadLeft(2, '0');
            string month = sys001.Month.ToString().PadLeft(2, '0');
            string year = sys001.Year.ToString().Substring(2);
            int updatedUserId = fixedDeposit.CreatedUserId;

            //voucherNo = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, updatedUserId, CurrentUserEntity.BranchCode, new object[] { day, month, year });
            voucherNo = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, updatedUserId, fixedDeposit.SourceBranchCode, new object[] { day, month, year });
            TLMDTO00005 transactionType = this.TranTypeDAO.SelectTranTypeStatus(tlf.TransactionCode);

            //Save TLF
            //tlf.SourceCurrency = currencyDTO.Cur;
            tlf.Id = this.TLFDAO.SelectMaxId() + 1;
            tlf.HomeAmt = tlf.Amount * rate.Rate;
            tlf.HomeAmount = tlf.HomeAmt+tlf.HomeOAmt;
            tlf.Acode = acode;      //edited 
            tlf.SettlementDate = sys001;
            tlf.Rate = rate.Rate;
            tlf.Status = transactionType.Status;
            tlf.Eno = voucherNo;
            TLFDAO.Save(tlf);

            //Save CashDeno 
            cashdeno.SettlementDate = sys001;
            cashdeno.Rate = rate.Rate;
            cashdeno.TlfEntryNo = voucherNo;
            cashdeno.Id = this.CashDenoDAO.SelectMaxId() + 1;
            //cashdeno.Reverse = false;
            this.CashDenoDAO.Save(cashdeno);

            //Update Fledger FBal Amount
            this.FledgerDAO.UpdateFBalOfFLedgerForDeposit(fixedDeposit.AccountNo, fixedDeposit.Amount, fixedDeposit.CreatedUserId, DateTime.Now);

            //Update FReceipt LastInterestDate
            this.FReceiptDAO.UpdateLastIntDate(fixedDeposit.AccountNo, fixedDeposit.ReceiptNo, fixedDeposit.CreatedUserId, DateTime.Now);

            //Save FPrnFile
            balance = this.FledgerDAO.SelectFBalByAccountNo(fixedDeposit.AccountNo);
            fprnfile.Balance = balance;
            fprnfile.CurrencyId = tlf.SourceCurrency;
            this.FPrnfileDAO.Save(fprnfile);
            transactionType.Narration = voucherNo; 
            return transactionType;
        }
        #endregion
    }
}
