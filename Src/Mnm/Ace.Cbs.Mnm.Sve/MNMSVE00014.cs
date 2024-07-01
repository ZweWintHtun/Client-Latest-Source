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
using Spring.Transaction;
using Spring.Transaction.Interceptor;


namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00014:BaseService,IMNMSVE00014
    {
        #region DAO
        public ITLMDAO00015 CashDenoDAO { get; set; }
        public ITLMDAO00009 DepoDenoDAO { get; set; }
        public ITLMDAO00016 PODAO { get; set; }
        public ICXSVE00002 CodeGenerator { get; set; }
        public IPFMDAO00054 TLFDAO { get; set; }
        public ITLMDAO00005 TranTypeDAO { get; set; }
        #endregion

        #region Properties
        public string voucherNo { get; set; }
        public string nextVoucherNo { get; set; }
        public string OrgnEno { get; set; }
        public string OrgnTransactionCode { get; set; }
        public string OrgnPaymentOrderNo { get; set; }
        public decimal rate { get; set; }
        public DateTime settlementDate { get; set; }
        public string currency { get; set; }
        public string channel { get; set; }
        #endregion

        #region Methods
        public IList<TLMDTO00015> GetDepoDenoAndCashDeno(string groupNo, string sourceBranch)
        {
            return CashDenoDAO.GetDepoDenoAndCashDeno(groupNo, sourceBranch);
        }

        public TLMDTO00016 GetDepoDenoData(string groupNo, string poNo, string budget, string sourceBranch)
        {
            TLMDTO00016 po = new TLMDTO00016();
            TLMDTO00009 depoDeno = this.DepoDenoDAO.SelectDepoDeno(groupNo, poNo, sourceBranch);
            if (depoDeno == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV30023";//Refund PO No. for this Group No.
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
                        TLMDTO00015 cashDeno = this.CashDenoDAO.GetMultiPO(groupNo, poNo, sourceBranch,"R");
                        if (cashDeno == null)
                        {
                            this.ServiceResult.ErrorOccurred = true;
                            this.ServiceResult.MessageCode = "ME00003";//Deno record not found for this transaction
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

        public TLMDTO00016 GetPOData(string poNo, string budget,string sourceBranch)
        {
            TLMDTO00016 po = PODAO.GetPOData(poNo, budget, sourceBranch);
           
            if (po != null)
            {
                TLMDTO00015 cashDeno = this.CashDenoDAO.GetSinglePO(poNo, sourceBranch);
              
               if (cashDeno == null)
               {
                   this.ServiceResult.ErrorOccurred = true;
                   this.ServiceResult.MessageCode = "MV00103";//Invalid PO No.
               }
               else
               {
                   po.CashDenoDTO = cashDeno;
               }
            }
            return po;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00054> SaveSinglePO(TLMDTO00016 dto, CXDTO00001 denodto)
        {
            try
            {
                IList<PFMDTO00054> POINFO = new List<PFMDTO00054>();
                this.Adjustment(dto);
                this.CashDenoDAO.UpdateCashDenoByDenoEntryNo(voucherNo, OrgnEno, dto.PONo, dto.SourceBranchCode, dto.CreatedUserId, DateTime.Now);

                nextVoucherNo = this.GetVoucherNo(dto.CreatedUserId, dto.SourceBranchCode);
                string narration = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AdjustPOAmount);
                string tranCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.POIssueCash);
                PFMORM00054 tlf = this.GetTLF(nextVoucherNo, dto.ACode, dto.Amount, narration, tranCode, null, null, null, currency,
                                            dto.SourceBranchCode, rate, settlementDate, channel, dto.CreatedUserId,OrgnPaymentOrderNo);
                POINFO.Add(new PFMDTO00054(nextVoucherNo, settlementDate, dto.ACode, dto.Amount, rate.ToString(), string.Empty, currency, string.Empty, string.Empty));
                this.TLFDAO.Save(tlf);

                decimal charges = Convert.ToDecimal(dto.Charges);
                if (dto.Income =="Y")
                {
                    string code = this.GetCOACode(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Income), dto.SourceBranchCode,currency);
                    string narrationdata = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AdjustPOCharges);
                    PFMORM00054 tlfdata = this.GetTLF(nextVoucherNo, code, charges, narrationdata, tranCode, null, null, null, currency,
                                         dto.SourceBranchCode, rate, settlementDate, channel, dto.CreatedUserId,OrgnPaymentOrderNo);
                    POINFO.Add(new PFMDTO00054(nextVoucherNo, settlementDate, code, charges, rate.ToString(), string.Empty, currency, charges.ToString(), string.Empty));
                    this.TLFDAO.Save(tlfdata);
                }

                this.PODAO.UpdatePOByAmount(dto.PONo, dto.Budget, dto.SourceBranchCode, dto.Amount, charges, dto.CreatedUserId, DateTime.Now);

                TLMORM00015 cashDeno = this.GetCashDeno(null, voucherNo, dto.PONo, dto.CreatedUserId, dto.SourceBranchCode, dto.Currency, settlementDate,rate, denodto);
                this.CashDenoDAO.Save(cashDeno);

                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90001";//Saving Successful.
                return POINFO;
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.Message;
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00054> SaveMultiPO(TLMDTO00016 dto, CXDTO00001 denodto)
        {
            try
            {
                IList<PFMDTO00054> POINFO= new List<PFMDTO00054>();
                POINFO = this.Adjustment(dto);
                
               
                nextVoucherNo = this.GetVoucherNo(dto.CreatedUserId, dto.SourceBranchCode);
                string narration = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AdjustPOAmount);
                string tranCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.POIssueCash);
                PFMORM00054 tlf = this.GetTLF(nextVoucherNo, dto.ACode, dto.Amount, narration, tranCode, null, null, null, currency,
                                            dto.SourceBranchCode, rate, settlementDate, channel, dto.CreatedUserId,dto.PONo);
                POINFO.Add(new PFMDTO00054(nextVoucherNo, settlementDate, dto.ACode, dto.Amount, rate.ToString(), string.Empty, currency, string.Empty, string.Empty));
                this.TLFDAO.Save(tlf);

                decimal charges = Convert.ToDecimal(dto.Charges);
                if (dto.Income == "Y")
                {
                    string code = this.GetCOACode(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Income), dto.SourceBranchCode,currency);
                    string narrationdata = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AdjustPOCharges);
                    PFMORM00054 tlfdata = this.GetTLF(nextVoucherNo, code, charges, narrationdata, tranCode, null, null, null, currency,
                                         dto.SourceBranchCode, rate, settlementDate, channel, dto.CreatedUserId,OrgnPaymentOrderNo);
                    POINFO.Add(new PFMDTO00054(nextVoucherNo, settlementDate, code, charges, rate.ToString(), string.Empty, currency, charges.ToString(), string.Empty));
                    this.TLFDAO.Save(tlfdata);
                }

                this.PODAO.UpdatePOByAmount(dto.PONo, dto.Budget, dto.SourceBranchCode, dto.Amount, charges, dto.CreatedUserId, DateTime.Now);
                this.DepoDenoDAO.UpdateDepoDenoByReverseStatus(dto.GroupNo, dto.PONo, dto.SourceBranchCode, dto.CreatedUserId, DateTime.Now,false);  //edited by ASDA
                this.CashDenoDAO.UpdateCashDenoByTlfEnoAndCashDate(nextVoucherNo, dto.CreatedUserId, dto.GroupNo, dto.SourceBranchCode);

                TLMORM00015 cashDeno = this.GetCashDeno(null, dto.GroupNo, null, dto.CreatedUserId, dto.SourceBranchCode, dto.Currency,settlementDate,rate, denodto);
                this.CashDenoDAO.Save(cashDeno);

                decimal finalAmount = Convert.ToDecimal(dto.Amount + dto.Charges);
                TLMORM00009 depoDeno = this.GetDepoDeno(dto.GroupNo, nextVoucherNo, dto.PONo, finalAmount, dto.SourceBranchCode, dto.Currency, dto.CreatedUserId, Convert.ToDecimal(dto.CashDenoDTO.IncomeCharges),Convert.ToDecimal(dto.CashDenoDTO.CommunicationCharges));
                this.DepoDenoDAO.Save(depoDeno);



                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90001";//Saving Successful.
                return POINFO;
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.Message;
                throw new Exception(this.ServiceResult.MessageCode);
            }
           
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00054> DeleteSinglePO(TLMDTO00016 dto)
        {
            try
            {
                IList<PFMDTO00054> POINFO = new List<PFMDTO00054>();
                POINFO = this.Adjustment(dto);
                this.PODAO.DeletePOData(dto.PONo, dto.Budget, dto.SourceBranchCode, dto.CreatedUserId, DateTime.Now);
                this.CashDenoDAO.UpdateCashDenoByDenoEntryNo(voucherNo, OrgnEno, dto.PONo, dto.SourceBranchCode, dto.CreatedUserId, DateTime.Now);

                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90003";//Delete Successful.
                return POINFO;
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.Message;
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00054> DeleteMultiPO(TLMDTO00016 dto, CXDTO00001 denodto)
        {
            try
            {
                IList<PFMDTO00054> POINFO = new List<PFMDTO00054>();
                POINFO = this.Adjustment(dto);
                this.PODAO.DeletePOData(dto.PONo, dto.Budget, dto.SourceBranchCode, dto.CreatedUserId, DateTime.Now);
                this.CashDenoDAO.UpdateCashDenoByTlfEntryNo(voucherNo, dto.GroupNo, dto.SourceBranchCode, dto.CreatedUserId, DateTime.Now,"R");
                this.DepoDenoDAO.UpdateDepoDenoByReverseStatus(dto.GroupNo, dto.PONo, dto.SourceBranchCode, dto.CreatedUserId, DateTime.Now, false);  //edited by ASDA

                TLMORM00015 cashDeno = this.GetCashDeno(null, dto.GroupNo, null, dto.CreatedUserId, dto.SourceBranchCode, dto.Currency, settlementDate,rate, denodto);
                this.CashDenoDAO.Save(cashDeno);

                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90003";//Delete Successful.
                return POINFO;
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.Message;
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00054> Adjustment(TLMDTO00016 dto)
        {
            IList<PFMDTO00054> POInfo = new List<PFMDTO00054>();
             voucherNo = this.GetVoucherNo(dto.CreatedUserId,dto.SourceBranchCode);
             IList<PFMDTO00054> TLFData = this.TLFDAO.SelectTlfDataByPONo(dto.PONo, dto.SourceBranchCode);
             OrgnEno = TLFData[0].Eno;
             OrgnTransactionCode = TLFData[0].TransactionCode;
             OrgnPaymentOrderNo = TLFData[0].PaymentOrderNo;
             rate = Convert.ToDecimal(TLFData[0].Rate);
             settlementDate = Convert.ToDateTime(TLFData[0].SettlementDate);
             currency = TLFData[0].CurrencyCode;
             channel = TLFData[0].Channel;
            string adjustNarration = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AdjustPODelete);
            string adjustTranCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReversalPOIssueCash);
            PFMORM00054 tlf = this.GetTLF(voucherNo, dto.ACode, dto.OldAmount, adjustNarration, adjustTranCode, OrgnEno, OrgnTransactionCode, OrgnPaymentOrderNo, currency,
                            dto.SourceBranchCode, rate, settlementDate, channel, dto.CreatedUserId,null);
            POInfo.Add(new PFMDTO00054(voucherNo, settlementDate, dto.ACode, dto.OldAmount, rate.ToString(), OrgnEno, currency, string.Empty, string.Empty));
            this.TLFDAO.Save(tlf);

            decimal charges = Convert.ToDecimal(dto.OldCharges);
            if (dto.Income=="Y")
            {
                string code = this.GetCOACode(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Income), dto.SourceBranchCode,currency);
                PFMORM00054 tlfdata = this.GetTLF(voucherNo, code, charges, adjustNarration, adjustTranCode, OrgnEno, OrgnTransactionCode, OrgnPaymentOrderNo, currency,
                                     dto.SourceBranchCode, rate, settlementDate, channel, dto.CreatedUserId,null);
                POInfo.Add(new PFMDTO00054(voucherNo, settlementDate, code, charges, rate.ToString(), OrgnEno, currency, charges.ToString(), string.Empty));
                this.TLFDAO.Save(tlfdata);
            }

            this.TLFDAO.UpdateTlfByOrgnEno(voucherNo, adjustTranCode, dto.PONo, dto.SourceBranchCode, dto.CreatedUserId, DateTime.Now);
            //TLMDTO00015 cashDTO = this.CashDenoDAO.SelectByEno(OrgnEno, dto.SourceBranchCode);
            //if (cashDTO != null)
            //{
            //    this.CashDenoDAO.UpdateCashDenoByDenoEntryNo(voucherNo, OrgnEno, dto.PONo, dto.SourceBranchCode, dto.CreatedUserId, DateTime.Now);
            //}
            return POInfo;
        }

        public string GetCOA(string code, string branch)
        {
            ChargeOfAccountDTO coa = CXCOM00011.Instance.GetScalarObject<ChargeOfAccountDTO>("COA.Server.SelectAccountName", new object[] { code, branch, true });
            string accountName = coa.AccountName;
            return accountName;
        }

        public string GetCOACode(string accountName, string branch,string currency)
        {
            string acode = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { accountName, currency, branch, true });
            return acode;
        }

        public string GetTransactionStatus(string transactionCode)
        {
            TLMDTO00005 transactionType = this.TranTypeDAO.SelectTranTypeStatus(transactionCode);
            string status = transactionType.Status;
            return status;
        }

        public string GetVoucherNo(int updatedUserId,string sourceBranch)
        {
            DateTime date = DateTime.Now;
            string day = date.Day.ToString().PadLeft(2, '0');
            string month = date.Month.ToString().PadLeft(2, '0');
            string year = date.Year.ToString().Substring(2);

            voucherNo = this.CodeGenerator.GetGenerateCode("AdjustmentVoucher", string.Empty, updatedUserId, sourceBranch, new object[] { day, month, year });
            return voucherNo;
        }

        private TLMORM00015 GetCashDeno(string denoEntryNo,string tlfEntryNo,string acType,int createdUserId,string sourceBranch,string currency,DateTime settlementDate,decimal rate,CXDTO00001 denodto)
        {
            TLMORM00015 cashDeno = new TLMORM00015();
            cashDeno.Id = this.CashDenoDAO.SelectMaxId() + 1;
            cashDeno.DenoEntryNo=denoEntryNo;
            cashDeno.TlfEntryNo = tlfEntryNo;
            cashDeno.AccountType = acType;
            cashDeno.Amount = denodto.TotalAmount;
            cashDeno.AdjustAmount = denodto.AdjustAmount;
            cashDeno.CashDate = DateTime.Now;
            cashDeno.DenoDetail = denodto.DenoString;
            cashDeno.DenoRate = denodto.DenoRateString;
            cashDeno.DenoRefundDetail = denodto.RefundString;
            cashDeno.DenoRefundRate = denodto.RefundRateString;
            cashDeno.CounterNo = denodto.CounterNo;
            cashDeno.UserNo = Convert.ToString(createdUserId);
            cashDeno.Status = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);
            cashDeno.Reverse = false;
            cashDeno.SourceBranchCode = sourceBranch;
            cashDeno.Currency = currency;
            cashDeno.SettlementDate = settlementDate;
            cashDeno.Rate = rate;
            cashDeno.Active = true;
            cashDeno.CreatedUserId = createdUserId;
            cashDeno.CreatedDate = DateTime.Now;
            return cashDeno;
        }

        private TLMORM00009 GetDepoDeno(string groupNo,string tlfEntryNo,string acType,decimal amount,string sourceBranch,string currency,int createdUserId, decimal incomeCharges, decimal communicationCharges)
          {
            TLMORM00009 depoDeno = new TLMORM00009();
            depoDeno.GroupNo = groupNo;
            depoDeno.Tlf_Eno = tlfEntryNo;
            depoDeno.AccountType =acType;
            depoDeno.Amount = amount;
            depoDeno.Reverse_Status = false;
            depoDeno.Income = incomeCharges;
            depoDeno.Communicationcharge = communicationCharges;
            depoDeno.SourceBranchCode = sourceBranch;
            depoDeno.Currency = currency;
            depoDeno.CreatedDate = DateTime.Now;
            depoDeno.CreatedUserId =createdUserId;
            depoDeno.Active = true;
            return depoDeno;
          }
            
        private PFMORM00054 GetTLF(string eno,string acode,decimal amount,string narration,string transactionCode,string orgnEno,string orgnTransactionCode,string orgnPONo,
                                   string currency,string sourceBranch,decimal rate,DateTime settlementDate,string channel,int createdUserId,string poNo)
        {
            PFMORM00054 tlf = new PFMORM00054();
            tlf.Id = this.TLFDAO.SelectMaxId() + 1;
            tlf.Eno = eno;
            tlf.AccountNo = acode;
            tlf.Amount =amount;
            tlf.Acode = acode;
            tlf.HomeAmt = tlf.Amount * rate;
            tlf.HomeOAmt = Convert.ToDecimal(0.00);
            tlf.HomeAmount = tlf.HomeAmt + tlf.HomeOAmt;
            tlf.LocalAmt = amount;
            tlf.LocalOAmt = Convert.ToDecimal(0.00);
            tlf.LocalAmount = tlf.LocalAmt + tlf.LocalOAmt;
            tlf.Description = this.GetCOA(tlf.Acode, sourceBranch);
            tlf.Narration = narration;
            tlf.CheckTime = DateTime.Now;
            tlf.DateTime = DateTime.Now;
            tlf.TransactionCode = transactionCode;
            tlf.Status = this.GetTransactionStatus(tlf.TransactionCode);
            tlf.OrgnEno = orgnEno;
            tlf.OrgnTransactionCode = orgnTransactionCode;
            tlf.OrgnPaymentOrderNo = orgnPONo;
            tlf.PaymentOrderNo = poNo;
            tlf.UserNo = Convert.ToString(createdUserId);
            tlf.CurrencyCode = currency;
            tlf.SourceCurrency = currency;
            tlf.SourceBranchCode = sourceBranch;
            tlf.Rate = rate;
            tlf.SettlementDate = settlementDate;
            tlf.Channel = channel;
            tlf.CreatedDate = DateTime.Now;
            tlf.CreatedUserId = createdUserId;
            tlf.Active = true;
            return tlf;
        }
              
            
        #endregion
    }
}
