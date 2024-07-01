//----------------------------------------------------------------------
// <copyright file="TLMVIW00002.cs" company="ACE Data Systems">
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
    /// VW_NEW_MULTIPLE_DRAWING_OUTSTANDING
    /// </summary>
    [Serializable]
    public class TLMVIW00002
    {
            TLMVIW00002() { }
            public virtual int Id { get; set; }
            public virtual string TLF_ENO { get; set; }
            public virtual string Entry_NO { get; set; }
            public virtual string AccountType { get; set; }
            public virtual Nullable<decimal> Amount { get; set; }
            public virtual string Currency { get; set; }
            public virtual string SourceBranch { get; set; }
    }
}
