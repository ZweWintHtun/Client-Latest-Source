//----------------------------------------------------------------------
// <copyright file="TLMORM00032.cs" company="ACE Data Systems">
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
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Dmd
{
    /// <summary>
    /// RemittanceRate ORM Entity
    /// </summary>
    [Serializable]
    public class TLMORM00032 : EntityBase<TLMORM00032>
    {
        public TLMORM00032() { }
        public virtual int RemitBrId { get; set; }
        public virtual string BranchCode{get;set;}
        public virtual decimal StartNo { get; set; }
        public virtual decimal EndNo { get; set; }
        public virtual decimal Rate { get; set; }
        public virtual decimal FixAmount { get; set; }
        public virtual System.Nullable<decimal> Discount { get; set; }
        public virtual System.Nullable<decimal> TrDiscount { get; set; }
        public virtual System.Nullable<decimal> CsDiscount { get; set; }
        public virtual System.Nullable<decimal> CsMinRate { get; set; }
        public virtual System.Nullable<decimal> MinRate { get; set; }
        public virtual string UniqueId{get;set;}
        public virtual string SourceBranchCode{get;set;}
        public virtual string Currency{get;set;}
        public virtual Branch Branch { get; set; }
        public virtual TLMORM00028 RemitBr { get; set; }
    }
}
