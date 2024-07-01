//----------------------------------------------------------------------
// <copyright file="TCMORM00009.cs" Name="CashClosing" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>arkar</CreatedUser>
// <CreatedDate>12/02/2013</CreatedDate>
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
    public class TCMORM00009 : EntityBase<TCMORM00009>
    {
        public TCMORM00009() { }

        public virtual string CounterNo { get; set; }
        public virtual System.Nullable<DateTime> Date { get; set; }
        public virtual string Currency { get; set; }
        public virtual decimal CAmount { get; set; }
        public virtual string DenoDetail { get; set; }
        public virtual string UId { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual decimal HomeAmount { get; set; }
    }
}