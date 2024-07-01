//----------------------------------------------------------------------
// <copyright file="TLMORM00008.cs" Name="DEP_TLF" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KoKoTun</CreatedUser>
// <CreatedDate>01/24/2014</CreatedDate>
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
    [Serializable]
    public class TLMORM00008 : EntityBase<TLMORM00008>
    {
        public TLMORM00008() { }

        public virtual string ENO { get; set; }
        public virtual string DepositCode { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual string NAME { get; set; }
        public virtual decimal Quantity { get; set; }
        public virtual decimal AMOUNT { get; set; }
        public virtual decimal QUOTANO { get; set; }
        public virtual System.Nullable<DateTime> DATE_TIME { get; set; }
        public virtual string STATUS { get; set; }
        public virtual string UID { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual string CurrencyCode { get; set; }
        public virtual System.Nullable<decimal> RATE { get; set; }
        public virtual System.Nullable<DateTime> SETTLEMENTDATE { get; set; }
    }
}