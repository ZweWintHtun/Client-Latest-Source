//----------------------------------------------------------------------
// <copyright file="TLMVIW00008.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-08-22</CreatedDate>
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
    /// <summary>
    /// VW_IBL_Testkey
    /// </summary>
    [Serializable]
   public class TLMVIW00008
    {
        TLMVIW00008() { }
        TLMVIW00008(DateTime date)
        {
            this.Start_Date = date;           
        }
        public virtual int Id { get; set; }
        public virtual string Code { get; set; }
        public virtual Nullable<decimal> Value { get; set; }
        public virtual Nullable<DateTime> Start_Date { get; set; }
        public virtual bool Active { get; set; }
        public virtual string Status { get; set; }
    }
}
