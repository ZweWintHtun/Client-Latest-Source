//----------------------------------------------------------------------
// <copyright file="MNMORM00022.cs" Name="LI" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San </CreatedUser>
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
    public class MNMORM00022 
    {
        public MNMORM00022() { }
        public virtual int Id { get; set; }
        public virtual string Eno { get; set; }
        public virtual string ACCTNO { get; set; }
        public virtual string Lno { get; set; }
        public virtual string TodSerial{ get; set; }
        public virtual System.Nullable<double> M1{ get; set; }
        public virtual System.Nullable<double> M2{ get; set; }
        public virtual System.Nullable<double> M3{ get; set; }
        public virtual System.Nullable<double> M4{ get; set; }
        public virtual System.Nullable<double> M5{ get; set; }
        public virtual System.Nullable<double> M6{ get; set; }
        public virtual System.Nullable<double> M7{ get; set; }
        public virtual System.Nullable<double> M8{ get; set; }
        public virtual System.Nullable<double> M9{ get; set; }
        public virtual System.Nullable<double> M10{ get; set; }
        public virtual System.Nullable<double> M11{ get; set; }
        public virtual System.Nullable<double> M12{ get; set; }
        public virtual System.Nullable<DateTime> LastDate{ get; set; }
        public virtual System.Nullable<double> LastInt{ get; set; }
        public virtual string SourceBr{ get; set; }
        public virtual string Cur{ get; set; }
        public virtual string UID{ get; set; }
        public virtual bool Active{ get; set; }
        public virtual System.DateTime TS{ get; set; }
        public virtual System.DateTime CreatedDate{ get; set; }
        public virtual int CreatedUserId{ get; set; }
        public virtual System.Nullable<DateTime> UpdatedDate{ get; set; }
        public virtual System.Nullable<int> UpdatedUserId{ get; set; }      
    }
}
