//----------------------------------------------------------------------
// <copyright file="TLMORM00029.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>2013-05-21</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version>1.0</Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Tel.Dmd
{
    /// <summary>
    /// RemitBranchIBL ORM Entity
    /// </summary>   
    /// 
     [Serializable]
    public class TLMORM00029 : EntityBase<TLMORM00029>
    {
       public TLMORM00029() { }

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
