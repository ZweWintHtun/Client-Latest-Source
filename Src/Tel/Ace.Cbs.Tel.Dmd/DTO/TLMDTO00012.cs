//----------------------------------------------------------------------
// <copyright file="TLMDTO00012.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San </CreatedUser>
// <CreatedDate>2013-05-22</CreatedDate>
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
    /// Deno DTO Entity
    /// </summary>
    [Serializable]
    public class TLMDTO00012 : EntityBase<TLMDTO00012>
    {
        public TLMDTO00012(string description, decimal d1, decimal d2, string symbol, string currency)
        {
            this.Description = description;
            this.D1 = d1;
            this.D2 = d2;
            this.Symbol = symbol;
            this.Currency = currency;
        }

        public TLMDTO00012()
        { }

        public TLMDTO00012(string desp)
        {
            this.Description = desp;
        }
        public TLMDTO00012(int id, string desp, string symbol)
        {
            this.Id = id;
            this.Description = desp;
            this.Symbol = symbol;
        }
        public TLMDTO00012(decimal d1, string symbol)
        {
            this.D1 = d1;
            this.Symbol = symbol;
        }

        public TLMDTO00012(int id, string desp)
        {
            this.Id = id;
            this.Description = desp;
        }


        public TLMDTO00012(int id, string description, decimal d1, decimal d2, string uID, string cUR, string sYMBOL)
        {
            this.Id = id;
            this.Description = description;
            this.D1 = d1;
            this.D2 = d2;
            this.UID = uID;
            this.Currency = cUR;
            this.Symbol = sYMBOL;
        }

        public TLMDTO00012(int id, string description, decimal d1, decimal d2, string uID, string cUR, string sYMBOL, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
        {
            this.Id = id;
            this.Description = description;
            this.D1 = d1;
            this.D2 = d2;
            this.UID = uID;
            this.Currency = cUR;
            this.Symbol = sYMBOL;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        //Id,Description,D1,D2,UId,Currency,Symbol,Active,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,TS
        public TLMDTO00012(int id, string description, decimal d1, decimal d2, string uID, string cUR, string sYMBOL, bool active, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId, byte[] tS)
        {
            this.Id = id;
            this.Description = description;
            this.D1 = d1;
            this.D2 = d2;
            this.UId = uID;
            this.Currency = cUR;
            this.Symbol = sYMBOL;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public virtual int Id { get; set; }
        public virtual string UId { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual string Description { get; set; }
        public virtual decimal TotalAmount { get; set; }
        public virtual string Narration { get; set; }
        public virtual decimal D1 { get; set; }
        public virtual decimal D2 { get; set; }
        public virtual string Currency { get; set; }
        public virtual string Symbol { get; set; }
        public virtual string UID { get; set; }
        public virtual decimal AdjustAmount { get; set; }
        public virtual System.DateTime Date_Time { get; set; }
        public virtual System.DateTime EditDate_Time { get; set; }
        public virtual string EditUser { get; set; }
        public virtual decimal EditType { get; set; }
        public virtual int DenoCount { get; set; }
        public virtual int RefundCount { get; set; }
        public virtual string CounterNo { get; set; }
        public virtual bool IsCheck { get; set; }
        public virtual string DenoString { get; set; }
        public virtual string DenoRateString { get; set; }
        public virtual string RefundString { get; set; }
        public virtual string RefundRateString { get; set; }
        public virtual decimal Surplus { get; set; }
        public virtual decimal Shortage { get; set; }
    }
}