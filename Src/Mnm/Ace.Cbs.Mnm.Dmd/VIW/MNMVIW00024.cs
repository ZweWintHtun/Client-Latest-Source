//----------------------------------------------------------------------
// <copyright file="MNMVIW00002.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> HM </CreatedUser>
// <CreatedDate>2014-01-15</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
    /// <summary>
    /// VW_MOB3224
    /// </summary>
    /// 
    [Serializable]
    class MNMVIW00024 : Supportfields<MNMVIW00024>
    {
        public virtual int Id { get; set; }
        public virtual string Cur { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual string Name { get; set; }      
        public virtual string Rno { get; set; }
        public virtual DateTime Rdate { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual decimal Duration { get; set; }
        public virtual string AcSign { get; set; }
        public virtual DateTime MatureDate { get; set; }

    }
}
