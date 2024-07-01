//----------------------------------------------------------------------
// <copyright file="LOMDTO00015.cs" Name="Land_Building" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Haymar</CreatedUser>
// <CreatedDate>30/01/2015</CreatedDate>
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
/// Land_Building DTO
/// </summary>
namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMDTO00014 : Supportfields<LOMDTO00014>
    {
        public LOMDTO00014() { }

        public LOMDTO00014(string loan_Type,string loan_Desp)
        {
            this.LOANS_TYPE = loan_Type;
            this.LOANSDESP = loan_Desp;
        }

        public virtual string LOANS_TYPE { get; set; }
        public virtual string LOANSDESP { get; set; }
        public virtual string LOANSPROG { get; set; }
        public virtual string ENQUIRYPRG { get; set; }
        public virtual string EDITPRG { get; set; }
        public virtual string REMARK { get; set; }

    }
}
