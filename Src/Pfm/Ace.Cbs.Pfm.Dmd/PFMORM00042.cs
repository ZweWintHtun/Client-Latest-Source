//----------------------------------------------------------------------
// <copyright file="PFMORM00042.cs" Name="Report_TLF" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NL</CreatedUser>
// <CreatedDate>11/21/2013</CreatedDate>
// <UpdatedUser>Ye Mann Aung</UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    [Serializable]
    public class PFMORM00042 : EntityBase<PFMORM00042>
    {
        public PFMORM00042() { }

        public virtual string Eno { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual System.Nullable<decimal> Amount { get; set; }
        public virtual string ACode { get; set; }
        public virtual System.Nullable<decimal> HomeAmount { get; set; }
        public virtual System.Nullable<decimal> HomeAmt { get; set; }
        public virtual System.Nullable<decimal> HomeOAmt { get; set; }
        public virtual System.Nullable<decimal> LocalAmount { get; set; }
        public virtual System.Nullable<decimal> LocalAmt { get; set; }
        public virtual System.Nullable<decimal> LocalOAmt { get; set; }
        public virtual string SourceCur { get; set; }
        public virtual string CurCode { get; set; }
        public virtual string Cheque { get; set; }
        public virtual string PONo { get; set; }
        public virtual string DRegisterNo { get; set; }
        public virtual string ERegisterNo { get; set; }
        public virtual string LgNo { get; set; }
        public virtual string LNo { get; set; }
        public virtual string Desp { get; set; }
        public virtual string Narration { get; set; }
        public virtual System.Nullable<DateTime> DATE_TIME { get; set; }
        public virtual string Status { get; set; }
        public virtual string TranCode { get; set; }
        public virtual string ACSign { get; set; }
        public virtual string DomBankPost { get; set; }
        public virtual string ClrPostStatus { get; set; }
        public virtual string OrgnEno { get; set; }
        public virtual string OrgnTranCode { get; set; }
        public virtual string OrgnCheque { get; set; }
        public virtual string OrgnPONo { get; set; }
        public virtual string OrgnDReg { get; set; }
        public virtual string OrgnEReg { get; set; }
        public virtual string OrgnLgNo { get; set; }
        public virtual string OrgnLno { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string ContraEno { get; set; }
        public virtual string ContraLno { get; set; }
        public virtual System.Nullable<DateTime> ContraDate { get; set; }
        public virtual string OtherBank { get; set; }
        public virtual System.Nullable<bool> DeliverReturn { get; set; }
        public virtual string ReceiptNo { get; set; }
        public virtual string OtherBankChq { get; set; }
        public virtual string OtherBankAcctNo { get; set; }
        public virtual string CustId { get; set; }
        public virtual string GChqNo { get; set; }
        public virtual System.Nullable<DateTime> ChkTime { get; set; }
        public virtual string WorkStation { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual System.Nullable<decimal> Rate { get; set; }
        public virtual System.Nullable<DateTime> SettlementDate { get; set; }
        public virtual string Channel { get; set; }
        public virtual string RefVNo { get; set; }
        public virtual string RefType { get; set; }
        public virtual string UId { get; set; }
        public virtual PFMORM00028 CledgerAcctNo { get; set; }
        public virtual PFMORM00023 FledgerAcctNo { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var t = obj as PFMORM00042;
            if (t == null)
                return false;
            if (Eno == t.Eno && AcctNo == t.AcctNo && ACode == t.ACode && Status==t.Status)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return (Eno + "|" + AcctNo + "|" + ACode + "|" + Status).GetHashCode();
        }
    }
}