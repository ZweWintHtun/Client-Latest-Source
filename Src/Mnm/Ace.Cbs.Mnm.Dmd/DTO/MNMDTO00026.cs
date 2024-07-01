//----------------------------------------------------------------------
// <copyright file="MNMDTO00026.cs" Name="FixIntPostingBefore" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>12/09/2013</CreatedDate>
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
    public class MNMDTO00026 : Supportfields<MNMDTO00026>
    {
        public MNMDTO00026() { }

        public MNMDTO00026(int id, string acctNo, string rNo, decimal amount, DateTime date_Time, string budget, string userNo, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
        {
            this.Id = id;
            this.AcctNo = acctNo;
            this.RNo = rNo;
            this.Amount = amount;
            this.Date_Time = date_Time;
            this.Budget = budget;
            this.UserNo = userNo;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }
        public virtual int Id { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string RNo { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual DateTime Date_Time { get; set; }
        public virtual string Budget { get; set; }
        public virtual string UserNo { get; set; }
        public virtual bool IsCheck { get; set; }
    }
}