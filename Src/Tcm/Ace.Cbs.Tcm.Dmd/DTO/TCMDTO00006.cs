//----------------------------------------------------------------------
// <copyright file="TCMDTO00006.cs" Name="SIAccWit" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>arkar</CreatedUser>
// <CreatedDate>12/15/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Tcm.Dmd
{
    [Serializable]
    public class TCMDTO00006 : EntityBase<TCMDTO00006>
    {
        public TCMDTO00006() { }

        //public TCMDTO00006(int id, string acctNo, string crAcctNo, string type, System.Nullable<decimal> amount, System.Nullable<DateTime> date_Time, string userNo, string desp, string budget, string uId, string sourceBr, string cur)
        //{
        //    this.Id = id;
        //    this.AccountNo = acctNo;
        //    this.CreditAccountNo = crAcctNo;
        //    this.Type = type;
        //    this.Amount = amount;
        //    this.Date_Time = date_Time;
        //    this.UserNo = userNo;
        //    this.Description = desp;
        //    this.Budget = budget;
        //    this.UId = uId;
        //    this.SourceBranch = sourceBr;
        //    this.Currency = cur;
        //}

        //public TCMDTO00006(int id, string acctNo, string crAcctNo, string type, System.Nullable<decimal> amount, System.Nullable<DateTime> date_Time, string userNo, string desp, string budget, string uId, string sourceBr, string cur, bool active, byte[] tS, int createdUserId, DateTime createdDate, System.Nullable<int> updatedUserId, System.Nullable<DateTime> updatedDate)
        //{
        //    this.Id = id;
        //    this.AccountNo = acctNo;
        //    this.CreditAccountNo = crAcctNo;
        //    this.Type = type;
        //    this.Amount = amount;
        //    this.Date_Time = date_Time;
        //    this.UserNo = userNo;
        //    this.Description = desp;
        //    this.Budget = budget;
        //    this.UId = uId;
        //    this.SourceBranch = sourceBr;
        //    this.Currency = cur;
        //    this.Active = active;
        //    this.TS = tS;
        //    this.CreatedUserId = createdUserId;
        //    this.CreatedDate = createdDate;
        //    this.UpdatedUserId = updatedUserId;
        //    this.UpdatedDate = updatedDate;
        //}

        public virtual string AccountNo { get; set; }
        public virtual string CreditAccountNo { get; set; }
        public virtual string Type { get; set; }
        public virtual System.Nullable<decimal> Amount { get; set; }
        public virtual System.Nullable<DateTime> Date_Time { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string Description { get; set; }
        public virtual string Budget { get; set; }
        public virtual string UId { get; set; }
        public virtual string SourceBranch { get; set; }
        public virtual string Currency { get; set; }
        public virtual bool IsCheck { get; set; }
    }
}