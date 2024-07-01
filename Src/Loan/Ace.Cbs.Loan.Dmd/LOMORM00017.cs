//----------------------------------------------------------------------
// <copyright file="LOMORM0017.cs" Name="LMT99#00" company="ACE Data Systems">
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
    /// Hypothecation
    /// </summary>
    [Serializable]
    public class LOMORM00017 : Supportfields<LOMORM00017>
    {
        public LOMORM00017() { }

        public virtual string LNo { get; set; }
        public virtual string KStock { get; set; }
        public virtual System.Nullable<decimal> Value { get; set; }
        public virtual System.Nullable<DateTime> CloseDate { get; set; }
        public virtual System.Nullable<decimal> IsAMT { get; set; }
        public virtual string IsType { get; set; }
        public virtual System.Nullable<DateTime> IsDate { get; set; }
        public virtual System.Nullable<DateTime> IsExpiredDate { get; set; }
        public virtual string SourceBr { get; set; }


    }
}
