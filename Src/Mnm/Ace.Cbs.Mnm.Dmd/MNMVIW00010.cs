//----------------------------------------------------------------------
// <copyright file="MNMVIW00002.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> NLKK </CreatedUser>
// <CreatedDate>2014-01-15</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Mnm.Dmd
{
    /// <summary>
    /// VW_LedgerBalance_All
    /// </summary>
    /// 
    [Serializable]
    class MNMVIW00010
    {
        public virtual int Id { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual decimal Cbal { get; set; }
        public virtual decimal ODAmt { get; set; }
        public virtual decimal ODLimit { get; set; }
        public virtual string Name { get; set; }
        public virtual string Cur { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string AcSign { get; set; }
    }
}
