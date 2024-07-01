//----------------------------------------------------------------------
// <copyright file="MNMVIW00030.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> HM </CreatedUser>
// <CreatedDate>2014-02-11</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
    /// <summary>
    /// VW_MOB19RL_ALL for Receipt Reversal
    /// </summary>
    /// 
    [Serializable]
    class MNMVIW00030 : EntityBase<MNMVIW00030>
    {        
        public virtual System.Nullable<DateTime> CHKTIME { get; set; }
        public virtual DateTime DATE_TIME { get; set; }
        public virtual string ENO { get; set; }
        public virtual string ORGNENO { get; set; }
        public virtual string ACCTNO { get; set; }
        public virtual string NAME { get; set; }
        public virtual string OTHERBANK { get; set; }
        public virtual string CHEQUE { get; set; }
        public virtual string SOURCECUR { get; set; }
        public virtual System.Nullable<decimal> LOCALAMOUNT { get; set; }
        public virtual string STATUS { get; set; }
        public virtual string TRANCODE { get; set; }
        public virtual string WORKSTATION { get; set; }

    }
}
