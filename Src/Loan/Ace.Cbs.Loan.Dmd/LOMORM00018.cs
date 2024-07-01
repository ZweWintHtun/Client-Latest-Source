//----------------------------------------------------------------------
// <copyright file="LOMORM0018.cs" Name="LMT99#00" company="ACE Data Systems">
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
    /// GJType
    /// </summary>
    [Serializable]
    public class LOMORM00018 : EntityBase<LOMORM00018>
    {
        public LOMORM00018() { }
        public virtual int Id { get; set; }
        public virtual string LNo { get; set; }
        public virtual string GJType { get; set; }
        public virtual System.Nullable<decimal> Quantity { get; set; }
        public virtual string Weight { get; set; }
        public virtual System.Nullable<decimal> Value { get; set; }
        public virtual System.Nullable<DateTime> CloseDate { get; set; }
        public virtual string SourceBr { get; set; }


    }
}
