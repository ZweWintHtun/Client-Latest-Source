//----------------------------------------------------------------------
// <copyright file="TLMORM00013.cs" company="ACE Data Systems">
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
    /// CashSetup ORM Entity
    /// </summary>
    [Serializable]
    public class TLMORM00013 : Supportfields<TLMORM00013>
    {
        public TLMORM00013() { }
        public virtual string CashCode { get; set; }
        public virtual string Description { get; set; }
        public virtual string UniqueId { get; set; }
    }
}
