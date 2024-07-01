//----------------------------------------------------------------------
// <copyright file="MNMORM00012.cs" Name="Legalint" company="ACE Data Systems">
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

namespace Ace.Cbs.Mnm.Dmd
{
    [Serializable]
    public class MNMORM00012 : EntityBase<MNMORM00012>
    {
        public MNMORM00012() { }

        public virtual string LNo { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string AType { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual DateTime Date_Time { get; set; }
        public virtual string Type { get; set; }
        public virtual string Narration { get; set; }
        public virtual string CRAcctno { get; set; }
        public virtual string UserNo { get; set; }
        public virtual System.Nullable<DateTime> CloseDate { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }
        public virtual string UId { get; set; }
    }
}	
