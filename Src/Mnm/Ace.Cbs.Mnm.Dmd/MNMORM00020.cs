//----------------------------------------------------------------------
// <copyright file="MNMORM00020.cs" Name="PREV_RD" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Banking</CreatedUser>
// <CreatedDate>11/15/2013</CreatedDate>
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
    public class MNMORM00020 : EntityBase<MNMORM00020>
    {
        public MNMORM00020() { }

        public virtual string REGISTERNO { get; set; }
        public virtual string DRAWINGNO { get; set; }
        public virtual string DRAFTNO { get; set; }
        public virtual string DBANK { get; set; }
        public virtual string BR_ALIAS { get; set; }
        public virtual string TYPE { get; set; }
        public virtual string ACCTNO { get; set; }
        public virtual string NAME { get; set; }
        public virtual string ADDRESS { get; set; }
        public virtual string NRC { get; set; }
        public virtual string CHECKNO { get; set; }
        public virtual string TOACCTNO { get; set; }
        public virtual string TONAME { get; set; }
        public virtual string TONRC { get; set; }
        public virtual string TOADDRESS { get; set; }
        public virtual System.Nullable<decimal> TESTKEY { get; set; }
        public virtual System.Nullable<decimal> AMOUNT { get; set; }
        public virtual System.Nullable<decimal> COMMISSION { get; set; }
        public virtual System.Nullable<decimal> TLXCHARGES { get; set; }
        public virtual System.Nullable<DateTime> DATE_TIME { get; set; }
        public virtual System.Nullable<DateTime> RECEIPTDATE { get; set; }
        public virtual System.Nullable<DateTime> INCOMEDATE { get; set; }
        public virtual string RDTYPE { get; set; }
        public virtual string INCOMETYPE { get; set; }
        public virtual string ACSIGN { get; set; }
        public virtual string USERNO { get; set; }
        public virtual string BUDGET { get; set; }
        public virtual System.Nullable<DateTime> SENDDATE { get; set; }
        public virtual string LOANSERIAL { get; set; }
        public virtual string DENO_STATUS { get; set; }
        public virtual string PHONENO { get; set; }
        public virtual string TOPHONENO { get; set; }
        public virtual string NARRATION { get; set; }
        public virtual string UID { get; set; }
        public virtual string SOURCEBR { get; set; }
        public virtual string CUR { get; set; }
        public virtual string CHANNEL { get; set; }
        public virtual System.Nullable<DateTime> SETTLEMENTDATE { get; set; }
    }
}