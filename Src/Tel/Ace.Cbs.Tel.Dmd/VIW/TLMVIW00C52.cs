//----------------------------------------------------------------------
// <copyright file="TLMVIW00C52.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-10-29</CreatedDate>
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
    /// <!--VW_BANKCASH_WITHOUT_REVERSAL-->
    /// </summary>
    [Serializable]
   public class TLMVIW00C52
    {
        public TLMVIW00C52() { }
        public virtual int Id { get; set; }
        public virtual string ACode { get; set; }
        public virtual string Status { get; set; }
        public virtual decimal LocalAmt { get; set; }
        public virtual decimal LocalOAmt { get; set; }
        public virtual DateTime Date_Time { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string SourceCur { get; set; }
        public virtual DateTime SettlementDate { get; set; }
        public virtual string Narration { get; set; }
        public virtual string WorkStation { get; set; }
    }
}
