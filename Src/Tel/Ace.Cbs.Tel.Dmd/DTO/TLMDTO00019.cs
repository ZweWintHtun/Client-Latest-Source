//----------------------------------------------------------------------
// <copyright file="TLMDTO00019.cs" company="ACE Data Systems">
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
    /// FixedInterestWithdrawal DTO Entity
    /// </summary>
    [Serializable]
    public class TLMDTO00019 : EntityBase<TLMDTO00019>
    {
        public TLMDTO00019() { }
        public TLMDTO00019(string accountNo, decimal amount,DateTime datetime,string crdno,string sourcebr,string cur,DateTime settledate)
        {
            this.AccountNo = accountNo;
            this.Amount = amount;
            this.Date_Time = datetime;
            this.CrAcctNo = crdno;
            this.SourceBranchCode = sourcebr;
            this.Currency = cur;
            this.SettlementDate = settledate;
        }
        public virtual string AccountNo{get;set;}
        public virtual decimal Amount { get; set; }
        public virtual DateTime Date_Time{get;set;}
        public virtual string CrAcctNo{get;set;}
        public virtual string UserNo{get;set;}
        public virtual string Budget{get;set;}
        public virtual string UniqueId{get;set;}
        public virtual string SourceBranchCode{get;set;}
        public virtual string Currency{get;set;}
        public virtual DateTime SettlementDate{get;set;}
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
}
