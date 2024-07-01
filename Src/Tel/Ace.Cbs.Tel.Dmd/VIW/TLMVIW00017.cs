//----------------------------------------------------------------------
// <copyright file="TLMVIW00017.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Nyo Me San </CreatedUser>
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
    [Serializable]
   public class TLMVIW00017
    {
        public TLMVIW00017() { }

        
        public virtual int Id { get; set; }
        public virtual string Ebank { get; set; }
        public virtual string ToAccountNo { get; set; }
        public virtual string RegisterNo { get; set; }
        public virtual string Br_Alias { get; set; }
        public virtual Nullable<DateTime> Date_Time { get; set; }
        public virtual string Type { get; set; }
        public virtual string ToName { get; set; }
        public virtual string ToNRC { get; set; }
        public virtual Nullable<decimal> Amount { get; set; }
        public virtual string AccountSign { get; set; }
        public virtual bool OtherBank { get; set; }
        public virtual string SourceBranchCode { get; set; }
      
    }
}
