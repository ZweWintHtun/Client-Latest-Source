//----------------------------------------------------------------------
// <copyright file="TLMORM00005.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Su Su Wai</CreatedUser>
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
    /// TranType Entity
    /// </summary>
    [Serializable]
    public class TLMORM00005 : Supportfields<TLMORM00005>
    {
        public TLMORM00005() { }
        public virtual string TransactionCode { get; set; }
        public virtual string Description { get; set; }
        public virtual string Narration { get; set; }
        public virtual string Status { get; set; }
        public virtual string PBReference { get; set; }
        public virtual string RVReference { get; set; }
        public virtual string UniqueId { get; set; }    
    }
}
