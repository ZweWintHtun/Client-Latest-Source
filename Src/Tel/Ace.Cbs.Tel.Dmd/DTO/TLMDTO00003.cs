//----------------------------------------------------------------------
// <copyright file="TLMDTO00003.cs" company="ACE Data Systems">
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
    /// PORate DTO Entity
    /// </summary>
   [Serializable]
   public class TLMDTO00003 : EntityBase<TLMDTO00003>
    {
        public TLMDTO00003() { }
        public TLMDTO00003(decimal rate,decimal fixAmount,decimal startNo,decimal endNo)
        {
            this.Rate = rate;
            this.FixAmount = fixAmount;
            this.StartNo = startNo;
            this.EndNo = endNo;
        }

        public TLMDTO00003(int id, System.Nullable<decimal> range, decimal rate, decimal fixAmt, decimal startNo, decimal endNo, string uId, string cur)
        {
            this.Id = id;
            this.Range = range;
            this.Rate = rate;
            this.FixAmount = fixAmt;
            this.StartNo = startNo;
            this.EndNo = endNo;
            this.UniqueId = uId;
            this.Currency = cur;
        }

        //Id,Range,Rate,FixAmount,StartNo,EndNo,UId,Cur,Active,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,TS
        public TLMDTO00003(int id, System.Nullable<decimal> range, decimal rate, decimal fixAmt, decimal startNo, decimal endNo,
            string uId, string cur, bool active, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId, byte[] tS)
        {
            this.Id = id;
            this.Range = range;
            this.Rate = rate;
            this.FixAmount = fixAmt;
            this.StartNo = startNo;
            this.EndNo = endNo;
            this.UniqueId = uId;
            this.Currency = cur;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }


       public TLMDTO00003(int id, System.Nullable<decimal> range, decimal rate, decimal fixAmt, decimal startNo, decimal endNo, string uId, string cur, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
        {
            this.Id = id;
            this.Range = range;
            this.Rate = rate;
            this.FixAmount = fixAmt;
            this.StartNo = startNo;
            this.EndNo = endNo;
            this.UniqueId = uId;
            this.Currency = cur;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public virtual System.Nullable<decimal> Range{get;set;}
        public virtual decimal Rate { get; set; }
        public virtual decimal FixAmount { get; set; }
        public virtual decimal StartNo{get;set;}
        public virtual decimal EndNo{get;set;}
        public virtual string UniqueId{get;set;}
        public virtual string Currency{get;set;}
        public virtual bool IsCheck { get; set; }
        public virtual string Status { get; set; }
    }
}
