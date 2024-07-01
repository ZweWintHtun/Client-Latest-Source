//----------------------------------------------------------------------
// <copyright file="MNMDTO00004.cs" Name="Prev_CashDeno" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>SuNge</CreatedUser>
// <CreatedDate>11/28/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
    [Serializable]
    public class MNMDTO00004 : Supportfields<MNMDTO00004>
    {
        public MNMDTO00004() { }

        public virtual int Id { get; set; }
        public virtual string Deno_Eno { get; set; }
        public virtual string Tlf_Eno { get; set; }
        public virtual string AcType { get; set; }
        public virtual string FromType { get; set; }
        public virtual string BranchCode { get; set; }
        public virtual string ReceiptNo { get; set; }
        public virtual System.Nullable<decimal> Amount { get; set; }
        public virtual System.Nullable<decimal> AdjustAmt { get; set; }
        public virtual System.Nullable<DateTime> Cash_Date { get; set; }
        public virtual string Deno_Detail { get; set; }
        public virtual string DenoRefund_Detail { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string CounterNo { get; set; }
        public virtual string Status { get; set; }
        public virtual System.Nullable<bool> Reverse { get; set; }
        public virtual string UId { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }
        public virtual string DenoRate { get; set; }
        public virtual string DenoRefundRate { get; set; }
        public virtual System.Nullable<DateTime> SettlementDate { get; set; }
        public virtual string AllDenoRate { get; set; }
        public virtual System.Nullable<decimal> Rate { get; set; }
        public virtual bool IsCheck { get; set; }
    }
}