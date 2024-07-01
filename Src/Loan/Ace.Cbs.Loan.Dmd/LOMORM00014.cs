//----------------------------------------------------------------------
// <copyright file="LOMORM00013.cs" Name="LMT99#00" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>ASDA</CreatedUser>
// <CreatedDate>19/01/2015</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

/// <summary>
/// LoanType ORM
/// </summary>

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMORM00014 : EntityBase<LOMORM00014>
    {
        public LOMORM00014() { }

        public virtual string LOANS_TYPE { get; set; }
        public virtual string LOANSDESP { get; set; }
        public virtual string LOANSPROG { get; set; }
        public virtual string ENQUIRYPRG { get; set; }
        public virtual string EDITPRG { get; set; }
        public virtual string REMARK { get; set; }
    }
}
