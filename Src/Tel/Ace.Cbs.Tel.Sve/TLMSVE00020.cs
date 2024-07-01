//----------------------------------------------------------------------
// <copyright file="TLMSVE00020.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ye Mann Aung</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Core.Utt;
using Ace.Windows.Admin.DataModel;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Cx.Com.Dto;

namespace Ace.Cbs.Tel.Sve
{
   public class TLMSVE00020 : BaseService , ITLMSVE00020
    {

       public ICXSVE00002 CodeGenerator { get; set; }
      
       public string VoucherNo { get; set; }
       
       private ITLMDAO00001 remittanceEncashDAO;
       public ITLMDAO00001 RemittanceEncashDAO
       {
           get { return this.remittanceEncashDAO; }
           set { this.remittanceEncashDAO = value; }
       }

       private IPFMDAO00056 sys001DAO;
       public IPFMDAO00056 Sys001DAO
       {
           get { return this.sys001DAO; }
           set { this.sys001DAO = value; }
       }

       private ICXDAO00006 codeCheckerDAO;
       public ICXDAO00006 CodeCheckerDAO
       {
           get { return this.codeCheckerDAO; }
           set { this.codeCheckerDAO = value; }
       }
       private IPFMDAO00054 tlfDAO;
       public IPFMDAO00054 TLFDAO
       {
           get { return this.tlfDAO; }
           set { this.tlfDAO = value; }
       }

       private ITLMDAO00015 CashDenoDao { get; set; }

       private DateTime settlementDate;
       public DateTime SettlementDate
       {
           get { return settlementDate; }
           set { settlementDate = value; }
       }

      // public ICXDAO00008 CheckRegister { get; set; }

       #region Methods

       public IList<TLMDTO00001> GetEncashRemittanceData(string sourceBr)
       {
           return this.RemittanceEncashDAO.SelectRemittanceEncashData(sourceBr);
       }

       public IList<TLMDTO00001> GetEncashRemittanceDataCashType(string sourceBr)
       {
           return this.RemittanceEncashDAO.SelectRemittanceEncashDataCashType(sourceBr);
       }

       private string GetVoucherNo(string currency, int createdUserID , DateTime settlementDate, string sourceBranch)
       {
           return this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, createdUserID, sourceBranch, new object[] { settlementDate.Day.ToString().PadLeft(2, '0'), settlementDate.Month.ToString().PadLeft(2, '0'), settlementDate.Year.ToString().Substring(2) });
       }

       private string GetEncashNo(string currency, int createdUserID,string sourceBranch)
       {
           return this.CodeGenerator.GetGenerateCode("encashCode", string.Empty, createdUserID, sourceBranch, new object[] { });
           //return this.CodeGenerator.GetGenerateCode("encashCode", string.Empty, createdUserID, CurrentUserEntity.BranchCode, new object[] { });
       }

