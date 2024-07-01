//----------------------------------------------------------------------
// <copyright file="LOMORM00013.cs" Name="LMT99#00" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>ASDA</CreatedUser>
// <CreatedDate>19/01/2015</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Tel.Dmd;

/// <summary>
/// Legal ORM
/// </summary>

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMORM00013 : EntityBase<LOMORM00013>
    {
        public LOMORM00013() { }

        public virtual int Id { get; set; }
        public virtual string Lno { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string AcType { get; set; }
        public virtual Nullable<DateTime> LegalDate { get; set; }
        public virtual Nullable<decimal> Bal { get; set; }
        public virtual Nullable<decimal> OldInt { get; set; }
        public virtual Nullable<decimal> OldScharge { get; set; }
        public virtual Nullable<decimal> OldExtra { get; set; }
        public virtual Nullable<decimal> Interest { get; set; }
        public virtual Nullable<decimal> IntRate { get; set; }
        public virtual Nullable<DateTime> CloseDate { get; set; }
        public virtual Nullable<DateTime> LastIntDate { get; set; }
        public virtual Nullable<decimal> NewBal { get; set; }
        public virtual Nullable<DateTime> AcceptDate { get; set; }
        public virtual Nullable<DateTime> ReleaseDate { get; set; }
        public virtual string LastRePayNo { get; set; }
        public virtual string SourceBr { get; set; }
        //public virtual LOMORM00021 Loans { get; set; }
        public virtual string Cur { get; set; }
        public virtual TLMORM00018 Loans { get; set; }

    }
}
