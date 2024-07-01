//----------------------------------------------------------------------
// <copyright file="MNMORM00021.cs" Name="INTLF" company="ACE Data Systems">
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
    public class MNMORM00021 : EntityBase<MNMORM00021>
    {
        public MNMORM00021() { }

        public virtual string ENO { get; set; }
        public virtual string ACCTNO { get; set; }
        public virtual decimal AMOUNT { get; set; }
        public virtual string ACODE { get; set; }
        public virtual decimal HOMEAMOUNT { get; set; }
        public virtual decimal HOMEAMT { get; set; }
        public virtual decimal HOMEOAMT { get; set; }
        public virtual decimal LOCALAMOUNT { get; set; }
        public virtual decimal LOCALAMT { get; set; }
        public virtual decimal LOCALOAMT { get; set; }
        public virtual string SOURCECUR { get; set; }
        public virtual string CURCODE { get; set; }
        public virtual string DESP { get; set; }
        public virtual string NARRATION { get; set; }
        public virtual System.Nullable<DateTime> DATE_TIME { get; set; }
        public virtual string STATUS { get; set; }
        public virtual string TRANCODE { get; set; }
        public virtual string ACSIGN { get; set; }
        public virtual string ORGNENO { get; set; }
        public virtual string USERNO { get; set; }
        public virtual byte[] CHKTIME { get; set; }
        public virtual string CLRPOSTSTATUS { get; set; }
        public virtual string CHEQUE { get; set; }
        public virtual string RECEIPTNO { get; set; }
        public virtual string UID { get; set; }
        public virtual string SOURCEBR { get; set; }
        public virtual System.Nullable<decimal> RATE { get; set; }
        public virtual System.Nullable<DateTime> SETTLEMENTDATE { get; set; }
    }
}