       private decimal GetRateInfo(string currency,string branchCode, string parameter)
       {
           PFMDTO00075 dto = new PFMDTO00075();
           if (parameter.Equals("C"))
           {
               dto = CXCOM00011.Instance.GetScalarObject<PFMDTO00075>("RateInfo.Rate.Select", new object[] { currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType), true, currency, true });
           }
           else
           {
               dto = CXCOM00011.Instance.GetScalarObject<PFMDTO00075>("RateInfo.Rate.Select", new object[] { currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType), true, currency, true });
           }
           return dto.Rate;
       }

       //Comment by ASDA(bugListNo - 178 , requested by KSWin)
       //private TLMORM00015 GetCashDenoData(CXDTO00001 cashString, TLMDTO00039 rawEncashData,string voucherno)
       //{
       //    TLMORM00015 cashdenoDto = new TLMORM00015();
       //    cashdenoDto.AccountType = rawEncashData.RegisterNo;
       //    cashdenoDto.TlfEntryNo = voucherno;
       //    cashdenoDto.Amount = rawEncashData.Amount;
       //    cashdenoDto.CashDate = DateTime.Now;
       //    cashdenoDto.DenoDetail = cashString.DenoString;
       //    cashdenoDto.DenoRefundDetail = cashString.RefundString;
       //    cashdenoDto.UserNo = rawEncashData.CreatedUserId.ToString();
       //    cashdenoDto.CounterNo = cashString.CounterNo;
       //    cashdenoDto.Status = CXCOM00009.ReceiveCounterType;
       //    cashdenoDto.Reverse = false;
       //    cashdenoDto.SourceBranchCode = rawEncashData.SourceBranch;
       //    cashdenoDto.Currency = rawEncashData.Currency;
       //    cashdenoDto.DenoRate = cashString.DenoRateString;
       //    cashString.RefundRateString = cashString.RefundRateString;
       //    cashdenoDto.SettlementDate = rawEncashData.SettlementDate;
       //    cashdenoDto.Rate = rawEncashData.Rate;
       //    cashdenoDto.Active = true;
       //    cashdenoDto.CreatedDate = DateTime.Now;
       //    cashdenoDto.CreatedUserId = rawEncashData.CreatedUserId;

       //    return cashdenoDto;
       //}
       #endregion

       #region MainMethods

       [Transaction(TransactionPropagation.Required)]
       public string SaveRemittanceEncashProcess(TLMDTO00039 rawEncashData, string parameter, CXDTO00001 dtostring)
       {
           if (rawEncashData != null)
           {
               this.SettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), rawEncashData.SourceBranch ,true });
               
               if (this.SettlementDate == null)
               {
                   this.ServiceResult.ErrorOccurred = true;
                   throw new Exception(CXMessage.ME00021); // Client Data Not Found.
               }
               rawEncashData.Rate = this.GetRateInfo(rawEncashData.Currency, rawEncashData.SourceBranch, parameter);
               //rawEncashData.HomeAmount = rawEncashData.Rate * rawEncashData.Amount;
               //rawEncashData.HomeAmt = rawEncashData.Rate * rawEncashData.Amount;
               rawEncashData.SettlementDate = this.SettlementDate;
               if (parameter.Equals("C"))
               {
                   //added by ASDA (bug No_178 , user want to generate "Encash Remittance Voucher (Cash Payment)" with (IBS*****) )
                   this.VoucherNo = CodeGenerator.GetGenerateCode("IBSVoucher", string.Empty, rawEncashData.CreatedUserId, rawEncashData.SourceBranch);
               }
               else
               {
                   this.VoucherNo = this.GetVoucherNo(rawEncashData.Currency, rawEncashData.CreatedUserId, rawEncashData.SettlementDate, rawEncashData.SourceBranch);
               }

               PFMORM00054 tlfData = new PFMORM00054();
                   tlfData = this.BindTLFData(rawEncashData);

                   if (tlfData != null)
                   {
                       if (parameter.Equals("T"))
                       {
                           try
                           {
                               this.TLFDAO.Save(tlfData);
                               this.ServiceResult.ErrorOccurred = false;
                           }
                           catch
                           {
                               this.ServiceResult.ErrorOccurred = true;
                               this.ServiceResult.MessageCode = "ME90000";
                               throw new Exception(this.ServiceResult.MessageCode);
                           }
                       }
                       tlfData = this.BindTLFData(rawEncashData);
                       tlfData.Acode = rawEncashData.DebitAcode;
                       tlfData.AccountNo = rawEncashData.DebitAccountNo;
                       tlfData.Description = rawEncashData.DebitDescription;
                       tlfData.TransactionCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.EncashmentRemittanceDebitTransfer);//"EREMITDRTR"
                       //tlfData.Narration = string.Empty;
                       tlfData.Narration = "E Remitt:";
                       if (parameter.Equals("T"))
                       {
                           tlfData.Status = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferDebitVoucher);
                       }
                       else
                       {
                           tlfData.Status = "CDV";
                       }
                       tlfData.AccountSign = string.Empty;
                       tlfData.TransactionCode = (!parameter.Equals(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashPaymentStatus))) ? CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.EncashmentRemittanceDebitTransfer) : CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.EncashmentRemittanceCash);

                       try
                       {
                           this.TLFDAO.Save(tlfData);
                           this.ServiceResult.ErrorOccurred = false;
                       }
                       catch
                       {
                           this.ServiceResult.ErrorOccurred = true;
                           this.ServiceResult.MessageCode = "ME90000";
                           throw new Exception(this.ServiceResult.MessageCode);
                       }
                   }

                   TLMORM00001 re = new TLMORM00001();
                   re = this.BindREData(rawEncashData);
                   
                   if (re != null)
                   {
                       try
                       {
                           if (!RemittanceEncashDAO.UpdateRemittanceEncashData(re.RegisterNo, re.IssueDate, re.EncashNo, re.SettlementDate , re.UpdatedUserId.Value, re.UpdatedDate.Value))
                           {
                               this.ServiceResult.ErrorOccurred = true;
                               this.ServiceResult.MessageCode = "ME90000";
                           }
                           else
                           {
                               this.ServiceResult.ErrorOccurred = false;
                           }
                       }
                       catch
                       {
                           this.ServiceResult.ErrorOccurred = true;
                           this.ServiceResult.MessageCode = "ME90000";
                           throw new Exception(this.ServiceResult.MessageCode);
                       }
                   }

                   if (!String.IsNullOrEmpty(rawEncashData.CreditAccountNo))
                   {
                       PFMDTO00028 cledgerDTO = CodeCheckerDAO.GetAccountInfoOfCledgerByAccountNo(rawEncashData.CreditAccountNo);

                       if (cledgerDTO != null)
                       {
                           try
                           {
                               this.CodeCheckerDAO.UpdateCurrentBalance(cledgerDTO.AccountNo, cledgerDTO.CurrentBal + rawEncashData.Amount, ++cledgerDTO.TransactionCount, rawEncashData.CreatedUserId, rawEncashData.CreatedUserId.ToString());
                               if (cledgerDTO.LoansCount > 0)
                               {
                                   Sys001DAO.UpdateStatusByName(rawEncashData.CreatedUserId, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ServiceChargesCal), "N",rawEncashData.CreatedDate);
                                   this.ServiceResult.ErrorOccurred = false;
                               }
                               else if (cledgerDTO.OverdraftLimit > 0 || cledgerDTO.TemporaryOverdraftLimit > 0)
                               {
                                   Sys001DAO.UpdateStatusByName(rawEncashData.CreatedUserId, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.OverdrafIntrestCal), "N",rawEncashData.CreatedDate);
                                   this.ServiceResult.ErrorOccurred = false;
                               }
                           }
                           catch
                           {
                               this.ServiceResult.ErrorOccurred = true;
                               this.ServiceResult.MessageCode = "ME90000";
                               throw new Exception(this.ServiceResult.MessageCode);
                           }

                       }
                   }

                   //if (dtostring != null)   //Comment by ASDA(bugListNo - 178 , requested by KSWin)
                   //{
                   //    try
                   //    {
                   //        this.CashDenoDao.Save(this.GetCashDenoData(dtostring, rawEncashData, this.VoucherNo));
                   //    }
                   //    catch
                   //    {
                   //        this.ServiceResult.ErrorOccurred = true;
                   //        this.ServiceResult.MessageCode = "ME90000";
                   //    }
                   //}

                   this.ServiceResult.MessageCode = (this.ServiceResult.MessageCode == string.Empty) ? "MI00051" : this.ServiceResult.MessageCode;

                   return this.VoucherNo;
           }
           else
           {
               throw new Exception();
           }
       }
       public TLMDTO00001 GetRegisterNo(string po)
       {
           try
           {
               return this.RemittanceEncashDAO.SelectRegisterNoByPO(po);
           }
           catch (Exception ex)
           {
               this.ServiceResult.ErrorOccurred = true;
               this.ServiceResult.MessageCode = ex.Message;
               return null;
           }
       }

       #endregion

       #region TransferDTODataToORM
       private PFMORM00054 BindTLFData(TLMDTO00039 getTLF)
       {
           PFMORM00054 tlf = new PFMORM00054();
           tlf.Id = this.TLFDAO.SelectMaxId() + 1;
           tlf.Eno = this.VoucherNo;
           tlf.AccountNo = getTLF.CreditAccountNo;
           tlf.Acode = getTLF.CreditAcode;
           tlf.Amount = getTLF.Amount;
           tlf.HomeAmt = getTLF.Amount*getTLF.Rate;
           tlf.LocalAmt = getTLF.Amount;
           tlf.HomeOAmt = 0;
           tlf.LocalOAmt = 0;
           tlf.HomeAmount = tlf.HomeAmt + ((tlf.HomeOAmt == null) ? 0 : tlf.HomeOAmt.Value);
           tlf.LocalAmount = tlf.LocalAmt + ((tlf.LocalOAmt == null) ? 0 : tlf.LocalOAmt.Value);
          
           tlf.CurrencyCode = getTLF.Currency;
           tlf.SourceCurrency = getTLF.SourceCurrency;
           tlf.Description = getTLF.CreditDescription;
           tlf.Narration = getTLF.Narration;
           tlf.DateTime = getTLF.CreatedDate;
           tlf.Status = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferCreditVoucher);
           tlf.TransactionCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.EncashmentRemittanceCreditTransfer); //"EREMITCRTR"
           tlf.AccountSign = getTLF.AccountSign;
           tlf.SourceBranchCode = getTLF.SourceBranch;
           CurrencyDTO curdto = CXCOM00011.Instance.GetScalarObject<CurrencyDTO>("Cur.HomeCur.Select", new object[] { true });
           tlf.SourceCurrency = curdto.Cur;
           tlf.Rate = getTLF.Rate;
           tlf.SettlementDate = getTLF.SettlementDate;
           tlf.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
           tlf.ReferenceVoucherNo = getTLF.ReferenceVoucherNo;
           tlf.ReferenceType = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.RemittanceCode);
           tlf.ERegisterNo = getTLF.RegisterNo;
           tlf.UserNo = getTLF.CreatedUserId.ToString();
           tlf.CreatedUserId = getTLF.CreatedUserId;
           tlf.CreatedDate = getTLF.CreatedDate;

           return tlf;
       }

       private TLMORM00001 BindREData(TLMDTO00039 getRE)
       {
           TLMORM00001 re = new TLMORM00001();

           re.RegisterNo = getRE.RegisterNo;
           re.IssueDate = DateTime.Now;
           re.EncashNo = this.GetEncashNo(getRE.Currency,getRE.CreatedUserId,getRE.SourceBranch);
           re.SettlementDate = getRE.SettlementDate;
           re.UpdatedUserId = getRE.CreatedUserId;
           re.UpdatedDate = DateTime.Now;

           return re;
       }
       #endregion
 
    }
}
