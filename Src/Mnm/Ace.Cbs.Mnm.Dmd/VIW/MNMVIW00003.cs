//----------------------------------------------------------------------
// <copyright file="MNMVIW00003.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> HM </CreatedUser>
// <CreatedDate>2014-01-14</CreatedDate>
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
    public class MNMVIW00003 : Supportfields<MNMVIW00003>
    {
        public MNMVIW00003() { }

        public virtual int Id { get; set; }
        public virtual string ACODE { get; set; }
        public virtual string DCODE { get; set; }
        public virtual string CBMACODE { get; set; }
        public virtual string ACNAME { get; set; }
        public virtual string ACTYPE { get; set; }
       
        public virtual System.Nullable<decimal> MSRC1 { get; set; }
        public virtual System.Nullable<decimal> MSRC2 { get; set; }
        public virtual System.Nullable<decimal> MSRC3 { get; set; }
        public virtual System.Nullable<decimal> MSRC4 { get; set; }
        public virtual System.Nullable<decimal> MSRC5 { get; set; }
        public virtual System.Nullable<decimal> MSRC6 { get; set; }
        public virtual System.Nullable<decimal> MSRC7 { get; set; }
        public virtual System.Nullable<decimal> MSRC8 { get; set; }
        public virtual System.Nullable<decimal> MSRC9 { get; set; }
        public virtual System.Nullable<decimal> MSRC10 { get; set; }
        public virtual System.Nullable<decimal> MSRC11 { get; set; }
        public virtual System.Nullable<decimal> MSRC12 { get; set; }
       
    }
}
