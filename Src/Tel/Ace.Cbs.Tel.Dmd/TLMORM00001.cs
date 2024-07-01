//----------------------------------------------------------------------
// <copyright file="TLMORM00001.cs" company="ACE Data Systems">
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
    /// RE ORM Entity
   /// </summary>
   [Serializable]
    public class TLMORM00001 : Supportfields<TLMORM00001>
    {
       public TLMORM00001() { }
       
        public virtual string RegisterNo { get; set; }
        public virtual string EncashNo{get;set;}
        public virtual string Ebank{get;set;}
        public virtual string Br_Alias{get;set;}
        public virtual string Type{get;set;}
        public virtual string Name{get;set;}
        public virtual string NRC{get;set;}
        public virtual string ToAccountNo { get; set; }
        public virtual string ToName{get;set;}
        public virtual string ToNRC{get;set;}
        public virtual string ToAddress{get;set;}
        public virtual System.Nullable<decimal> TestKey{get;set;}
        public virtual System.Nullable<decimal> Amount { get; set; }
        public virtual System.Nullable<DateTime> Date_Time{get;set;}
        public virtual System.Nullable<DateTime> IssueDate{get;set;}
        public virtual string AccountSign{get;set;}
        public virtual string UserNo{get;set;}
        public virtual string Budget{get;set;}
        public virtual System.Nullable<short> PrintStatus{get;set;}
        public virtual string PhoneNo{get;set;}
        public virtual string ToPhoneNo{get;set;}
        public virtual string UniqueId { get; set; }
        public virtual string SourceBranchCode{get;set;}
        public virtual string Currency{get;set;}
        public virtual System.Nullable<DateTime> SettlementDate{get;set;}
        
    }
}
