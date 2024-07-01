//----------------------------------------------------------------------
// <copyright file="TLMDTO00013.cs" company="ACE Data Systems">
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
    /// CashSetup DTO Entity
    /// </summary>
    [Serializable]
    public class TLMDTO00013 : Supportfields<TLMDTO00013>
    {
        public TLMDTO00013() { }
        public TLMDTO00013(string desp) 
        {
            this.Description = desp;
        }

        public TLMDTO00013(string cashCode,string desp)
        {
            this.CashCode = cashCode;
            this.Description = desp;
        }

        public TLMDTO00013(int isCounter,string counterNo, string currencyCode,bool hasVault)
        {
            this.IsCounter = isCounter;
            this.CounterNo = counterNo;
            this.CurrencyCode = currencyCode;
            this.HasValut = hasVault;
        }

        //CashCode,Description,UniqueId,Active,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,TS
        public TLMDTO00013(string cashCode, string desp, string uid, bool active, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId, byte[] tS)
        {
            this.CashCode = cashCode;
            this.Description = desp;
            this.UniqueId = uid;
            this.Active = active;
            this.CreatedUserId = createdUserId;
            this.CreatedDate = createdDate;
            this.TS = tS;
            this.UpdatedUserId = updatedUserId;
            this.UpdatedDate = updatedDate;
        }

        public TLMDTO00013(int isCounter, string counterNo, string currencyCode, int hasVault)
        {
            this.IsCounter = isCounter;
            this.CounterNo = counterNo;
            this.CurrencyCode = currencyCode;
            this.HasValut = hasVault==1?true:false;
        }

        public virtual bool HasValut { get; set; }
        public virtual string CounterNo { get; set; }
        public virtual string CurrencyCode { get; set; }
        public virtual int IsCounter { get; set; }
        public virtual string CashCode { get; set; }
        public virtual string Description { get; set; }
        public virtual string UniqueId { get; set; }
    }
}
