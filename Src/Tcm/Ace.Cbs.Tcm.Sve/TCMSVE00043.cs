//----------------------------------------------------------------------
// <copyright file="TLMSVE00043.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-11-20</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Service;
using Spring.Transaction;
using Ace.Windows.CXServer.Utt;
using Spring.Transaction.Interceptor;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Cx.Com.Dmd;
using System.Linq;

namespace Ace.Cbs.Tcm.Sve
{
    /// <summary>
    /// Clearing Posting Service
    /// </summary>
    public class TCMSVE00043 : BaseService, ITCMSVE00043
    {
        #region "DAO"
        public IPFMDAO00054 TLFDAO { get; set; }
        public IPFMDAO00033 BalDAO { get; set; }
        private IPFMDAO00028 cledgerDAO;
        public IPFMDAO00028 CledgerDAO
        {
            get { return this.cledgerDAO; }
            set { this.cledgerDAO = value; }
        }
        public ICXSVE00006 CodeChecker { get; set; }
        public ICXSVE00003 PrintService { get; set; }
        public ICXDAO00006 CodeCheckerDAO { get; set; }
        public IPFMDAO00056 Sys001DAO { get; set; }
        #endregion

        #region "Private Parameters"

        string currency = string.Empty;
        decimal exchangeRate = 0;
        DateTime settlementDate;
        decimal M_CAmt = 0;
        decimal M_Oamt = 0;
        PFMDTO00028 cledgerDTO { get; set; }
        string currentacSign = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurrentAccountSign);
        string savingacSign = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavingAccountSign);

      

        #endregion

        #region "Methods"
        /// <summary>
        /// To Bind Grid View,Get Data Lists from TLF Table
        /// Returns TLFList to Client Side.
        /// </summary>
        /// <returns>PFMDTO00054 TLF List</returns>
        public IList<PFMDTO00054> GetClearingPostingTLFList(string sourcebranchCode)
        {
            return TLFDAO.SelectTlfInfoList(sourcebranchCode);
        }

        /// <summary>
        /// This Method was coded.
        /// 1.To Save TLf
        /// 2.To Update Cledger
        /// 3.To Update Tlf
        /// 4.To Save PRNFile
        /// 5.Printing Transaction
        /// 
        /// (1) If Account Sign is "C" and No Return Check,Use No 3.
        ///     If Account Sign is "C" and Return Check, Use two times to No 1.
        ///     One time is for Debit Transaction. Two time is for Credit Transaction.
        ///     Update TLF.
        /// (2) If Account Sign is "S" and No Return Check,Use No 4 and No 5 and No 2.
        ///     If Account Sign is "S" and Return Check, Use two times to No 1.
        ///     One time is for Debit Transaction. Two time is for Credit Transaction.
        ///     Update TLF.
        ///        
        /// </summary>
        /// <param name="TLFDTOList">TLFDTOList From Grid View,Created UserId</param>
        /// <returns> Boolean</returns>
        public bool ClearingPosting(IList<PFMDTO00054> TLFDTOList, int createduserId,DateTime createdDate)
        {
           bool isClearing=true;
           PFMDTO00054 tlfdto=new PFMDTO00054();
           try
           {

               for (int i = 0; i < TLFDTOList.Count; i++)
               {
                   try
                   {
                       currency = BalDAO.SelectTopCurrencyCodeByAccountNo(TLFDTOList[i].AccountNo);
                       exchangeRate = CXCOM00010.Instance.GetExchangeRate(currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType));
                       //settlementDate = CXCOM00010.Instance.GetNextSettlementDate("NEXT_SETTLEMENT_DATE", CurrentUserEntity.BranchCode);
                       settlementDate = CXCOM00010.Instance.GetNextSettlementDate("NEXT_SETTLEMENT_DATE", TLFDTOList[i].SourceBranchCode);
                   }
                   catch
                   {
                       throw new Exception(CXMessage.ME00021);
                   }
                   if (TLFDTOList[i].AccountSign.Substring(0, 1) == currentacSign || TLFDTOList[i].AccountSign.Substring(0, 1) == savingacSign)
                   {
                       cledgerDTO = this.CodeChecker.GetAccountInfoOfCledgerByAccountNo(TLFDTOList[i].AccountNo);
                       if (cledgerDTO != null)
                       {
                           if (TLFDTOList[i].AccountSign.Substring(0, 1) == currentacSign)
                           {
                               tlfdto = CXServiceWrapper.Instance.Invoke<ICXSVE00004, PFMDTO00054>(x => x.AmtOamtParameterCheck(TLFDTOList[i].AccountNo, TLFDTOList[i].Amount, CXDMD00002.Credit));
                               M_CAmt = tlfdto.LocalAmt.Value;
                               M_Oamt = tlfdto.LocalOAmt.Value;
                               if (cledgerDTO.LoansCount > 0)
                               {
                                   if (Sys001DAO.UpdateStatusByName(createduserId, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ServiceChargesCal), "N",createdDate) == false)
                                   {
                                       // Update Error
                                       throw new Exception(CXMessage.ME90001);
                                   }
                               }
                               else
                               {
                                   if (cledgerDTO.OverdraftLimit > 0 || cledgerDTO.TemporaryOverdraftLimit > 0)
                                   {
                                       if (Sys001DAO.UpdateStatusByName(createduserId, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.OverdrafIntrestCal), "N",createdDate) == false)
                                       {
                                           // Update Error
                                           throw new Exception(CXMessage.ME90001);
                                           isClearing = false;
                                       }
                                   }
                               }
                           }
                           else
                           {
                               M_CAmt = TLFDTOList[i].Amount;
                               M_Oamt = 0;
                           }
                       }
                       else
                       {
                           this.ServiceResult.ErrorOccurred = true;
                           this.ServiceResult.MessageCode = CXMessage.ME00054;
                           isClearing = false;
                       }
                       tlfdto.SourceBranchCode = TLFDTOList[i].SourceBranchCode;
                       tlfdto = TLFDAO.SelectTlfInfoListInService(TLFDTOList[i].SourceBranchCode, TLFDTOList[i].Eno);
                       //if (TLFDTOList[i].IsCheck == true)
                       //tlfdto.SourceBranchCode = CurrentUserEntity.BranchCode;
                       // tlfdto = TLFDAO.SelectTlfInfoListInService(CurrentUserEntity.BranchCode, TLFDTOList[i].Eno);
                       if (TLFDTOList[i].IsCheck == true)
                       {
                           tlfdto.Narration = "Return Cheque";
                           tlfdto.DateTime = DateTime.Now;
                           tlfdto.UserNo = createduserId.ToString();
                           tlfdto.DeliverReturn = false;
                           tlfdto.ReceiptNo = "0";
                           tlfdto.IsCheck = TLFDTOList[i].IsCheck;
                           tlfdto.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
                       }

                       tlfdto.CreatedUserId = createduserId;
                       tlfdto.UpdatedUserId = createduserId;
                       tlfdto.OtherBankChq = TLFDTOList[i].OtherBankChq;
                       this.TransactionTLF(tlfdto);
                       isClearing = true;
                   }

               }
           }
           catch
           {
               this.ServiceResult.ErrorOccurred = true;
               this.ServiceResult.MessageCode = CXMessage.ME90000;
               throw new Exception(this.ServiceResult.MessageCode);
               //return false;
           }         
            return isClearing;
        }

        /// <summary>
        /// Save PrnFile when Account Sign is "S" and No Return Check.
        /// </summary>
        /// <param name="prnFileDTO"></param>
        [Transaction(TransactionPropagation.Required)]
        private void InsertPRNFile(PFMDTO00043 prnFileDTO)
        {
            try
            {
                this.PrintService.PRNFile_Save(prnFileDTO);
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME00061;
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }

        /// <summary>
        /// This Method is used to Return Check is true and false.
        /// </summary>
        /// <param name="TLFDTO"></param>
        [Transaction(TransactionPropagation.Required)]
        private void TransactionTLF(PFMDTO00054 TLFDTO)
        {
            decimal cbal = 0;
            PFMDTO00054 tlfEntity = new PFMDTO00054();
            switch (TLFDTO.IsCheck)
            {               
                case false:
                    cbal = cledgerDTO.CurrentBal + TLFDTO.Amount;
                    if (this.CodeCheckerDAO.UpdateCurrentBalance(TLFDTO.AccountNo, cbal, ++cledgerDTO.TransactionCount, TLFDTO.CreatedUserId, TLFDTO.CreatedUserId.ToString()) == false)
                    {                           
                        /*Update Error*/
                        throw new Exception(CXMessage.ME90001);
                    }
                    /*Update TLF*/
                    this.UpdateTLF(TLFDTO);                   
                    if (TLFDTO.AccountSign.Substring(0, 1) == savingacSign)
                    {
                        PFMDTO00043 PrnFileDTO = new PFMDTO00043();
                        PrnFileDTO.Reference = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ClearingCreditDeliver) }).PBReference;
                        PrnFileDTO.AccountNo = TLFDTO.AccountNo;
                        PrnFileDTO.DATE_TIME = DateTime.Now;
                        PrnFileDTO.Credit = TLFDTO.Amount;                       
                        PrnFileDTO.Debit = 0;
                        PrnFileDTO.Balance = cbal;
                        PrnFileDTO.SourceBranchCode = TLFDTO.SourceBranchCode;
                        //PrnFileDTO.SourceBranchCode = CurrentUserEntity.BranchCode;
                        PrnFileDTO.UserNo =TLFDTO.CreatedUserId.ToString();
                        PrnFileDTO.CreatedDate = DateTime.Now;
                        PrnFileDTO.CreatedUserId = TLFDTO.CreatedUserId;
                        PrnFileDTO.CurrencyCode = currency;
                        this.InsertPRNFile(PrnFileDTO);
                    }
                    break;

                case true: /* Save to TLF File (2 Lines Debit Credit) This condition is Delivered Return Case*/
                    /*<----------For DEBIT Transaction------------------>*/
                    this.SaveTLFORM(TLFDTO,true);
                    TLFDTO.Narration = "Clearing Deliver" + TLFDTO.OtherBankChq;
                    /*<----------Update TLF----------------------------->*/
                    this.UpdateTLF(TLFDTO);
                    /*<----------For CREDIT Transaction------------------>*/
                    this.SaveTLFORM(TLFDTO, false);
                    break;

            }
        }

        /// <summary>
        /// This Method is used to update TLF.
        /// </summary>
        /// <param name="TLFDTO"></param>

        [Transaction(TransactionPropagation.Required)]
        private void UpdateTLF(PFMDTO00054 TLFDTO)
        {
            PFMDTO00054 tlfEntity = new PFMDTO00054();
            tlfEntity.Eno = TLFDTO.Eno;
            tlfEntity.AccountNo = TLFDTO.AccountNo;
            tlfEntity.Status = TLFDTO.Status;
            //tlfEntity.SourceBranchCode = CurrentUserEntity.BranchCode;
            tlfEntity.SourceBranchCode = TLFDTO.SourceBranchCode;
            tlfEntity.HomeAmt = M_CAmt * exchangeRate;
            tlfEntity.HomeOAmt = M_Oamt * exchangeRate;
            tlfEntity.LocalAmt = M_CAmt;
            tlfEntity.LocalOAmt = M_Oamt;
            tlfEntity.UpdatedUserId = TLFDTO.UpdatedUserId;
            tlfEntity.CLRPostStatus =CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.DenoStatus);
            tlfEntity.DeliverReturn = (TLFDTO.IsCheck == true) ? true : false;
            tlfEntity.Narration = (TLFDTO.IsCheck == false) ? "Clearing Deliver" : TLFDTO.Narration;
            if (this.CodeCheckerDAO.UpdateTLFForClearingPosting(tlfEntity) == false)
            {
                throw new Exception(CXMessage.ME90001);
            }
        }

        /// <summary>
        /// This Method is used to Save TLF.
        /// </summary>
        /// <param name="tlfEntity"></param>
        /// <param name="isDEBIT"></param>
        [Transaction(TransactionPropagation.Required)]
        private void SaveTLFORM(PFMDTO00054 tlfEntity,bool isDEBIT)
        {
            try
            {
                PFMORM00054 TLFORM = new PFMORM00054();
                try{
                /*In Return Check Case,Get COAsetup AccoutNo "OAQ001" to insert AccountNo and Acode of Tlf Table .*/
                //string dniaccountNo = CXCOM00010.Instance.GetCoaSetupAccountNo("DNI", CurrentUserEntity.BranchCode); 
                  string dniaccountNo = CXCOM00010.Instance.GetCoaSetupAccountNo("DNI", tlfEntity.SourceBranchCode); 
                     TLFORM.AccountNo = (isDEBIT == true) ? tlfEntity.AccountNo : dniaccountNo;
                  }
                catch
                {
                      this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021;
                }

                TLFORM.Id = TLFDAO.SelectMaxId() + 1;
               
                TLFORM.Amount = tlfEntity.Amount;
                TLFORM.Eno = tlfEntity.Eno;
                TLFORM.Acode = (isDEBIT == true) ?tlfEntity.Acode:TLFORM.AccountNo;
                TLFORM.HomeAmount = tlfEntity.HomeAmount;
                TLFORM.HomeAmt = tlfEntity.HomeAmt;
                TLFORM.HomeOAmt = tlfEntity.HomeOAmt;
                TLFORM.LocalAmount = tlfEntity.LocalAmount;
                TLFORM.LocalAmt = tlfEntity.LocalAmt;
                TLFORM.LocalOAmt = 0;
                TLFORM.SourceCurrency = tlfEntity.SourceCurrency;
                TLFORM.CurrencyCode = tlfEntity.SourceCurrency;
                TLFORM.Description = (isDEBIT == true) ? tlfEntity.Description : "Debit Note Issue";
                TLFORM.Narration = (isDEBIT == true) ? tlfEntity.Narration : "Cheque Rtn:" + tlfEntity.AccountNo;
                TLFORM.AccountSign = (isDEBIT == true) ? tlfEntity.AccountSign : string.Empty;
                TLFORM.DateTime = DateTime.Now;
                TLFORM.TransactionCode = (isDEBIT == true) ? CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferDebitVoucherCode) : CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferCreditVoucherCode);
                TLFORM.Status = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { TLFORM.TransactionCode }).Status;
                TLFORM.CLRPostStatus = string.Empty;
                TLFORM.UserNo = tlfEntity.UserNo;
                TLFORM.CreatedUserId = tlfEntity.CreatedUserId;
                TLFORM.UpdatedUserId = tlfEntity.CreatedUserId;
                TLFORM.OtherBank = tlfEntity.OtherBank;
                TLFORM.Channel = tlfEntity.Channel;
                TLFORM.OtherBankChq = tlfEntity.OtherBankChq;
                TLFORM.DeliverReturn = tlfEntity.DeliverReturn;
                TLFORM.ReceiptNo = tlfEntity.ReceiptNo;
                TLFORM.SourceBranchCode = tlfEntity.SourceBranchCode;
                TLFORM.Rate = exchangeRate;
                TLFORM.SettlementDate = settlementDate;
                this.TLFDAO.Save(TLFORM);
            }
          
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME90000;
            }
        }

        #endregion        
    }
}
