//----------------------------------------------------------------------
// <copyright file="TLMORM00027.cs" company="ACE Data Systems">
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
    /// ServerLog ORM Entity
    /// </summary>
    [Serializable]
    public class TLMORM00027 : EntityBase<TLMORM00027>
    {
        public TLMORM00027() { }
        public virtual string BranchNo { get; set; }
        public virtual string ServerName { get; set; }
        public virtual string DbName { get; set; }
        public virtual string IPAddress { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual string ISPName { get; set; }
        public virtual string UniqueId { get; set; }
        //public virtual string IBDIPAddress { get; set; }
        public virtual string Version { get; set; }
    }
}
