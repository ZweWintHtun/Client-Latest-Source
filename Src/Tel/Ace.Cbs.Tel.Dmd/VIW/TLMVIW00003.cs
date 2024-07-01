//----------------------------------------------------------------------
// <copyright file="TLMVIW00003.cs" company="ACE Data Systems">
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
    /// VW_MOB3522_NORMAL
    /// </summary>
    [Serializable]
   public class TLMVIW00003
    {
        TLMVIW00003() { }
        public virtual int Id { get; set; }
        public virtual string Acode { get; set; }
        public virtual string PoNo { get; set; }
        public virtual DateTime ADate { get; set; }
        public virtual DateTime IDate { get; set; }
        public virtual Nullable<decimal> Amount { get; set; }
        public virtual string Status { get; set; }
        public virtual string Cur { get; set; }
        public virtual string SourceBranchCode { get; set; }
    }
}
