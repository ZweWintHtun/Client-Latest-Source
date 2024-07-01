//----------------------------------------------------------------------
// <copyright file="SAMORM00003.cs" Name="HOLIDAY" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>07/26/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Sam.Dmd
{
    [Serializable]
    public class SAMORM00003 : EntityBase<SAMORM00003>
    {
        public SAMORM00003() { }

        public virtual DateTime DATE { get; set; }
        public virtual string DESCRIPTION { get; set; }
        public virtual string USERNO { get; set; }
        public virtual string UID { get; set; }
    }
}