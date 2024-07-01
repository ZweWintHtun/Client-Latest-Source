//----------------------------------------------------------------------
// <copyright file="TLMORM00032.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San </CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Tel.Dmd
{
    /// <summary>
    /// RemittanceRate DTO Entity
    /// </summary>
    [Serializable]
    public class TLMDTO00032 : EntityBase<TLMDTO00032>
    {
        public TLMDTO00032() { }


        public TLMDTO00032(string branchCode, string branchName, string statecode, string currency, decimal telaxcharges, decimal startNo, decimal endNo, decimal rate, decimal fixAmount, decimal trDiscount, decimal csDiscount)
        {//branchName
            this.BranchCode = branchCode;
            this.BranchName = branchName;
            this.StateCode = statecode;
            this.Currency = currency;
            this.TelaxCharges = telaxcharges;
            this.StartNo = startNo;
            this.EndNo = endNo;
            this.Rate = rate;
            this.FixAmount = fixAmount;
            this.TrDiscount = trDiscount;
            this.CsDiscount = csDiscount;
        }


        public TLMDTO00032(int id, int remitBrId, string branchCode, decimal startNo, decimal endNo, decimal rate, decimal fixAmt, System.Nullable<decimal> discount, System.Nullable<decimal> trDiscount, System.Nullable<decimal> csDiscount, System.Nullable<decimal> csMinRate, System.Nullable<decimal> minRate, string uId, string sourceBr, string cur, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
        {
            this.Id = id;
            this.RemitBrId = remitBrId;
            this.BranchCode = branchCode;
            this.StartNo = startNo;
            this.EndNo = endNo;
            this.Rate = rate;
            this.FixAmount = fixAmt;
            this.Discount = discount;
            this.TrDiscount = trDiscount;
            this.CsDiscount = csDiscount;
            this.CsMinRate = csMinRate;
            this.MinRate = minRate;
            this.UniqueId = uId;
            this.SourceBranchCode = sourceBr;
            this.Currency = cur;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        //Id,RemitBrId,BranchCode,StartNo,EndNo,Rate,FixAmount,Discount,TrDiscount,CsDiscount,CsMinRate,MinRate,UniqueId,
        //SourceBranchCode,Currency,Active,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,TS
        public TLMDTO00032(int id, int remitBrId, string branchCode, decimal startNo, decimal endNo, decimal rate, decimal fixAmt,
            System.Nullable<decimal> discount, System.Nullable<decimal> trDiscount, System.Nullable<decimal> csDiscount, 
            System.Nullable<decimal> csMinRate, System.Nullable<decimal> minRate, string uId, string sourceBr,
            string cur, bool active, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId, byte[] tS)
        {
            this.Id = id;
            this.RemitBrId = remitBrId;
            this.BranchCode = branchCode;
            this.StartNo = startNo;
            this.EndNo = endNo;
            this.Rate = rate;
            this.FixAmount = fixAmt;
            this.Discount = discount;
            this.TrDiscount = trDiscount;
            this.CsDiscount = csDiscount;
            this.CsMinRate = csMinRate;
            this.MinRate = minRate;
            this.UniqueId = uId;
            this.SourceBranchCode = sourceBr;
            this.Currency = cur;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public TLMDTO00032(decimal rate, decimal fixAmount)
        {
            this.Rate = rate;
            this.FixAmount = fixAmount;
        }
        public TLMDTO00032(decimal endNo,decimal rate, decimal fixAmount)
        {
            this.EndNo = endNo;
            this.Rate = rate;
            this.FixAmount = fixAmount;
        }
       


        public virtual int RemitBrId { get; set; }
        public virtual string BranchCode{get;set;}
        public virtual string BranchName { get; set; }
        public virtual string StateCode { get; set; }
        public virtual decimal StartNo { get; set; }
        public virtual decimal EndNo { get; set; }
        public virtual decimal Rate { get; set; }
        public virtual decimal FixAmount { get; set; }
        public virtual System.Nullable<decimal> Discount { get; set; }
        public virtual System.Nullable<decimal> TrDiscount { get; set; }
        public virtual System.Nullable<decimal> CsDiscount { get; set; }
        public virtual System.Nullable<decimal> CsMinRate { get; set; }
        public virtual System.Nullable<decimal> MinRate { get; set; }
        public virtual string UniqueId{get;set;}
        public virtual string SourceBranchCode{get;set;}
        public virtual string Currency{get;set;}
        public virtual decimal TelaxCharges { get; set; }

    }
}
