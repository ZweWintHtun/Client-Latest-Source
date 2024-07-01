//----------------------------------------------------------------------
// <copyright file="TLMORM00030.cs" company="ACE Data Systems">
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
    /// IBLDrawingRate DTO Entity
    /// </summary>
    [Serializable]
    public class TLMDTO00030 : EntityBase<TLMDTO00030>
    {
        public TLMDTO00030() { }
        public TLMDTO00030(decimal startNo, decimal endNO, System.Nullable<decimal> rate, System.Nullable<decimal> fixedAmount)
        {
            this.StartNo = startNo;
            this.EndNo = endNO;
            this.Rate = rate;
            this.FixAmount = fixedAmount;
        }
        public TLMDTO00030(int id, string bRANCHCODE, decimal sTARTNO, decimal eNDNO, System.Nullable<decimal> rATE,
            System.Nullable<decimal> fIXAMT, System.Nullable<decimal> dISCOUNT, System.Nullable<decimal> tRDISCOUNT,
            System.Nullable<decimal> cSDISCOUNT, System.Nullable<decimal> cSMINRATE, System.Nullable<decimal> mINRATE, string uID,
            string sOURCEBR, string cUR, bool active, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId, byte[] tS)
        {
            this.Id = id;
            this.BranchCode = bRANCHCODE;
            this.StartNo = sTARTNO;
            this.EndNo = eNDNO;
            this.Rate = rATE;
            this.FixAmount = fIXAMT;
            this.Discount = dISCOUNT;
            this.TrDiscount = tRDISCOUNT;
            this.CsDiscount = cSDISCOUNT;
            this.CsMinRate = cSMINRATE;
            this.MinRate = mINRATE;
            this.UniqueId = uID;
            this.SourceBranchCode = sOURCEBR;
            this.Currency = cUR;
            this.Active = active;
            this.TS = tS;
            this.CreatedUserId = createdUserId;
            this.CreatedDate = createdDate;
            this.UpdatedUserId = updatedUserId;
            this.UpdatedDate = updatedDate;

        }
       
        public TLMDTO00030(int id, int remitbrIblID, string bRANCHCODE, decimal sTARTNO, decimal eNDNO, System.Nullable<decimal> rATE, System.Nullable<decimal> fIXAMT, System.Nullable<decimal> dISCOUNT, System.Nullable<decimal> tRDISCOUNT, System.Nullable<decimal> cSDISCOUNT, System.Nullable<decimal> cSMINRATE, System.Nullable<decimal> mINRATE, string uID, string sOURCEBR, string cUR, bool active, byte[] tS, int createdUserId, DateTime createdDate, System.Nullable<int> updatedUserId, System.Nullable<DateTime> updatedDate)
        {
            this.Id = id;
            this.RemitbrIblID = remitbrIblID;
            this.BranchCode = bRANCHCODE;
            this.StartNo = sTARTNO;
            this.EndNo = eNDNO;
            this.Rate = rATE;
            this.FixAmount = fIXAMT;
            this.Discount = dISCOUNT;
            this.TrDiscount = tRDISCOUNT;
            this.CsDiscount = cSDISCOUNT;
            this.CsMinRate = cSMINRATE;
            this.MinRate = mINRATE;
            this.UniqueId = uID;
            this.SourceBranchCode = sOURCEBR;
            this.Currency = cUR;
            this.Active = active;
            this.TS = tS;
            this.CreatedUserId = createdUserId;
            this.CreatedDate = createdDate;
            this.UpdatedUserId = updatedUserId;
            this.UpdatedDate = updatedDate;

        }
       
        public TLMDTO00030(decimal rate, decimal fixedAmount)
        {
            this.Rate = rate;
            this.FixAmount = fixedAmount;
        }


        public virtual int RemitbrIblID { get; set; }
        public virtual string BranchCode{get;set;}
        public virtual decimal StartNo{get;set;}
        public virtual decimal EndNo { get; set; }
        public virtual System.Nullable<decimal> Rate { get; set; }
        public virtual System.Nullable<decimal> FixAmount { get; set; }
        public virtual System.Nullable<decimal> Discount { get; set; }
        public virtual System.Nullable<decimal> TrDiscount { get; set; }
        public virtual System.Nullable<decimal> CsDiscount { get; set; }
        public virtual System.Nullable<decimal> CsMinRate { get; set; }
        public virtual System.Nullable<decimal> MinRate { get; set; }
        public virtual string UniqueId{get;set;}
        public virtual string SourceBranchCode{get;set;}
        public virtual string Currency{get;set;}
        
    }
}
