//----------------------------------------------------------------------
// <copyright file="MNMORM00023.cs" Name="PREV_COMMIT_FEES" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>SSA</CreatedUser>
// <CreatedDate>12/04/2013</CreatedDate>
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
    public class MNMORM00025 : EntityBase<MNMORM00025>
    {
        public MNMORM00025() { }

        public virtual int ID { get; set; }
        public virtual string Acctno { get; set; }
        public virtual string LNo { get; set; }
        public virtual decimal M1 { get; set; }
        public virtual decimal M2 { get; set; }
        public virtual decimal M3 { get; set; }
        public virtual decimal M4 { get; set; }
        public virtual decimal M5 { get; set; }
        public virtual decimal M6 { get; set; }
        public virtual decimal M7 { get; set; }
        public virtual decimal M8 { get; set; }
        public virtual decimal M9 { get; set; }
        public virtual decimal M10 { get; set; }
        public virtual decimal M11 { get; set; }
        public virtual decimal M12 { get; set; }
        public virtual string P1Status { get; set; }
        public virtual string P2Status { get; set; }
        public virtual string P3Status { get; set; }
        public virtual string P4Status { get; set; }
        public virtual System.Nullable<DateTime> LastDate { get; set; }
        public virtual System.Nullable<decimal> LastInt { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string ACSign { get; set; }
        public virtual System.Nullable<DateTime> CloseDate { get; set; }
        public virtual string Budget { get; set; }
        public virtual System.Nullable<DateTime> TODCloseDate { get; set; }
        public virtual string UId { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }
    }
}