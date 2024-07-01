//----------------------------------------------------------------------
// <copyright file="LOMDTO00055.cs" Name="Installment Period" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Thet Aung Khine</CreatedUser>
// <CreatedDate>24/10/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMDTO00055 : Supportfields<LOMDTO00055>
    {
        public LOMDTO00055() { }

        public LOMDTO00055(int id, string name, int noofDay, int noofMonth)
        {
            this.Id = id;
            this.NAME = name;
            this.NOOFDAY = noofDay;
            this.NOOFMONTH = noofMonth;
        }

        public LOMDTO00055(int id, string name, int noofDay, int noofMonth, bool active, byte[] tS, int createdUserId, DateTime createdDate, System.Nullable<int> updatedUserId, System.Nullable<DateTime> updatedDate)
        {
            this.Id = id;
            this.NAME = name;
            this.NOOFDAY = noofDay;
            this.NOOFMONTH = noofMonth;
            this.Active = active;
            this.TS = tS;
            this.CreatedUserId = createdUserId;
            this.CreatedDate = createdDate;
            this.UpdatedUserId = updatedUserId;
            this.UpdatedDate = updatedDate;
        }

        public LOMDTO00055(int id, string name)
        {
            this.Id = id;
            this.NAME = name;
        }
        public LOMDTO00055(int id, string name, int NoOfMonth)
        {
            this.Id = id;
            this.NAME = name;
            this.NOOFMONTH = NoOfMonth;
        }

        public LOMDTO00055(string Name,int NoOfDay,int NoOfMonth)
        {
            this.NAME = Name;
            this.NOOFDAY = NoOfDay;
            this.NOOFMONTH = NoOfMonth;
        }
        public LOMDTO00055(string name)
        {
            this.NAME = name;
        }
        public virtual int Id { get; set; }
        public virtual string NAME { get; set; }        
        public virtual int NOOFDAY { get; set; }
        public virtual int NOOFMONTH { get; set; }

        public virtual bool IsCheck { get; set; }
    }
}
