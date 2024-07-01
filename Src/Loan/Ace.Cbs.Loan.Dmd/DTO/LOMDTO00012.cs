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
/// PenalFee DTO
/// </summary>
namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMDTO00012 : EntityBase<LOMDTO00012>
    {
        public LOMDTO00012(){ }

        public LOMDTO00012(string lno,int startday,int endday, decimal fee,decimal amount,int duration,string status,string sourcebr)
        {
            this.Lno = lno;
            this.StartDay = startday;
            this.EndDay = endday;
            this.Fee = fee;
            this.Amount = amount;
            this.Duration = duration;
            this.Status = status;
            this.SourceBr = sourcebr;
        }

        public string Lno { get; set; }
        public int StartDay { get; set; }
        public int EndDay { get; set; }
        public decimal Fee { get; set; }
        public decimal Amount { get; set; }
        public int Duration { get; set; }
        public string Status { get; set; }
        public string SourceBr { get; set; }
    }
}
