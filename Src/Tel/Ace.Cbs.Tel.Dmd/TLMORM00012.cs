//----------------------------------------------------------------------
// <copyright file="TLMORM00012.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San </CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Tel.Dmd
{
    /// <summary>
    /// Deno ORM Entity
    /// </summary>
    [Serializable]
    public class TLMORM00012 : EntityBase<TLMORM00012>
    {       
        public virtual string Description { get; set; }
        public virtual decimal D1 { get; set; }
        public virtual decimal D2 { get; set; }
        public virtual string UId { get; set; }
        public virtual string Currency { get; set; }
        public virtual string Symbol { get; set; }
    }
}
