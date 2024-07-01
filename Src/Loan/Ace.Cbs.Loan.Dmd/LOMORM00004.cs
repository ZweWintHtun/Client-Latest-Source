//----------------------------------------------------------------------
// <copyright file="LONORM0004.cs" Name="INSURAN" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KSW</CreatedUser>
// <CreatedDate>08/18/2014</CreatedDate>
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
    public class LOMORM00004 : EntityBase<LOMORM00004>
    {
        public LOMORM00004() { }

        public virtual string INSUCODE { get; set; }
        public virtual string INSUDESP { get; set; }
    }
}