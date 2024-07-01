//----------------------------------------------------------------------
// <copyright file="MNMDTO00002.cs" Name="PREV_PO" company="ACE Data Systems">
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
    public class MNMDTO00002 : Supportfields<MNMDTO00002>
    {
        public MNMDTO00002() { }

        public virtual string PONo { get; set; }
        public virtual decimal AMOUNT { get; set; }
        public virtual string ACCTNO { get; set; }
        public virtual System.Nullable<DateTime> ADATE { get; set; }
        public virtual System.Nullable<DateTime> IDATE { get; set; }
        public virtual string STATUS { get; set; }
        public virtual string TOACCTNO { get; set; }
        public virtual string CHECKNO { get; set; }
        public virtual string INCOME { get; set; }
        public virtual string USERNO { get; set; }
        public virtual string ACSIGN { get; set; }
        public virtual System.Nullable<decimal> CHARGES { get; set; }
        public virtual string ACODE { get; set; }
        public virtual string BUDGET { get; set; }
        public virtual string UID { get; set; }
        public virtual string SOURCEBR { get; set; }
        public virtual string CUR { get; set; }
        public virtual System.Nullable<decimal> RATE { get; set; }
        public virtual System.Nullable<DateTime> SETTLEMENTDATE { get; set; }
        public virtual System.Nullable<DateTime> REFUNDSDATE { get; set; }
        public virtual bool IsCheck { get; set; }
    }
}