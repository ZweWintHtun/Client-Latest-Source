//----------------------------------------------------------------------
// <copyright file="MNMDTO00022.cs" Name="LI" company="ACE Data Systems">
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
    public class MNMDTO00022 : EntityBase<MNMDTO00022>
    {
        public MNMDTO00022() { }
        public virtual string eno{ get; set; }
        public virtual string aCCTNO{ get; set; }
        public virtual string lno{ get; set; }
        public virtual string todSerial{ get; set; }
        public virtual System.Nullable<double> m1{ get; set; }
        public virtual System.Nullable<double> m2{ get; set; }
        public virtual System.Nullable<double> m3{ get; set; }
        public virtual System.Nullable<double> m4{ get; set; }
        public virtual System.Nullable<double> m5{ get; set; }
        public virtual System.Nullable<double> m6{ get; set; }
        public virtual System.Nullable<double> m7{ get; set; }
        public virtual System.Nullable<double> m8{ get; set; }
        public virtual System.Nullable<double> m9{ get; set; }
        public virtual System.Nullable<double> m10{ get; set; }
        public virtual System.Nullable<double> m11{ get; set; }
        public virtual System.Nullable<double> m12{ get; set; }
        public virtual System.Nullable<DateTime> lastDate{ get; set; }
        public virtual System.Nullable<double> lastInt{ get; set; }
        public virtual string sourceBr{ get; set; }
        public virtual string cur{ get; set; }
        public virtual System.Guid uID{ get; set; }
        public virtual bool active{ get; set; }
        public virtual System.DateTime tS{ get; set; }
        public virtual System.DateTime createdDate{ get; set; }
        public virtual int createdUserId{ get; set; }
        public virtual System.Nullable<DateTime> updatedDate{ get; set; }
        public virtual System.Nullable<int> updatedUserId{ get; set; }
    }
}
