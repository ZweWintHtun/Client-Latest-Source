//----------------------------------------------------------------------
// <copyright file="TLMDTO00059.cs" Name="GIFTCHEQUE" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KSW</CreatedUser>
// <CreatedDate>08/01/2014</CreatedDate>
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
    /*Gift Cheque DTO*/
    [Serializable]
    public class TLMDTO00059 : Supportfields<TLMDTO00059>
    {
        public TLMDTO00059() { }

        public virtual string GCNO { get; set; }
        public virtual decimal AMOUNT { get; set; }
        public virtual decimal TotalAMOUNT { get; set; }
        public virtual string NAME { get; set; }
        public virtual string ACCTNO { get; set; }
        public virtual System.Nullable<DateTime> ADATE { get; set; }
        public virtual System.Nullable<DateTime> IDATE { get; set; }
        public virtual string STATUS { get; set; }
        public virtual string TOACCTNO { get; set; }
        public virtual string TONAME { get; set; }
        public virtual string CHECKNO { get; set; }
        public virtual string INCOME { get; set; }
        public virtual string USERNO { get; set; }
        public virtual string ACSIGN { get; set; }
        public virtual System.Nullable<decimal> CHARGES { get; set; }
        public virtual string ACODE { get; set; }
        public virtual string BUDGET{ get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }
        public virtual System.Nullable<decimal> Rate { get; set; }
        public virtual System.Nullable<DateTime> SettlementDate { get; set; }
        public virtual bool IsCheck { get; set; }
        public virtual string counterNo { get; set; }
    }
}
