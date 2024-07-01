//----------------------------------------------------------------------
// <copyright file="TLMORM00007.cs" Name="TransactionFee" company="ACE Data Systems">
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

namespace Ace.Cbs.Tel.Dmd
{
    [Serializable]
    public class TLMORM00007 : EntityBase<TLMORM00007>
    {
        public TLMORM00007() { }

        public virtual string FeeCode { get; set; }
        public virtual decimal Fee { get; set; }
        public virtual string Cur { get; set; }
        public virtual string UId { get; set; }
    }
}