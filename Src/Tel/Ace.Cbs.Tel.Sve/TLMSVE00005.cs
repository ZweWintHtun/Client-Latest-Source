//----------------------------------------------------------------------
// <copyright file="TLMSVE00005.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hnin Thazin Shwe</CreatedUser>
// <CreatedDate>07/12/2013</CreatedDate>
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
using Spring.Transaction;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dto;

namespace Ace.Cbs.Tel.Sve
{
  public  class TLMSVE00005 :  BaseService,ITLMSVE00005
    {

       
       
      public ITLMDAO00015 CashDenoDAO { get; set; }
      public ICXSVE00002 CodeGenerator { get; set; }

      [Transaction(TransactionPropagation.Required)]
      public string Save(TLMDTO00015 cashDenoEntity)
      {
          try
          {
              DateTime settlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), cashDenoEntity.SourceBranchCode,true });
              if (settlementDate == null)
              {
                  this.ServiceResult.ErrorOccurred = true;
                  this.ServiceResult.MessageCode = CXMessage.ME00021; // Client Data Not Found.
                  return null;
              }
              decimal rate = CXCOM00010.Instance.GetExchangeRate(cashDenoEntity.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType));
              if (rate == 0)
              {
                  this.ServiceResult.ErrorOccurred = true;
                  this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not Found.
                  return null;
              }
              TLMORM00015 cashDeno = new TLMORM00015();
              try
              {
                  //string EntryNo = this.CodeGenerator.GetGenerateCode("VaultVoucher", string.Empty, cashDenoEntity.CreatedUserId,CurrentUserEntity.BranchCode);
                  string EntryNo = this.CodeGenerator.GetGenerateCode("VaultVoucher", string.Empty, cashDenoEntity.CreatedUserId, cashDenoEntity.SourceBranchCode);
                  //TLMORM00015 cashDeno = new TLMORM00015();
                  cashDeno.Id = this.CashDenoDAO.SelectMaxId() + 1;
                  cashDeno.TlfEntryNo = EntryNo;
                  cashDeno.FromType = cashDenoEntity.FromType;
                  cashDeno.ReceiptNo = "NA";
                  cashDeno.Amount = cashDenoEntity.Amount;
                  cashDeno.CashDate = cashDenoEntity.CreatedDate;
                  cashDeno.DenoDetail = cashDenoEntity.DenoDetail;
                  cashDeno.DenoRefundDetail = cashDenoEntity.DenoRefundDetail;
                  cashDeno.DenoRefundRate = cashDenoEntity.DenoRefundRate;
                  cashDeno.DenoRate = cashDenoEntity.DenoRate;
                  cashDeno.UserNo = cashDenoEntity.UserNo;
                  cashDeno.AdjustAmount = cashDenoEntity.AdjustAmount;
                  cashDeno.CounterNo = cashDenoEntity.CounterNo;
                  cashDeno.Status = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PaymentCashStatus);
                  cashDeno.SourceBranchCode = cashDenoEntity.SourceBranchCode;
                  cashDeno.Currency = cashDenoEntity.Currency;
                  cashDeno.Reverse = false;               
                  cashDeno.SettlementDate = settlementDate;
                  cashDeno.Rate = rate;
                  cashDeno.CreatedUserId = cashDenoEntity.CreatedUserId;
                  cashDeno.CreatedDate = cashDenoEntity.CreatedDate;
                  this.CashDenoDAO.Save(cashDeno);
                  this.ServiceResult.ErrorOccurred = false;
                  this.ServiceResult.MessageCode = "MI00051";
              }
              catch
              {
                  this.ServiceResult.ErrorOccurred = true;
                  throw new Exception();
                  //this.ServiceResult.MessageCode = "MI00051";
              }
              return cashDeno.TlfEntryNo;

          }
          catch
          {
              throw new Exception();
          }
      }
    }
}
