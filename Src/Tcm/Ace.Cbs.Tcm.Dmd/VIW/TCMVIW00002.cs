//----------------------------------------------------------------------
// <copyright file="TCMVIW00002.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Ye Mann Aung </CreatedUser>
// <CreatedDate>2013-12-07</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Tcm.Dmd
{
    [Serializable]
    public class TCMVIW00002
    {
        /// <summary>
        /// VW_Banking_Clearing_LC_Without_Reversal
        /// </summary>
        public virtual int Id { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual string Particular { get; set; }
        public virtual decimal Debit { get; set; }
        public virtual decimal Credit { get; set; }
        public virtual DateTime Date_Time { get; set; }
        public virtual string Eno { get; set; }
        public virtual DateTime SettlementDate { get; set; }
        public virtual string Currency { get; set; }
        public virtual string WorkStation { get; set; }
    }
}
