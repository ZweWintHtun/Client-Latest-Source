//----------------------------------------------------------------------
// <copyright file="TLMORM00037.cs" company="ACE Data Systems">
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
    /// BRANCHKEY DTO Entity
    /// </summary>
    [Serializable]
    public class TLMDTO00037 : EntityBase<TLMDTO00037>
    {
        public TLMDTO00037() { }
        public TLMDTO00037(decimal value)
        {
            this.Value = value;
        }

        public TLMDTO00037(int id, string code, decimal value, System.Nullable<DateTime> start_Date)
        {
            this.Id = id;
            this.Code = code;
            this.Value = value;
            this.StartDate = start_Date;
        }

                    //Id,Code,Value,StartDate,UniqueId,Active,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,TS
        public TLMDTO00037(int id, string code, decimal value, System.Nullable<DateTime> start_Date, string uId, bool active, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId, byte[] tS)
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

        public TLMDTO00037(int id, string code, decimal value, System.Nullable<DateTime> start_Date, string uId, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
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

        public TLMDTO00037(string code, decimal value, DateTime datetime, string status)
        {
            this.Code = code;
            this.Value = value;
            this.StartDate = datetime;
            this.Status = status;
        }

        public TLMDTO00037(DateTime datetime, string status)
        {
            this.StartDate = datetime;
            this.Status = status;
        }

        public TLMDTO00037(int id, string code, decimal value, DateTime datetime, string status)
        {
            this.Id = id;
            this.Code = code;
            this.Value = value;
            this.StartDate = datetime;
            this.Status = status;
        }
        public TLMDTO00037(int id, string code, decimal value, DateTime datetime, string status, bool active)
        {
            this.Id = id;
            this.Code = code;
            this.Value = value;
            this.StartDate = datetime;
            this.Status = status;
            this.Active = active;
        }

        public string Code { get; set; }
        public decimal Value { get; set; }  //value is not null in table definition
        public Nullable<DateTime> StartDate { get; set; }
        public string UniqueId { get; set; }
        public virtual bool IsCheck { get; set; }
        public string Status { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
}
