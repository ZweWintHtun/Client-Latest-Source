//----------------------------------------------------------------------
// <copyright file="LOMDTO00007.cs" Name="GJTCode" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KSW</CreatedUser>
// <CreatedDate>08/25/2014</CreatedDate>
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
    public class LOMDTO00007 : Supportfields<LOMDTO00007>
    {
        public LOMDTO00007() { }

        public LOMDTO00007(string code, string description)
        {
            this.Code = code;
            this.Description = description;
        }

        public LOMDTO00007(string code, string description, bool active, byte[] TS, int createdUserId, DateTime createdDate, System.Nullable<int> updatedUserId, System.Nullable<DateTime> updatedDate)
        {
            this.Code = code;
            this.Description = description;
            this.Active = active;
            this.TS = TS;
            this.CreatedUserId = createdUserId;
            this.CreatedDate = createdDate;
            this.UpdatedUserId = updatedUserId;
            this.UpdatedDate = updatedDate;
        }

        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsCheck { get; set; }
    }
}