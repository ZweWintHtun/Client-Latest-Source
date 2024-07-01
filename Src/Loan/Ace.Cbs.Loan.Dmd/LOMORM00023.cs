//----------------------------------------------------------------------
// <copyright file="LOMORM0018.cs" Name="LMT99#00" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>HM</CreatedUser>
// <CreatedDate>07/01/2015</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// Partial_Loans
    /// </summary>
    [Serializable]
    public class LOMORM00023 : Supportfields<LOMORM00023>
    {
        public LOMORM00023() { }

        public virtual string Lno { get; set; }
        public virtual int PartialNo { get; set; }
        public virtual string Acctno { get; set; }
        public virtual System.Nullable<decimal> Amount { get; set; }
        public virtual System.Nullable<DateTime> Date_Time { get; set; }
        public virtual System.Nullable<DateTime> LastintDate { get; set; }
        public virtual System.Nullable<DateTime> CloseDate { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }


    }
}
