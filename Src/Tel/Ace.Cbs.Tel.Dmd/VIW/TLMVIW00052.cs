//----------------------------------------------------------------------
// <copyright file="TLMVIW00052.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-09-06</CreatedDate>
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
    /// VW_BANKCASH_BYHOMECUR
    /// </summary>
    [Serializable]
   public class TLMVIW00052
    {
        public TLMVIW00052() { }

        public virtual int Id { get; set; }
        public virtual string ACode { get; set; }
        public virtual string Status { get; set; }
        public virtual decimal HomeAmt { get; set; }
        public virtual decimal HomeOAmt { get; set; }
        public virtual DateTime Date_Time { get; set; }
        public virtual string sourcebr { get; set; }
        public virtual string SourceCur { get; set; }
        public virtual DateTime SettlementDate { get; set; }
        public virtual string Narration { get; set; }
        public virtual string WorkStation { get; set; }
    }
}
