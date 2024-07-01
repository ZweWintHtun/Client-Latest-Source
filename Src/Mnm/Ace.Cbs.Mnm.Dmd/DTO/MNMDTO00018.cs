//----------------------------------------------------------------------
// <copyright file="MNMDTO00018.cs" Name="PREV_LI" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Banking</CreatedUser>
// <CreatedDate>11/15/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
    [Serializable]
    public class MNMDTO00018 : Supportfields<MNMDTO00018>
    {
        public MNMDTO00018() { }

        public virtual int ID { get; set; }
        public virtual string LNo { get; set; }
        public virtual string Acctno { get; set; }
        public virtual System.Nullable<decimal> Q1 { get; set; }
        public virtual System.Nullable<decimal> Q2 { get; set; }
        public virtual System.Nullable<decimal> Q3 { get; set; }
        public virtual System.Nullable<decimal> Q4 { get; set; }
        public virtual System.Nullable<decimal> QBal1 { get; set; }
        public virtual System.Nullable<decimal> QBal2 { get; set; }
        public virtual System.Nullable<decimal> QBal3 { get; set; }
        public virtual System.Nullable<decimal> QBal4 { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string ACSign { get; set; }
        public virtual System.Nullable<DateTime> CloseDate { get; set; }
        public virtual string Budget { get; set; }
        public virtual string UId { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }
        public virtual bool IsCheck { get; set; }	
    }
}