//----------------------------------------------------------------------
// <copyright file="TCMDTO00009.cs" Name="CashClosing" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>arkar</CreatedUser>
// <CreatedDate>12/02/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Tcm.Dmd
{
    [Serializable]
    public class TCMDTO00009 : EntityBase<TCMDTO00009>
    {
        public TCMDTO00009() { }

        public TCMDTO00009(string cur, decimal totalCashBalance, decimal totalHomeAmount)
        {
            this.Cur = cur;
            this.TotalCashBalance = totalCashBalance;
            this.TotalHomeAmount = totalHomeAmount;
        }

        public TCMDTO00009(decimal currentAmount,string denoDetail, decimal homeAmount)
        {
            this.DenoDetail = denoDetail;
            this.CAmount = currentAmount;
            this.HomeAmount = homeAmount;
        }

        public TCMDTO00009(DateTime maximunDate)
        {
            this.Date = maximunDate;
        }

        public TCMDTO00009(int maxId)
        {
            this.Id = maxId;
        }

        public virtual string CounterNo { get; set; }
        public virtual System.Nullable<DateTime> Date { get; set; }
        public virtual string Cur { get; set; }
        public virtual decimal CAmount { get; set; }
        public virtual string DenoDetail { get; set; }
        public virtual string UId { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual decimal HomeAmount { get; set; }
        public virtual bool IsCheck { get; set; }
        public virtual decimal TotalCashBalance { get; set; }
        public virtual decimal TotalHomeAmount { get; set; }
    } 
}