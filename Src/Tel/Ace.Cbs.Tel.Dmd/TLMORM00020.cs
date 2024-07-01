//----------------------------------------------------------------------
// <copyright file="TLMORM00020.cs" company="ACE Data Systems">
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
    /// DepositCode ORM Entity
    /// </summary>
    [Serializable]
    public class TLMORM00020 : Supportfields<TLMORM00020>
    {        
        public TLMORM00020() { }
        public virtual string DepositCode { get; set; }
        public virtual string Description { get; set; }
        public virtual string UniqueId { get; set; }
        public virtual string SourceBranchCode { get; set; }
    }
}
