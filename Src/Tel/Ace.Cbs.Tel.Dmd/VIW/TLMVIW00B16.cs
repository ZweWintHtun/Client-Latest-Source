﻿//----------------------------------------------------------------------
// <copyright file="TLMVIW00B16.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-09-19</CreatedDate>
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
    /// VW_PREVRE_RE
    /// </summary
    [Serializable]
   public class TLMVIW00B16
    {
        public TLMVIW00B16() { }

        public virtual int Id { get; set; }
        public virtual string RegisterNo { get; set; }
        public virtual string EncashNo { get; set; }
        public virtual string EBank { get; set; }
        public virtual string Br_Alias { get; set; }
        public virtual string Type { get; set; }
        public virtual string Name { get; set; }
        public virtual string NRC { get; set; }
        public virtual string ToAccountNo { get; set; }
        public virtual string ToName { get; set; }
        public virtual string ToNRC { get; set; }
        public virtual string ToAddress { get; set; }
        public virtual Nullable<decimal> TestKey { get; set; }
        public virtual Nullable<decimal> Amount { get; set; }
        public virtual Nullable<DateTime> DateTime { get; set; }
        public virtual Nullable<DateTime> IssueDate { get; set; }
        public virtual string ACSign { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string Budget { get; set; }
        public virtual string Currency { get; set; }
        public virtual Nullable<DateTime> SettlementDate { get; set; }
        public virtual bool OtherBank { get; set; }
        public virtual string BankAlias { get; set; }

    }
}