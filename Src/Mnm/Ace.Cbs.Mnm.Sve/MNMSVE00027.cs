using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Dto;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00027 : BaseService, IMNMSVE00027
    {
        ITLMDAO00017 RDDAO { get; set; }
        ITLMDAO00015 CashDenoDAO { get; set; }
        ITLMDAO00009 DepoDenoDAO { get; set; }
        IPFMDAO00054 _TLFDAO { get; set; }
        ICXSVE00006 ReverSalDAO { get; set; }
        ICXSVE00002 CodeGenerator { get; set; }
        ICXDAO00006 CodeCheckerDAO { get; set; }
        IPFMDAO00056 Sys001DAO { get; set; }
        ICXDAO00004 TLFDAO { get; set; }
        ICXDAO00003 PrintDAO { get; set; }
        ICXDAO00013 FPRNDAO { get; set; }
        private decimal rate;
        private DateTime nextSettlementDate;
        public TLMDTO00005 TranDTO { get; set; }
        public IList<PFMDTO00054> TLF_LIST { get; set; }

        public TLMDTO00017 DrawingRegisterNoValidate(string RegisterNo, string SourceBranchCode)
        {
            TLMDTO00017 DrawingRemittanceDTO = new TLMDTO00017();
            try
            {
                if (string.IsNullOrEmpty(RegisterNo))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME90018;//Invalid Parameter Value.
                }
                if (string.IsNullOrEmpty(SourceBranchCode))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME90018;//Invalid Parameter Value.
                }
                DrawingRemittanceDTO = RDDAO.SelectByRegisterNo(RegisterNo, SourceBranchCode);
                if (DrawingRemittanceDTO == null || string.IsNullOrEmpty(DrawingRemittanceDTO.Dbank))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00168;//Invalid Parameter Value.
                }
                //TLMDTO00015 cashdenoinfo = CashDenoDAO.SelectCashDenoInfoByACType(RegisterNo, SourceBranchCode);
                ////TLMDTO00015 cashdenoinfo = new TLMDTO00015();
                //if (cashdenoinfo != null || !string.IsNullOrEmpty(cashdenoinfo.AccountType))
                //{
                //    DrawingRemittanceDTO.GroupNo = string.IsNullOrEmpty(DepoDenoDAO.SelectGroupNoByAcType(RegisterNo, SourceBranchCode)) == true ? string.Empty : DepoDenoDAO.SelectGroupNoByAcType(RegisterNo, SourceBranchCode);
                //}
                string groupNo = this.DepoDenoDAO.SelectGroupNoByAcType(RegisterNo, SourceBranchCode);
                DrawingRemittanceDTO.GroupNo = groupNo;
                return DrawingRemittanceDTO == null ? null : DrawingRemittanceDTO;
            }
            catch (Exception ex)
            {
                return DrawingRemittanceDTO;
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00054> Save(TLMDTO00017 drawingRegisterDTO, CXDTO00001 DenoInfo, bool isVoucher)
        {
            try
            {
                IList<PFMDTO00054> ListTLFDTO = new List<PFMDTO00054>();
                ListTLFDTO = _TLFDAO.SelectByDRegisterNo(drawingRegisterDTO.RegisterNo, drawingRegisterDTO.SourceBranchCode, System.DateTime.Now);
                this.rate = CXCOM00010.Instance.GetExchangeRate(drawingRegisterDTO.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType));

                #region Get NextSettlementDate
                this.nextSettlementDate = this.Sys001DAO.SelectSysDate("NEXT_SETTLEMENT_DATE", drawingRegisterDTO.SourceBranchCode);
                if (this.nextSettlementDate == null || this.nextSettlementDate.ToString() == string.Empty)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MI30027";     //NextSettlementDate Not Found
                    return ListTLFDTO;
                }
                #endregion

                else
                {                    
                    if (ListTLFDTO.Count > 0)
                    {
                        string ReversalVouno = string.Empty;
                        DateTime sys001 = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), drawingRegisterDTO.SourceBranchCode, true });

                        string day = sys001.Day.ToString().PadLeft(2, '0');
                        string month = sys001.Month.ToString().PadLeft(2, '0');
                        string year = sys001.Year.ToString().Substring(2);
                        int? updatedUserId = drawingRegisterDTO.UpdatedUserId;

                        //to get vouno => " R + day + month + year + serial "
                        //ReversalVouno = this.CodeGenerator.GetGenerateCode("Reversal Voucher", string.Empty, updatedUserId, CurrentUserEntity.BranchCode, new object[] { day, month, year });                                 //To get Reversal Voucher No 
                        ReversalVouno = this.CodeGenerator.GetGenerateCode("Reversal Code", string.Empty, Convert.ToInt32(updatedUserId), drawingRegisterDTO.SourceBranchCode, new object[] { day, month, year });
                       
                        //Reversal Process
                        this.ReversalProcess(ListTLFDTO[0].Eno, ReversalVouno, drawingRegisterDTO.GroupNo, drawingRegisterDTO.SourceBranchCode, System.DateTime.Now, drawingRegisterDTO.SourceBranchCode, Convert.ToInt32(updatedUserId), null, string.Empty, true);
                        TLF_LIST[0].Eno = ReversalVouno;
                        TLF_LIST[0].OrgnEno = ListTLFDTO[0].Eno;
                        for (int i = 0; i < TLF_LIST.Count; i++)
                        {
                            TLMDTO00005 reversaltrancodedto = this.CodeCheckerDAO.SelectByTranCode(this.CodeCheckerDAO.SelectByTranCode(TLF_LIST[i].TransactionCode).RVReference);
                            TLF_LIST[i].Status = reversaltrancodedto.Status;
                        }

                        //group
                        if (!string.IsNullOrEmpty(drawingRegisterDTO.GroupNo))
                        {
                            //already Voucher
                            if (isVoucher)
                            {
                                //Update Cash Deno by Reverse =true and DEnoEntyNo=Reversal ENO
                                this.CodeCheckerDAO.UpdateCashDenoByENO(drawingRegisterDTO.GroupNo, ReversalVouno, drawingRegisterDTO.SourceBranchCode, drawingRegisterDTO.UpdatedUserId.Value);
                                //Update DepoDeno Reverse =1
                                this.CodeCheckerDAO.UpdateDepoDenoByTLF_EnoGropuNoSourceBr(ListTLFDTO[0].Eno, drawingRegisterDTO.GroupNo, drawingRegisterDTO.SourceBranchCode, drawingRegisterDTO.UpdatedUserId.Value);
                                this.DepoDenoDAO.DeleteByGroupNoAndACType(drawingRegisterDTO.RegisterNo, drawingRegisterDTO.SourceBranchCode, drawingRegisterDTO.UpdatedUserId.Value, drawingRegisterDTO.GroupNo);

                                //still other group amount
                                if (DenoInfo != null)
                                {
                                    //insert CashDeno
                                    this.CashDenoDAO.Save(this.ConvertToCashDenoORM(drawingRegisterDTO, DenoInfo));
                                }
                            }
                            //not Voucher yet
                            else
                            {
                                //still other group amount
                                if (DenoInfo != null)
                                {
                                    //Update CashDeno
                                    this.CashDenoDAO.UpdateCashDenoByTlfEno(DenoInfo, drawingRegisterDTO.UpdatedUserId.Value, drawingRegisterDTO.SourceBranchCode, drawingRegisterDTO.GroupNo, drawingRegisterDTO.CashAmount.Value);
                                    //Delete DepoDeno
                                    this.DepoDenoDAO.DeleteByGroupNoAndACType(drawingRegisterDTO.RegisterNo, drawingRegisterDTO.SourceBranchCode, drawingRegisterDTO.UpdatedUserId.Value, drawingRegisterDTO.GroupNo);

                                }
                                //no other group amount
                                else
                                {
                                    //Delete CashDeno By TlfEno
                                    this.CashDenoDAO.DeleteByTlfEno(drawingRegisterDTO.GroupNo, drawingRegisterDTO.SourceBranchCode, drawingRegisterDTO.UpdatedUserId.Value);
                                    //Delete DepoDeno
                                    this.DepoDenoDAO.DeleteByGroupNoAndACType(drawingRegisterDTO.RegisterNo, drawingRegisterDTO.SourceBranchCode, drawingRegisterDTO.UpdatedUserId.Value, drawingRegisterDTO.GroupNo);
                                }
                            }
                        }
                        //single
                        else
                        {
                            if (isVoucher)
                            {
                                this.CodeCheckerDAO.UpdateCashDenoByAcType(drawingRegisterDTO.RegisterNo, ReversalVouno, drawingRegisterDTO.SourceBranchCode, drawingRegisterDTO.UpdatedUserId.Value);
                            }

                            else
                            {
                                if (DenoInfo != null)
                                {
                                    this.CashDenoDAO.UpdateCashDenoByACType(DenoInfo, drawingRegisterDTO.UpdatedUserId.Value, drawingRegisterDTO.SourceBranchCode, drawingRegisterDTO.RegisterNo, drawingRegisterDTO.CashAmount.Value);
                                    this.CodeCheckerDAO.UpdateCashDenoByENO(ListTLFDTO[0].Eno, ReversalVouno, drawingRegisterDTO.SourceBranchCode, drawingRegisterDTO.UpdatedUserId.Value);
                                }
                                else
                                {
                                    this.CashDenoDAO.DeleteByACType(drawingRegisterDTO.RegisterNo, drawingRegisterDTO.SourceBranchCode, drawingRegisterDTO.UpdatedUserId.Value);
                                }
                            }


                        }

                        RDDAO.DeleteByRegisterNo(drawingRegisterDTO.RegisterNo, drawingRegisterDTO.SourceBranchCode, drawingRegisterDTO.UpdatedUserId.Value);
                    }
                    else  //Added by ASDA
                    {
                        if (!string.IsNullOrEmpty(drawingRegisterDTO.GroupNo))
                        {
                            if (DenoInfo != null)
                            {

                                //Update CashDeno
                                this.CashDenoDAO.UpdateCashDenoByTlfEno(DenoInfo, drawingRegisterDTO.UpdatedUserId.Value, drawingRegisterDTO.SourceBranchCode, drawingRegisterDTO.GroupNo, drawingRegisterDTO.CashAmount.Value);
                                //Delete DepoDeno
                                this.DepoDenoDAO.DeleteByGroupNoAndACType(drawingRegisterDTO.RegisterNo, drawingRegisterDTO.SourceBranchCode, drawingRegisterDTO.UpdatedUserId.Value, drawingRegisterDTO.GroupNo);

                            }
                            else
                            {

                                //Delete CashDeno By TlfEno
                                this.CashDenoDAO.DeleteByTlfEno(drawingRegisterDTO.GroupNo, drawingRegisterDTO.SourceBranchCode, drawingRegisterDTO.UpdatedUserId.Value);
                                //Delete DepoDeno
                                this.DepoDenoDAO.DeleteByGroupNoAndACType(drawingRegisterDTO.RegisterNo, drawingRegisterDTO.SourceBranchCode, drawingRegisterDTO.UpdatedUserId.Value, drawingRegisterDTO.GroupNo);
                            }
                        }
                        else
                        {

                            this.CashDenoDAO.DeleteByACType(drawingRegisterDTO.RegisterNo, drawingRegisterDTO.SourceBranchCode, drawingRegisterDTO.UpdatedUserId.Value);

                        }

                        RDDAO.DeleteByRegisterNo(drawingRegisterDTO.RegisterNo, drawingRegisterDTO.SourceBranchCode, drawingRegisterDTO.UpdatedUserId.Value);
                    }

                    return TLF_LIST;
                }

            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MI30041"; //Reversal Transaction Fail.
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }

        public bool SelectForDenoForm(TLMDTO00017 drawingRegisterDTO, out IList<TLMDTO00015> ListCashDeno, out decimal? RemainingAmount)
        {
            //IList<TLMDTO00015> ListCashDeno = new List<TLMDTO00015>();
            try
            {
                if (string.IsNullOrEmpty(drawingRegisterDTO.RegisterNo))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME90018;//Invalid Parameter Value.
                }
                if (string.IsNullOrEmpty(drawingRegisterDTO.GroupNo))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME90018;//Invalid Parameter Value.
                }
                if (string.IsNullOrEmpty(drawingRegisterDTO.SourceBranchCode))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME90018;//Invalid Parameter Value.
                }
                string GroupNo = string.IsNullOrEmpty(DepoDenoDAO.SelectGroupNoByAcType(drawingRegisterDTO.RegisterNo, drawingRegisterDTO.SourceBranchCode)) == true ? string.Empty : DepoDenoDAO.SelectGroupNoByAcType(drawingRegisterDTO.RegisterNo, drawingRegisterDTO.SourceBranchCode);
                if (!string.IsNullOrEmpty(GroupNo))
                {
                    ListCashDeno = CashDenoDAO.GetCashDenoInfo(drawingRegisterDTO.GroupNo, "R", drawingRegisterDTO.SourceBranchCode);
                    if (ListCashDeno.Count > 0)
                    {
                        foreach (TLMDTO00015 CashDenoDTO in ListCashDeno)
                        {
                            if (CashDenoDTO.CashDate != null)
                            {
                                RemainingAmount = CashDenoDTO.Amount - drawingRegisterDTO.Amount;
                                if (RemainingAmount == 0)
                                {
                                    return false;
                                    //Save(drawingRegisterDTO);
                                }
                                else if (RemainingAmount > 0)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
                RemainingAmount = 0;
                ListCashDeno = null;
                return false;
            }
            catch (Exception ex)
            {
                RemainingAmount = 0;
                ListCashDeno = null;
                return false;
            }
        }

        public TLMDTO00017 GetOtherGroupAmount(string groupNo, string registerNo, string sourceBr)
        {
            TLMDTO00017 returnEntity = new TLMDTO00017();
            //Select Other Amount
            returnEntity.Amount = this.DepoDenoDAO.SelectOtherAmountByGroupNo(groupNo, registerNo, sourceBr);
            return returnEntity;
        }

 public TLMDTO00017 GetGroupAmount(string groupNo, string registerNo, string sourceBr)
        {
            TLMDTO00017 returnEntity = new TLMDTO00017();
            //Select Other Amount
            returnEntity.Amount = this.DepoDenoDAO.SelectAmountByGroupNo(groupNo, registerNo, sourceBr);
            return returnEntity;
        }

        public TLMDTO00015 GetAmountByAcType(string acType, string sourceBranchCode)
        {
            TLMDTO00015 returnEntity = new TLMDTO00015();
            returnEntity.Amount = this.CashDenoDAO.SelectAmountByACType(acType, sourceBranchCode);
            return returnEntity;
        }
        private TLMORM00015 ConvertToCashDenoORM(TLMDTO00017 entity, CXDTO00001 denoInfo)
        {
            TLMORM00015 CashDenoORM = new TLMORM00015();
            CashDenoORM.DenoEntryNo = null;
            CashDenoORM.TlfEntryNo = entity.GroupNo;
            CashDenoORM.AccountType = string.IsNullOrEmpty(entity.GroupNo) ? entity.RegisterNo : null;
            CashDenoORM.FromType = null;
            CashDenoORM.BranchCode = null;
            CashDenoORM.ReceiptNo = null;
            CashDenoORM.Amount = entity.CashAmount;
            CashDenoORM.AdjustAmount = denoInfo.AdjustAmount;
            CashDenoORM.CashDate = DateTime.Now;
            CashDenoORM.DenoDetail = denoInfo.DenoString;
            CashDenoORM.DenoRefundDetail = denoInfo.RefundString;
            CashDenoORM.UserNo = entity.CreatedUserId.ToString();
            CashDenoORM.CounterNo = denoInfo.CounterNo;
            CashDenoORM.Status = "R";
            CashDenoORM.Reverse = false;
            CashDenoORM.UniqueId = null;
            CashDenoORM.SourceBranchCode = entity.SourceBranchCode;
            CashDenoORM.Currency = entity.Currency;
            CashDenoORM.DenoRate = denoInfo.DenoRateString;
            CashDenoORM.DenoRefundRate = denoInfo.RefundRateString;
            CashDenoORM.SettlementDate = this.nextSettlementDate;
            CashDenoORM.AllDenoRate = null;
            CashDenoORM.Rate = this.rate;
            CashDenoORM.Active = true;
            CashDenoORM.CreatedDate = DateTime.Now;
            CashDenoORM.CreatedUserId = entity.CreatedUserId;

            return CashDenoORM;
 }

        public bool CheckDenoStatus(string registerNo, string sourceBr)
        {
            TLMDTO00017 RDInfo = RDDAO.SelectDrawingDataByRegisterNo(registerNo,sourceBr);
            if (!string.IsNullOrEmpty(RDInfo.Deno_Status))
                return true;
            else
                return false;
       
}

        #region REVERSAL

        [Transaction(TransactionPropagation.Required)]
        public void ReversalProcess(string ENO, string ReversalENO, string GroupNo, string BranchCode, DateTime Date, string ActiveBranch, int UpdatedUserID, TLMDTO00015 casndenodto, string Trancode, bool IsCbalChanges)
        {
            #region validation
            if (string.IsNullOrEmpty(ENO))
            {
                throw new Exception("ME90018");//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(ReversalENO))
            {
                throw new Exception("ME90018");//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(BranchCode))
            {
                throw new Exception("ME90018");//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(Date.ToString()))
            {
                throw new Exception("ME90018");//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(ActiveBranch))
            {
                throw new Exception("ME90018");//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(UpdatedUserID.ToString()))
            {
                throw new Exception("ME90018");//Invalid Parameter Value.
            }
            //if (casndenodto == null || string.IsNullOrEmpty(casndenodto.AccountType.ToString()))
            //{
            //    throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            //}
            if (Date.Date != System.DateTime.Now.Date)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME30002";
                return;//Not Allow Back Date Transaction
            }
            #endregion
            #region validate Entry No
            IList<PFMDTO00054> ListTLFdto;
            PFMDTO00028 cledgerDTO;
            PFMDTO00023 fledgerDTO;
            IList<TLMDTO00004> ListIBLTLFDTO;
            //Select TLF By ENO, ActiveBranch, Date
            ListTLFdto = this.CodeCheckerDAO.SelectTLFByENOBranchCodeDate(ENO, BranchCode, Date, Trancode);
            TLF_LIST = ListTLFdto;
            //Check List TLF DTO count is Less than Equal 0 or not 
            if (ListTLFdto.Count <= 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV00213"; //Entry No Not Found
                return;
            }
            else
            {
                //Check the top of tlf object,these are already issue or not
                if (!string.IsNullOrEmpty(ListTLFdto[0].OrgnEno))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME30003"; //Already Reverse Voucher
                    return;
                }
            }
            #endregion
            #region reversal TLF
            foreach (PFMDTO00054 tlfdto in ListTLFdto)
            {
                /////Insert Into TLF
                TLMDTO00005 reversaltrancodedto = this.CodeCheckerDAO.SelectByTranCode(this.CodeCheckerDAO.SelectByTranCode(tlfdto.TransactionCode).RVReference);
                TranDTO = reversaltrancodedto;
 
                #region Convert ORGTLFDTO to Reversal TLF DTO
                PFMORM00054 ReversalTLFORM = new PFMORM00054();

                ReversalTLFORM.Id = this.TLFDAO.SelectMaxId() + 1;
                ReversalTLFORM.Eno = ReversalENO;
                ReversalTLFORM.OrgnEno = ENO;
                ReversalTLFORM.OrgnTransactionCode = tlfdto.TransactionCode;
                ReversalTLFORM.OrgnPaymentOrderNo = tlfdto.PaymentOrderNo;
                ReversalTLFORM.OrgnDRegister = tlfdto.DRegisterNo;
                ReversalTLFORM.OrgnERegister = tlfdto.ERegisterNo;
                ReversalTLFORM.OrgnLgNo = tlfdto.LgNo;
                ReversalTLFORM.OrgnLNo = tlfdto.Lno;
                ReversalTLFORM.OrgnCheque = tlfdto.Cheque;

                ReversalTLFORM.AccountNo = tlfdto.AccountNo;
                ReversalTLFORM.Amount = tlfdto.Amount;
                ReversalTLFORM.Acode = tlfdto.Acode;
                ReversalTLFORM.HomeAmount = tlfdto.HomeAmount;
                ReversalTLFORM.HomeAmt = tlfdto.HomeAmt;
                ReversalTLFORM.HomeOAmt = tlfdto.HomeOAmt;
                ReversalTLFORM.LocalAmount = tlfdto.LocalAmount;
                ReversalTLFORM.LocalAmt = tlfdto.LocalAmt;
                ReversalTLFORM.LocalOAmt = tlfdto.LocalOAmt;
                ReversalTLFORM.SourceCurrency = tlfdto.SourceCurrency;
                ReversalTLFORM.CurrencyCode = tlfdto.CurrencyCode;
                ReversalTLFORM.Cheque = tlfdto.Cheque;
                ReversalTLFORM.PaymentOrderNo = tlfdto.PaymentOrderNo;
                ReversalTLFORM.DRegisterNo = tlfdto.DRegisterNo;
                ReversalTLFORM.ERegisterNo = tlfdto.ERegisterNo;
                ReversalTLFORM.LgNo = tlfdto.LgNo;
                ReversalTLFORM.Lno = tlfdto.Lno;
                ReversalTLFORM.Description = tlfdto.Description;
                //Reversal TranType DTO Description
                ReversalTLFORM.Narration = reversaltrancodedto.Description;
                ReversalTLFORM.DateTime = tlfdto.DateTime;
                //Reversal TranType DTO Transaction Status
                ReversalTLFORM.Status = reversaltrancodedto.Status;
                //Reversal TranType DTO Transaction Code
                ReversalTLFORM.TransactionCode = reversaltrancodedto.TransactionCode;
                ReversalTLFORM.AccountSign = tlfdto.AccountSign;
                ReversalTLFORM.DOMBankPost = tlfdto.DOMBankPost;
                ReversalTLFORM.CLRPostStatus = tlfdto.CLRPostStatus;
                ReversalTLFORM.UserNo = UpdatedUserID.ToString();
                ReversalTLFORM.ContraENo = tlfdto.ContraENo;
                ReversalTLFORM.ContraLNo = tlfdto.ContraLNo;
                //ReversalTLFORM.ContraDateTime = tlfdto.ContraDateTime;
                ReversalTLFORM.OtherBank = tlfdto.OtherBank;
                ReversalTLFORM.DeliverReturn = tlfdto.DeliverReturn;
                ReversalTLFORM.ReceiptNo = tlfdto.ReceiptNo;
                ReversalTLFORM.OtherBankChq = tlfdto.OtherBankChq;
                ReversalTLFORM.CheckTime = tlfdto.DateTime;
                ReversalTLFORM.OtherBankAcctNo = tlfdto.OtherBankAcctNo;
                ReversalTLFORM.SettlementDate = tlfdto.SettlementDate;
                ReversalTLFORM.CustomerId = tlfdto.CustomerId;
                ReversalTLFORM.GChequeNo = tlfdto.GChequeNo;
                ReversalTLFORM.SourceBranchCode = tlfdto.SourceBranchCode;
                ReversalTLFORM.Rate = tlfdto.Rate;
                ReversalTLFORM.Active = true;
                ReversalTLFORM.Channel = tlfdto.Channel;
                ReversalTLFORM.ReferenceVoucherNo = tlfdto.ReferenceVoucherNo;
                ReversalTLFORM.ReferenceType = tlfdto.ReferenceType;

                ReversalTLFORM.CreatedUserId = UpdatedUserID;
                ReversalTLFORM.CreatedDate = DateTime.Now;
                #endregion
                //Insert TLF
                this.TLFDAO.Save(ReversalTLFORM);

                //update Original TLF 
                this.CodeCheckerDAO.UpdateTLFOrgnENOOrgnTranCodeByENO(ReversalENO,tlfdto.AccountNo, reversaltrancodedto.TransactionCode, ENO, BranchCode, UpdatedUserID, DateTime.Now);

                //Select CLdger By Account No
                cledgerDTO = this.CodeCheckerDAO.GetAccountInfoOfCledgerByAccountNo(tlfdto.AccountNo);
                if (cledgerDTO != null && string.IsNullOrEmpty(cledgerDTO.AccountNo))
                {
                    //Select Fledger by Account No
                    fledgerDTO = this.CodeCheckerDAO.GetAccountInfoOfFledgerByAccountNo(tlfdto.AccountNo);
                    if (fledgerDTO != null && !string.IsNullOrEmpty(fledgerDTO.AccountNo))
                    {
                        if (tlfdto.Status.Substring(1, 1) == "C")
                        {
                            if (fledgerDTO.FixedBalance - tlfdto.Amount >= 0)
                            {
                                //Update FLedger
                                this.CodeCheckerDAO.UpdateFLedgerByAccountNo(tlfdto.AccountNo);
                                //Update FReceipt
                                this.CodeCheckerDAO.UpdateFReceiptByAccountNoRNO(tlfdto.AccountNo, tlfdto.ReceiptNo, fledgerDTO.FixedBalance - tlfdto.Amount, UpdatedUserID);
                                //FPRN File Common Module
                                PFMORM00058 FPRNORM = new PFMORM00058();
                                FPRNORM.AccountNo = tlfdto.AccountNo;
                                FPRNORM.Balance = fledgerDTO.FixedBalance;
                                FPRNORM.Reference = reversaltrancodedto.PBReference;
                                if (reversaltrancodedto.Status[1] == 'C')
                                {
                                    FPRNORM.Debit = 0;
                                    FPRNORM.Credit = tlfdto.Amount;
                                }
                                else
                                {
                                    FPRNORM.Debit = tlfdto.Amount;
                                    FPRNORM.Credit = 0;
                                }
                                //FPRNORM.PrintLineNo= cledgerDTO.PrintLineNo;
                                FPRNORM.CurrencyId = tlfdto.CurrencyCode;
                                FPRNORM.SourceBr = BranchCode;
                                FPRNORM.AccessDate = System.DateTime.Now;
                                FPRNORM.CreatedDate = System.DateTime.Now;
                                FPRNORM.CreatedUserId = UpdatedUserID;
                                FPRNORM.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
                                //FPRNORM.UserNo

                                this.FPRNDAO.Save(FPRNORM);
                            }
                            else
                            {
                                throw new Exception(CXMessage.MV00109);//Insufficient amount
                            }
                        }
                        else
                        {
                            //Update FLedger
                            this.CodeCheckerDAO.UpdateFLedgerByAccountNo(tlfdto.AccountNo);
                            //Update FReceipt
                            this.CodeCheckerDAO.UpdateFReceiptByAccountNoRNO(tlfdto.AccountNo, tlfdto.ReceiptNo, fledgerDTO.FixedBalance + tlfdto.Amount, UpdatedUserID);
                            /////FPRN File Common Module
                            PFMORM00058 FPRNORM = new PFMORM00058();
                            FPRNORM.AccountNo = tlfdto.AccountNo;
                            FPRNORM.Balance = fledgerDTO.FixedBalance;
                            FPRNORM.Reference = reversaltrancodedto.PBReference;
                            if (reversaltrancodedto.Status[1] == 'C')
                            {
                                FPRNORM.Debit = 0;
                                FPRNORM.Credit = tlfdto.Amount;
                            }
                            else
                            {
                                FPRNORM.Debit = tlfdto.Amount;
                                FPRNORM.Credit = 0;
                            }
                            //FPRNORM.PrintLineNo= cledgerDTO.PrintLineNo;
                            FPRNORM.CurrencyId = tlfdto.CurrencyCode;
                            FPRNORM.SourceBr = BranchCode;
                            FPRNORM.AccessDate = System.DateTime.Now;
                            FPRNORM.CreatedDate = System.DateTime.Now;
                            FPRNORM.CreatedUserId = UpdatedUserID;
                            FPRNORM.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
                            //FPRNORM.UserNo

                            this.FPRNDAO.Save(FPRNORM);
                        }
                    }
                }
                else if (cledgerDTO != null && !string.IsNullOrEmpty(cledgerDTO.AccountNo))
                {
                    //Check Credit or Debit
                    if (tlfdto.Status.Substring(1, 1) == "C")
                    {
                        if (IsCbalChanges)
                        {
                            if (cledgerDTO.CurrentBal - (cledgerDTO.MinimumBalance + tlfdto.Amount) >= 0)
                            {
                                //Update Cledger
                                this.CodeCheckerDAO.UpdateCurrentBalance(tlfdto.AccountNo, cledgerDTO.CurrentBal - tlfdto.Amount, ++cledgerDTO.TransactionCount, UpdatedUserID, UpdatedUserID.ToString());
                            }
                            else
                            {
                                throw new Exception("MV00109");//Insufficient amount
                            }
                        }
                    }
                    else
                    {
                        if (IsCbalChanges)
                        {
                            //Update Cledger
                            this.CodeCheckerDAO.UpdateCurrentBalance(tlfdto.AccountNo, cledgerDTO.CurrentBal + tlfdto.Amount, ++cledgerDTO.TransactionCount, UpdatedUserID, UpdatedUserID.ToString());
                        }
                    }
                }

                //Check AC Type or (Maybe Common Module)
                //Check Account Type Current or Saving .Contains("C".ToUpper()))
                if (!string.IsNullOrEmpty(tlfdto.AccountSign))
                {
                    if (tlfdto.AccountSign[0] == 'C')
                    {
                        //Check UCheque Exist or Not
                        if (this.CodeCheckerDAO.CheckUchequeByAccountNoChequeNo(tlfdto.AccountNo, tlfdto.Cheque, BranchCode))
                        {
                            //Delete UCheque
                            this.CodeCheckerDAO.DeletefromUCheckbyChequeNoAccountNo(tlfdto.AccountNo, tlfdto.Cheque, BranchCode, UpdatedUserID);
                        }
                    }
                    //Check Account Type Current or Saving ("S".ToUpper()))
                    else if (tlfdto.AccountSign[0] == 'S')
                    {
                        //PRN File Common Module
                        PFMORM00043 PRNFileORM = new PFMORM00043();
                        PRNFileORM.AccountNo = tlfdto.AccountNo;
                        PRNFileORM.Balance = cledgerDTO.CurrentBal + cledgerDTO.OverdraftLimit;
                        PRNFileORM.Reference = reversaltrancodedto.PBReference;
                        if (reversaltrancodedto.Status[1] == 'C')
                        {
                            PRNFileORM.Debit = 0;
                            PRNFileORM.Credit = tlfdto.Amount;
                        }
                        else
                        {
                            PRNFileORM.Debit = tlfdto.Amount;
                            PRNFileORM.Credit = 0;
                        }
                        //PRNFileORM.PrintLineNo= cledgerDTO.PrintLineNo;
                        PRNFileORM.CurrencyCode = tlfdto.SourceCurrency;
                        PRNFileORM.SourceBranchCode = BranchCode;
                        PRNFileORM.DATE_TIME = System.DateTime.Now;
                        PRNFileORM.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
                        //PRNFileORM.UserNo

                        this.PrintDAO.PRNFile_Save(PRNFileORM);
                    }
                }
            }
            #endregion
        }

        #endregion
    }
}