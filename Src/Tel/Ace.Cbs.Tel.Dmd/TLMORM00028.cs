//----------------------------------------------------------------------
// <copyright file="TLMORM00028.cs" company="ACE Data Systems">
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
    /// RemitBranch ORM Entity
    /// </summary>
    [Serializable]
 public class TLMORM00028 :EntityBase<TLMORM00028>

    {
        public TLMORM00028() { }
        public virtual int Id { get; set; }
        public virtual string BranchCode { get; set; }
        public virtual decimal TelaxCharges { get; set; }
        public virtual decimal TTSerial { get; set; }
        public virtual decimal DraftSerial { get; set; }
        public virtual string StateCode { get; set; }
        public virtual string DrawingAccount { get; set; }
        public virtual string EncashAccount { get; set; }
        public virtual string IBSComAccount { get; set; }
        public virtual string TelaxAccount { get; set; }
        public virtual System.Nullable<Decimal> IblSerial { get; set; }
        public virtual string IRPOAccount { get; set; }
        public virtual string UniqueIdentifier { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual string Currency { get; set; }

    }
}
