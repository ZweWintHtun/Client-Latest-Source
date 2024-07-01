//----------------------------------------------------------------------
// <copyright file="MNMVIW00003.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> HM </CreatedUser>
// <CreatedDate>2014-01-20</CreatedDate>
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
    public class MNMVIW00017 : Supportfields<MNMVIW00017>
    {
        public MNMVIW00017() { }

        public virtual int Id { get; set; }
        public virtual string CurAcctNo { get; set; }
        public virtual string SavAcctNo { get; set; }
        public virtual System.Nullable<decimal> CBal { get; set; }
        public virtual System.Nullable<decimal> CMinBal { get; set; }
        public virtual string SourceBr { get; set; }
    }
}