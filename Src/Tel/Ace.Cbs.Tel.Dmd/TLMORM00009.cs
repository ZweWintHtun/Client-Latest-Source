//----------------------------------------------------------------------
// <copyright file="TLMORM00009.cs" company="ACE Data Systems">
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
    /// DepoDeno ORM Entity
    /// </summary>
    [Serializable]
    public class TLMORM00009 : Supportfields<TLMORM00009>
    {
        public TLMORM00009() { }
        public virtual int Id { get; set; }
        public virtual string GroupNo{get;set;}
        public virtual string Tlf_Eno{get;set;}
        public virtual string AccountType{get;set;}
        public virtual decimal Amount { get; set; }
        public virtual bool Reverse_Status{get;set;}
        public virtual System.Nullable<decimal> Income { get; set; }
        public virtual System.Nullable<decimal> Communicationcharge { get; set; }
        //public virtual System.Nullable<decimal> Commissions { get; set; }
        public virtual string UniqueId{get;set;}
        public virtual string SourceBranchCode{get;set;}
        public virtual string Currency{get;set;}
        public virtual TLMORM00015 CashDeno { get; set; }
    }
}
