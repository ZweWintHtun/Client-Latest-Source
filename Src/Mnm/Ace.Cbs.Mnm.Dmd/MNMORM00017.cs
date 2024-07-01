//----------------------------------------------------------------------
// <copyright file="MNMORM00017.cs" Name="LI" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>SuNge</CreatedUser>
// <CreatedDate>11/27/2013</CreatedDate>
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
    public class MNMORM00017 : Supportfields<MNMORM00017>
    {
        public MNMORM00017() { }

        public virtual int Id { get; set; }
        //public virtual string TNo { get; set; }
        public virtual string LNo { get; set; }
        public virtual string Acctno { get; set; }
        //public virtual System.Nullable<decimal> PrincipalAmount { get; set; }
        //public virtual System.Nullable<decimal> InterestAmount { get; set; }
        public virtual System.Nullable<decimal> IntRate { get; set; }
        public virtual int Duration { get; set; }
        public virtual int Repaymentoption { get; set; }
        //public virtual System.Nullable<decimal> InterestAmount { get; set; }
        //public virtual DateTime StartDate { get; set; }
        //public virtual DateTime EndDate { get; set; }        
        //public virtual int RepaymentPeriod { get; set; }
        //public virtual System.Nullable<int> RepayTotalCount { get; set; }
        //public virtual System.Nullable<decimal> AddPayAmount { get; set; }
        //public virtual string AddPayInterval { get; set; }
        public virtual System.Nullable<decimal> M1 { get; set; }
        public virtual System.Nullable<decimal> M2 { get; set; }
        public virtual System.Nullable<decimal> M3 { get; set; }
        public virtual System.Nullable<decimal> M4 { get; set; }
        public virtual System.Nullable<decimal> M5 { get; set; }
        public virtual System.Nullable<decimal> M6 { get; set; }
        public virtual System.Nullable<decimal> M7 { get; set; }
        public virtual System.Nullable<decimal> M8 { get; set; }
        public virtual System.Nullable<decimal> M9 { get; set; }
        public virtual System.Nullable<decimal> M10 { get; set; }
        public virtual System.Nullable<decimal> M11 { get; set; }
        public virtual System.Nullable<decimal> M12 { get; set; }
        public virtual System.Nullable<decimal> Q1 { get; set; }
        public virtual System.Nullable<decimal> Q2 { get; set; }
        public virtual System.Nullable<decimal> Q3 { get; set; }
        public virtual System.Nullable<decimal> Q4 { get; set; }
        public virtual System.Nullable<decimal> QBal1 { get; set; }
        public virtual System.Nullable<decimal> QBal2 { get; set; }
        public virtual System.Nullable<decimal> QBal3 { get; set; }
        public virtual System.Nullable<decimal> QBal4 { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string ACSign { get; set; }
        public virtual System.Nullable<DateTime> CloseDate { get; set; }
        public virtual string Budget { get; set; }
        public virtual string UId { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }
        //public virtual DateTime DueDate { get; set; }
    }
}