//----------------------------------------------------------------------
// <copyright file="TLMORM00025.cs" company="ACE Data Systems">
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
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Tel.Dmd
{
    /// <summary>
    /// Reconsile ORM Entity
    /// </summary>
    [Serializable]
  public  class TLMORM00025 : EntityBase<TLMORM00025>
    {
        public TLMORM00025() { }
        public virtual string BranchCode { get; set; }
        public virtual System.Nullable<DateTime> Date_Time { get; set; }
        public virtual string Type { get; set; }
        public virtual System.Nullable<short> DagRno { get; set; }
        public virtual System.Nullable<int> AgRno { get; set; }
        public virtual System.Nullable<int> DupNo { get; set; }
        public virtual System.Nullable<int> Cursel { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual string UniqueId { get; set; }
        public virtual Branch Branch { get; set; }
    }
}
