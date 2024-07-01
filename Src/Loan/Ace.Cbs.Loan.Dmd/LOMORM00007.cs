//----------------------------------------------------------------------
// <copyright file="LOMORM0007.cs" Name="GJTCode" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KSW</CreatedUser>
// <CreatedDate>08/25/2014</CreatedDate>
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
    [Serializable]
    public class LOMORM00007 : Supportfields<LOMORM00007>
    {
        public LOMORM00007() { }

        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
    }
}