//----------------------------------------------------------------------
// <copyright file="MNMORM00014.cs" Name="CI" company="ACE Data Systems">
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
    public class MNMORM00014 : EntityBase<MNMORM00014>
    {
        public MNMORM00014() { }

        public virtual string ACCTNO { get; set; }
        public virtual System.Nullable<decimal> M1 { get; set; }
        public virtual System.Nullable<decimal> M2 { get; set; }
        public virtual System.Nullable<decimal> M3 { get; set; }
        public virtual System.Nullable<decimal> M4 { get; set; }
        public virtual System.Nullable<decimal> M5 { get; set; }
        public virtual System.Nullable<decimal> M6 { get; set; }
        public virtual System.Nullable<decimal> M7 { get; set; }
        public virtual System.Nullable<decimal> M8 { get; set; }
        public virtual System.Nullable<decimal> M9 { get; set; }
        public virtual System.Nullable<decimal> M10 { get; set; }
        public virtual System.Nullable<decimal> M11 { get; set; }
        public virtual System.Nullable<decimal> M12 { get; set; }
        public virtual System.Nullable<DateTime> LASTDATE { get; set; }
        public virtual System.Nullable<decimal> LASTINT { get; set; }
        public virtual System.Nullable<DateTime> CLOSEDATE { get; set; }
        public virtual System.Nullable<DateTime> DATE_TIME { get; set; }
        public virtual string BUDGET { get; set; }
        public virtual string UID { get; set; }
        public virtual string SOURCEBR { get; set; }
        public virtual string CUR { get; set; }
    }
}