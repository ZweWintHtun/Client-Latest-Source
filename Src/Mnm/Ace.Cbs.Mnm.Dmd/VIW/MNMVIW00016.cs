//----------------------------------------------------------------------
// <copyright file="MNMVIW00002.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> NLKK </CreatedUser>
// <CreatedDate>2014-01-22</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Mnm.Dmd
{
    /// <summary>
    /// VW_TRIALSHEET
    /// </summary>
    /// 
    [Serializable]
    public class MNMVIW00016
    {
        public virtual int Id { get; set; }
        public virtual string ACode { get; set; }
        public virtual string CBMACode { get; set; }
        public virtual string ACName { get; set; }
        public virtual string ACType { get; set; }
        public virtual string Status { get; set; }
        public virtual string Cur { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual decimal HomeAmount { get; set; }
        public virtual int Reversal { get; set; }
        public virtual DateTime Date_Time { get; set; }
        public virtual DateTime SettlementDate { get; set; }
        public virtual string Workstation { get; set; }
        public virtual string SourceBr { get; set; }
    }
}
