//----------------------------------------------------------------------
// <copyright file="TLMORM00002.cs" company="ACE Data Systems">
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
    /// CounterInfo ORM Entity
    /// </summary>
     [Serializable]
    public class TLMORM00002 : Supportfields<TLMORM00002>
    {
         public TLMORM00002() { }
         public virtual string CounterNo { get; set; }
        public virtual string Description{get;set;}
        public virtual string CounterType{get;set;}
        public virtual bool HasVault{get;set;}
        public virtual string SourceBranchCode { get; set; }
       
     }
}
