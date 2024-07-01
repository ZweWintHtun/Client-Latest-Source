//----------------------------------------------------------------------
// <copyright file="LOMORM0012.cs" Name="LMT99#00" company="ACE Data Systems">
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
    /// PenalFee
    /// </summary>
    [Serializable]
    public class LOMORM00015 : Supportfields<LOMORM00015>
    {
        public LOMORM00015() { }
        public virtual string LNo { get; set; }
        public virtual System.Nullable<decimal> Capital { get; set; }
        public virtual System.Nullable<decimal> ExpYear { get; set; }
        public virtual System.Nullable<DateTime> EDate { get; set; }
        public virtual string Char { get; set; }
        public virtual string EVA { get; set; }
        public virtual string GW { get; set; }
        public virtual string Address { get; set; }
        public virtual string YearPB { get; set; }
        public virtual System.Nullable<decimal> Tax { get; set; }
        public virtual System.Nullable<decimal> IsAMT { get; set; }
        public virtual string IsType { get; set; }
        public virtual System.Nullable<DateTime> IsDate { get; set; }
        public virtual string SDEED { get; set; }
        public virtual string Land { get; set; }
        public virtual string HISLB { get; set; }
        public virtual string BPERMIT { get; set; }
        public virtual string LAFFID { get; set; }
        public virtual string PADV { get; set; }
        public virtual string SType { get; set; }
        public virtual string Class { get; set; }
        public virtual string Power { get; set; }
        public virtual System.Nullable<DateTime> DDate { get; set; }
        public virtual System.Nullable<decimal> FSVLand { get; set; }
        public virtual System.Nullable<decimal> FSVBLD { get; set; }
        public virtual System.Nullable<DateTime> CloseDate { get; set; }
        public virtual System.Nullable<DateTime> IsExpiredDate { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }

        public virtual System.Nullable<DateTime> LandLeaseSDate { get; set; }
        public virtual System.Nullable<DateTime> LandLeaseEDate { get; set; }
        public virtual string RemarkForLand { get; set; }
        
   }
}
