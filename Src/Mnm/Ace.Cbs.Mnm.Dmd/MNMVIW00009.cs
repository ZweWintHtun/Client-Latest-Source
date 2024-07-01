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
    [Serializable]
    class MNMVIW00009
    {
        /// <summary>
        /// VW_Sing
        /// </summary>
        /// 
        public virtual int Id { get; set; }
        public virtual string Acctno { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal Cbal { get; set; }
        public virtual decimal I1 { get; set; }
        public virtual decimal I2 { get; set; }
        public virtual decimal I3 { get; set; }
        public virtual decimal I4 { get; set; }
        public virtual string Budget { get; set; }
        public virtual string SourceBr { get; set; }
    }
}
