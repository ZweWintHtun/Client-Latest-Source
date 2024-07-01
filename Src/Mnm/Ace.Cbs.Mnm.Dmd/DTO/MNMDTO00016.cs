//----------------------------------------------------------------------
// <copyright file="MNMDTO00016.cs" Name="Prev_Bal" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>SuNge</CreatedUser>
// <CreatedDate>11/29/2013</CreatedDate>
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
    public class MNMDTO00016 : Supportfields<MNMDTO00016>
    {
        public MNMDTO00016() { }

        public virtual int Id { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string Cur { get; set; }
        public virtual System.Nullable<DateTime> DATE_TIME { get; set; }
        public virtual string USERNO { get; set; }
        public virtual System.Nullable<DateTime> CloseDate { get; set; }
        public virtual string Budget { get; set; }
        public virtual string ACSign { get; set; }
        public virtual decimal M1 { get; set; }
        public virtual System.Nullable<decimal> TCount1 { get; set; }
        public virtual decimal M2 { get; set; }
        public virtual System.Nullable<decimal> TCount2 { get; set; }
        public virtual decimal M3 { get; set; }
        public virtual System.Nullable<decimal> TCount3 { get; set; }
        public virtual decimal M4 { get; set; }
        public virtual System.Nullable<decimal> TCount4 { get; set; }
        public virtual decimal M5 { get; set; }
        public virtual System.Nullable<decimal> TCount5 { get; set; }
        public virtual decimal M6 { get; set; }
        public virtual System.Nullable<decimal> TCount6 { get; set; }
        public virtual decimal M7 { get; set; }
        public virtual System.Nullable<decimal> TCount7 { get; set; }
        public virtual decimal M8 { get; set; }
        public virtual System.Nullable<decimal> TCount8 { get; set; }
        public virtual decimal M9 { get; set; }
        public virtual System.Nullable<decimal> TCount9 { get; set; }
        public virtual decimal M10 { get; set; }
        public virtual System.Nullable<decimal> TCount10 { get; set; }
        public virtual decimal M11 { get; set; }
        public virtual System.Nullable<decimal> TCount11 { get; set; }
        public virtual decimal M12 { get; set; }
        public virtual System.Nullable<decimal> TCount12 { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual bool IsCheck { get; set; }
    }
}