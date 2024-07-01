using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using AutoMapper;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Tcm.Sve
{
      
   public class TCMSVE00011 : BaseService , ITCMSVE00011
   {
       #region Properties
       public ITCMSVE00011 CashDeno { get; set; }
       public ITLMDAO00015 CashDenoDAO { get; set; }
       public ITLMDAO00056 CashDenoHistoryDAO { get; set; }
       TLMDTO00015 Entity { get; set; }
       #endregion
       #region MainMethod
       public TLMDTO00015 GetCashDenoByEntryNo(string entryNo,string branchCode)
       {
           Entity = this.CashDenoDAO.GetCashDenoByEntryNo(entryNo, branchCode);
           return Entity;
       }
      
       
       public string Save(TLMDTO00015 entity)
       {
           try
           {
               #region Convert DTO to ORM
               TLMORM00056 cashDenoHistory = new TLMORM00056();
               cashDenoHistory.Id = entity.Id;
               cashDenoHistory.DenoEntryNo = entity.DenoEntryNo;
               cashDenoHistory.TlfEntryNo = entity.TlfEntryNo;
               cashDenoHistory.AccountType = entity.AccountType;
               cashDenoHistory.FromType = entity.FromType;
               cashDenoHistory.BranchCode = entity.BranchCode;
               cashDenoHistory.ReceiptNo = entity.ReceiptNo;
               cashDenoHistory.Amount = entity.Amount;
               cashDenoHistory.AdjustAmount = entity.AdjustAmount;
               cashDenoHistory.CashDate = entity.CashDate;
               cashDenoHistory.DenoDetail = entity.DenoDetail;
               cashDenoHistory.DenoRefundDetail = entity.DenoRefundDetail;
               cashDenoHistory.UserNo = entity.UserNo;
               cashDenoHistory.CounterNo = entity.CounterNo;
               cashDenoHistory.Status = entity.Status;
               cashDenoHistory.Reverse = entity.Reverse;
               cashDenoHistory.UniqueId = entity.UniqueId;
               cashDenoHistory.SourceBranchCode = entity.SourceBranchCode;
               cashDenoHistory.Currency = entity.Currency;
               cashDenoHistory.DenoRate = entity.DenoRate;
               cashDenoHistory.DenoRefundRate = entity.DenoRefundRate;
               cashDenoHistory.SettlementDate = entity.SettlementDate;
               cashDenoHistory.AllDenoRate = entity.AllDenoRate;
               cashDenoHistory.Rate = entity.Rate;
               cashDenoHistory.Active = entity.Active;
               cashDenoHistory.TS = entity.TS;
               cashDenoHistory.CreatedDate = entity.CreatedDate;
               cashDenoHistory.CreatedUserId = entity.CreatedUserId;
               cashDenoHistory.UpdatedDate = entity.UpdatedDate;
               cashDenoHistory.UpdatedUserId = entity.UpdatedUserId;
               #endregion
               this.CashDenoHistoryDAO.Save(cashDenoHistory);
               this.CashDenoDAO.DeleteCashDenoByEntryNo(entity.TlfEntryNo, entity.SourceBranchCode);
               this.ServiceResult.ErrorOccurred = false;
               return cashDenoHistory.TlfEntryNo;
           }
           catch (Exception ex)
           {
               this.ServiceResult.ErrorOccurred = true;
               this.ServiceResult.MessageCode = "ME90000";
               throw new Exception(this.ServiceResult.MessageCode);
               //return null;
           }
       }
       #endregion
   }
}
