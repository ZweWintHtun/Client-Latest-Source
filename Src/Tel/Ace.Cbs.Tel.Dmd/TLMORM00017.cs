//----------------------------------------------------------------------
// <copyright file="TLMORM00017.cs" company="ACE Data Systems">
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
    /// RD ORM Entity
    /// </summary>
    [Serializable]
    public class TLMORM00017 : Supportfields<TLMORM00017>
    {
        public TLMORM00017() { }
        public virtual string RegisterNo{get;set;}
        public virtual string DrawingNo{get;set;}
        public virtual string DraftNo{get;set;}
        public virtual string Dbank{get;set;}
        public virtual string Br_Alias{get;set;}
        public virtual string Type{get;set;}
        public virtual string AccountNo{get;set;}
        public virtual string Name{get;set;}
        public virtual string Address{get;set;}
        public virtual string NRC{get;set;}
        public virtual string CheckNo{get;set;}
        public virtual string ToAccountNo{get;set;}
        public virtual string ToName{get;set;}
        public virtual string ToNRC{get;set;}
        public virtual string ToAddress{get;set;}
        public virtual System.Nullable<decimal> TestKey { get; set; }
        public virtual System.Nullable<decimal> Amount { get; set; }
        public virtual System.Nullable<decimal> Commission { get; set; }
        public virtual System.Nullable<decimal> TlxCharges { get; set; }
        public virtual System.Nullable<DateTime> DateTime{get;set;}
        public virtual System.Nullable<DateTime> ReceiptDate{get;set;}
        public virtual  System.Nullable<DateTime> IncomeDate{get;set;}
        public virtual string RDType{get;set;}
        public virtual string IncomeType{get;set;}
        public virtual string AccountSign{get;set;}
        public virtual string UserNo{get;set;}
        public virtual string Budget{get;set;}
        public virtual  System.Nullable<DateTime> SendDate{get;set;}
        public virtual string LoanSerial{get;set;}
        public virtual string Deno_Status{get;set;}
        public virtual string PhoneNo{get;set;}
        public virtual string ToPhoneNo{get;set;}
        public virtual string Narration{get;set;}
        public virtual string UniqueId{get;set;}
        public virtual string SourceBranchCode{get;set;}
        public virtual string Currency{get;set;}
        public virtual string Channel{get;set;}
        public virtual  System.Nullable<DateTime> SettlementDate{get;set;}
    }
}
