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
    /// GJDto
    /// </summary>
    [Serializable]
    public class LOMDTO00018 : Supportfields<LOMDTO00018>
    {
        public LOMDTO00018() { }

        public LOMDTO00018(int id ,string lno,string gjType,System.Nullable<decimal> qty,string weight,
            System.Nullable<decimal> value,System.Nullable<DateTime> closedate,string sourcebr) 
        {
            this.Id = id;
            this.LNo = lno;
            this.GJType = gjType;
            this.Quantity = qty;
            this.Weight = weight;
            this.Value = value;
            this.CloseDate = closedate;
            this.SourceBr = sourcebr;
        }

        public LOMDTO00018(int id ,string lno, string gjType, System.Nullable<decimal> qty, System.Nullable<DateTime> closedate, string sourcebr)
        {
            this.Id = id;
            this.LNo = lno;
            this.GJType = gjType;
            this.Quantity = qty;
            this.CloseDate = closedate;
            this.SourceBr = sourcebr;
        }

        public int Id { get; set; }
        public virtual string LNo { get; set; }
        public virtual string GJType { get; set; }
        public virtual System.Nullable<decimal> Quantity { get; set; }
        public virtual string Weight { get; set; }
        public virtual System.Nullable<decimal> Value { get; set; }
        public virtual System.Nullable<DateTime> CloseDate { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string description { get; set; }        

    }
}
