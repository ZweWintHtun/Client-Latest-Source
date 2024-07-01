//----------------------------------------------------------------------
// <copyright file="TCMORM00008.cs" Name="TLFDate" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>arkar</CreatedUser>
// <CreatedDate>12/02/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Tcm.Dmd
{
    [Serializable]
    public class TCMORM00008 : EntityBase<TCMORM00008>
    {
        public TCMORM00008() { }

        public virtual System.Nullable<DateTime> TLFMinDate { get; set; }
        public virtual System.Nullable<DateTime> TLFSDate { get; set; }
        public virtual System.Nullable<DateTime> MTLFMaxDate { get; set; }
        public virtual System.Nullable<DateTime> MTLFMinDate { get; set; }
        public virtual System.Nullable<DateTime> MTLFSMaxDate { get; set; }
        public virtual System.Nullable<DateTime> MTLFSMinDate { get; set; }
        public virtual System.Nullable<DateTime> YTLFMaxDate { get; set; }
        public virtual System.Nullable<DateTime> YTLFMinDate { get; set; }
        public virtual System.Nullable<DateTime> YTLFSMaxDate { get; set; }
        public virtual System.Nullable<DateTime> YTLFSMinDate { get; set; }
        public virtual System.Nullable<DateTime> HTLFMaxDate { get; set; }
        public virtual System.Nullable<DateTime> HTLFMinDate { get; set; }
        public virtual System.Nullable<DateTime> HTLFSMaxDate { get; set; }
        public virtual System.Nullable<DateTime> HTLFSMinDate { get; set; }
        public virtual string UId { get; set; }
        public virtual string SourceBr { get; set; }
    }
}