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
    /// Pledge
    /// </summary>
    [Serializable]
    public class LOMORM00016 : EntityBase<LOMORM00016>
    {
        public LOMORM00016() { }

        public virtual int Id { get; set; }
        public virtual string LNo { get; set; }
        public virtual string StockNo { get; set; }
        public virtual System.Nullable<decimal> StockQTY { get; set; }
        public virtual System.Nullable<decimal> Market_VAL { get; set; }
        public virtual System.Nullable<DateTime> CloseDate { get; set; }
        public virtual System.Nullable<decimal> IsAMT { get; set; }
        public virtual string IsType { get; set; }
        public virtual System.Nullable<DateTime> IsDate { get; set; }
        public virtual System.Nullable<DateTime> IsExpiredDate { get; set; }           
        public virtual string SourceBr { get; set; }
        

    }
}
