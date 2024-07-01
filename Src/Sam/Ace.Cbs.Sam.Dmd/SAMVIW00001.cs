//----------------------------------------------------------------------
// <copyright file="SAMVIW00001.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2015-02-18</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Sam.Dmd
{
    /// <summary>
    /// [VW_RATELIST]
    /// </summary>
    [Serializable]
   public class SAMVIW00001
    {
        public virtual int Id { get; set; }
        public virtual string CODE { get; set; }
        public virtual Nullable<decimal> DURATION { get; set; }
        public virtual string DESP { get; set; }
        public virtual string RATE { get; set; }
        public virtual Nullable<DateTime> DATE_TIME { get; set; }
        public virtual string USERNO { get; set; }
        public virtual string STATUS { get; set; }
    }
}
