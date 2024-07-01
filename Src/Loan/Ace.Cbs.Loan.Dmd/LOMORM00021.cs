//----------------------------------------------------------------------
// <copyright file="TLMORM00018.cs" company="ACE Data Systems">
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


namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// Loans ORM Entity
    /// </summary>
    [Serializable]
    public class LOMORM00021 : EntityBase<LOMORM00021>
    {
        public LOMORM00021() { }
        public virtual string Lno { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual string AType { get; set; }
        public virtual string BType { get; set; }
        public virtual System.Nullable<DateTime> SDate { get; set; }
        public virtual System.Nullable<decimal> SAmount { get; set; }
        public virtual string Time { get; set; }
        public virtual string Loans_Type { get; set; }
        public virtual System.Nullable<DateTime> ExpireDate { get; set; }
        public virtual System.Nullable<decimal> IntRate { get; set; }
        public virtual System.Nullable<decimal> UnUsedRate { get; set; }
        public virtual System.Nullable<decimal> UsedOverRate { get; set; }
        public virtual System.Nullable<decimal> FirstSAmount { get; set; }
        public virtual System.Nullable<DateTime> LasIntDate { get; set; }
        public virtual string LasRepayNo { get; set; }
        public virtual System.Nullable<decimal> Min_Period { get; set; }
        public virtual bool Vouchered { get; set; }
        public virtual string ACSign { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string Assessor { get; set; }
        public virtual string Lawer { get; set; }
        public virtual bool LegalCase { get; set; }
        public virtual System.Nullable<DateTime> LegalDate { get; set; }
        public virtual string LegaLawer { get; set; }
        public virtual System.Nullable<DateTime> CloseDate { get; set; }
        public virtual bool NPLCase { get; set; }
        public virtual System.Nullable<DateTime> NPLDate { get; set; }
        public virtual string LastUserNo { get; set; }
        public virtual System.Nullable<DateTime> LastDate { get; set; }
        public virtual System.Nullable<bool> Partial { get; set; }
        public virtual System.Nullable<DateTime> VoucherDate { get; set; }
        public virtual System.Nullable<int> PartialNo { get; set; }
        public virtual decimal Scharges { get; set; }
        public virtual string TodSerial { get; set; }
        public virtual System.Nullable<DateTime> TodCloseDate { get; set; }
        public virtual string Charges_Status { get; set; }
        public virtual string MarkNPLUser { get; set; }
        public virtual string NPLReleaseUser { get; set; }
        public virtual string MarkLegalUser { get; set; }
        public virtual string LegalReleaseUser { get; set; }
        public virtual string UniqueId { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual string Currency { get; set; }
        public virtual string BalStatus { get; set; }
        public virtual bool isLateFee { get; set; }
        public virtual bool isSCharge { get; set; }
        //public virtual MNMORM00017 Li { get; set; }
    }
}
