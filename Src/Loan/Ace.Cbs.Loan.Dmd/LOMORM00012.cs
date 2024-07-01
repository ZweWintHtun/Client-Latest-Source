//----------------------------------------------------------------------
// <copyright file="LOMORM0012.cs" Name="LMT99#00" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>HM</CreatedUser>
// <CreatedDate>07/01/2015</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// PenalFee
    /// </summary>
    [Serializable]
    public class LOMORM00012 : EntityBase<LOMORM00012>
    {
        public LOMORM00012() { }
        public virtual string Lno { get; set; }
        public virtual int StartDay { get; set; }
        public virtual int EndDay { get; set; }
        public virtual decimal Fee { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual int Duration { get; set; }
        public virtual string Status { get; set; }
        public virtual string SourceBr { get; set; }
    }
}
