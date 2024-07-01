//----------------------------------------------------------------------
// <copyright file="TLMVIW00008.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-08-22</CreatedDate>
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
    /// VW_Deno Outstanding Report
    /// </summary>
    [Serializable]
    public class TLMVIW00001
    {
        TLMVIW00001() { }
        public virtual int Id { get; set; }
        public virtual string ENo { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string Narration { get; set; }
        public virtual Nullable<decimal> Amount { get; set; }
        public virtual Nullable<DateTime> Date_Time { get; set; }
        public virtual string SourceCurrency { get; set; }
        public virtual string SourceBranch { get; set; }

    }
}
