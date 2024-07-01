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
    /// VW_MOB3226
    /// </summary>
    /// 
    [Serializable]
    class MNMVIW00012
    {
        public virtual int Id { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal AMOUNT { get; set; }
        public virtual decimal Fbal { get; set; }
        public virtual string AccruedStatus { get; set; }
        public virtual string Rno { get; set; }
        public virtual DateTime RDate { get; set; }
        public virtual DateTime WDate { get; set; }
        public virtual DateTime LastIntDate { get; set; }
        public virtual string AcSign { get; set; }
        public virtual DateTime Duration { get; set; }
        public virtual DateTime MatureDate { get; set; }
        public virtual string Cur { get; set; }
        public virtual string SourceBr { get; set; }
    }
}
