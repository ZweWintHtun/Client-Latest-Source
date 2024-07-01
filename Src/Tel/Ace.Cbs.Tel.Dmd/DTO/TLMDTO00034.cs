//----------------------------------------------------------------------
// <copyright file="TLMORM00034.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San </CreatedUser>
// <CreatedDate></CreatedDate>
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
    /// DAYKEY DTO Entity
    /// </summary>
    [Serializable]
    public class TLMDTO00034 : EntityBase<TLMDTO00034>
    {
        public TLMDTO00034() { }

        public TLMDTO00034(decimal value)
        {
            this.Value = value;
        }

        public TLMDTO00034(int id, string code, decimal value, System.Nullable<DateTime> start_Date)
        {
            this.Id = id;
            this.Code = code;
            this.Value = value;
            this.StartDate = start_Date;
        }

                                 //Id,Code,Value,StartDate,UniqueId,Active,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,TS
        public TLMDTO00034(int id, string code, decimal value, System.Nullable<DateTime> start_Date, string uId, bool active, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId, byte[] tS)
        {
            this.Id = id;
            this.Code = code;
            this.Value = value;
            this.StartDate = start_Date;
            this.UniqueId = uId;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public TLMDTO00034(int id, string code, decimal value, System.Nullable<DateTime> start_Date, string uId, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
        {
            this.Id = id;
            this.Code = code;
            this.Value = value;
            this.StartDate = start_Date;
            this.UniqueId = uId;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public virtual string Code { get; set; }
        public virtual System.Nullable<decimal> Value { get; set; }
        public virtual System.Nullable<DateTime> StartDate { get; set; }
        public virtual string UniqueId { get; set; }
        public virtual bool IsCheck { get; set; }	
    }
}
