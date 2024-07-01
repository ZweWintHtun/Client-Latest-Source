//----------------------------------------------------------------------
// <copyright file="MNMORM00042.cs" Name="TEMPFReceipt" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KSW</CreatedUser>
// <CreatedDate>07/17/2014</CreatedDate>
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
    public class MNMORM00042 : EntityBase<MNMORM00042>
    {
        public MNMORM00042() { }

        public virtual string RNo { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual decimal Duration { get; set; }
        public virtual System.Nullable<DateTime> WDate { get; set; }
        public virtual System.Nullable<DateTime> LasIntDate { get; set; }
        public virtual int PrnTime { get; set; }
        public virtual decimal LastPrnBal { get; set; }
        public virtual decimal BudEndAcc { get; set; }
        public virtual decimal BudEndTax { get; set; }
        public virtual decimal Accrued { get; set; }
        public virtual decimal DrAccured { get; set; }
        public virtual string APerson { get; set; }
        public virtual string ACSign { get; set; }
        public virtual decimal IntRate { get; set; }
        public virtual string AccruedStatus { get; set; }
        public virtual string FirstRNo { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string ToAcctNo { get; set; }
        public virtual string Cur { get; set; }
        public virtual decimal FD { get; set; }
        public virtual System.Nullable<DateTime> RDATE { get; set; }
        public virtual string USERNO { get; set; }
        public virtual System.Nullable<DateTime> LastAccruedDate { get; set; }
    }
}