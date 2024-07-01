//----------------------------------------------------------------------
// <copyright file="LOMDTO00011.cs" Name="LMT99#00" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>ASDA</CreatedUser>
// <CreatedDate>07/01/2015</CreatedDate>
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
/// LMT99#0 DTO
/// </summary>
namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMDTO00011 : EntityBase<LOMDTO00011>
    {
        public LOMDTO00011(){}
        public LOMDTO00011(int id) 
        { this.Id = id;
       
        
        }

       
        public string AcctNo { get; set; }
        public DateTime Date_Time { get; set; }
        public decimal OVDLimit { get; set; }
        public string LoanNo { get; set; }
        public decimal OLDLimit { get; set; }
        public string UserNo { get; set; }
        public Nullable<DateTime> CloseDate { get; set; }
        public string SourceBr { get; set; }
        public string Cur { get; set; }     
    }
}
