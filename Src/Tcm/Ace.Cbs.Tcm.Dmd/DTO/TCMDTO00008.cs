//----------------------------------------------------------------------
// <copyright file="TCMDTO00008.cs" Name="TLFDate" company="ACE Data Systems">
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
    public class TCMDTO00008 : EntityBase<TCMDTO00008>
    {
        public TCMDTO00008() { }

        public TCMDTO00008(int id, System.Nullable<DateTime> tLFMinDate, System.Nullable<DateTime> tLFSDate, System.Nullable<DateTime> mTLFMaxDate, System.Nullable<DateTime> mTLFMinDate, System.Nullable<DateTime> mTLFSMaxDate, System.Nullable<DateTime> mTLFSMinDate, System.Nullable<DateTime> yTLFMaxDate, System.Nullable<DateTime> yTLFMinDate, System.Nullable<DateTime> yTLFSMaxDate, System.Nullable<DateTime> yTLFSMinDate, System.Nullable<DateTime> hTLFMaxDate, System.Nullable<DateTime> hTLFMinDate, System.Nullable<DateTime> hTLFSMaxDate, System.Nullable<DateTime> hTLFSMinDate, string uId)
        {
            this.Id = id;
            this.TLFMinDate = tLFMinDate;
            this.TLFSDate = tLFSDate;
            this.MTLFMaxDate = mTLFMaxDate;
            this.MTLFMinDate = mTLFMinDate;
            this.MTLFSMaxDate = mTLFSMaxDate;
            this.MTLFSMinDate = mTLFSMinDate;
            this.YTLFMaxDate = yTLFMaxDate;
            this.YTLFMinDate = yTLFMinDate;
            this.YTLFSMaxDate = yTLFSMaxDate;
            this.YTLFSMinDate = yTLFSMinDate;
            this.HTLFMaxDate = hTLFMaxDate;
            this.HTLFMinDate = hTLFMinDate;
            this.HTLFSMaxDate = hTLFSMaxDate;
            this.HTLFSMinDate = hTLFSMinDate;
            this.UId = uId;
        }

        public TCMDTO00008(int id, System.Nullable<DateTime> tLFMinDate, System.Nullable<DateTime> tLFSDate, System.Nullable<DateTime> mTLFMaxDate, System.Nullable<DateTime> mTLFMinDate, System.Nullable<DateTime> mTLFSMaxDate, System.Nullable<DateTime> mTLFSMinDate, System.Nullable<DateTime> yTLFMaxDate, System.Nullable<DateTime> yTLFMinDate, System.Nullable<DateTime> yTLFSMaxDate, System.Nullable<DateTime> yTLFSMinDate, System.Nullable<DateTime> hTLFMaxDate, System.Nullable<DateTime> hTLFMinDate, System.Nullable<DateTime> hTLFSMaxDate, System.Nullable<DateTime> hTLFSMinDate, string uId, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
        {
            this.Id = id;
            this.TLFMinDate = tLFMinDate;
            this.TLFSDate = tLFSDate;
            this.MTLFMaxDate = mTLFMaxDate;
            this.MTLFMinDate = mTLFMinDate;
            this.MTLFSMaxDate = mTLFSMaxDate;
            this.MTLFSMinDate = mTLFSMinDate;
            this.YTLFMaxDate = yTLFMaxDate;
            this.YTLFMinDate = yTLFMinDate;
            this.YTLFSMaxDate = yTLFSMaxDate;
            this.YTLFSMinDate = yTLFSMinDate;
            this.HTLFMaxDate = hTLFMaxDate;
            this.HTLFMinDate = hTLFMinDate;
            this.HTLFSMaxDate = hTLFSMaxDate;
            this.HTLFSMinDate = hTLFSMinDate;
            this.UId = uId;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public virtual System.Nullable<DateTime> TLFMinDate { get; set; }
        public virtual System.Nullable<DateTime> TLFSDate { get; set; }
        public virtual System.Nullable<DateTime> MTLFMaxDate { get; set; }
        public virtual System.Nullable<DateTime> MTLFMinDate { get; set; }
        public virtual System.Nullable<DateTime> MTLFSMaxDate { get; set; }
        public virtual System.Nullable<DateTime> MTLFSMinDate { get; set; }
        public virtual System.Nullable<DateTime> YTLFMaxDate { get; set; }
        public virtual System.Nullable<DateTime> YTLFMinDate { get; set; }
        public virtual System.Nullable<DateTime> YTLFSMaxDate { get; set; }
        public virtual System.Nullable<DateTime> YTLFSMinDate { get; set; }
        public virtual System.Nullable<DateTime> HTLFMaxDate { get; set; }
        public virtual System.Nullable<DateTime> HTLFMinDate { get; set; }
        public virtual System.Nullable<DateTime> HTLFSMaxDate { get; set; }
        public virtual System.Nullable<DateTime> HTLFSMinDate { get; set; }
        public virtual string UId { get; set; }
        public virtual bool IsCheck { get; set; }
        public virtual string SourceBr { get; set; }
    }
}