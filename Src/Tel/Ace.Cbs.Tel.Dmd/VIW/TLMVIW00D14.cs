//----------------------------------------------------------------------
// <copyright file="TLMORM00009.cs" company="ACE Data Systems">
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
    /// DepoDeno ORM Entity
    /// </summary>
    [Serializable]
    public class TLMVIW00D14 : Supportfields<TLMVIW00D14>
    {
        public TLMVIW00D14() { }
        public virtual int Id { get; set; }
        public virtual string groupno { get; set; }
        public virtual string tlf_eno { get; set; }
        public virtual string actype { get; set; }
        public virtual decimal amount { get; set; }
        public virtual bool reverse_status { get; set; }
        public virtual bool Reverse { get; set; }
        public virtual DateTime CASHDATE { get; set; }
        public virtual System.Nullable<decimal> Income { get; set; }
        public virtual System.Nullable<decimal> Commucharge { get; set; }
        public virtual string userno { get; set; }
        public virtual string status { get; set; }
        public virtual string counterno { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string cur { get; set; }
        
    }
}
