//----------------------------------------------------------------------
// <copyright file="MNMSVE00013.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>11/04/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
//using Ace.Cbs.Cx.Ser.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Tcm.Ctr.Dao;

namespace Ace.Cbs.Mnm.Sve
{
    /// <summary>
    ///Saving Interest Withdraw Reversal Service
    /// </summary>
    public class MNMSVE00013 : BaseService, IMNMSVE00013
    {
        #region DAO
        public IPFMDAO00054 TLFDAO { get; set; }
        public ICXSVE00002 CodeGenerator { get; set; }
        public ITCMDAO00006 SIACCWITDAO { get; set; }
        public IPFMDAO00040 SIDAO { get; set; }
        public ITLMDAO00015 CashDenoDAO { get; set; }
        public ICXSVE00003 PrintingDAO { get; set; }
        public ICXSVE00010 SPDAO { get; set; }

        #endregion

        #region Helper Method
        public IList<PFMDTO00054> SelectSavingInterestWithdrawReversalByEntryNo(string entryno, string sourcebr)
        {
            IList<PFMDTO00054> tlfdto = this.TLFDAO.SelectTLFInfoForReversalByEntryNo(entryno, sourcebr);
            if (tlfdto.Count > 1 )
            {
                if (tlfdto[0].DateTime.ToString("dd/MM/yyyy") != DateTime.Now.ToString("dd/MM/yyyy"))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME30002;
                    return null;
                }
                else
                {
                    return tlfdto;
                }
            }
            else
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00222;
                return tlfdto;
            }
        }
        public string SelectCOAAccountName(string acode, string sourcebr)
        {
            string coadto = CXCOM00011.Instance.GetScalarObject<string>("COA.Server.SelectAccountNameforReversal", new object[] { acode, sourcebr, true });
            if (coadto != null)
            {
                return coadto;
            }
            else
            {
                return string.Empty;
            }
        }
        public string[] SelectStatusAndTranCode(string transactioncode)
        {
            string[] trancodeandstatus = new string[2];
            TLMDTO00005 trantypedto = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { transactioncode, true });
            if (trantypedto != null)
            {
                trancodeandstatus[0] = trantypedto.RVReference;
                TLMDTO00005 trantype = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { trantypedto.RVReference, true });
                if (trantype != null)
                {
                    trancodeandstatus[1] = trantype.Status;
                }
            }
            return trancodeandstatus;
        }
        public DateTime SelectSettlementDate(string sourcebr)
        {
            DateTime nextSettlementDate = Ace.Cbs.Cx.Com.Utt.CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate",
                       new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), sourcebr ,true});
            return nextSettlementDate;
        }
        [Transaction(TransactionPropagation.Required)]
        public void SaveForCash(PFMDTO00054 tlfFDTO, string reversalEntryNo)
        {
            this.SaveandUpdateTLF(tlfFDTO);
            this.SIACCWITDAO.DeleteByAccountNo(tlfFDTO.UpdatedUserId.Value, tlfFDTO.AccountNo, tlfFDTO.SourceBranchCode);
            this.SIDAO.UpdateAccruedIntByAccountNo(tlfFDTO.Amount, tlfFDTO.UpdatedUserId.Value, tlfFDTO.AccountNo);
            this.CashDenoDAO.UpdateCashDenoByTlfEnoAndCashDate(reversalEntryNo, tlfFDTO.UpdatedUserId.Value, tlfFDTO.Eno, tlfFDTO.SourceBranchCode);
            this.ServiceResult.ErrorOccurred = false;
            this.ServiceResult.MessageCode = CXMessage.MI00062;  //"Interest Cash Withdrawal Reversal is successfully completed."
        }
        public IList<PFMDTO00043> GetPrint(string accountno)
        {
            #region Select Prnfile

            IList<PFMDTO00043> prnFileDTOLsit = this.PrintingDAO.PRNFile_SelecByAccountNo(accountno);
            return prnFileDTOLsit;
            #endregion
        }
        [Transaction(TransactionPropagation.Required)]
        public void SaveForTransfer(PFMDTO00054 tlfdto, string reversalEno)
        {
            try
            {
            if (tlfdto.AccountNo.Trim().Length > 6)
            {
                PFMDTO00028 cledgerdto = CXServiceWrapper.Instance.Invoke<ICXSVE00006, PFMDTO00028>(x => x.GetAccountInfoOfCledgerByAccountNo(tlfdto.AccountNo));
                if (cledgerdto.CloseDate != null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00223;
                    return;
                }

                tlfdto.AccountSign = cledgerdto.AccountSign;
                bool isLink = false;
                string messageNo = string.Empty;
                if (!CXServiceWrapper.Instance.Invoke<ICXSVE00006, bool>(x => x.CheckAmount(tlfdto.AccountNo, tlfdto.Amount,false,true,true, ref isLink, ref messageNo)))
                {
                    string _m = messageNo;
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = messageNo;
                    return;
                }
            }
            
                //this.SPDAO.Sp_ALUpdate_Check(tlfdto.AccountNo);
                this.SPDAO.Sp_ALUpdate_Int_TransferAdjust(reversalEno, tlfdto.Eno, tlfdto.AccountNo, tlfdto.Amount, tlfdto.Cheque, tlfdto.UserNo, tlfdto.isAutolink,
                   tlfdto.VoucherStatus, tlfdto.Channel, string.Empty, string.Empty, tlfdto.SourceBranchCode, tlfdto.Rate.Value, tlfdto.SourceCurrency, tlfdto.SettlementDate.Value, tlfdto.CreatedUserId);
                this.SIDAO.UpdateAccruedIntByAccountNo(tlfdto.Amount, tlfdto.CreatedUserId, tlfdto.SourceBranchCode);
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MI00063; //Interest Transfer Reversal process complete!
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.ME90000; //Saving Error.
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }
        public void SaveandUpdateTLF(PFMDTO00054 tlfdto)
        {
            PFMORM00054 tlf = new PFMORM00054();
            string[] trancodeandstatus = this.SelectStatusAndTranCode(tlfdto.TransactionCode);
            string entryNo = this.GetReversalEntryNo(tlfdto.CreatedUserId, tlfdto.SourceBranchCode);
            tlf.Eno = entryNo;
            tlf.AccountNo = tlfdto.AccountNo;
            tlf.Acode = tlfdto.Acode;
            tlf.Amount = tlfdto.Amount;
            tlf.HomeAmount = tlfdto.HomeAmount;
            tlf.HomeAmt = tlfdto.HomeAmt;
            tlf.HomeOAmt = tlfdto.HomeOAmt;
            tlf.LocalAmount = tlfdto.LocalAmount;
            tlf.LocalAmt = tlfdto.LocalAmt;
            tlf.LocalOAmt = tlfdto.LocalOAmt;
            tlf.Narration = tlfdto.Narration;
            tlf.Description = tlfdto.Description;
            //tlf.Description = string.Empty;
            tlf.DateTime = DateTime.Now;
            tlf.Status = trancodeandstatus[1];
            tlf.TransactionCode = trancodeandstatus[0];
            tlf.OrgnEno = tlfdto.Eno;
            tlf.OrgnTransactionCode = tlfdto.TransactionCode;
            tlf.UserNo = tlfdto.UserNo;
            tlf.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
            tlf.ReferenceVoucherNo = string.Empty;
            tlf.ReferenceType = string.Empty;
            tlf.SourceBranchCode = tlfdto.SourceBranchCode;
            tlf.SourceCurrency = tlfdto.SourceCurrency;
            tlf.Rate = tlfdto.Rate;
            tlf.AccountSign = tlfdto.AccountSign;
            tlf.CurrencyCode = string.Empty;
            tlf.SettlementDate = this.SelectSettlementDate(tlfdto.SourceBranchCode);
            tlf.CheckTime = DateTime.Now;
            tlf.CreatedUserId = tlfdto.CreatedUserId;
            tlf.CreatedDate = DateTime.Now;
            tlf.Id = this.TLFDAO.SelectMaxId() + 1;
            this.TLFDAO.Save(tlf);
            this.TLFDAO.UpdateTLFForSavingInterestWithdrawReversal(tlf.Eno, tlfdto.TransactionCode, DateTime.Now, tlfdto.CreatedUserId, tlfdto.Eno, tlfdto.TransactionCode, tlfdto.SourceCurrency, tlfdto.SourceBranchCode, tlfdto.TS);
        }
        public string GetReversalEntryNo(int createdUserId, string sourceBranchCode)
        {

            string reversalEntryNo = string.Empty;
            reversalEntryNo = this.CodeGenerator.GetGenerateCode("Reversal Code", string.Empty, createdUserId, sourceBranchCode, new object[] { DateTime.Now.Day.ToString().PadLeft(2, '0'), DateTime.Now.Month.ToString().PadLeft(2, '0'), DateTime.Now.Year.ToString().Substring(2) });
            return reversalEntryNo;
        }
        #endregion

        #region Main Methods
        [Transaction(TransactionPropagation.Required)]
        public string Save(IList<PFMDTO00054> tlfdto, bool isCash)
        {
            try
            {
                string reversalEntryNo = this.GetReversalEntryNo(tlfdto[0].CreatedUserId, tlfdto[0].SourceBranchCode);
                foreach (PFMDTO00054 item in tlfdto)
                {
                    if (isCash)
                    {
                        this.SaveForCash(item, reversalEntryNo);
                    }
                    else
                    {
                        this.SaveForTransfer(item, reversalEntryNo);
                    }
                }
                return reversalEntryNo;
            }
            catch (Exception ex)
            {
                if (CXServiceWrapper.Instance.ServiceResult.MessageCode == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = ex.Message;
                }
                else if (CXServiceWrapper.Instance.ServiceResult.MessageCode != null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXServiceWrapper.Instance.ServiceResult.MessageCode;
                }
                else
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME90000;
                }

                throw new Exception(this.ServiceResult.MessageCode);
            }
        }
        #endregion




    }
}