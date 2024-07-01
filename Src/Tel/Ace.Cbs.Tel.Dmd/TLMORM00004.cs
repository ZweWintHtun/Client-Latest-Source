//----------------------------------------------------------------------
// <copyright file="TLMORM00004.cs" company="ACE Data Systems">
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
    /// IblTLF ORM Entity
   /// </summary>
   /// 
     [Serializable]
    public class TLMORM00004 : EntityBase<TLMORM00004>
    {
         public TLMORM00004() { }

        public virtual int Id { get; set; }
        public virtual string FromBranch{get;set;}
        public virtual string ToBranch{get;set;}
        public virtual string AccountNo{get;set;}
        public virtual decimal Amount { get; set; }
        public virtual string TranType{get;set;}
        public virtual System.DateTime Date_Time{get;set;}
        public virtual bool InOut{get;set;}
        public virtual bool Success{get;set;}
        public virtual string Eno{get;set;}
        public virtual string UserNo{get;set;}
        public virtual string Cheque{get;set;}
        public virtual System.Nullable<decimal> Income { get; set; }
        public virtual System.Nullable<decimal> Communicationcharge { get; set; }
        public virtual System.Nullable<bool> Reversal{get;set;}
        public virtual int? IncomeType{get;set;}
        public virtual string RelatedAccount{get;set;}
        public virtual string RelatedBranch{get;set;}
        public virtual string UniqueId{get;set;}
        public virtual string SourceBranchCode{get;set;}
        public virtual string Currency{get;set;}
        public virtual TLMORM00015 CashDeno { get; set; }
    }
}
