//----------------------------------------------------------------------
// <copyright file="TLMORM00003.cs" company="ACE Data Systems">
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
    /// PORate ORM Entity
    /// </summary>
    [Serializable]
    public class TLMORM00003 : EntityBase<TLMORM00003>
    {
        public TLMORM00003() { }
        public virtual System.Nullable<decimal> Range { get; set; }
        public virtual decimal Rate { get; set; }
        public virtual decimal FixAmount { get; set; }
        public virtual decimal StartNo { get; set; }
        public virtual decimal EndNo { get; set; }
        public virtual string UniqueId { get; set; }
        public virtual string Currency { get; set; }
    }
}
