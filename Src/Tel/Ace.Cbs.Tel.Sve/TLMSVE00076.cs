//----------------------------------------------------------------------
// <copyright file="TLMSVE00076.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2014-07-21</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dto;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Tel.Sve
{
  public class TLMSVE00076:BaseService,ITLMSVE00076
    {
      private ITLMDAO00015 CashDenoDAO { get; set; }
      private ITLMDAO00017 RDDAO { get; set; }
      private DateTime SettlementDate { get; set; }
      private decimal Rate { get; set; }


      public IList<TLMDTO00017> GetDrawingCashDepositDenoLists(string registerNo, string branchcode)
      {
          IList<TLMDTO00017> DrawingCashDepositDenoList = new List<TLMDTO00017>();
          TLMDTO00015 CashDenoDTO = new TLMDTO00015();
          TLMDTO00017 RDTO = new TLMDTO00017();
          if (registerNo.Substring(0, 1) != "G")
          {
              CashDenoDTO = this.CashDenoDAO.SelectCashDenoByAccountTypeOrTLFEno(registerNo, branchcode);
              if (CashDenoDTO != null)
              {
                  if (CashDenoDTO.CashDate != null || CashDenoDTO.Reverse == true)
                  {
                      this.ServiceResult.ErrorOccurred = true;
                      this.ServiceResult.MessageCode = CXMessage.MV00230;// MV00168 Invalid Drawing Registerno to input denomination.                  
                  }
                  else
                  {
                      RDTO = this.RDDAO.SelectByRegisterNo(registerNo, branchcode);
                      RDTO.Amount = CashDenoDTO.Amount;
                      RDTO.CashAmount = RDTO.Amount;
                      DrawingCashDepositDenoList.Add(RDTO);
                  }
              }
              else
              {
                  this.ServiceResult.ErrorOccurred = true;
                  this.ServiceResult.MessageCode = CXMessage.MV00168;// MV00168 Invalid Drawing Registerno to input denomination.                  
              }
          }
          else
          {
              DrawingCashDepositDenoList = this.RDDAO.SelectRDDataListByGroupNo(registerNo, branchcode,true);
              if (DrawingCashDepositDenoList.Count > 0)
              {
                  CashDenoDTO = this.CashDenoDAO.SelectCashDenoByAccountTypeOrTLFEno(registerNo, branchcode);
                  if (CashDenoDTO != null)
                  {
                      if (CashDenoDTO.CashDate != null || CashDenoDTO.Reverse == true)
                      {
                          this.ServiceResult.ErrorOccurred = true;
                          this.ServiceResult.MessageCode = CXMessage.MV00230;// MV00168 Invalid Drawing Registerno to input denomination.                  
                      }
                      else
                      {
                         // DrawingCashDepositDenoList = this.RDDAO.SelectRDandAmountListInDrawingCashDepositDenominationEntry(registerNo, branchcode);
                          DrawingCashDepositDenoList = this.RDDAO.SelectRDDataListByGroupNo(registerNo, branchcode,false);
                          
                          for (int i = 0; i < DrawingCashDepositDenoList.Count; i++)
                          {
                              DrawingCashDepositDenoList[i].Currency = CashDenoDTO.Currency;
                              DrawingCashDepositDenoList[i].CashAmount = DrawingCashDepositDenoList[i].Amount;
                              DrawingCashDepositDenoList[i].Amount = CashDenoDTO.Amount;
                              
                          }
                      }
                  }
                  else
                  {
                      this.ServiceResult.ErrorOccurred = true;
                      this.ServiceResult.MessageCode = CXMessage.MV00168;// MV00168 Invalid Drawing Registerno to input denomination.                  
                  }
              }
              else
              {
                  this.ServiceResult.ErrorOccurred = true;
                  this.ServiceResult.MessageCode = "MV30020"; // MV30020 Invalid Group no for drawing denomination entry.                 
              }           
          }
          return DrawingCashDepositDenoList;
      }

       [Transaction(TransactionPropagation.Required)]
      public void Save(TLMDTO00015 cashdenoDTO,IList<string> registerNoList)
      {
         // TLMORM00015 cashDenoEntity = this.GetCashDeno(cashdenoDTO, denoString);
          try
          {
              this.Rate = CXCOM00010.Instance.GetExchangeRate(cashdenoDTO.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType));
              cashdenoDTO.Rate = this.Rate;
              this.SettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), cashdenoDTO.SourceBranchCode, true });
              cashdenoDTO.SettlementDate = SettlementDate;
              this.CashDenoDAO.UpdateCashDenoByGroupNo(cashdenoDTO);
              for (int i = 0; i < registerNoList.Count; i++)
              {
                  this.RDDAO.UpdateDenoStatusByRegisterNo(registerNoList[i], cashdenoDTO.SourceBranchCode, CurrentUserEntity.CurrentUserID, DateTime.Now);
              }              
              this.ServiceResult.ErrorOccurred = false;
          }
          catch
          {
              this.ServiceResult.ErrorOccurred = true;
              this.ServiceResult.MessageCode = "ME90000";
          }    
      }
       private TLMORM00015 GetCashDeno(TLMDTO00017 cashDeNoDTO, CXDTO00001 denoString)
       {
           this.SettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), cashDeNoDTO.SourceBranchCode ,true});
           if (this.SettlementDate == null)
           {
               this.ServiceResult.ErrorOccurred = true;
               this.ServiceResult.MessageCode = CXMessage.ME00021; // Client Data Not Found.
               return null;
           }
           this.Rate = CXCOM00010.Instance.GetExchangeRate(cashDeNoDTO.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType));
           if (this.Rate == 0)
           {
               this.ServiceResult.ErrorOccurred = true;
               this.ServiceResult.MessageCode = CXMessage.ME00021; // Client Data Not Found.
               return null;
           }
           TLMORM00015 cashDeno = new TLMORM00015();
           if (cashDeNoDTO.RegisterNo.Substring(0, 1) == "G")
           {
               cashDeno.TlfEntryNo = cashDeNoDTO.RegisterNo;
           }
           else
           {
               cashDeno.AccountType = cashDeNoDTO.RegisterNo;
           }          
           cashDeno.Amount = cashDeNoDTO.Amount;
           cashDeno.UserNo = cashDeNoDTO.UserNo;
           cashDeno.Status = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PaymentCashStatus);
           cashDeno.CounterNo = denoString.CounterNo;
           cashDeno.SourceBranchCode = cashDeNoDTO.SourceBranchCode;
           cashDeno.CashDate = DateTime.Now;
           cashDeno.SettlementDate = this.SettlementDate;
           cashDeno.DenoDetail = denoString.DenoString;
           cashDeno.DenoRate = denoString.DenoRateString;
           cashDeno.DenoRefundDetail = denoString.RefundString;
           cashDeno.DenoRefundRate = denoString.RefundRateString;
           cashDeno.Currency = cashDeNoDTO.Currency;
           cashDeno.Rate = this.Rate;
           cashDeno.Active = true;
           cashDeno.CreatedUserId = cashDeNoDTO.CreatedUserId;
           cashDeno.CreatedDate = DateTime.Now;
           cashDeno.Reverse = false;
           return cashDeno;
       }
    }
}
