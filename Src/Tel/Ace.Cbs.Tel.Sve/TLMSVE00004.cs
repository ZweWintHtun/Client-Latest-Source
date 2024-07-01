//----------------------------------------------------------------------
// <copyright file="TLMSVE00004.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Su Su Wai</CreatedUser>
// <CreatedDate>24/07/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using AutoMapper;
using System.Linq;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Windows.Admin.Contracts.Dao;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Sve
{
    /// <summary>
    /// Vault Withdrawl Denomination Entry Service
    /// </summary>
    public class TLMSVE00004 : BaseService, ITLMSVE00004
    {
        #region DAO Properties
        public ICXSVE00002 CodeGenerator { get; set; }
        public ITLMDAO00015 CashDenoDAO { get; set; }
        public ICounterInfoDAO CounterInfoDAO { get; set; }
        #endregion

        #region DTO Properties
        private DateTime SettlementDate { get; set; }
        private decimal Rate { get; set; }      
        #endregion

        #region Main Method
        [Transaction(TransactionPropagation.Required)]
        public TLMDTO00015 Save(IList<TLMDTO00015> cashDenoDTOList)
        {

            IList<TLMORM00015> cashDenoList = TransferDTOtoORM(cashDenoDTOList);

            this.SettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), cashDenoList[0].SourceBranchCode ,true});
            if (this.SettlementDate == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME00021; // Client Data Not Found.
                return null;
            }
            this.Rate = CXCOM00010.Instance.GetExchangeRate(cashDenoList[0].Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType));
            if (this.Rate == 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MI00013; //No Rate For this Currency.
                return null;
            }
            TLMDTO00015 returnEntity = new TLMDTO00015();
            string paymentCashStatus = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PaymentCashStatus);

            int fromTypeIndex = cashDenoList.ToList().FindIndex(x => x.Status.Equals(paymentCashStatus));
            //returnEntity.DebitEno = this.CodeGenerator.GetGenerateCode("VaultVoucher", string.Empty, cashDenoList[fromTypeIndex].CreatedUserId,CurrentUserEntity.BranchCode);
            returnEntity.DebitEno = this.CodeGenerator.GetGenerateCode("VaultVoucher", string.Empty, cashDenoList[fromTypeIndex].CreatedUserId, cashDenoList[fromTypeIndex].SourceBranchCode);
            cashDenoList[fromTypeIndex].TlfEntryNo = returnEntity.DebitEno;          
            this.CashDenoDAO.Save(this.GetCashDeno(cashDenoList[fromTypeIndex]));

            if (cashDenoList.Count > 1)
            {
                int toTypeIndex = cashDenoList.ToList().FindIndex(x => x.Status != paymentCashStatus);
                //returnEntity.CreditEno = this.CodeGenerator.GetGenerateCode("VaultVoucher", string.Empty, cashDenoList[toTypeIndex].CreatedUserId,CurrentUserEntity.BranchCode);
                returnEntity.CreditEno = this.CodeGenerator.GetGenerateCode("VaultVoucher", string.Empty, cashDenoList[toTypeIndex].CreatedUserId, cashDenoList[toTypeIndex].SourceBranchCode);
                cashDenoList[toTypeIndex].TlfEntryNo = returnEntity.CreditEno;
                this.CashDenoDAO.Save(this.GetCashDeno(cashDenoList[toTypeIndex]));
            }
            this.ServiceResult.ErrorOccurred = false;
            return returnEntity;

        }

        public IList<CounterInfoDTO> GetAllCounterInfoListBySourceBranchCode(string sourceBranchCode)
        {
            return this.CounterInfoDAO.SelectBySourceBranchCode(sourceBranchCode);
        }

        #endregion      

        #region Convert DTO to ORM

        private TLMORM00015 GetCashDeno(TLMORM00015 cashDeno)
        {
            cashDeno.CashDate = DateTime.Now;
            cashDeno.AdjustAmount = 0;
            cashDeno.UserNo = cashDeno.CreatedUserId.ToString();
            cashDeno.CounterNo = cashDeno.CounterNo;
            cashDeno.Reverse = false;
            cashDeno.SettlementDate = this.SettlementDate;
            cashDeno.Rate = this.Rate;
            cashDeno.Active = true;            
            cashDeno.CreatedDate = DateTime.Now;
            return cashDeno;
        }

        private IList<TLMORM00015> TransferDTOtoORM(IList<TLMDTO00015> cashDenoList)
        {
            IList<TLMORM00015> cashDenoORMList = new List<TLMORM00015>();
            foreach (TLMDTO00015 item in cashDenoList)
            {
                TLMORM00015 cashDenoORM = new TLMORM00015();
                cashDenoORM.TlfEntryNo = item.TlfEntryNo;
                cashDenoORM.Id = this.CashDenoDAO.SelectMaxId() + 1;
                cashDenoORM.AccountType = item.AccountType;
                cashDenoORM.FromType = item.FromType;
                cashDenoORM.Amount = item.Amount;
                cashDenoORM.AdjustAmount = item.AdjustAmount;
                cashDenoORM.CashDate = item.CashDate;
                cashDenoORM.DenoDetail = item.DenoDetail;
                cashDenoORM.DenoRefundDetail = item.DenoRefundDetail;
                cashDenoORM.DenoRefundRate = item.DenoRefundRate;
                cashDenoORM.DenoRate = item.DenoRate;
                cashDenoORM.UserNo = Convert.ToString(item.UserNo);
                cashDenoORM.CounterNo = item.CounterNo;
                cashDenoORM.Status = item.Status;
                cashDenoORM.Reverse = item.Reverse;
                cashDenoORM.SourceBranchCode = item.SourceBranchCode;
                cashDenoORM.Currency = item.Currency;
                cashDenoORM.SettlementDate = item.SettlementDate;
                cashDenoORM.Rate = item.Rate;
                cashDenoORM.AllDenoRate = item.AllDenoRate;
                cashDenoORM.CreatedDate = item.CreatedDate;
                cashDenoORM.CreatedUserId = item.CreatedUserId;

                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI00051";
                cashDenoORMList.Add(cashDenoORM);
            }
            return cashDenoORMList;
        }

        #endregion

       
    }
}
