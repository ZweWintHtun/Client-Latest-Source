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
    /// HypothecationDto
    /// </summary>
    [Serializable]
    public class LOMDTO00017 : Supportfields<LOMDTO00017>
    {
        public LOMDTO00017() { }

        public LOMDTO00017(string lno,string kstock,System.Nullable<decimal> value,System.Nullable<DateTime> closedate,System.Nullable<decimal> isamt,
            string isType,System.Nullable<DateTime> isdate,System.Nullable<DateTime> isexpiredDate,string sourceBr)
        {
            this.LNo = lno;
            this.KStock = kstock;
            this.Value = value;
            this.CloseDate = closedate;
            this.IsAMT = isamt;
            this.IsType = isType;
            this.IsDate = isdate;
            this.IsExpiredDate = isexpiredDate;
            this.SourceBr = sourceBr;
        }

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
