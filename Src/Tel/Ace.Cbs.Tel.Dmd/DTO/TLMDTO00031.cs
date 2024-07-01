//----------------------------------------------------------------------
// <copyright file="TLMORM00031.cs" company="ACE Data Systems">
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
    /// ZONE DTO Entity
    /// </summary>
    [Serializable]
    public class TLMDTO00031 : EntityBase<TLMDTO00031>
    {
        public TLMDTO00031() { }
        public TLMDTO00031(string accountCode)
        {
            this.AccountCode = accountCode;
        }

        public TLMDTO00031(string zoneType,string accountCode) 
        {
            this.ZoneType = zoneType;
            this.AccountCode = accountCode;
        }

        public TLMDTO00031(string zoneType, string zoneDescription, string accountCode)
        {
            this.ZoneType = zoneType;
            this.ZoneDescription = this.ZoneDescription;
            this.AccountCode = accountCode;
        }

        public TLMDTO00031(int id, string zONETYPE, string zONEDESP, string bRCODE, string aCODE, string sOURCEBR)
        {
            this.Id = id;
            this.ZoneType = zONETYPE;
            this.ZoneDescription = zONEDESP;
            this.BranchCode = bRCODE;
            this.AccountCode = aCODE;
            this.SourceBranchCode = sOURCEBR;
        }

        //Id,ZoneType,ZoneDescription,BranchCode,AccountCode,UniqueId,SourceBranchCode,Active,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,TS
        public TLMDTO00031(int id, string zONETYPE, string zONEDESP, string bRCODE, string aCODE, string uID, string sOURCEBR,
            bool active, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId, byte[] tS)
        {
            this.Id = id;
            this.ZoneType = zONETYPE;
            this.ZoneDescription = zONEDESP;
            this.BranchCode = bRCODE;
            this.AccountCode = aCODE;
            this.UniqueId = uID;
            this.SourceBranchCode = sOURCEBR;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }


        public TLMDTO00031(int id, string zONETYPE, string zONEDESP, string bRCODE, string aCODE, string uID, string sOURCEBR, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
        {
            this.Id = id;
            this.ZoneType = zONETYPE;
            this.ZoneDescription = zONEDESP;
            this.BranchCode = bRCODE;
            this.AccountCode = aCODE;
            this.UniqueId = uID;
            this.SourceBranchCode = sOURCEBR;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public virtual string ZoneType { get; set; }
        public virtual string ZoneDescription { get; set; }
        public virtual string BranchCode { get; set; }
        public virtual string AccountCode { get; set; }
        public virtual string UniqueId { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual bool IsCheck { get; set; }	
    }
}
