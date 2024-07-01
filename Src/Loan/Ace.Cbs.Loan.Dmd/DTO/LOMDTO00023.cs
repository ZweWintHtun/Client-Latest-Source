//----------------------------------------------------------------------
// <copyright file="LOMDTO00021.cs" Name="LI" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Banking</CreatedUser>
// <CreatedDate>11/15/2013</CreatedDate>
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
    /// Partial_Loans DTO
    /// </summary>
    [Serializable]
    public class LOMDTO00023 : Supportfields<LOMDTO00023>
    {
        public LOMDTO00023() { }

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