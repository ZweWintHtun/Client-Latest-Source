//----------------------------------------------------------------------
// <copyright file="TLMDTO00002.cs" company="ACE Data Systems">
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
    /// CounterInfo DTO Entity
    /// </summary>
    [Serializable]
    public class TLMDTO00002 : Supportfields<TLMDTO00002>
    {
        public TLMDTO00002() { }

        public TLMDTO00002(string counterNo, string description, bool hasVault)
        {
            this.CounterNo = counterNo;
            this.Description = description;
            this.HasVault = hasVault;
        }
        public TLMDTO00002(string counterNo, string description,string counterType, bool hasVault)
        {
            this.CounterNo = counterNo;
            this.Description = description;
            this.CounterType = counterType;
            this.HasVault = hasVault;
        }
        public TLMDTO00002(string counterNo, string description, string counterType, bool hasVault, string sourceBr)
        {
            this.CounterNo = counterNo;
            this.Description = description;
            this.CounterType = counterType;
            this.HasVault = hasVault;
            this.SourceBranchCode = sourceBr;

        }
        public TLMDTO00002(string counterNo, string description, string counterType, bool hasVault, string sourceBr, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
        {
            this.CounterNo = counterNo;
            this.Description = description;
            this.CounterType = counterType;
            this.HasVault = hasVault;
            this.SourceBranchCode = sourceBr;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }		
        public TLMDTO00002(string counterNo)
        {
            this.CounterNo = counterNo;
            
        }

        public virtual string CounterNo { get; set; }
        public virtual string Description { get; set; }
        public virtual string CounterType { get; set; }
        public virtual bool HasVault { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual bool IsCheck { get; set; }	
    }
}
