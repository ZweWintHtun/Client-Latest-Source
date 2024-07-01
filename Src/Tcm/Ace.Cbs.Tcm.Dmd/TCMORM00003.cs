//----------------------------------------------------------------------
// <copyright file="TCMORM00003.cs" Name="NPLInt" company="ACE Data Systems">
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

namespace Ace.Cbs.Tcm.Dmd
{
    [Serializable]
    public class TCMORM00003 : EntityBase<TCMORM00003>
    {
        public TCMORM00003() { }

        public virtual string LNo { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string AType { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual System.Nullable<DateTime> Date_Time { get; set; }
        public virtual string Type { get; set; }
        public virtual string Narration { get; set; }
        public virtual string UserNo { get; set; }
        public virtual System.Nullable<DateTime> ReleaseDate { get; set; }
        public virtual string UId { get; set; }
        public virtual string SourceBr { get; set; }
    }
}	
