//----------------------------------------------------------------------
// <copyright file="MNMORM00026.cs" Name="FixIntPostingBefore" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>12/09/2013</CreatedDate>
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
    public class MNMORM00026 : EntityBase<MNMORM00026>
    {
        public MNMORM00026() { }

        public virtual string AcctNo { get; set; }
        public virtual string RNo { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual DateTime Date_Time { get; set; }
        public virtual string Budget { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }
    }
}