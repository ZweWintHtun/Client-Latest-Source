//----------------------------------------------------------------------
// <copyright file="TLMVIW00017.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Nyo Me San </CreatedUser>
// <CreatedDate>2013-08-22</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Tel.Dmd
{
    [Serializable]

  public  class TLMVIW00015
    {
        public TLMVIW00015() { }

        public virtual int Id { get; set; }
        public virtual string REGISTERNO { get; set; }
        public virtual string ACCTNO { get; set; }
        public virtual string BR_ALIAS { get; set; }
        public virtual string TYPE { get; set; }
        public virtual Nullable<DateTime> DATE_TIME { get; set; }
        public virtual string NAME { get; set; }
        public virtual string NRC { get; set; }
        public virtual string TONAME { get; set; }
        public virtual string TONRC { get; set; }
        public virtual string DBANK { get; set; }
        public virtual decimal COMMISSION { get; set; }
        public virtual decimal AMOUNT { get; set; }
        public virtual DateTime RECEIPTDATE { get; set; }
        public virtual DateTime INCOMEDATE { get; set; }
        public virtual string CUR { get; set; }
        public virtual string SOURCEBR { get; set; }
    }
}
