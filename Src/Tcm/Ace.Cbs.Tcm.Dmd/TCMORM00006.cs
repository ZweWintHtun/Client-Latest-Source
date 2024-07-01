//----------------------------------------------------------------------
// <copyright file="TCMORM00006.cs" Name="SIAccWit" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>arkar</CreatedUser>
// <CreatedDate>12/15/2013</CreatedDate>
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
    public class TCMORM00006 : EntityBase<TCMORM00006>
    {
        public TCMORM00006() { }

        public virtual string AccountNo { get; set; }
        public virtual string CreditAccountNo { get; set; }
        public virtual string Type { get; set; }
        public virtual System.Nullable<decimal> Amount { get; set; }
        public virtual System.Nullable<DateTime> Date_Time { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string Description { get; set; }
        public virtual string Budget { get; set; }
        public virtual string UId { get; set; }
        public virtual string SourceBranch { get; set; }
        public virtual string Currency { get; set; }
    }
}