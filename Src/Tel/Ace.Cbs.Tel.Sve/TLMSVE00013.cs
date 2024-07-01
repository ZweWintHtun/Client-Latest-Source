//----------------------------------------------------------------------
// <copyright file="TLMSVE00013.cs" company="ACE Data Systems">
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
using Ace.Windows.Admin.DataModel;
using Spring.Transaction;
using Ace.Cbs.Cx.Com.Utt;


namespace Ace.Cbs.Tel.Sve
{
    public class TLMSVE00013 : BaseService, ITLMSVE00013
    {
        #region DAO
        public IPFMDAO00001 CustomerIdDAO { get; set; }
        public ICXSVE00002 CodeGenerator { get; set; }
        public ITLMDAO00005 TranTypeDAO { get; set; }
        public IPFMDAO00054 TLFDAO { get; set; }
        public ITLMDAO00015 CashDenoDAO { get; set; }
        public IPFMDAO00023 FLedgerDAO { get; set; }
        public IPFMDAO00058 FPrnfileDAO { get; set; }
        public IPFMDAO00032 FReceiptDAO { get; set; }
        public ICXSVE00006 CustPhotoInfo { get; set; }
        #endregion

        #region Properties
        PFMDTO00001 customerIdEntity { get; set; }
        TLMDTO00041 fixDepositEntity { get; set; }
        #endregion

