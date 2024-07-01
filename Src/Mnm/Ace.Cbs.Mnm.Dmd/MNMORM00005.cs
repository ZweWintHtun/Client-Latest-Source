//----------------------------------------------------------------------
// <copyright file="MNMORM00005.cs" Name="TOD_SCHARGE" company="ACE Data Systems">
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
    public class MNMORM00005 : EntityBase<MNMORM00005>
    {
        public MNMORM00005() { }

        public virtual int ID { get; set; }
        public virtual string Acctno { get; set; }
        public virtual string LNo { get; set; }
        public virtual System.Nullable<decimal> S1 { get; set; }
        public virtual System.Nullable<decimal> S2 { get; set; }
        public virtual System.Nullable<decimal> S3 { get; set; }
        public virtual System.Nullable<decimal> S4 { get; set; }
        public virtual System.Nullable<decimal> S5 { get; set; }
        public virtual System.Nullable<decimal> S6 { get; set; }
        public virtual System.Nullable<decimal> S7 { get; set; }
        public virtual System.Nullable<decimal> S8 { get; set; }
        public virtual System.Nullable<decimal> S9 { get; set; }
        public virtual System.Nullable<decimal> S10 { get; set; }
        public virtual System.Nullable<decimal> S11 { get; set; }
        public virtual System.Nullable<decimal> S12 { get; set; }
        public virtual System.Nullable<decimal> LastInt { get; set; }
        public virtual System.Nullable<DateTime> LastDate { get; set; }
        public virtual string Budget { get; set; }
        public virtual string UserNo { get; set; }
        public virtual System.Nullable<DateTime> CloseDate { get; set; }
        public virtual string ACSign { get; set; }
        public virtual System.Nullable<DateTime> TODCloseDate { get; set; }
        public virtual System.Nullable<DateTime> TOD_SDate { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }
        public virtual string UId { get; set; }
    }
}