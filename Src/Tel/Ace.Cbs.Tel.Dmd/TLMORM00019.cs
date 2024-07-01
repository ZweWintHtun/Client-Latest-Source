//----------------------------------------------------------------------
// <copyright file="TLMORM00019.cs" company="ACE Data Systems">
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
    /// FixedInterestWithdrawal ORM Entity
    /// </summary>
    [Serializable]
    public class TLMORM00019 : EntityBase<TLMORM00019>
    {
        public TLMORM00019() { }
        public virtual string AccountNo{get;set;}
        public virtual decimal Amount { get; set; }
        public virtual DateTime Date_Time{get;set;}
        public virtual string CreditAccountNo{get;set;}
        public virtual string UserNo{get;set;}
        public virtual string Budget{get;set;}
        public virtual string UniqueId{get;set;}
        public virtual string SourceBranchCode{get;set;}
        public virtual string Currency{get;set;}
        public virtual DateTime SettlementDate{get;set;}
    }
}
