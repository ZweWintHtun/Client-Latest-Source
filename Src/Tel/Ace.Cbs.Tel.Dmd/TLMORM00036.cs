//----------------------------------------------------------------------
// <copyright file="TLMORM00036.cs" company="ACE Data Systems">
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

namespace Ace.Cbs.Tel.Dmd
{
    /// <summary>
    /// AMOUNTKEY ORM Entity
    /// </summary>
    [Serializable]
    public class TLMORM00036 : EntityBase<TLMORM00036>
    {
        public TLMORM00036() { }
        public virtual string Code { get; set; }
        public virtual System.Nullable<decimal> Value { get; set; }
        public virtual System.Nullable<DateTime> StartDate { get; set; }
        public virtual string UniqueId { get; set; }
    }
}
