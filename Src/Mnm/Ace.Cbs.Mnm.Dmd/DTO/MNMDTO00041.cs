//----------------------------------------------------------------------
// <copyright file="MNMDTO00041.cs" Name="TempFRECEIPTDate" company="ACE Data Systems">
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
    public class MNMDTO00041 : Supportfields<MNMDTO00041>
    {
        public MNMDTO00041() { }

        public MNMDTO00041(DateTime startDATE_Time, DateTime endDATE_Time,int counts, string sourceBr)
        {
            this.StartDATE_Time = startDATE_Time;
            this.EndDATE_Time = endDATE_Time;
            this.Counts = counts;
            this.SourceBr = sourceBr;
        }

       
        public virtual System.Nullable<DateTime> StartDATE_Time { get; set; }
        public virtual System.Nullable<DateTime> EndDATE_Time { get; set; }
        public virtual System.Nullable<int> Counts { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual bool IsCheck { get; set; }
    }
}