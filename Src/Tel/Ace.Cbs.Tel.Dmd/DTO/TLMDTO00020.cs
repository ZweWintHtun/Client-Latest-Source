//----------------------------------------------------------------------
// <copyright file="TLMDTO00020.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San </CreatedUser>
// <CreatedDate>2013-05-22</CreatedDate>
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
    /// DepositCode DTO Entity
    /// </summary>
    [Serializable]
    public class TLMDTO00020 : Supportfields<TLMDTO00020>
    {

        public TLMDTO00020() { }

        public TLMDTO00020(string dEPCODE, string dESP)
        {
            this.DepositCode = dEPCODE;
            this.Description = dESP;
        }

        public TLMDTO00020(string dEPCODE, string dESP, string uID, string sourceBr)
        {
            this.DepositCode = dEPCODE;
            this.Description = dESP;
            this.UniqueId = uID;
            this.SourceBranchCode = sourceBr;
        }

                            //DepositCode,Description,UniqueId,SourceBranchCode,Active,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,TS
        public TLMDTO00020(string dEPCODE, string dESP, string uID, string sourceBr, bool active, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId, byte[] tS)
        {
            this.DepositCode = dEPCODE;
            this.Description = dESP;
            this.UniqueId = uID;
            this.SourceBranchCode = sourceBr;
            this.Active = active;
            this.TS = tS;
            this.CreatedUserId = createdUserId;
            this.CreatedDate = createdDate;
            this.UpdatedUserId = updatedUserId;
            this.UpdatedDate = updatedDate;
        }	

        public TLMDTO00020(string dEPCODE, string dESP, string uID, string sourceBr, bool active, byte[] tS, int createdUserId, DateTime createdDate, System.Nullable<int> updatedUserId, System.Nullable<DateTime> updatedDate)
        {
            this.DepositCode = dEPCODE;
            this.Description = dESP;
            this.UniqueId = uID;
            this.SourceBranchCode = sourceBr;
            this.Active = active;
            this.TS = tS;
            this.CreatedUserId = createdUserId;
            this.CreatedDate = createdDate;
            this.UpdatedUserId = updatedUserId;
            this.UpdatedDate = updatedDate;
        }	

        public virtual string DepositCode { get; set; }
        public virtual string Description { get; set; }
        public virtual string UniqueId { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual bool IsCheck { get; set; }
    }
}
