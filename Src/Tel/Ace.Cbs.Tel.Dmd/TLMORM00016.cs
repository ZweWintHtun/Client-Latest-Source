//----------------------------------------------------------------------
// <copyright file="TLMORM00016.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San </CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser>Htet Mon Win</UpdatedUser>
// <UpdatedDate>2013-05-28</UpdatedDate>
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
    /// PO ORM Entity
    /// </summary>
    [Serializable]
    public class TLMORM00016 : Supportfields<TLMORM00016>
    {
        public virtual string PONo { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual System.Nullable<DateTime> ADate { get; set; } //Register Date
        public virtual System.Nullable<DateTime> IDate { get; set; } //Refund Date
        public virtual string Status { get; set; }
        public virtual string ToAccountNo { get; set; }
        public virtual string CheckNo { get; set; }
        public virtual string AccountSign { get; set; }
        public virtual string Income { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string AcSign { get; set; }
        public virtual System.Nullable<decimal> Charges { get; set; }
        public virtual string ACode { get; set; }
        public virtual string Budget { get; set; }
        public virtual string UniqueId { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual string Currency { get; set; }
        public virtual System.Nullable<decimal> Rate { get; set; }
        public virtual System.Nullable<DateTime> SettlementDate { get; set; }
        public virtual System.Nullable<DateTime> RefundDate { get; set; }
    }
}
