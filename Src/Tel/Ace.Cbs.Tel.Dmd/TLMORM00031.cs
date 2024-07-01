//----------------------------------------------------------------------
// <copyright file="TLMORM00031.cs" company="ACE Data Systems">
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
    /// ZONE ORM Entity
    /// </summary>
    [Serializable]
    public class TLMORM00031 : EntityBase<TLMORM00031>
    {
        public TLMORM00031() { }
        public virtual string ZoneType { get; set; }
        public virtual string ZoneDescription { get; set; }
        public virtual string BranchCode { get; set; }
        public virtual string AccountCode { get; set; }
        public virtual string UniqueId { get; set; }
        public virtual string SourceBranchCode { get; set; }
    }
}
