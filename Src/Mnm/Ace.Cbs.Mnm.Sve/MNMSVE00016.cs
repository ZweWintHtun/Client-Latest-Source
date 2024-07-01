using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;

namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00016:BaseService,IMNMSVE00016
    {
        #region DAO
        public ITLMDAO00015 CashDenoDAO { get; set; }
        public ITLMDAO00009 DepoDenoDAO { get; set; }
        public ITLMDAO00016 PODAO { get; set; }
        public ICXSVE00002 CodeGenerator { get; set; }
        public ICXSVE00006 CodeChecker { get; set; }
       
        public IPFMDAO00054 TLFDAO { get; set; }
        public ITLMDAO00005 TranTypeDAO { get; set; }
        public IPFMDAO00028 CledgerDAO { get; set; }

        public string voucherNo { get; set; }
        public string orgnEno { get; set; }
        public string orgnTransactionCode { get; set; }
        public string orgnPaymentOrderNo { get; set; }
        public decimal rate  { get; set; }
        public DateTime settlementDate  { get; set; }
        public string currency { get; set; }
        public string channel { get; set; }
        public string accountSign { get; set; }
        public string referenceVoucherNo { get; set; }
        public string referenceType { get; set; }

        public string narration { get; set; }
        public string tranCode { get; set; }
        public IList<PFMDTO00054> tlfDataList { get; set; }
        TLMDTO00016 po { get; set; }
        #endregion

        public TLMDTO00016 GetPOData(string poNo, string budget, string sourceBranch)
        {  
             

                po = new TLMDTO00016();
                po =  PODAO.GetPOData(poNo, budget, sourceBranch);

                if (po != null)
                {
                    tlfDataList = TLFDAO.SelectTlfForPORefundReversal(poNo, sourceBranch);
                    
                    if (tlfDataList.Count == 0 || tlfDataList == null)
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "ME30003"; //Not allowed already reversal.
                    }
                    else
                    {
                        po.Tlf_ENo = tlfDataList[0].Eno;
                        TLMDTO00015 cashDeno = new TLMDTO00015();
                        cashDeno.DepoDenoAmount = 0;
                        po.CashDenoDTO = cashDeno;

                        IList<TLMDTO00009> depoDeno = this.DepoDenoDAO.SelectDepoDenoForCheckSinglePO(poNo, po.Tlf_ENo, sourceBranch); //edited by ASDA

                        if (depoDeno != null && depoDeno.Count != 0)
                        {
                            this.ServiceResult.ErrorOccurred = true;
                            this.ServiceResult.MessageCode = "MV90048";//Only Single PO.                            
                        }
                        else if (po.Status == "J")
                        {
                            IList<PFMDTO00001> customer = CodeChecker.GetCustomerInfomationByAccountNo(po.ToAccountNo, false);
                            if (customer != null)
                            {
                                po.CustomerName = customer[0].Name;
                            }
                            else
                            {
                                this.ServiceResult.ErrorOccurred = true;
                                this.ServiceResult.MessageCode = "MV00175";//Account No Not Found.
                            }
                            //take customer info
                            //po.CustomerName
                        }
                    }

                }
                else
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV00103";//Invalid Payment Order No.
                }
            
            return po;
        }

        public TLMDTO00016 GetDepoDenoData(string groupNo, string poNo, string budget, string sourceBranch)
        {
            TLMDTO00016 po = new TLMDTO00016();
            TLMDTO00009 depoDeno = this.DepoDenoDAO.SelectDepoDeno(groupNo, poNo, sourceBranch);
            if (depoDeno == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV30023";//Invalid PO No. for this Group No.
            }
            else
            {
                if (depoDeno.Reverse_Status == true)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV30024";//This PO No. is already Reverse for this Group No.
                }
                else
                {
                    po = PODAO.GetPOData(poNo, budget, sourceBranch);
                    if (po != null)
                    {
                        TLMDTO00015 cashDeno = this.CashDenoDAO.GetMultiPO(groupNo, poNo, sourceBranch,"P");
                        if (cashDeno == null)
                        {
                            this.ServiceResult.ErrorOccurred = true;
                            this.ServiceResult.MessageCode = "MV30030";//Deno record not found for this transaction
                        }
                        else if (cashDeno.Reverse == true)
                        {
                            this.ServiceResult.ErrorOccurred = true;
                            this.ServiceResult.MessageCode = "MV30026";//Deno is already Reverse!
                        }
                        else
                        {
                            decimal Amount = this.DepoDenoDAO.SumAmountByPONo(groupNo, poNo, sourceBranch);
                            cashDeno.DepoDenoAmount = Amount;
                            po.CashDenoDTO = cashDeno;

                        }
                    }

                }
            }
            return po;
        }

        public IList<PFMDTO00054> SaveRefundPO(TLMDTO00041 refundDTO)
        {
            try
            {
                DateTime todayDate = DateTime.Now;
                string day = todayDate.Day.ToString().PadLeft(2, '0');
                string month = todayDate.Month.ToString().PadLeft(2, '0');
                string year = todayDate.Year.ToString().Substring(2);
                int updatedUserId = refundDTO.CreatedUserId;

                TLMDTO00015 cashDenoDTO = new TLMDTO00015();
                cashDenoDTO.Currency = refundDTO.CurrencyCode;
                //added by ASDA***
                cashDenoDTO.Amount = refundDTO.TotalAmount;
                cashDenoDTO.DenoRate = refundDTO.DenoRate;
                cashDenoDTO.DenoDetail = refundDTO.DenoDetail;
                cashDenoDTO.DenoRefundRate = refundDTO.DenoRefundRate;
                cashDenoDTO.DenoRefundDetail = refundDTO.DenoRefundDetail;
                cashDenoDTO.AdjustAmount = refundDTO.AdjustAmount;
                cashDenoDTO.CounterNo = refundDTO.CounterNo;
                cashDenoDTO.SourceBranchCode = refundDTO.SourceBranchCode;  
                cashDenoDTO.CreatedUserId = refundDTO.CreatedUserId;
                //End***
              
                tlfDataList = this.TLFDAO.SelectTlfForPORefundReversal(refundDTO.PaymentOrderNo, refundDTO.SourceBranchCode);
                voucherNo = this.CodeGenerator.GetGenerateCode("POReversalVoucher", string.Empty, updatedUserId, refundDTO.SourceBranchCode, new object[] { day, month, year });                
               
                for (int i = 0; i < tlfDataList.Count; i++)
                {
                    if(string.IsNullOrEmpty(refundDTO.GroupNo))
                    // Call Commodule to save Tlf table 
                        
                    this.CodeChecker.ReversalProcess(tlfDataList[i].Eno, voucherNo, null, tlfDataList[i].SourceBranchCode,
                        DateTime.Now, tlfDataList[i].SourceBranchCode, updatedUserId, cashDenoDTO, string.Empty, true); 

                    else
                        // Call Commodule to save Tlf table 
                        this.CodeChecker.ReversalProcess(tlfDataList[i].Eno, voucherNo, refundDTO.GroupNo, tlfDataList[i].SourceBranchCode,
                            DateTime.Now, tlfDataList[i].SourceBranchCode, updatedUserId, cashDenoDTO, string.Empty, true);

                    #region OldCode
                    //orgnEno = tlfDataList[i].Eno;
                    //orgnTransactionCode = tlfDataList[i].TransactionCode;
                    //orgnPaymentOrderNo = tlfDataList[i].PaymentOrderNo;
                    //rate = Convert.ToDecimal(tlfDataList[i].Rate);
                    //settlementDate = Convert.ToDateTime(tlfDataList[i].SettlementDate);
                    //currency = tlfDataList[i].CurrencyCode;
                    //channel = tlfDataList[i].Channel;
                    //accountSign = tlfDataList[i].AccountSign;
                    //referenceVoucherNo = tlfDataList[i].ReferenceVoucherNo;
                    //referenceType = tlfDataList[i].ReferenceType;

                    //narration = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReversePORefund);
                    //tranCode = this.GetReference(orgnTransactionCode);

                    ////Save TLF
                    //PFMORM00054 tlf = this.GetTLF(voucherNo, tlfDataList[i].AccountNo, tlfDataList[i].Acode, refundDTO.Amount, narration, tranCode, orgnEno, orgnTransactionCode, orgnPaymentOrderNo,
                    //                currency, refundDTO.SourceBranchCode, rate, settlementDate, channel, refundDTO.CreatedUserId, accountSign, referenceVoucherNo, referenceType);
                    //this.TLFDAO.Save(tlf);

                    ////Update TLF
                    //this.TLFDAO.UpdateTLFForSavingInterestWithdrawReversal(voucherNo, tranCode, DateTime.Now, refundDTO.CreatedUserId, orgnEno, orgnTransactionCode, currency, refundDTO.SourceBranchCode, refundDTO.TS);
                    #endregion
                }

                #region OldCode
                ////Update CashDeno
                    //if (refundDTO.Status == "C")
                    //{ this.CashDenoDAO.UpdateCashDenoByAccountType(voucherNo, refundDTO.PaymentOrderNo, refundDTO.SourceBranchCode, refundDTO.CreatedUserId, DateTime.Now); }
                    //else
                //{ this.CledgerDAO.UpdateCBalForPORefundReversal(refundDTO.AccountNo, refundDTO.Amount, refundDTO.CreatedUserId); }

                //Update TLF
                // this.TLFDAO.UpdateTlfByPONo(refundDTO.PaymentOrderNo, voucherNo, refundDTO.SourceBranchCode, refundDTO.CreatedUserId, DateTime.Now);

                //if (!string.IsNullOrEmpty(refundDTO.GroupNo))
                //{
                //this.DepoDenoDAO.UpdateDepoDenoByReverseStatus(refundDTO.GroupNo, refundDTO.PaymentOrderNo, refundDTO.SourceBranchCode, refundDTO.CreatedUserId, DateTime.Now);
                //this.CashDenoDAO.UpdateCashDenoByTlfEntryNo(voucherNo, refundDTO.GroupNo, refundDTO.SourceBranchCode, refundDTO.CreatedUserId, DateTime.Now,"P");

                //if (!string.IsNullOrEmpty(refundDTO.DenoDetail))
                //{
                //    TLMORM00015 cashDeno = this.GetCashDeno(null, refundDTO.GroupNo, null, refundDTO.CreatedUserId, refundDTO.SourceBranchCode, refundDTO.CurrencyCode, settlementDate, rate,
                //                         refundDTO.TotalAmount, refundDTO.AdjustAmount, refundDTO.DenoDetail, refundDTO.DenoRate, refundDTO.DenoRefundDetail, refundDTO.DenoRefundRate, refundDTO.CounterNo);
                //    this.CashDenoDAO.Save(cashDeno);
                //}
                // }

                #endregion

                tlfDataList[0].RegisterNo = this.voucherNo;
                //Update PO
                this.PODAO.UpdateIDateAndRefundSDate(refundDTO.PaymentOrderNo, refundDTO.BudgetYear, refundDTO.SourceBranchCode, refundDTO.CreatedUserId);

                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90001";//Saving Successful.
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.Message;
                throw new Exception(this.ServiceResult.MessageCode);
            }
            return tlfDataList;
                            
        }

        public TLMDTO00015 GetCashDenoForPOReversal(string tlfENo, string sourceBranch)
        {
            return CashDenoDAO.GetCashDenoForPOReversal(tlfENo, sourceBranch);
        }

        #region OldCode
        //private PFMORM00054 GetTLF(string eno, string accountNo,string acode, decimal amount, string narration, string transactionCode, string orgnEno, string orgnTransactionCode, string orgnPONo,
        //                          string currency, string sourceBranch, decimal rate, DateTime settlementDate, string channel, int createdUserId,string acSign,string refVno,string refType)
        //{
        //    PFMORM00054 tlf = new PFMORM00054();
        //    tlf.Id = this.TLFDAO.SelectMaxId() + 1;
        //    tlf.Eno = eno;
        //    tlf.AccountNo = accountNo;
        //    tlf.Amount = amount;
        //    tlf.Acode = acode;
        //    tlf.HomeAmt = tlf.Amount * rate;
        //    tlf.HomeOAmt = Convert.ToDecimal(0.00);
        //    tlf.HomeAmount = tlf.HomeAmt + tlf.HomeOAmt;
        //    tlf.LocalAmt = amount;
        //    tlf.LocalOAmt = Convert.ToDecimal(0.00);
        //    tlf.LocalAmount = tlf.LocalAmt + tlf.LocalOAmt;
        //    tlf.Description = this.GetCOA(tlf.Acode, sourceBranch);
        //    tlf.Narration = narration;
        //    tlf.CheckTime = DateTime.Now;
        //    tlf.DateTime = DateTime.Now;
        //    tlf.TransactionCode = transactionCode;
        //    tlf.Status = this.GetTransactionStatus(tlf.TransactionCode);
        //    tlf.OrgnEno = orgnEno;
        //    tlf.OrgnTransactionCode = orgnTransactionCode;
        //    tlf.OrgnPaymentOrderNo = orgnPONo;
        //    //tlf.PaymentOrderNo = poNo;
        //    tlf.UserNo = Convert.ToString(createdUserId);
        //    tlf.CurrencyCode = currency;
        //    tlf.SourceCurrency = currency;
        //    tlf.SourceBranchCode = sourceBranch;
        //    tlf.Rate = rate;
        //    tlf.SettlementDate = settlementDate;
        //    tlf.Channel = channel;
        //    tlf.AccountSign = acSign;
        //    tlf.ReferenceVoucherNo = refVno;
        //    tlf.ReferenceType = refType;
        //    tlf.CreatedDate = DateTime.Now;
        //    tlf.CreatedUserId = createdUserId;
        //    tlf.Active = true;
        //    return tlf;
        //}

        //private TLMORM00015 GetCashDeno(string denoEntryNo, string tlfEntryNo, string acType, int createdUserId, string sourceBranch, string currency, DateTime settlementDate, decimal rate, decimal totalAmount,
        //                                decimal adjustAmount, string denoString, string denoRateString, string refundString, string refundRateString,string counterNo)
        //{
        //    TLMORM00015 cashDeno = new TLMORM00015();
        //    cashDeno.DenoEntryNo = denoEntryNo;
        //    cashDeno.TlfEntryNo = tlfEntryNo;
        //    cashDeno.AccountType = acType;
        //    cashDeno.Amount = totalAmount;
        //    cashDeno.AdjustAmount = adjustAmount;
        //    cashDeno.CashDate = DateTime.Now;
        //    cashDeno.DenoDetail = denoString;
        //    cashDeno.DenoRate = denoRateString;
        //    cashDeno.DenoRefundDetail = refundString;
        //    cashDeno.DenoRefundRate = refundRateString;
        //    cashDeno.CounterNo = counterNo;
        //    cashDeno.UserNo = Convert.ToString(createdUserId);
        //    cashDeno.Status = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PaymentCashStatus);
        //    cashDeno.Reverse = false;
        //    cashDeno.SourceBranchCode = sourceBranch;
        //    cashDeno.Currency = currency;
        //    cashDeno.SettlementDate = settlementDate;
        //    cashDeno.Rate = rate;
        //    cashDeno.Active = true;
        //    cashDeno.CreatedUserId = createdUserId;
        //    cashDeno.CreatedDate = DateTime.Now;
        //    return cashDeno;
        //}

        //public string GetCOA(string code, string branch)
        //{
        //    ChargeOfAccountDTO coa = CXCOM00011.Instance.GetScalarObject<ChargeOfAccountDTO>("COA.Server.SelectAccountName", new object[] { code, branch, true });
        //    string accountName = coa.AccountName;
        //    return accountName;
        //}

        //public string GetTransactionStatus(string transactionCode)
        //{
        //    TLMDTO00005 transactionType = this.TranTypeDAO.SelectTranTypeStatus(transactionCode);
        //    string status = transactionType.Status;
        //    return status;
        //}

        //public string GetReference(string transactionCode)
        //{
        //    TLMDTO00005 transactionType = this.TranTypeDAO.SelectByTranCode(transactionCode);
        //    string reference = transactionType.RVReference;
        //    return reference;
        //}

        #endregion

      
    }
}
