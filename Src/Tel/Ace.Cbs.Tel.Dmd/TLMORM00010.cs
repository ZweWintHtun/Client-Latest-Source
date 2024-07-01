//----------------------------------------------------------------------
// <copyright file="TLMORM00010.cs" company="ACE Data Systems">
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
    /// Workstation ORM Entity
    /// </summary>
    [Serializable]
    public class TLMORM00010 : EntityBase<TLMORM00010>
    {
        public TLMORM00010() { }
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string IPAddress { get; set; }
        public virtual string LogOnUserId { get; set; }
        public virtual string LogOnGroupId { get; set; }
        public virtual string PrinterName { get; set; }
        public virtual string HostName { get; set; }
        public virtual string MaskAddress { get; set; }
        public virtual string UniqueId { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual string CounterNo { get; set; }
        public virtual TLMORM00002 CounterInfo { get; set; }
    }
}
