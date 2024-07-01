//----------------------------------------------------------------------
// <copyright file="MNMORM00041.cs" Name="TempFRECEIPTDate" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KSW</CreatedUser>
// <CreatedDate>07/17/2014</CreatedDate>
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
    public class MNMORM00041 : EntityBase<MNMORM00041>
    {
        public MNMORM00041() { }

        public virtual System.Nullable<DateTime> StartDATE_Time { get; set; }
        public virtual System.Nullable<DateTime> EndDATE_Time { get; set; }
        public virtual System.Nullable<int> Counts { get; set; }
        public virtual string SourceBr { get; set; }
    }
}