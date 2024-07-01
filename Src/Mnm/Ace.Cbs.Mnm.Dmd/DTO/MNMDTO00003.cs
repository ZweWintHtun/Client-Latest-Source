//----------------------------------------------------------------------
// <copyright file="MNMDTO00003.cs" Name="Prev_DepoDeno" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>SSA</CreatedUser>
// <CreatedDate>11/28/2013</CreatedDate>
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
    public class MNMDTO00003 : Supportfields<MNMDTO00003>
    {
        public MNMDTO00003() { }

        public virtual int Id { get; set; }
        public virtual string GroupNo { get; set; }
        public virtual string Tlf_Eno { get; set; }
        public virtual string AcType { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual bool Reverse_Status { get; set; }
        public virtual System.Nullable<decimal> Income { get; set; }
        public virtual System.Nullable<decimal> CommuCharge { get; set; }
        public virtual string UId { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }
    }
}