//----------------------------------------------------------------------
// <copyright file="TLMVIW00006.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Nyo Me San </CreatedUser>
// <CreatedDate>2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Tel.Dmd
{
    /// <summary>
    /// VW_IBLTLF
    /// </summary>
    [Serializable]
    public class TLMVIW00006 : EntityBase<TLMVIW00006>
    {
        public TLMVIW00006() { }
        public virtual string FROMBRANCH { get; set; }
        public virtual string TOBRANCH { get; set; }
        public virtual string ACCTNO { get; set; }
        public virtual decimal AMOUNT { get; set; }
        public virtual string TRANTYPE { get; set; }
        public virtual System.DateTime DATE_TIME { get; set; }
        public virtual bool INOUT { get; set; }
        public virtual bool SUCCESS { get; set; }
        public virtual string ENO { get; set; }
        public virtual string USERNO { get; set; }
        public virtual string CHEQUE { get; set; }
        public virtual System.Nullable<decimal> INCOME { get; set; }
        public virtual System.Nullable<decimal> COMMUCHARGE { get; set; }
        public virtual bool REVERSAL { get; set; }
        public virtual int INCOMETYPE { get; set; }
        public virtual string RELATEDAC { get; set; }
        public virtual string RELATEDBRANCH { get; set; }
        public virtual string SOURCEBR { get; set; }
        public virtual string CURRENCY { get; set; }

        //Branch Code Relation
        public virtual Ace.Windows.Admin.DataModel.Branch FromBranchRelation { get; set; }
        public virtual Ace.Windows.Admin.DataModel.Branch ToBranchRelation { get; set; }
      
    }
}
