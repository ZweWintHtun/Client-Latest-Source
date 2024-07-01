//----------------------------------------------------------------------
// <copyright file="MNMORM00013.cs" Name="DATEFILE" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Banking</CreatedUser>
// <CreatedDate>11/15/2013</CreatedDate>
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
    public class MNMORM00013 : EntityBase<MNMORM00013>
    {
        public MNMORM00013() { }

        public virtual DateTime FIXINTDATE { get; set; }
        public virtual DateTime FIXVOUDATE { get; set; }
        public virtual string UID { get; set; }
        public virtual string SOURCEBR { get; set; }
    }
}