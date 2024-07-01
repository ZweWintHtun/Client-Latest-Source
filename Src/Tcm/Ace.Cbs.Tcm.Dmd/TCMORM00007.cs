//----------------------------------------------------------------------
// <copyright file="TCMORM00007.cs" Name="MinBal" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Banking</CreatedUser>
// <CreatedDate>11/19/2013</CreatedDate>
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
    public class TCMORM00007 : EntityBase<TCMORM00007>
    {
        public TCMORM00007() { }

        public virtual string AccountNo { get; set; }
        public virtual DateTime Date_Time { get; set; }
        public virtual string UserNo { get; set; }
        public virtual decimal Old_Limit { get; set; }
        public virtual decimal New_Limit { get; set; }
        public virtual string Remark { get; set; }
        public virtual string UId { get; set; }
        public virtual string Currency { get; set; }
        public virtual string SourceBranch { get; set; }
    }
}