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
    public class LOMDTO00016 : EntityBase<LOMDTO00016>
    {
        public LOMDTO00016() { }

        public LOMDTO00016(int id) { this.Id = id; }

        public LOMDTO00016(int id,string lno,string stockno,System.Nullable<decimal> stockQty,System.Nullable<decimal> market_val,System.Nullable<DateTime> closedate,
            System.Nullable<decimal> isamt,string isType,System.Nullable<DateTime> isdate, System.Nullable<DateTime> isexpireddate,string sourcebr)
        {
            this.Id = id;
            this.LNo = lno;
            this.StockNo = stockno;
            this.StockQTY = stockQty;
            this.Market_VAL = market_val;
            this.CloseDate = closedate;
            this.IsAMT = isamt;
            this.IsType = isType;
            this.IsDate = isdate;
            this.IsExpiredDate = isexpireddate;
            this.SourceBr = sourcebr;
        }

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
        public virtual string StockName { get; set; }


    }
}