        #region Main Transaction Method
        [Transaction(TransactionPropagation.Required)]
        public string SaveFixedDepositWithdraw(IList<TLMDTO00041> fixedDepositEntityList)
        {
            string voucherNo = string.Empty;
            try
            {
                DateTime sys001 = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), fixedDepositEntityList[0].SourceBranchCode ,true });
                decimal rate = CXCOM00010.Instance.GetExchangeRate(fixedDepositEntityList[0].CurrencyCode, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType));
                //CurrencyDTO currencyDTO = CXCOM00011.Instance.GetScalarObject<CurrencyDTO>("Cur.HomeCur.Select", new object[] { true });
                //Generate Voucher No
                string day = sys001.Day.ToString().PadLeft(2, '0');
                string month = sys001.Month.ToString().PadLeft(2, '0');
                string year = sys001.Year.ToString().Substring(2);
                int updatedUserId = fixedDepositEntityList[0].CreatedUserId;
                voucherNo = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, updatedUserId, fixedDepositEntityList[0].SourceBranchCode, new object[] { day, month, year });
                //voucherNo = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, updatedUserId, CurrentUserEntity.BranchCode, new object[] { day, month, year });
                //voucherNo = this.CodeGenerator.GetGenerateCode("FixedWithdraw.Entry.No.Code", string.Empty, updatedUserId, CurrentUserEntity.BranchCode, new object[] { day, month, year });

                foreach (TLMDTO00041 fixedDepositDTO in fixedDepositEntityList)
                {
                    //Save TLF
                    PFMORM00054 tlfEntity = new PFMORM00054();
                    tlfEntity.Id = this.TLFDAO.SelectMaxId() + 1;
                    tlfEntity.Eno = voucherNo;
                    tlfEntity.AccountNo = fixedDepositDTO.AccountNo;
                    tlfEntity.Amount = fixedDepositDTO.Amount;
                    tlfEntity.AccountSign = fixedDepositDTO.AccountSignature;
                    tlfEntity.SourceBranchCode = fixedDepositEntityList[0].SourceBranchCode;
                    tlfEntity.CheckTime = DateTime.Now;
                    tlfEntity.SettlementDate = sys001;
                    tlfEntity.Channel = fixedDepositEntityList[0].Channel;
                    tlfEntity.ReceiptNo = fixedDepositDTO.ReceiptNo;
                    tlfEntity.Description = fixedDepositDTO.Description;
                    tlfEntity.Rate = rate;
                    tlfEntity.CurrencyCode = fixedDepositDTO.CurrencyCode;
                    tlfEntity.SourceCurrency = fixedDepositDTO.CurrencyCode;
                    tlfEntity.HomeAmt = fixedDepositDTO.Amount * rate;
                    tlfEntity.HomeOAmt = Convert.ToDecimal(0.00);
                    tlfEntity.HomeAmount = tlfEntity.HomeAmt + tlfEntity.HomeOAmt;
                    tlfEntity.LocalAmt = fixedDepositDTO.Amount;
                    tlfEntity.LocalOAmt = Convert.ToDecimal(0.00);
                    tlfEntity.LocalAmount = tlfEntity.LocalAmt + tlfEntity.LocalOAmt;
                    tlfEntity.Active = true;
                    tlfEntity.CreatedUserId = fixedDepositEntityList[0].CreatedUserId;
                    tlfEntity.UserNo = fixedDepositEntityList[0].CreatedUserId.ToString();
                    tlfEntity.CreatedDate = DateTime.Now;
                    tlfEntity.DateTime = DateTime.Now;
                    if (!String.IsNullOrEmpty(fixedDepositDTO.AccountNo))
                    {
                        tlfEntity.Acode = GetCOA(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixControl), fixedDepositDTO.CurrencyCode, fixedDepositEntityList[0].SourceBranchCode);
                        tlfEntity.Narration = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixedWithdrawal);
                        tlfEntity.TransactionCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.WithdrawalCode);
                    }
                    else
                    {
                        tlfEntity.AccountNo = GetCOA(fixedDepositDTO.Description, fixedDepositDTO.CurrencyCode, fixedDepositEntityList[0].SourceBranchCode);
                        tlfEntity.Acode = tlfEntity.AccountNo;
                        tlfEntity.Narration = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixedDepositInterest);
                        tlfEntity.TransactionCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashDebitType);
                    }
                    TLMDTO00005 transactionType = this.TranTypeDAO.SelectTranTypeStatus(tlfEntity.TransactionCode);
                    tlfEntity.Status = transactionType.Status;
                    this.TLFDAO.Save(tlfEntity);
                }

                //Save Cash Deno
                TLMORM00015 cashDenoEntity = new TLMORM00015();
                cashDenoEntity.Id = this.CashDenoDAO.SelectMaxId() + 1;
                cashDenoEntity.TlfEntryNo = voucherNo;
                cashDenoEntity.AccountType = fixedDepositEntityList[0].AccountNo;
                cashDenoEntity.ReceiptNo = fixedDepositEntityList[0].ReceiptNo;
                if (fixedDepositEntityList.Count == 1)
                {
                    cashDenoEntity.Amount = fixedDepositEntityList[0].Amount;
                }
                else
                {
                    cashDenoEntity.Amount = fixedDepositEntityList[0].Amount + fixedDepositEntityList[1].Amount;
                }
                cashDenoEntity.Status = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PaymentCashStatus);
                cashDenoEntity.CounterNo = fixedDepositEntityList[0].CounterNo;
                cashDenoEntity.DenoDetail = fixedDepositEntityList[0].DenoDetail;
                cashDenoEntity.DenoRate = fixedDepositEntityList[0].DenoRate;
                cashDenoEntity.DenoRefundDetail = fixedDepositEntityList[0].DenoRefundDetail;
                cashDenoEntity.DenoRefundRate = fixedDepositEntityList[0].DenoRefundRate;
                cashDenoEntity.SettlementDate = sys001;
                cashDenoEntity.SourceBranchCode = fixedDepositEntityList[0].SourceBranchCode;
                cashDenoEntity.Currency = fixedDepositEntityList[0].CurrencyCode;
                cashDenoEntity.Rate = rate;
                cashDenoEntity.UserNo = fixedDepositEntityList[0].CreatedUserId.ToString();
                cashDenoEntity.AdjustAmount = fixedDepositEntityList[0].AdjustAmount;
                cashDenoEntity.CashDate = null;
                //cashDenoEntity.CashDate = DateTime.Now;
                cashDenoEntity.Active = true;
                cashDenoEntity.CreatedUserId = fixedDepositEntityList[0].CreatedUserId;
                cashDenoEntity.CreatedDate = DateTime.Now;
                cashDenoEntity.Reverse = false;
                this.CashDenoDAO.Save(cashDenoEntity);

                //Update FLedger FBal Amount
                this.FLedgerDAO.UpdateFBalOfFLedgerForWithdrawal(fixedDepositEntityList[0].AccountNo, fixedDepositEntityList[0].Amount, fixedDepositEntityList[0].CreatedUserId, DateTime.Now);

                //Update FReceipt Withdraw Date
                this.FReceiptDAO.UpdateFreceiptWithdraw(fixedDepositEntityList[0].AccountNo, fixedDepositEntityList[0].ReceiptNo, DateTime.Now, fixedDepositEntityList[0].CreatedUserId, DateTime.Now);

                //Save FPrnFile
                PFMORM00058 fprnFile = new PFMORM00058();
                fprnFile.AccountNo = fixedDepositEntityList[0].AccountNo;
                fprnFile.CurrencyId = fixedDepositEntityList[0].CurrencyCode;
                fprnFile.Debit = fixedDepositEntityList[0].Amount;
                fprnFile.Balance = this.FLedgerDAO.SelectFBalByAccountNo(fixedDepositEntityList[0].AccountNo);
                fprnFile.Reference = fixedDepositEntityList[0].ReceiptNo;
                fprnFile.SourceBr = fixedDepositEntityList[0].SourceBranchCode;
                fprnFile.Channel = fixedDepositEntityList[0].Channel;
                fprnFile.AccessDate = DateTime.Now;
                fprnFile.Active = true;
                fprnFile.CreatedUserId = fixedDepositEntityList[0].CreatedUserId;
                fprnFile.AccessUser = fixedDepositEntityList[0].CreatedUserId.ToString();
                fprnFile.CreatedDate = DateTime.Now;
                this.FPrnfileDAO.Save(fprnFile);

                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI00051";//Saving Successful.
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.Message;
                throw new Exception(this.ServiceResult.MessageCode);
            }
            return voucherNo;
        }
        #endregion

        #region Select Methods
        public IList<PFMDTO00001> GetCustomersByAccountNumber(string accountNo)
        {
            IList<PFMDTO00021> faofDTOLists = CXServiceWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00021>>(x => x.GetFAOFsByAccountNumber(accountNo));
            IList<PFMDTO00001> customerLists = new List<PFMDTO00001>();
            PFMDTO00001 customerInfo = new PFMDTO00001();



            if (faofDTOLists.Count > 0)
            {
                var name = (from value in faofDTOLists
                            where value.Name != null
                            select value);
                IList<PFMDTO00021> faofDTOLists2=name.ToList<PFMDTO00021>();

                if (faofDTOLists2.Count>0)
                {
                    customerLists.Add(customerInfo);
                    customerLists[0].Name = faofDTOLists2[0].Name;
                }
                
                var customerId = from value in faofDTOLists
                                 where value.CustomerId != null
                                 select value.CustomerId;
                if (customerId.ToList().Count > 0)
                {
                    IList<string> customerIdList = customerId.ToList();

                    IList<PFMDTO00001> list = this.CustomerIdDAO.SelectListByCustId(customerIdList);
                    foreach (PFMDTO00001 info in list)
                    {
                        customerLists.Add(info);
                    }
                    customerLists[0].AccountSign = faofDTOLists[0].AccountSignature;
                    customerLists[0].JoinType = faofDTOLists[0].JoinType;
                    customerLists[0].NoOfPersonSign = faofDTOLists[0].NoOfPersonSign;
                    PFMDTO00001 customerResult = CXServiceWrapper.Instance.Invoke<ICXSVE00006, PFMDTO00001>(x => x.GetCustomerByCustomerId(faofDTOLists[0].CustomerId));
                    if (customerResult != null)
                    {
                        if (customerResult.CustPhoto.CustPhotos != null)
                        {
                            customerLists[0].CustPhotos = customerResult.CustPhoto.CustPhotos;
                        }
                        else
                        {
                            customerLists[0].CustPhotos = null;
                        }

                        if (customerResult.Signature != null)
                        {
                            customerLists[0].Signature = customerResult.Signature;
                        }
                        else
                        {
                            customerLists[0].Signature = null;
                        }
                    }
                }
                else
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV00175";//Account No Not Found.
                }
            }
            else
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV00175";//Account No Not Found.   
                return customerLists;
            }
            return customerLists;
        }
        
        public IList<PFMDTO00032> GetWithdrawalReceiptNosByAccountNumber(string accountNo)
        {
            IList<PFMDTO00032> freceipt=FReceiptDAO.SelectWithdrawalReceiptNoByAccountNo(accountNo);
            return freceipt;
        }

        public IList<PFMDTO00001> GetCustomerInfoAndWithdrawalReceiptNoByAccountNumber(string accountNo)
        {
            IList<PFMDTO00001> customerInfo = this.GetCustomersByAccountNumber(accountNo);
            if (customerInfo.Count > 0)
            {
                customerInfo[0].FreceiptInfo = this.GetWithdrawalReceiptNosByAccountNumber(accountNo);
            }                        
            return customerInfo;
        }

        public string GetCOA(string code, string currency,string branch)
        {
            string acode = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { code, currency, branch, true });
            return acode;
        }

        public PFMDTO00032 CheckReceiptNoNotDepositedOrAlreadyWithdrawn(string accountNo,string receiptNo,string branch) // add by hmw
        {
            PFMDTO00032 freceiptInfo = this.FReceiptDAO.CheckWithdrawalReceiptNo(accountNo,receiptNo,branch);
            return freceiptInfo;           
        }
        #endregion
    }
}

