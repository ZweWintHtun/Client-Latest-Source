//----------------------------------------------------------------------
// <copyright file="TCMDTO00004.cs" Name="Term" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Banking</CreatedUser>
// <CreatedDate>11/14/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Tcm.Dmd
{
    [Serializable]
    public class TCMDTO00004 : Supportfields<TCMDTO00004>
    {
        public TCMDTO00004() { }

    
        public virtual string HPNo { get; set; }
        public virtual string TermNo { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual System.Nullable<DateTime> PaidDate { get; set; }
        public virtual System.Nullable<DateTime> DueDate { get; set; }
        public virtual string Status { get; set; }
        public virtual string ODAmount { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual System.Nullable<decimal> TotalLateFees { get; set; }
        public virtual System.Nullable<decimal> LastInt { get; set; }
        public virtual System.Nullable<DateTime> LateFeePaidDate { get; set; }
        public virtual string UId { get; set; }
        public virtual string Cur { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual bool IsCheck { get; set; }
    }
}	
